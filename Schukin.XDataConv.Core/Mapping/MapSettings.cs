using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public class MapSettings : ICloneable, INotifyPropertyChanged
    {
        private bool _isFindAllMatches;
        private MapCollection _mapping;
        public event PropertyChangedEventHandler PropertyChanged;

        public MapSettings()
        {
            Mapping = new MapCollection(new MapItem[] { });
        }

        public MapCollection Mapping
        {
            get => _mapping;
            private set
            {
                _mapping = value;
                OnPropertyChanged();
            }
        }

        public bool IsFindAllMatches
        {
            get => _isFindAllMatches;
            set
            {
                _isFindAllMatches = value; 
                OnPropertyChanged();
            }
        }

        public void LoadDefault(StoreEngine store)
        {
            var storeMap = store.GetMap();
            var mapping = new MapCollection(storeMap.Select(item => new MapItem
            {
                Name = item.PropertyName,
                FieldName = item.FieldName,
                MemberInfo = item.MemberInfo,
                ImportMatchLines = new List<MatchLine>()
            }).ToArray());

            var excludedImportFieldName = new[] { "LDID", "ADRID", "MONTH", "YEAR" };
            var checkedIsConvertImportToUpperCase = new[] { "FAMIL", "IMJA", "OTCH" };
            var checkedIsUseForCompare1 = new[] { "ILCHET", "GKU", "ORG" };
            var checkedIsUseForCompare2 = new[] { "FAMIL", "IMJA", "OTCH", "POSEL", "NASP", "YLIC", "NDOM", "NKORP", "NKW", "NKOMN", "GKU", "ORG" };
            var checkedIsUseForInject = new[] { "OPL", "OTPL", "KOLZR", "VIDTAR", "TARIF", "FAKT", "SUMTAR", "SUMDOLG", "OPLDOLG", "DATDOLG" };
            var checkedIsUseForLog = new[] { "FAMIL", "IMJA", "OTCH", "DROG" };

            foreach (var mapItem in mapping)
            {
                mapItem.ImportFieldName =
                    excludedImportFieldName.Contains(mapItem.FieldName) ? null : mapItem.FieldName;

                mapItem.IsConvertImportToUpperCase = checkedIsConvertImportToUpperCase.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare1 = checkedIsUseForCompare1.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare2 = checkedIsUseForCompare2.Contains(mapItem.FieldName);
                mapItem.IsUseForInject = checkedIsUseForInject.Contains(mapItem.FieldName);
                mapItem.IsUseForLog = checkedIsUseForLog.Contains(mapItem.FieldName);
            }

            mapping["IlChetNew"].ImportFieldName = String.Empty;

            Mapping = mapping;

            IsFindAllMatches = true;
        }

        public void Save(string filename)
        {
            var doc = new XDocument();
            var comment = new XComment("XDataConv configuration file v2.1 -- Schukin S.");

            var mappingsElement = new XElement("mappings");

            var settingElement = new XElement("setting",
                new XAttribute("name", "isFindAllMatches"),
                IsFindAllMatches
            );

            mappingsElement.Add(settingElement);

            foreach (var item in Mapping)
            {
                var mappingElement = new XElement("mapping",
                    new XAttribute("name", item.Name),
                    new XElement("importFieldName", item.ImportFieldName),
                    new XElement("isConvertImportToUpperCase", item.IsConvertImportToUpperCase),
                    new XElement("isUseForCompare1", item.IsUseForCompare1),
                    new XElement("isUseForCompare2", item.IsUseForCompare2),
                    new XElement("isUseForInject", item.IsUseForInject),
                    new XElement("isUseForLog", item.IsUseForLog)
                );

                if (item.ImportMatchLinesCount > 0)
                {
                    var matchingsElement = new XElement("matchings");

                    foreach (var matchingItem in item.ImportMatchLines)
                    {
                        var matchingElement = new XElement("matching");

                        matchingElement.Add(
                            new XElement("sourceWord", matchingItem.SourceWord),
                            new XElement("aliasWord", matchingItem.AliasWord)
                        );

                        matchingsElement.Add(matchingElement);
                    }

                    mappingElement.Add(matchingsElement);
                }

                mappingsElement.Add(mappingElement);
            }

            doc.Add(comment, mappingsElement);
            doc.Save(filename);
        }

        public void Load(string filename)
        {
            var xml = XDocument.Load(filename);

            var mappingsElement = xml.Element("mappings");

            if (mappingsElement == null)
                return;

            foreach (var settingElement in mappingsElement.Elements("setting"))
            {
                if (settingElement.Attribute("name")?.Value == "isFindAllMatches")
                {
                    bool.TryParse(settingElement.Value, out var isFindAllMatches);
                    IsFindAllMatches = isFindAllMatches;
                }
            }

            Mapping.SetDefaultValuesForAllItems();

            foreach (var mappingElement in mappingsElement.Elements("mapping"))
            {
                var nameAttribute = mappingElement.Attribute("name");
                if (nameAttribute == null)
                    continue;

                var mapping = Mapping.FirstOrDefault(item => item.Name == nameAttribute.Value);
                if (mapping == null)
                    continue;

                mapping.ImportFieldName = mappingElement.Element("importFieldName")?.Value;

                var isConvertImportToUpperCaseElement = mappingElement.Element("isConvertImportToUpperCase");
                if (isConvertImportToUpperCaseElement != null)
                {
                    bool.TryParse(isConvertImportToUpperCaseElement.Value, out var mappingIsConvertImportToUpperCase);
                    mapping.IsConvertImportToUpperCase = mappingIsConvertImportToUpperCase;
                }

                var isUseForCompare1Element = mappingElement.Element("isUseForCompare1");
                if (isUseForCompare1Element != null)
                {
                    bool.TryParse(isUseForCompare1Element.Value, out var mappingIsUseForCompare1);
                    mapping.IsUseForCompare1 = mappingIsUseForCompare1;
                }

                var isUseForCompare2Element = mappingElement.Element("isUseForCompare2");
                if (isUseForCompare2Element != null)
                {
                    bool.TryParse(isUseForCompare2Element.Value, out var mappingIsUseForCompare2);
                    mapping.IsUseForCompare2 = mappingIsUseForCompare2;
                }

                var isUseForInjectElement = mappingElement.Element("isUseForInject");
                if (isUseForInjectElement != null)
                {
                    bool.TryParse(isUseForInjectElement.Value, out var isUseForInject);
                    mapping.IsUseForInject = isUseForInject;
                }

                var isUseForLogElement = mappingElement.Element("isUseForLog");
                if (isUseForLogElement != null)
                {
                    bool.TryParse(isUseForLogElement.Value, out var isUseForLog);
                    mapping.IsUseForLog = isUseForLog;
                }

                var matchingsElement = mappingElement.Element("matchings");
                if (matchingsElement == null)
                    continue;

                foreach (var matchingElement in matchingsElement.Elements("matching"))
                {
                    mapping.ImportMatchLines.Add(new MatchLine
                    {
                        SourceWord = matchingElement.Element("sourceWord")?.Value,
                        AliasWord = matchingElement.Element("aliasWord")?.Value
                    });
                }
            }
        }

        public object Clone()
        {
            var source = this;
            var settings = new MapSettings
            {
                Mapping = new MapCollection(source.Mapping.Select(mapItem => new MapItem
                {
                    Name = mapItem.Name,
                    FieldName = mapItem.FieldName,
                    ImportFieldName = mapItem.ImportFieldName,
                    IsConvertImportToUpperCase = mapItem.IsConvertImportToUpperCase,
                    IsUseForCompare1 = mapItem.IsUseForCompare1,
                    IsUseForCompare2 = mapItem.IsUseForCompare2,
                    IsUseForInject = mapItem.IsUseForInject,
                    IsUseForLog = mapItem.IsUseForLog,
                    MemberInfo = mapItem.MemberInfo,
                    ImportMatchLines = mapItem.ImportMatchLines.Select(item =>
                        new MatchLine
                        {
                            SourceWord = item.SourceWord,
                            AliasWord = item.AliasWord
                        }).ToList()
                }).ToArray()),
                IsFindAllMatches = source.IsFindAllMatches
            };

            return settings;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

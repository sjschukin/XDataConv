using System.Collections.Generic;
using System.Linq;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public class MapSettings
    {
        public MapSettings()
        {
            Mapping = new MapCollection(new MapItem[] { });
        }

        public MapCollection Mapping { get; private set; }
        public bool IsFindAllMatches { get; set; }

        public void LoadDefault(StoreEngine store)
        {
            var storeMap = store.GetMap();
            var map = new MapCollection(storeMap.Select(item => new MapItem
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

            foreach (var mapItem in map)
            {
                mapItem.ImportFieldName =
                    excludedImportFieldName.Contains(mapItem.FieldName) ? null : mapItem.FieldName;

                mapItem.IsConvertImportToUpperCase = checkedIsConvertImportToUpperCase.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare1 = checkedIsUseForCompare1.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare2 = checkedIsUseForCompare2.Contains(mapItem.FieldName);
                mapItem.IsUseForInject = checkedIsUseForInject.Contains(mapItem.FieldName);
                mapItem.IsUseForLog = checkedIsUseForLog.Contains(mapItem.FieldName);
            }

            Mapping = map;

            IsFindAllMatches = true;
        }

        //public MapSettings Clone()
        //{

        //}
    }
}

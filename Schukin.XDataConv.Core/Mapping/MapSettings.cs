using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public class MapSettings
    {
        private StoreEngine _store;

        public MapSettings(StoreEngine store)
        {
            Mapping = GetDefaultMap();
        }

        public MapCollection Mapping { get; }

        private MapCollection GetDefaultMap()
        {
            var storeMap = Store.GetMap();
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

            return map;
        }

        public IEnumerable<MapInfo> GetMap()
        {
            var dataItemMap = new DataItemMap();

            return dataItemMap.MemberMaps
                .Where(item => item.Data.Ignore != true)
                .Select(item => new MapInfo
                {
                    PropertyName = item.Data.Member.Name,
                    FieldName = item.Data.Names.FirstOrDefault(),
                    MemberInfo = item.Data.Member
                });
        }
    }
}

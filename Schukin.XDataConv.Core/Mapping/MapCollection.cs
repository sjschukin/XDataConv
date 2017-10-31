using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Schukin.XDataConv.Core
{
    public class MapCollection : IEnumerable<MapItem>
    {
        private readonly MapItem[] _items;

        public MapCollection(MapItem[] items)
        {
            _items = items;
        }

        public MapItem this[string column]
        {
            get { return _items.First(item => item.Name == column); }
        }

        public IEnumerator<MapItem> GetEnumerator()
        {
            return _items.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<MapItem> GetActiveItems()
        {
            return _items.Where(item => item.SourceColumnName.Trim() != "");
        }

        public IEnumerable<MapItem> GetUseForIdentify1()
        {
            return GetActiveItems().Where(item => item.UseForCompare1);
        }

        public IEnumerable<MapItem> GetUseForIdentify2()
        {
            return GetActiveItems().Where(item => item.UseForCompare2);
        }

        public IEnumerable<MapItem> GetUseForImport()
        {
            return GetActiveItems().Where(item => item.UseForImport);
        }

        public IEnumerable<MapItem> GetUseForLog()
        {
            return GetActiveItems().Where(item => item.UseForLog);
        }

        public void Reset()
        {
            foreach (var item in _items)
            {
                item.SourceColumnName = "";
                item.UseForCompare1 = false;
                item.UseForCompare2 = false;
                item.UseForImport = false;
                item.SourceOrdinal = -1;
                item.MatchLines.Clear();
            }
        }
    }
}

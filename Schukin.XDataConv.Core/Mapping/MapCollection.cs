using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Schukin.XDataConv.Core
{
    public class MapCollection : IEnumerable<Map>
    {
        private readonly Map[] _items;

        public MapCollection(Map[] items)
        {
            _items = items;
        }

        public Map this[string column]
        {
            get { return _items.First(item => item.Name == column); }
        }

        public IEnumerator<Map> GetEnumerator()
        {
            return _items.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Map> GetActiveItems()
        {
            return _items.Where(item => item.SourceColumnName.Trim() != "");
        }

        public IEnumerable<Map> GetUseForIdentify1()
        {
            return GetActiveItems().Where(item => item.UseForCompare1);
        }

        public IEnumerable<Map> GetUseForIdentify2()
        {
            return GetActiveItems().Where(item => item.UseForCompare2);
        }

        public IEnumerable<Map> GetUseForImport()
        {
            return GetActiveItems().Where(item => item.UseForImport);
        }

        public IEnumerable<Map> GetUseForLog()
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

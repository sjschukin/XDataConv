using System;
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

        public MapItem this[string name]
        {
            get { return _items.First(item => item.Name == name); }
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
            return _items.Where(item => !String.IsNullOrWhiteSpace(item.ImportFieldName));
        }

        public IEnumerable<MapItem> GetUseForIdentify1()
        {
            return GetActiveItems().Where(item => item.IsUseForCompare1);
        }

        public IEnumerable<MapItem> GetUseForIdentify2()
        {
            return GetActiveItems().Where(item => item.IsUseForCompare2);
        }

        public IEnumerable<MapItem> GetUseForAssign()
        {
            return GetActiveItems().Where(item => item.IsUseForInject);
        }

        public IEnumerable<MapItem> GetUseForLog()
        {
            return GetActiveItems().Where(item => item.IsUseForLog);
        }

        public void Reset()
        {
            foreach (var item in _items)
            {
                item.ImportFieldName = null;
                item.IsUseForCompare1 = false;
                item.IsUseForCompare2 = false;
                item.IsUseForInject = false;
                item.ImportFieldOrdinal = -1;
                item.ImportMatchLines.Clear();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Schukin.XDataConv.Core
{
    public class SettingsMapCollection : IEnumerable<SettingsMapItem>
    {
        private readonly SettingsMapItem[] _items;

        public SettingsMapCollection(SettingsMapItem[] items)
        {
            _items = items;
        }

        public SettingsMapItem this[string name]
        {
            get { return _items.First(item => item.Name == name); }
        }

        public IEnumerator<SettingsMapItem> GetEnumerator()
        {
            return _items.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<SettingsMapItem> GetActiveItems()
        {
            return _items.Where(item => !String.IsNullOrWhiteSpace(item.ImportFieldName));
        }

        public IEnumerable<SettingsMapItem> GetUseForIdentify1()
        {
            return GetActiveItems().Where(item => item.IsUseForCompare1);
        }

        public IEnumerable<SettingsMapItem> GetUseForIdentify2()
        {
            return GetActiveItems().Where(item => item.IsUseForCompare2);
        }

        public IEnumerable<SettingsMapItem> GetUseForAssign()
        {
            return GetActiveItems().Where(item => item.IsUseForInject);
        }
    }
}

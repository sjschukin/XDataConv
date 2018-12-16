﻿using System.Collections.Generic;
using System.Reflection;

namespace Schukin.XDataConv.Core
{
    public class MapItem
    {
        public string Name { get; set; }
        public string FieldName { get; set; }
        public string ImportFieldName { get; set; }
        public bool IsConvertImportToUpperCase { get; set; }
        public bool IsUseForCompare1 { get; set; }
        public bool IsUseForCompare2 { get; set; }
        public bool IsUseForInject { get; set; }
        public bool IsUseForLog { get; set; }
        public List<MatchingItem> MatchingItems { get; set; }
        public int MatchingItemsCount => MatchingItems?.Count ?? 0;
        public MemberInfo MemberInfo { get; set; }
    }
}

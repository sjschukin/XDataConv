﻿using System.Collections.Generic;
using System.Reflection;

namespace Schukin.XDataConv.Core
{
    public class MapItem
    {
        public string Name { get; set; }
        public string FieldName { get; set; }
        public string SourceColumnName { get; set; }
        public bool UseForCompare1 { get; set; }
        public bool UseForCompare2 { get; set; }
        public bool UseForAssign { get; set; }
        public bool UseForLog { get; set; }
        public int SourceOrdinal { get; set; }
        public List<MatchLine> MatchLines { get; set; }
        public int MatchLinesCount => MatchLines?.Count ?? 0;
        public MemberInfo MemberInfo { get; set; }
    }
}

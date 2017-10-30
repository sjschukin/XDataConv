using System.Collections.Generic;

namespace Schukin.XDataConv.Core
{
    public class Map
    {
        public string Name { get; set; }
        public string AliasName => Name.ToUpper();
        public string SourceColumnName { get; set; }
        public bool UseForCompare1 { get; set; }
        public bool UseForCompare2 { get; set; }
        public bool UseForImport { get; set; }
        public bool UseForLog { get; set; }
        public int SourceOrdinal { get; set; }
        public List<MatchLine> MatchLines { get; set; }
        public int MatchLinesCount => MatchLines?.Count ?? 0;
    }
}

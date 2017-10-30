using System.Collections.Generic;

namespace Schukin.XDataConv.Core
{
    public class IdentifyResultItem
    {
        public IdentifyResultItem()
        {
            Details = new List<string>();
        }
        public int ResultType { get; set; }
        public string Name { get; set; }
        public List<string> Details { get; set; }
    }
}

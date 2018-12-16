using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core
{
    public class DataItemInfo : IDataItemInfo
    {
        public int SourceLineNumber { get; set; }
        public string StateMessage { get; set; }
        public DataItemStates State { get; set; }
    }
}

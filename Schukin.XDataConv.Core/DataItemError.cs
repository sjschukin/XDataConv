using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core
{
    public class DataItemError : IDataItemError
    {
        public int RowId { get; set; }
        public string Message { get; set; }
    }
}

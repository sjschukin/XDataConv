namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IDataItemInfo
    {
        int SourceLineNumber { get; set; }
        string StateMessage { get; set; }
        DataItemStates State { get; set; }
    }
}

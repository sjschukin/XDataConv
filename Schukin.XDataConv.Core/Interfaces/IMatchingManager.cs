using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IMatchingManager
    {
        SortableBindingList<DataItem> SourceData { get; }
        SortableBindingList<DataItem> SourceMatchedData { get; }
        SortableBindingList<DataItem> ImportedData { get; }
        SortableBindingList<DataItem> ImportedMatchedData { get; }
        Settings Settings { get; set; }
        IEnumerable<IDataItemError> MatchingErrors { get; }
        void InjectDataByIdentify1();
        void InjectDataByIdentify2();
    }
}
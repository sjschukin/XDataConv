using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IDataSource
    {
        IList<IDataItem> Data { get; }
    }
}

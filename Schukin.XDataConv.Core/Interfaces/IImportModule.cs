using System;
using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IImportModule
    {
        IEnumerable<string> SupportedFileExtensions { get; }
        IEnumerable<Tuple<IDataItem, IDataItemInfo>> LoadDataItems(string filename);
    }
}

using System;
using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IImportModule
    {
        IEnumerable<string> SupportedFileExtensions { get; }
        IEnumerable<IDataItemError> ImportErrors { get; }
        IEnumerable<IDataItem> LoadDataItems(string filename);
    }
}

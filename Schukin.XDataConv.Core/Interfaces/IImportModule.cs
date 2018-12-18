using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IImportModule<out T, out TError>
        where T : IDataItem
        where TError : IDataItemError
    {
        IEnumerable<string> SupportedFileExtensions { get; }
        IEnumerable<TError> ImportErrors { get; }
        IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename);
    }
}

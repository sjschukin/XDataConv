using System.Collections.Generic;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IDataSource<out T> where T : IDataItem
    {
        string FileName { get; }
        IEnumerable<T> Data { get; }
        void Open(string filename);
        void Save();
        void Save(string filename);
    }
}

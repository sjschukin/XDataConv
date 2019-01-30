namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IFileDataSource : IDataSource
    {
        string FileName { get; }
        void Open(string filename);
        void Save();
        void Save(string filename);
    }
}

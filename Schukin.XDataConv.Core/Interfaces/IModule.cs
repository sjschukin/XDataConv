using System.Collections.Generic;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core.Interfaces
{
    public interface IModule
    {
        string Name { get; }
        IEnumerable<DataItem> GetDataItems(string filename);
    }
}

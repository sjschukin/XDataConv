using System;
using System.Data;

namespace Schukin.XDataConv.Core
{
    public interface IModule
    {
        Guid Id { get; }
        string Name { get; }
        bool HasImport { get; }
        bool HasExport { get; }
        string ImportMenuText { get; }
        string ExportMenuText { get; }
        string Description { get; }
        void DoImport();
        void DoExport();
    }
}

using System;
using System.Data;

namespace Schukin.XDataConv.Core
{
    public abstract class ModuleBase : IModule
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract bool HasImport { get; }
        public abstract bool HasExport { get; }
        public abstract string ImportMenuText { get; }
        public abstract string ExportMenuText { get; }
        public abstract string Description { get; }
        public abstract void DoImport();
        public abstract void DoExport();
    }
}

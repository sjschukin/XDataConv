using System;
using System.Collections.Generic;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core.Base
{
    public abstract class ImportModuleBase : IImportModule
    {
        protected readonly SettingsMapCollection Mapping;
        protected readonly ILogger Logger;
        protected readonly List<IDataItemError> Errors;

        public abstract IEnumerable<string> SupportedFileExtensions { get; }
        public IEnumerable<IDataItemError> ImportErrors => Errors;

        protected ImportModuleBase(ILogger logger, SettingsMapCollection mapping)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));

            Errors = new List<IDataItemError>();
        }

        public virtual IEnumerable<IDataItem> LoadDataItems(string filename)
        {
            throw new NotImplementedException();
        }
    }
}

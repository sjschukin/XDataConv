using System;
using System.Collections.Generic;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core.Base
{
    public abstract class ImportModuleBase<T, TError> : IImportModule<T, TError>
        where T : IDataItem
        where TError : IDataItemError
    {
        protected readonly ILogger Logger;
        protected readonly List<TError> Errors;

        public abstract IEnumerable<string> SupportedFileExtensions { get; }
        public IEnumerable<TError> ImportErrors => Errors;

        protected ImportModuleBase(ILogger logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Errors = new List<TError>();
        }

        public virtual IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename)
        {
            throw new NotImplementedException();
        }
    }
}

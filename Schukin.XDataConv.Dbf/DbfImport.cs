using System;
using System.Collections.Generic;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Dbf
{
    public class DbfImport<T, TError> : ImportModuleBase<T, TError>
        where T : IDataItem, new()
        where TError : IDataItemError, new()
    {
        private readonly string[] _supportedFileExtensions = { "dbf" };

        public DbfImport(ILogger logger) : base(logger)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename)
        {
            throw new NotImplementedException();
        }
    }
}

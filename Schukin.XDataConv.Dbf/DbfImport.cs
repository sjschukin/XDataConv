using System;
using System.Collections.Generic;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Dbf
{
    public class DbfImport : ImportModuleBase
    {
        private readonly string[] _supportedFileExtensions = { "dbf" };

        public DbfImport(ILogger logger, SettingsMapCollection mapping):base(logger, mapping)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<IDataItem> LoadDataItems(string filename)
        {
            throw new NotImplementedException();
        }
    }
}

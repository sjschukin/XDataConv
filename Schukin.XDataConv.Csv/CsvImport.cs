using System;
using System.Collections.Generic;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Csv
{
    public class CsvImport : ImportModuleBase
    {
        private readonly string[] _supportedFileExtensions = { "csv" };

        public CsvImport(ILogger logger, MapCollection mapping) : base (logger, mapping)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<IDataItem> LoadDataItems(string filename)
        {
            throw new NotImplementedException();
        }
    }
}

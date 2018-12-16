using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Csv
{
    public class CsvImport
    {
        private readonly string[] _supportedFileExtensions = { "csv" };
        private readonly ILogger _logger;
        private readonly MapCollection _mapping;

        public CsvImport(ILogger logger, MapCollection mapping)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));
        }

        public IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public IEnumerable<Tuple<IDataItem, IDataItemInfo>> LoadDataItems(string filename)
        {
            throw new NotImplementedException();
        }
    }
}

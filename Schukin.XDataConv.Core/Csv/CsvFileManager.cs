using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core.Csv
{
    public class CsvFileManager
    {
        private readonly ILogger _logger;

        public CsvFileManager(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<DataItem> LoadDataItems(string filename)
        {
            _logger.Info($"Opening file {filename} for import.");

            using (var reader = new StreamReader(filename, Encoding.GetEncoding(1251)))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.RegisterClassMap<SourceMap>();

                csv.Configuration.ReadingExceptionOccurred = ex =>
                {
                    _logger.Error("Import CSV file error.", ex);
                };

                return csv.GetRecords<DataItem>().ToArray();
            }
        }

        public void WriteToFile(string filename, IEnumerable<DataItem> data)
        {
            if (data == null)
                throw new ApplicationException("Отсутствуют данные для сохранения.");

            using (var writer = new StreamWriter(filename, false, Encoding.GetEncoding(1251)))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.RegisterClassMap<SourceMap>();

                csv.WriteRecords(data);
            }
        }
    }
}

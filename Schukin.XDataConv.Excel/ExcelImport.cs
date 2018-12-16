using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Excel
{
    public class ExcelImport : IImportModule
    {
        private readonly string[] _supportedFileExtensions = {"xls", "xlsx"};
        private readonly ILogger _logger;
        private readonly MapCollection _mapping;

        public ExcelImport(ILogger logger, MapCollection mapping)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));
        }

        public IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public IEnumerable<Tuple<IDataItem, IDataItemInfo>> LoadDataItems(string filename)
        {
            var importedData = new List<Tuple<IDataItem, IDataItemInfo>>();

            _logger.Info($"Opening file {filename} for import.");
            
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // read the header
                if (!reader.Read())
                    throw new ApplicationException("Файл пуст.");

                _logger.Info("Reading a header.");

                var headerNames = GetHeaderNames(reader);

                _logger.Info("Checking if all need columns exist and getting columns ordinal.");

                var activeMapItems = _mapping.GetActiveItems().ToArray();
                var ordinal = new Dictionary<string, int>();
                var notFoundHeaderNames = new List<string>();
                
                foreach (var mapItem in activeMapItems)
                {
                    ordinal.Add(mapItem.Name, -1);

                    for (int i = 0; i < headerNames.Length; i++)
                    {
                        _logger.Debug($"Checking fo equal {mapItem.ImportFieldName} and {headerNames[i]}.");
                        if (!String.Equals(mapItem.ImportFieldName, headerNames[i], StringComparison.CurrentCultureIgnoreCase))
                            continue;

                        _logger.Debug($"Found {mapItem.Name} with ordinal {i}.");
                        ordinal[mapItem.Name] = i;
                        break;
                    }

                    if (ordinal[mapItem.Name] == -1)
                    {
                        _logger.Info("The column {mapItem.ImportFieldName} not found.");
                        notFoundHeaderNames.Add(mapItem.ImportFieldName);
                    }
                }

                if (notFoundHeaderNames.Any())
                    throw new ApplicationException($"Отсутствуют необходимые колонки {String.Join(", ", notFoundHeaderNames)}. Импорт невозможен.");

                _logger.Info("Checking columns complete. Start importing.");

                // read the body
                int lineNumber = 1;
                var properties = activeMapItems
                    .Select(mapItem => typeof(IDataItem).GetProperty(mapItem.Name))
                    .ToArray();

                while (reader.Read())
                {
                    lineNumber++;
                    string currentFieldName = null;
                    var dataItem = new DataItem();
                    var dataItemInfo = new DataItemInfo { SourceLineNumber = lineNumber };

                    try
                    {
                        foreach (var propertyInfo in properties)
                        {
                            currentFieldName = _mapping[propertyInfo.Name].FieldName;
                            var value = reader[ordinal[propertyInfo.Name]];

                            if (value == null)
                                continue;

                            var strValue = value.ToString().Trim();

                            if (strValue == String.Empty)
                                continue;

                            if (_mapping[propertyInfo.Name].IsConvertImportToUpperCase)
                                strValue = strValue.ToUpper();

                            propertyInfo.SetValue(dataItem,
                                Convert.ChangeType(strValue,
                                    Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                    propertyInfo.PropertyType));
                        }
                    }
                    catch (Exception)
                    {
                        dataItemInfo.State = DataItemStates.Error;
                        dataItemInfo.StateMessage =
                            $"Ошибка при импорте поля {currentFieldName} в строке {lineNumber}";
                    }

                    importedData.Add(new Tuple<IDataItem, IDataItemInfo>(dataItem, dataItemInfo));
                }
            }

            return importedData.ToArray();
        }

        private string[] GetHeaderNames(IDataRecord record)
        {
            var values = new string[record.FieldCount];

            for (int i = 0; i < record.FieldCount; i++)
            {
                values[i] = record.GetValue(i)?.ToString();
            }

            return values;
        }
    }
}

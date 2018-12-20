using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using ExcelDataReader;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Excel
{
    public class ExcelImport<T, TError> : ImportModuleBase<T, TError>
        where T : IDataItem, new()
        where TError : IDataItemError, new()
    {
        private readonly string[] _supportedFileExtensions = {".xls", ".xlsx"};
        
        public ExcelImport(ILogger logger) : base (logger)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename)
        {
            var importedData = new List<T>();

            Logger.Info($"Opening file {filename} for import.");
            Errors.Clear();
            
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // read the header
                if (!reader.Read())
                    throw new ApplicationException("Файл пуст.");

                Logger.Info("Reading a header.");

                var headerNames = GetHeaderNames(reader);

                Logger.Info("Checking if all need columns exist and getting columns ordinal.");

                var activeMapItems = mapping.GetActiveItems().ToArray();
                var ordinal = new Dictionary<string, int>();
                var notFoundHeaderNames = new List<string>();
                
                foreach (var mapItem in activeMapItems)
                {
                    ordinal.Add(mapItem.Name, -1);

                    for (int i = 0; i < headerNames.Length; i++)
                    {
                        Logger.Debug($"Checking fo equal {mapItem.ImportFieldName} and {headerNames[i]}.");
                        if (!String.Equals(mapItem.ImportFieldName, headerNames[i], StringComparison.CurrentCultureIgnoreCase))
                            continue;

                        Logger.Debug($"Found {mapItem.Name} with ordinal {i}.");
                        ordinal[mapItem.Name] = i;
                        break;
                    }

                    if (ordinal[mapItem.Name] == -1)
                    {
                        Logger.Info($"The column {mapItem.ImportFieldName} not found.");
                        notFoundHeaderNames.Add(mapItem.ImportFieldName);
                    }
                }

                if (notFoundHeaderNames.Any())
                    throw new ApplicationException($"Отсутствуют необходимые колонки {String.Join(", ", notFoundHeaderNames)}. Импорт невозможен.");

                Logger.Info("Checking columns complete. Start importing.");

                // read the body
                int lineNumber = 1;
                var properties = activeMapItems
                    .Select(mapItem => typeof(T).GetProperty(mapItem.Name))
                    .ToArray();

                while (reader.Read())
                {
                    lineNumber++;
                    string currentFieldName = null;
                    var dataItem = new T {RowId = lineNumber};

                    try
                    {
                        foreach (var propertyInfo in properties)
                        {
                            currentFieldName = mapping[propertyInfo.Name].FieldName;
                            var value = reader[ordinal[propertyInfo.Name]];

                            if (value == null)
                                continue;

                            var info = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                       propertyInfo.PropertyType;

                            if (info.Name == "String" && mapping[propertyInfo.Name].IsConvertImportToUpperCase)
                                value = ((string) value).ToUpper(CultureInfo.InvariantCulture);
                            else
                                value = Convert.ChangeType(value, info);

                            propertyInfo.SetValue(dataItem, value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Error occured during import file {filename}.", ex);
                        Errors.Add(new TError
                        {
                            RowId = lineNumber,
                            Message = $"Ошибка при импорте поля {currentFieldName} в строке {lineNumber}."
                        });
                    }

                    importedData.Add(dataItem);
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

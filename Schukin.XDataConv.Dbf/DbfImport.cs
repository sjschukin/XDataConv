using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NDbfReader;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Dbf
{
    public class DbfImport<T, TError> : ImportModuleBase<T, TError>
        where T : IDataItem, new()
        where TError : IDataItemError, new()
    {
        private const int ErrorCountLimit = 300;
        private readonly string[] _supportedFileExtensions = { ".dbf" };

        public DbfImport(ILogger logger) : base(logger)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename)
        {
            var importedData = new List<T>();
            int errorCount = 0;

            Logger.Info($"Opening file {filename} for import.");
            Errors.Clear();

            using (var table = Table.Open(filename))
            {
                Logger.Info("Reading a header.");

                var headerNames = table.Columns.Select(item => item.Name).ToArray();

                Logger.Info("Checking if all need columns exist and getting columns ordinal.");

                var activeMapItems = mapping.GetActiveItems().ToArray();
                var notFoundHeaderNames = new List<string>();

                foreach (var mapItem in activeMapItems)
                {
                    var isFound = headerNames.Any(item =>
                        item.Equals(mapItem.ImportFieldName, StringComparison.CurrentCultureIgnoreCase));

                    if (isFound)
                        continue;

                    Logger.Info($"The column {mapItem.ImportFieldName} not found.");
                    notFoundHeaderNames.Add(mapItem.ImportFieldName);
                }

                if (notFoundHeaderNames.Any())
                    throw new ApplicationException($"Отсутствуют необходимые колонки {String.Join(", ", notFoundHeaderNames)}. Импорт невозможен.");

                Logger.Info("Checking columns complete. Start importing.");

                int lineNumber = 0;
                var properties = activeMapItems
                    .Select(mapItem => typeof(T).GetProperty(mapItem.Name))
                    .ToArray();

                var reader = table.OpenReader(Encoding.GetEncoding(866));

                while (errorCount<= ErrorCountLimit && reader.Read())
                {
                    lineNumber++;
                    string currentFieldName = null;
                    var dataItem = new T { RowId = lineNumber };

                    try
                    {
                        foreach (var propertyInfo in properties)
                        {
                            currentFieldName = mapping[propertyInfo.Name].FieldName;
                            var value = reader.GetValue(currentFieldName);

                            if (value == null)
                                continue;

                            var info = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                       propertyInfo.PropertyType;

                            if (info.Name == "String" && mapping[propertyInfo.Name].IsConvertImportToUpperCase)
                                value = ((string)value).ToUpper(CultureInfo.InvariantCulture);
                            else
                                value = Convert.ChangeType(value, info);

                            propertyInfo.SetValue(dataItem, value);
                        }
                    }
                    catch (Exception ex)
                    {
                        errorCount++;

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
    }
}

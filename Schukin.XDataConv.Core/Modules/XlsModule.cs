using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelDataReader;
using NLog;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core.Modules
{
    public class XlsModule : IModule
    {
        private static readonly Logger Logger = LogManager.GetLogger("importLogger");

        public XlsModule()
        {
            Name = "Импорт файла Excel";
        }

        public string Name { get; }

        public IEnumerable<DataItem> GetDataItems(string filename)
        {
            //Logger.Info($" === Открытие файла {filename}");
            var importedData = new List<DataItem>();

            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // read the header
                if (!reader.Read())
                    throw new ApplicationException("Файл пуст.");

                //Logger.Info("Чтение заголовка");
                if (!Core.Instance.LoadMappingOrdinal(GetValues(reader)))
                    throw new ApplicationException("Отсутствуют необходимые колонки. Импорт невозможен.");

                // read the body
                int lineNumber = 1;
                var properties = Core.Instance.Mapping.GetActiveItems()
                    .Select(mapItem => typeof(DataItem).GetProperty(mapItem.Name))
                    .ToArray();

                while (reader.Read())
                {
                    lineNumber++;
                    string currentFieldName = null;
                    var dataItem = new DataItem {LineNumber = lineNumber};

                    try
                    {
                        foreach (var propertyInfo in properties)
                        {
                            currentFieldName = Core.Instance.Mapping[propertyInfo.Name].FieldName;
                            var value = reader[Core.Instance.Mapping[propertyInfo.Name].ImportFieldOrdinal];

                            if (value == null)
                                continue;

                            var strValue = value.ToString().Trim();

                            if (strValue == String.Empty)
                                continue;

                            if (Core.Instance.Mapping[propertyInfo.Name].IsConvertImportToUpperCase)
                                strValue = strValue.ToUpper();

                            propertyInfo.SetValue(dataItem,
                                Convert.ChangeType(strValue,
                                    Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                    propertyInfo.PropertyType));
                        }
                    }
                    catch (Exception)
                    {
                        dataItem.State = DataItemState.ImportError;
                        dataItem.StateMessage =
                            $"Ошибка при импорте поля {currentFieldName} в строке {lineNumber}";
                    }

                    importedData.Add(dataItem);
                }
            }

            return importedData.ToArray();
        }

        private string[] GetValues(IExcelDataReader reader)
        {
            var values = new string[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
            {
                values[i] = reader.GetValue(i)?.ToString();
            }

            return values;
        }
    }
}

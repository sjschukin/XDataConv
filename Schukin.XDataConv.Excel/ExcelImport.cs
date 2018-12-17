﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Excel
{
    public class ExcelImport : ImportModuleBase
    {
        private readonly string[] _supportedFileExtensions = {"xls", "xlsx"};
        
        public ExcelImport(ILogger logger, MapCollection mapping) : base (logger,mapping)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<IDataItem> LoadDataItems(string filename)
        {
            var importedData = new List<IDataItem>();

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

                var activeMapItems = Mapping.GetActiveItems().ToArray();
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
                        Logger.Info("The column {mapItem.ImportFieldName} not found.");
                        notFoundHeaderNames.Add(mapItem.ImportFieldName);
                    }
                }

                if (notFoundHeaderNames.Any())
                    throw new ApplicationException($"Отсутствуют необходимые колонки {String.Join(", ", notFoundHeaderNames)}. Импорт невозможен.");

                Logger.Info("Checking columns complete. Start importing.");

                // read the body
                int lineNumber = 1;
                var properties = activeMapItems
                    .Select(mapItem => typeof(IDataItem).GetProperty(mapItem.Name))
                    .ToArray();

                while (reader.Read())
                {
                    lineNumber++;
                    string currentFieldName = null;
                    var dataItem = new DataItem {RowId = lineNumber};

                    try
                    {
                        foreach (var propertyInfo in properties)
                        {
                            currentFieldName = Mapping[propertyInfo.Name].FieldName;
                            var value = reader[ordinal[propertyInfo.Name]];

                            if (value == null)
                                continue;

                            var strValue = value.ToString().Trim();

                            if (strValue == String.Empty)
                                continue;

                            if (Mapping[propertyInfo.Name].IsConvertImportToUpperCase)
                                strValue = strValue.ToUpper();

                            propertyInfo.SetValue(dataItem,
                                Convert.ChangeType(strValue,
                                    Nullable.GetUnderlyingType(propertyInfo.PropertyType) ??
                                    propertyInfo.PropertyType));
                        }
                    }
                    catch (Exception)
                    {
                        Errors.Add(new DataItemError
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
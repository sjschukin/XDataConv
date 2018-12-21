using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Base;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Csv
{
    public class CsvImport<T, TError> : ImportModuleBase<T, TError>
        where T : IDataItem, new()
        where TError : IDataItemError, new()
    {
        private class CsvImportMap : ClassMap<T> {}

        private readonly string[] _supportedFileExtensions = { ".csv" };

        public CsvImport(ILogger logger) : base(logger)
        {
        }

        public override IEnumerable<string> SupportedFileExtensions => _supportedFileExtensions;

        public override IEnumerable<T> LoadDataItems(SettingsMapCollection mapping, string filename)
        {
            Logger.Info($"Opening file {filename} for import.");
            Errors.Clear();

            using (var reader = new StreamReader(filename, Encoding.GetEncoding(1251)))
            using (var csv = new CsvReader(reader))
            {
                var csvImportMap = new CsvImportMap();
                ConfigureMap(csvImportMap, mapping);

                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.RegisterClassMap(csvImportMap);
                csv.Configuration.ReadingExceptionOccurred = ex =>
                {
                    Logger.Error($"Error occured during import file {filename}.", ex);
                    Errors.Add(new TError
                    {
                        RowId = ex.ReadingContext.RawRow,
                        Message = $"Ошибка при импорте поля {ex.ReadingContext.Field} в строке {ex.ReadingContext.RawRow}."
                    });
                };

                return csv.GetRecords<T>().ToArray();
            }
        }

        private void ConfigureMap(CsvImportMap csvImportMap, SettingsMapCollection mapping)
        {
            csvImportMap.AutoMap();
            csvImportMap.Map(item => item.RowId).Ignore().ConvertUsing(row => row.Context.RawRow);

            foreach (var memberMap in csvImportMap.MemberMaps)
            {
                var mappingItem = mapping.FirstOrDefault(item => item.Name == memberMap.Data.Member.Name);

                if (mappingItem ==null)
                    continue;

                memberMap.Data.Names.Clear();

                if (String.IsNullOrWhiteSpace(mappingItem.ImportFieldName))
                    memberMap.Data.Ignore = true;
                else
                    memberMap.Data.Names.Add(mappingItem.ImportFieldName);
            }
        }
    }
}

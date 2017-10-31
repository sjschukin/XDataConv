using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Schukin.XDataConv.Data
{
    public class StoreEngine
    {
        public IEnumerable<DataItem> Data { get; set; }
        public string CurrentFileName { get; set; }

        public void Open(string filename)
        {
            CurrentFileName = null;

            using (var reader = new StreamReader(filename, Encoding.GetEncoding(1251)))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.RegisterClassMap<DataItemMap>();

                Data = csv.GetRecords<DataItem>().ToArray();
            }

            CurrentFileName = filename;
        }

        public void Save()
        {
            Save(CurrentFileName);
        }

        public void Save(string filename)
        {
            if (Data == null)
                throw new ApplicationException("Отсутствуют данные для сохранения.");

            using (var writer = new StreamWriter(filename, false, Encoding.GetEncoding(1251)))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.RegisterClassMap<DataItemMap>();

                csv.WriteRecords(Data);
            }

            CurrentFileName = filename;
        }

        public IEnumerable<string> GetMappingColumnNames()
        {
            var dataItemMap = new DataItemMap();
            return dataItemMap.MemberMaps.Select(item => item.Data.Names[0]);
        }

        public IEnumerable<string> GetMappingPropertyNames()
        {
            var dataItemMap = new DataItemMap();
            return dataItemMap.MemberMaps.Select(item => item.Data.Names[0]);
        }
    }
}

//using System;
//using System.Data;
//using System.Globalization;
//using System.IO;
//using System.Text;
//using System.Windows.Forms;
//using CsvHelper;
//using Schukin.XDataConv.Data;

//namespace Schukin.XDataConv.Core.Modules
//{
//    public class CsvModule : ModuleBase
//    {
//        private readonly OpenFileDialog _importDialog;
//        private readonly SaveFileDialog _exportDialog;

//        public CsvModule()
//        {
//            Id = new Guid("9D9AD341-FC7A-49A6-92D3-7ECA7E672931");
//            Name = "CSV ЭСРН";
//            Description = "Импорт/экспорт файлами для ВИС ЭСРН";
//            HasImport = true;
//            ImportMenuText = "Формат ЭСРН (csv) ...";
//            HasExport = true;
//            ExportMenuText = "Формат ЭСРН (csv) ...";

//            _importDialog = new OpenFileDialog
//            {
//                CheckFileExists = true,
//                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv"
//            };
//            _exportDialog = new SaveFileDialog
//            {
//                CheckPathExists = true,
//                AddExtension = true,
//                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv",
//                DefaultExt = "csv"
//            };
//        }

//        public override Guid Id { get; }
//        public override string Name { get; }
//        public override bool HasImport { get; }
//        public override bool HasExport { get; }
//        public override string ImportMenuText { get; }
//        public override string ExportMenuText { get; }
//        public override string Description { get; }

//        public void DoImport2()
//        {
//            if (_importDialog.ShowDialog()!= DialogResult.OK)
//                return;

//            var table = Core.Instance.Store.DataTable;

//            if (table.Rows.Count > 0 && Core.Instance.ShowQuestion("В таблице присутствуют данные. Очистить?") == DialogResult.Yes)
//                Core.Instance.Store.Clear();

//            var columns = Core.Instance.ColumnNames;

//            using (var reader = new StreamReader(_importDialog.FileName, Encoding.GetEncoding(1251)))
//            using (var csvr = new CsvReader(reader))
//            {
//                csvr.Configuration.HasHeaderRecord = true;
//                csvr.Configuration.Delimiter = ";";

//                csvr.Read();
//                csvr.ReadHeader();

//                while (csvr.Read())
//                {
//                    var row = table.NewRow();

//                    foreach (var column in columns)
//                    {
//                        row[column] = csvr[column];
//                    }

//                    table.Rows.Add(row);
//                }
//            }

//            Core.Instance.ShowMessage("Импорт завершен.");
//        }

//        public override void DoImport()
//        {
//            if (_importDialog.ShowDialog() != DialogResult.OK)
//                return;

//            var table = Core.Instance.Store.DataTable;

//            if (table.Rows.Count > 0 && Core.Instance.ShowQuestion("В таблице присутствуют данные. Очистить?") == DialogResult.Yes)
//                Core.Instance.Store.Clear();



//            //var columns = Core.Instance.ColumnNames;

//            using (var reader = new StreamReader(_importDialog.FileName, Encoding.GetEncoding(1251)))
//            using (var csvr = new CsvReader(reader))
//            {
//                csvr.Configuration.HasHeaderRecord = true;
//                csvr.Configuration.Delimiter = ";";
//                csvr.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
//                csvr.Configuration.RegisterClassMap<DataItemMap>();

//                //var qqq = csvr.GetRecords<DataItem>();

//                while (csvr.Read())
//                {
//                    try
//                    {
//                        var record = csvr.GetRecord<DataItem>();
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine(e);
//                    }
                    

                    
//                }
//            }

//            Core.Instance.ShowMessage("Импорт завершен.");
//        }

//        public override void DoExport()
//        {
//            if (_exportDialog.ShowDialog() != DialogResult.OK)
//                return;

//            var table = Core.Instance.Store.DataTable;

//            if (table.Rows.Count == 0)
//                throw new ApplicationException("Отсутствуют сведения для выгрузки.");

//            char delimiter = ';';
//            var columns = Core.Instance.ColumnNames;

//            using (var writer = new StreamWriter(_exportDialog.FileName, false, Encoding.GetEncoding(1251)))
//            //using (var csvw=new CsvWriter(writer))
//            //{
//            //    csvw.Configuration.Delimiter = ";";

//            //    csvw.WriteHeader<>();
//            //}
//            {
//                // header
//                writer.WriteLine(String.Join(delimiter.ToString(), columns));

//                // body
//                foreach (DataRow row in table.Rows)
//                {
//                    var builder = new StringBuilder();

//                    for (var i = 0; i < columns.Length; i++)
//                    {
//                        builder.Append(row.Field<string>(columns[i]));

//                        if (i != columns.Length - 1)
//                            builder.Append(delimiter);
//                    }

//                    writer.WriteLine(builder.ToString());
//                }

//                writer.Close();
//            }
//            Core.Instance.ShowMessage("Выгрузка завершена.");
//        }
//    }
//}

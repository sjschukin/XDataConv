using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;
using NLog;

namespace Schukin.XDataConv.Core.Modules
{
    public class XlsModule : ModuleBase
    {
        private static readonly Logger Logger = LogManager.GetLogger("importLogger");
        private readonly OpenFileDialog _importDialog;

        public XlsModule()
        {
            Id = new Guid("8044778A-A214-4404-88B6-9B1D2AA70EA7");
            Name = "Файл XLS";
            Description = "Импорт файла Excel";
            HasImport = true;
            ImportMenuText = "Формат Excel (xls, xlsx) ...";
            HasExport = false;

            _importDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Файлы Microsoft Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            };
        }

        public override Guid Id { get; }
        public override string Name { get; }
        public override bool HasImport { get; }
        public override bool HasExport { get; }
        public override string ImportMenuText { get; }
        public override string ExportMenuText { get; }
        public override string Description { get; }

        public override void DoImport()
        {
            if (_importDialog.ShowDialog() != DialogResult.OK)
                return;

            DataTable table = null; // Core.Instance.Store.DataTable;
            var filename = _importDialog.FileName;

            if (table.Rows.Count == 0)
                throw new ApplicationException("Отсутствуют сведения для идентификации. Сначала необходимо загрузить данные.");

            if (Core.Instance.ShowMappingForm() != DialogResult.OK)
                return;

            //Logger.Info($" === Открытие файла {filename}");

            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                // read the header
                if (!reader.Read())
                    throw new ApplicationException("Файл пуст.");

                //Logger.Info("Чтение заголовка");
                if (!Core.Instance.LoadMappingOrdinal(GetValues(reader)))
                {
                    throw new ApplicationException("Отсутствуют необходимые колонки. Импорт невозможен.");
                }

                // read the body
                var rows = table.Rows.Cast<DataRow>().AsQueryable();
                var mappingIdentify1 = Core.Instance.Mapping.GetUseForIdentify1().ToArray();
                var mappingIdentify2 = Core.Instance.Mapping.GetUseForIdentify2().ToArray();
                var mappingImport = Core.Instance.Mapping.GetUseForImport().ToArray();
                var mappingLog = Core.Instance.Mapping.GetUseForLog().ToArray();
                int lineNumber = 1;

                while (reader.Read())
                {
                    var values = GetValues(reader);

                    // line for log
                    var sb = new StringBuilder();
                    sb.Append("Строка ");
                    sb.Append(lineNumber);
                    sb.Append(": ");

                    foreach (var map in mappingLog)
                    {
                        sb.Append(values[map.SourceOrdinal]);
                        sb.Append(" ");
                    }

                    var lineForLog = sb.ToString();

                    // find the row
                    var row = Core.Instance.FindDataRow(rows, mappingIdentify1, values, lineForLog, mappingLog) ??
                              Core.Instance.FindDataRow(rows, mappingIdentify2, values, lineForLog, mappingLog);
                    lineNumber++;

                    if (row == null)
                        continue;

                    foreach (var map in mappingImport)
                    {
                        row[map.Name] = reader.GetValue(map.SourceOrdinal)?.ToString() ?? "";
                    }
                }
            }
            //Logger.Info(" === Импорт файла завершен.");
            Core.Instance.ShowMessage("Импорт завершен.");
        }

        public override void DoExport()
        {
            throw new NotImplementedException();
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

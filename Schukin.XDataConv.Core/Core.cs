using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using NLog;
using Schukin.XDataConv.Core.Modules;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public sealed class Core
    {
        private static Core _instance;

        private readonly MapSettingsForm _mappingForm;
        private readonly List<IdentifyResultItem> _identifyResults;
        private readonly SaveFileDialog _saveStoreDialog;
        private readonly OpenFileDialog _openStoreDialog;
        private readonly OpenFileDialog _openFileImportDialog;

        private readonly XlsModule _xlsModule;

        //private readonly Logger _logger;

        private Core()
        {
            _mappingForm = new MapSettingsForm();
            _identifyResults = new List<IdentifyResultItem>();

            _saveStoreDialog = new SaveFileDialog
            {
                CheckPathExists = true,
                AddExtension = true,
                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv",
                DefaultExt = "csv"
            };
            _openStoreDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv"
            };

            _openFileImportDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Файлы Microsoft Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            };

            Store = new StoreEngine();
            _xlsModule = new XlsModule();

            //_logger = LogManager.GetCurrentClassLogger();
            Mapping = GetDefaultMap();
        }

        public static Core Instance => _instance ?? (_instance = new Core());
        public StoreEngine Store { get; }
        public MapCollection Mapping { get; }

        public bool OpenStore()
        {
            if (_openStoreDialog.ShowDialog() != DialogResult.OK)
                return true;

            try
            {
                Store.Open(_openStoreDialog.FileName);
            }
            catch (Exception e)
            {
                ShowError(e);
            }
            return false;
        }

        public bool SaveStore()
        {
            if (Store.Data == null)
                return false;

            try
            {
                if (Store.CurrentFileName != null)
                {
                    Store.Save();
                }
                else
                {
                    SaveStoreAs();
                }
                return true;
            }
            catch (Exception e)
            {
                ShowError(e);
            }
            return false;
        }

        public bool SaveStoreAs()
        {
            if (_saveStoreDialog.ShowDialog() != DialogResult.OK)
                return false;

            try
            {
                Store.Save(_saveStoreDialog.FileName);
                return true;
            }
            catch (Exception e)
            {
                ShowError(e);
            }
            return false;
        }

        public DialogResult ShowMappingForm()
        {
            _mappingForm.DataSource = Mapping.ToArray();
            return _mappingForm.ShowDialog();
        }

        public void ShowImportLog()
        {
            var form = new LogForm();
            form.Show();
            form.ShowLog(_identifyResults);
        }

        public void OpenFileImport()
        {
            if (_openFileImportDialog.ShowDialog() != DialogResult.OK)
                return;

            var filename = _openFileImportDialog.FileName;
            var extension = System.IO.Path.GetExtension(filename)?.ToLower();

            if (extension == null)
                return;

            try
            {
                IModule module = null;

                if (extension == ".xls" | extension == ".xlsx")
                    module = new XlsModule();

                if (module == null)
                    return;

                if (ShowMappingForm() != DialogResult.OK)
                    return;

                Store.ImportedData = module.GetDataItems(filename);
                
                //if (Store.Data == null || !Store.Data.Any())
                //    throw new ApplicationException("Отсутствуют сведения для идентификации. Сначала необходимо загрузить данные.");

                //_identifyResults.Clear();
                //module.DoImport();
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        public DataRow FindDataRow(IQueryable<DataRow> rows, MapItem[] identifyMapping, IReadOnlyList<string> values, string lineForLog, MapItem[] mappingLog)
        {
            if (identifyMapping == null)
                return null;

            var logItem = new IdentifyResultItem { Name = lineForLog };

            // linq expression tree engine
            var param = Expression.Parameter(typeof(DataRow), "row");
            Expression expression1 = null;

            foreach (var map in identifyMapping)
            {
                var readerValue = values[map.SourceOrdinal] ?? "";

                if (map.MatchLinesCount > 0)
                {
                    var matching =
                        map.MatchLines.FirstOrDefault(item => item.SourceWord == readerValue);

                    if (matching != null)
                        readerValue = matching.AliasWord;
                }

                var expression2 = Expression.Equal(
                    Expression.Call(
                        Expression.Property(param, "Item", Expression.Constant(map.Name)),
                        typeof(object).GetMethod("ToString")),
                    Expression.Constant(readerValue)
                );

                if (expression1 != null)
                {
                    expression2 = Expression.And(expression1, expression2);
                }

                expression1 = expression2;
            }

            if (expression1 == null)
                return null;

            var lambda = Expression.Lambda<Func<DataRow, bool>>(expression1, param);
            var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { rows.ElementType }, rows.Expression, lambda);
            var results = rows.Provider.CreateQuery<DataRow>(whereExpression);
            var count = results.Count();

            switch (count)
            {
                case 0:
                    logItem.ResultType = 0;
                    logItem.Details.Add("Не идентифицирован");
                    break;
                case 1:
                    logItem.ResultType = 1;
                    logItem.Details.Add("Идентифицирован");
                    break;
                default:
                    if (count > 1)
                    {
                        logItem.ResultType = 2;
                        logItem.Details.Add($"Найдено несколько соответствий ({count}):");

                        var sb = new StringBuilder();
                        foreach (var row in results)
                        {
                            foreach (var map in mappingLog)
                            {
                                sb.Append(row[map.Name]);
                                sb.Append(" ");
                            }
                        }
                    }
                    break;
            }

            logItem.Details.Add(lambda.ToString());
            _identifyResults.Add(logItem);

            return results.FirstOrDefault();
        }

        public void InjectData(IReadOnlyList<DataItem> importDataItems)
        {
            if (importDataItems == null || !importDataItems.Any())
                return;

            var data = Store.Data.AsQueryable();

            foreach (var importDataItem in importDataItems)
            {
                // linq expression tree engine
                var param = Expression.Parameter(typeof(DataItem), "item");
                //var param=Expression.Property(parap_, mapItem.Name)
                Expression expression1 = null;

                foreach (var mapItem in Mapping.GetUseForIdentify1())
                {
                    var importPropValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(importDataItem);

                    if (mapItem.MatchLinesCount > 0 && importPropValue is string importPropStrValue)
                    {
                        var matchLine =
                            mapItem.MatchLines.FirstOrDefault(item => item.SourceWord == importPropStrValue);

                        if (matchLine != null)
                            importPropValue = matchLine.AliasWord;
                    }

                    var expression2 = Expression.Equal(Expression.Property(param, mapItem.Name), Expression.Constant(importPropValue));

                    if (expression1 != null)
                        expression2 = Expression.And(expression1, expression2);

                    expression1 = expression2;
                }

                if (expression1 == null)
                    continue;

                var lambda = Expression.Lambda<Func<DataItem, bool>>(expression1, param);
                var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { data.ElementType }, data.Expression, lambda);
                var sourceDataItems = data.Provider.CreateQuery<DataItem>(whereExpression);

                var sourceDataItem = sourceDataItems.FirstOrDefault();
                AssignValues(importDataItem, sourceDataItem);
            }
        }

        private void AssignValues(DataItem source, DataItem destination)
        {
            if (source == null || destination == null)
                return;

            foreach (var mapItem in Mapping.GetUseForAssign())
            {
                var sourceValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(source);
                typeof(DataItem).GetProperty(mapItem.Name)?.SetValue(destination, sourceValue);
            }
        }

        public bool LoadMappingOrdinal(IReadOnlyList<string> headerNames)
        {
            var activeMap = Mapping.GetActiveItems();
            bool result = true;

            foreach (var mapItem in activeMap)
            {
                mapItem.SourceOrdinal = -1;

                for (int i = 0; i < headerNames.Count; i++)
                {
                    if (mapItem.SourceColumnName != headerNames[i])
                        continue;

                    mapItem.SourceOrdinal = i;
                    break;
                }

                if (mapItem.SourceOrdinal == -1)
                {
                    ShowMessage($"В файле не найдена необходимая колонка {mapItem.SourceColumnName}.");
                    result = false;
                }
            }
            return result;
        }

        public void ExitApplication()
        {
            Application.Exit();
        }

        public void ShowAboutDialog()
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        public void ShowError(Exception e)
        {
            Console.WriteLine($"{DateTime.Now} ERROR: {e}");
            //_logger.Error(e);
            MessageBox.Show(e.Message, "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "XDataConv", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private MapCollection GetDefaultMap()
        {
            var storeMap = Store.GetMap();
            var map = new MapCollection(storeMap.Select(item => new MapItem { Name = item.PropertyName, FieldName = item.FieldName, MemberInfo = item.MemberInfo, MatchLines = new List<MatchLine>() }).ToArray());

            var checkedUseForCompare1 = new[] { "ILCHET", "GKU", "ORG" };
            var checkedUseForCompare2 = new[] { "FAMIL", "IMJA", "OTCH", "POSEL", "NASP", "YLIC", "NDOM", "NKORP", "NKW", "NKOMN", "GKU", "ORG" };
            var checkedUseForImport = new[] { "OPL", "OTPL", "KOLZR", "VIDTAR", "TARIF", "FAKT", "SUMTAR", "SUMDOLG", "DATDOLG" };
            var checkedUseForLog = new[] { "FAMIL", "IMJA", "OTCH", "DROG" };

            foreach (var mapItem in map)
            {
                mapItem.SourceColumnName = mapItem.FieldName;

                mapItem.UseForCompare1 = checkedUseForCompare1.Contains(mapItem.FieldName);
                mapItem.UseForCompare2 = checkedUseForCompare2.Contains(mapItem.FieldName);
                mapItem.UseForAssign = checkedUseForImport.Contains(mapItem.FieldName);
                mapItem.UseForLog = checkedUseForLog.Contains(mapItem.FieldName);
            }

            return map;
        }
    }
}

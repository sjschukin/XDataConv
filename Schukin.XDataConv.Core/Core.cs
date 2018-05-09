using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Schukin.XDataConv.Core.Modules;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public sealed class Core
    {
        private static Core _instance;

        private readonly List<IdentifyResultItem> _identifyResults;

        //private readonly Logger _logger;

        private Core()
        {
            _identifyResults = new List<IdentifyResultItem>();
            Store = new StoreEngine();

            //_logger = LogManager.GetCurrentClassLogger();
            Mapping = GetDefaultMap();
        }

        public static Core Instance => _instance ?? (_instance = new Core());
        public StoreEngine Store { get; }
        public MapCollection Mapping { get; }

        public void ShowImportLog()
        {
            var form = new LogForm();
            form.Show();
            form.ShowLog(_identifyResults);
        }

        public void OpenFileImport(string filename)
        {
            var extension = System.IO.Path.GetExtension(filename)?.ToLower();

            if (extension == null)
                return;

            IModule module = null;

            if (extension == ".xls" | extension == ".xlsx")
                module = new XlsModule();

            if (module == null)
                return;

            Store.ImportedData = new SortableBindingList<DataItem>(module.GetDataItems(filename).ToList());
        }

        public void InjectDataByIdentify1()
        {
            InjectData(Mapping.GetUseForIdentify1);
        }

        public void InjectDataByIdentify2()
        {
            InjectData(Mapping.GetUseForIdentify2);
        }

        private void InjectData(Func<IEnumerable<MapItem>> getMappingCollection)
        {
            if (Store.ImportedData == null)
            {
                ShowMessage("Отсутствуют данные из которых необходимо произвести перенос.");
                return;
            }

            if (Store.Data == null)
            {
                ShowMessage("Отсутствуют данные в которые необходимо произвести перенос.");
                return;
            }

            var importedDataItems = Store.ImportedData.ToArray();

            if (!importedDataItems.Any())
                return;

            var data = Store.Data.AsQueryable();

            foreach (var importDataItem in importedDataItems)
            {
                // linq expression tree engine
                var param = Expression.Parameter(typeof(DataItem), "item");
                Expression expression1 = null;

                foreach (var mapItem in getMappingCollection())
                {
                    var importPropValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(importDataItem);

                    if (mapItem.ImportMatchLinesCount > 0 && importPropValue is string importPropStrValue)
                    {
                        var matchLine =
                            mapItem.ImportMatchLines.FirstOrDefault(item => item.SourceWord == importPropStrValue);

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

                if (sourceDataItems.Count() == 1)
                {
                    AssignValues(importDataItem, sourceDataItems.First());
                    importDataItem.State = DataItemState.None;
                    importDataItem.StateMessage = null;
                }
                else if (!sourceDataItems.Any())
                {
                    importDataItem.State = DataItemState.InjectNotFound;
                    importDataItem.StateMessage = "Соответствий не найдено";
                }
                else
                {
                    importDataItem.State = DataItemState.InjectAmbigous;
                    importDataItem.StateMessage =
                        $"Обнаружено более одного соответствия в строках {String.Join(";", sourceDataItems.Select(item => item.LineNumber))}";
                }
            }
        }

        private void AssignValues(DataItem source, DataItem destination)
        {
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
                mapItem.ImportFieldOrdinal = -1;

                for (int i = 0; i < headerNames.Count; i++)
                {
                    if (mapItem.ImportFieldName != headerNames[i])
                        continue;

                    mapItem.ImportFieldOrdinal = i;
                    break;
                }

                if (mapItem.ImportFieldOrdinal == -1)
                {
                    ShowMessage($"В файле не найдена необходимая колонка {mapItem.ImportFieldName}.");
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
            var map = new MapCollection(storeMap.Select(item => new MapItem
            {
                Name = item.PropertyName,
                FieldName = item.FieldName,
                MemberInfo = item.MemberInfo,
                ImportMatchLines = new List<MatchLine>()
            }).ToArray());

            var excludedImportFieldName = new[] { "LDID", "ADRID", "MONTH", "YEAR" };
            var checkedIsConvertImportToUpperCase = new[] { "FAMIL", "IMJA", "OTCH" };
            var checkedIsUseForCompare1 = new[] { "ILCHET", "GKU", "ORG" };
            var checkedIsUseForCompare2 = new[] { "FAMIL", "IMJA", "OTCH", "POSEL", "NASP", "YLIC", "NDOM", "NKORP", "NKW", "NKOMN", "GKU", "ORG" };
            var checkedIsUseForInject = new[] { "OPL", "OTPL", "KOLZR", "VIDTAR", "TARIF", "FAKT", "SUMTAR", "SUMDOLG", "OPLDOLG", "DATDOLG" };
            var checkedIsUseForLog = new[] { "FAMIL", "IMJA", "OTCH", "DROG" };

            foreach (var mapItem in map)
            {
                mapItem.ImportFieldName =
                    excludedImportFieldName.Contains(mapItem.FieldName) ? null : mapItem.FieldName;

                mapItem.IsConvertImportToUpperCase = checkedIsConvertImportToUpperCase.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare1 = checkedIsUseForCompare1.Contains(mapItem.FieldName);
                mapItem.IsUseForCompare2 = checkedIsUseForCompare2.Contains(mapItem.FieldName);
                mapItem.IsUseForInject = checkedIsUseForInject.Contains(mapItem.FieldName);
                mapItem.IsUseForLog = checkedIsUseForLog.Contains(mapItem.FieldName);
            }

            return map;
        }
    }
}

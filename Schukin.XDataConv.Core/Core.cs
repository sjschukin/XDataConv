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
            MapSettings = new MapSettings();
            MapSettings.LoadDefault(Store);
            //_logger = LogManager.GetCurrentClassLogger();
        }

        public static Core Instance => _instance ?? (_instance = new Core());
        public StoreEngine Store { get; }
        public MapSettings MapSettings { get; set; }

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

        public SortableBindingList<DataItem> GetUnassignedRows()
        {
            if (Store.Data == null)
                return null;

            var assignMapping = MapSettings.Mapping.GetUseForAssign();
            var mapItems = assignMapping as MapItem[] ?? assignMapping.ToArray();
            
            if (!mapItems.Any())
                throw new ApplicationException("В настройках не выбраны поля, которые должны быть скопированы в источник и по которым определяется фильтрация.");

            var data = Store.Data.AsQueryable();

            // linq expression tree filter
            var param = Expression.Parameter(typeof(DataItem), "item");
            Expression expression1 = null;

            foreach (var mapItem in mapItems)
            {
                var expression2 = Expression.Equal(Expression.Property(param, mapItem.Name), Expression.Constant(null, typeof(object)));

                if (expression1 != null)
                    expression2 = Expression.OrElse(expression1, expression2);

                expression1 = expression2;
            }

            var lambda = Expression.Lambda<Func<DataItem, bool>>(expression1, param);
            var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { data.ElementType }, data.Expression, lambda);
            var sourceDataItems = data.Provider.CreateQuery<DataItem>(whereExpression);

            return new SortableBindingList<DataItem>(sourceDataItems.ToList());
        }

        public void InjectDataByIdentify1(IEnumerable<DataItem> destination)
        {
            InjectData(MapSettings.Mapping.GetUseForIdentify1, Store.ImportedData, destination);
        }

        public void InjectDataByIdentify2(IEnumerable<DataItem> destination)
        {
            InjectData(MapSettings.Mapping.GetUseForIdentify2, Store.ImportedData, destination);
        }

        private void InjectData(Func<IEnumerable<MapItem>> getMappingCollection, IEnumerable<DataItem> source, IEnumerable<DataItem> destination)
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

            var sourceItems = source as DataItem[] ?? source.ToArray();

            if (!sourceItems.Any())
                return;

            var destinationItems = destination.AsQueryable();

            foreach (var sourceItem in sourceItems)
            {
                // linq expression tree engine
                var param = Expression.Parameter(typeof(DataItem), "item");
                Expression expression1 = null;

                foreach (var mapItem in getMappingCollection())
                {
                    var importPropValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(sourceItem);

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
                var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { destinationItems.ElementType }, destinationItems.Expression, lambda);
                var sourceDataItems = destinationItems.Provider.CreateQuery<DataItem>(whereExpression);

                if (sourceDataItems.Count() == 1)
                {
                    AssignValues(sourceItem, sourceDataItems.First());
                    sourceItem.State = DataItemState.None;
                    sourceItem.StateMessage = null;
                }
                else if (!sourceDataItems.Any())
                {
                    sourceItem.State = DataItemState.InjectNotFound;
                    sourceItem.StateMessage = "Соответствий не найдено";
                }
                else
                {
                    if (MapSettings.IsFindAllMatches)
                    {
                        AssignValues(sourceItem, sourceDataItems);
                        sourceItem.State = DataItemState.None;
                    }
                    else
                    {
                        sourceItem.State = DataItemState.InjectAmbigous;
                    }

                    sourceItem.StateMessage =
                        $"Обнаружено более одного соответствия в строках {String.Join(";", sourceDataItems.Select(item => item.LineNumber))}";
                }
            }
        }

        private void AssignValues(DataItem source, DataItem destination)
        {
            foreach (var mapItem in MapSettings.Mapping.GetUseForAssign())
            {
                var sourceValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(source);
                typeof(DataItem).GetProperty(mapItem.Name)?.SetValue(destination, sourceValue);
            }
        }

        private void AssignValues(DataItem source, IEnumerable<DataItem> destination)
        {
            foreach (var destinationItem in destination)
            {
                foreach (var mapItem in MapSettings.Mapping.GetUseForAssign())
                {
                    var sourceValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(source);
                    typeof(DataItem).GetProperty(mapItem.Name)?.SetValue(destinationItem, sourceValue);
                }
            }
        }

        public bool LoadMappingOrdinal(IReadOnlyList<string> headerNames)
        {
            var activeMap = MapSettings.Mapping.GetActiveItems();
            bool result = true;

            foreach (var mapItem in activeMap)
            {
                mapItem.ImportFieldOrdinal = -1;

                for (int i = 0; i < headerNames.Count; i++)
                {
                    if (mapItem.ImportFieldName.ToUpper() != headerNames[i])
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core
{
    public class MatchingManager : IMatchingManager
    {
        private readonly ILogger _logger;
        private readonly SortableBindingList<DataItem> _sourceData;
        private readonly SortableBindingList<DataItem> _sourceMatchedData;
        private readonly SortableBindingList<DataItem> _importedData;
        private readonly SortableBindingList<DataItem> _importedMatchedData;
        
        public MatchingManager(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _sourceData = new SortableBindingList<DataItem>();
            _sourceMatchedData = new SortableBindingList<DataItem>();
            _importedData = new SortableBindingList<DataItem>();
            _importedMatchedData = new SortableBindingList<DataItem>();
        }

        public SortableBindingList<DataItem> SourceData => _sourceData;
        public SortableBindingList<DataItem> SourceMatchedData => _sourceMatchedData;
        public SortableBindingList<DataItem> ImportedData => _importedData;
        public SortableBindingList<DataItem> ImportedMatchedData => _importedMatchedData;
        public Settings Settings { get; set; }
        public IEnumerable<IDataItemError> MatchingErrors { get; private set; }

        public void InjectDataByIdentify1()
        {
            if (Settings == null)
                throw new ApplicationException($"{nameof(Settings)} cannot be null.");

            _logger.Info("Perform matching by Identify1.");
            InjectData(Settings.Mapping.GetUseForIdentify1);
        }

        public void InjectDataByIdentify2()
        {
            if (Settings == null)
                throw new ApplicationException($"{nameof(Settings)} cannot be null.");

            _logger.Info("Perform matching by Identify2.");
            InjectData(Settings.Mapping.GetUseForIdentify2);
        }

        private void InjectData(Func<IEnumerable<SettingsMapItem>> getMappingCollection)
        {
            var matchingErrors = new List<IDataItemError>();

            if (!_importedData.Any())
                return;

            var sourceItems = _sourceData.AsQueryable();
            int index = 0;

            do
            {
                var importedItem = _importedData[index];

                // linq expression tree engine
                var param = Expression.Parameter(typeof(DataItem), "item");
                Expression expression1 = null;

                foreach (var mapItem in getMappingCollection())
                {
                    var importPropValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(importedItem);

                    if (mapItem.MatchingItemsCount > 0 && importPropValue is string importPropStrValue)
                    {
                        var matchLine =
                            mapItem.MatchingItems.FirstOrDefault(item => item.Source == importPropStrValue);

                        if (matchLine != null)
                            importPropValue = matchLine.Alias;
                    }

                    var expression2 = Expression.Equal(Expression.Property(param, mapItem.Name), Expression.Constant(importPropValue));

                    if (expression1 != null)
                        expression2 = Expression.And(expression1, expression2);

                    expression1 = expression2;
                }

                if (expression1 == null)
                    continue;

                var lambda = Expression.Lambda<Func<DataItem, bool>>(expression1, param);
                var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { sourceItems.ElementType }, sourceItems.Expression, lambda);
                var sourceFoundItems = sourceItems.Provider.CreateQuery<DataItem>(whereExpression);

                int foundCount = sourceFoundItems.Count();

                Console.WriteLine("index {0}, found {1}", index, foundCount);

                if (foundCount == 0)
                {
                    index++;

                    matchingErrors.Add(new DataItemError
                    {
                        RowId = importedItem.RowId,
                        Message = $"Не найдено соответствий для строки {importedItem.RowId}"
                    });
                    continue;
                }

                if (foundCount > 1 && Settings.IsFindAllMatches)
                {
                    AssignValuesAndMoveToMatched(importedItem, sourceFoundItems);
                    continue;
                }

                if (foundCount == 1)
                {
                    AssignValuesAndMoveToMatched(importedItem, sourceFoundItems.First());
                    continue;
                }

                index++;

                matchingErrors.Add(new DataItemError
                {
                    RowId = importedItem.RowId,
                    Message =
                        $"Найдено более одного соответствия для строки {importedItem.RowId}. Это строки {String.Join(", ", sourceFoundItems.Select(item => item.RowId))}"
                });

            } while (index < _importedData.Count);

            MatchingErrors = matchingErrors.ToArray();
            _logger.Info("Matching complete.");
        }

        private void AssignValuesAndMoveToMatched(DataItem importedItem, DataItem sourceItem)
        {
            foreach (var mapItem in Settings.Mapping.GetUseForAssign())
            {
                var importedValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(importedItem);
                typeof(DataItem).GetProperty(mapItem.Name)?.SetValue(sourceItem, importedValue);
            }

            _sourceData.Remove(sourceItem);
            _sourceMatchedData.Add(sourceItem);
            _importedData.Remove(importedItem);
            _importedMatchedData.Add(importedItem);
        }

        private void AssignValuesAndMoveToMatched(DataItem importedItem, IEnumerable<DataItem> sourceItems)
        {
            var sourceArray = sourceItems as DataItem[] ?? sourceItems.ToArray();

            for (int i = 0; i < sourceArray.Length; i++)
            {
                foreach (var mapItem in Settings.Mapping.GetUseForAssign())
                {
                    var importedValue = typeof(DataItem).GetProperty(mapItem.Name)?.GetValue(importedItem);
                    typeof(DataItem).GetProperty(mapItem.Name)?.SetValue(sourceArray[i], importedValue);
                }

                _sourceData.Remove(sourceArray[i]);
                _sourceMatchedData.Add(sourceArray[i]);
            }

            _importedData.Remove(importedItem);
            _importedMatchedData.Add(importedItem);
        }
    }
}

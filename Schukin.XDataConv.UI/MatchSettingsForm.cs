using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.UI
{
    public sealed partial class MatchSettingsForm : Form
    {
        private readonly List<MatchingItem> _originalDataSource;
        private readonly List<MatchingItem> _currentDataSource;

        private readonly SettingsMapItem _mapItem;
        private readonly IMatchingManager _matchingManager;

        public MatchSettingsForm(SettingsMapItem mapItem, IMatchingManager matchingManager)
        {
            _mapItem = mapItem ?? throw new ArgumentNullException(nameof(mapItem));
            _matchingManager = matchingManager ?? throw new ArgumentNullException(nameof(matchingManager));

            InitializeComponent();

            _originalDataSource = mapItem.MatchingItems;
            _currentDataSource = new List<MatchingItem>(_originalDataSource);

            InitializeComponentCustom();
            InitializeEventHandlers();

            BindDataGrid();
            ShowPossibleWordsAsync();
        }

        #region initialize component

        private void InitializeComponentCustom()
        {
            Text = $"Настройка соответствий для {_mapItem.FieldName}";
        }

        private void InitializeEventHandlers()
        {
            clearAllTool.Click += ClearAllTool_Click;
            copyNewLineImportTool.Click += CopyNewLineImportTool_Click;
            copyCellImportTool.Click += CopyCellImportTool_Click;
            copyNewLineSourceTool.Click += CopyNewLineSourceTool_Click;
            copyCellSourceTool.Click += CopyCellSourceTool_Click;
        }

        private void BindDataGrid()
        {
            matchGrid.AutoGenerateColumns = false;

            matchGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Значение из файла поставщика", DataPropertyName = "Source", Width = 250 },
                new DataGridViewTextBoxColumn { HeaderText = "Считать как", DataPropertyName = "Alias", Width = 250 }
            );

            bindingSource.DataSource = _currentDataSource;
        }

        #endregion

        private bool ValidateForm()
        {
            if (_currentDataSource.Any(item => String.IsNullOrWhiteSpace(item.Alias) || String.IsNullOrWhiteSpace(item.Source)))
            {
                MessageBox.Show("Список не может содержать пустые строки.", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (_currentDataSource.GroupBy(item => item.Source).Any(item => item.Count() > 1))
            {
                MessageBox.Show("Список не может содержать дубликаты в столбце 'Значение из файла'.", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private string[] GetDistinctValues(IQueryable<DataItem> data)
        {
            // item
            var param = Expression.Parameter(typeof(DataItem), "item");
            // item.Property
            var property = Expression.Property(param, _mapItem.Name);
            // item => item.Property
            var lambda = Expression.Lambda(property, param);
            // Items.Select(item => item.Property)
            var selectCall = Expression.Call(typeof(Queryable), "Select", new[] { data.ElementType, lambda.Body.Type },
                data.Expression, lambda);
            // Items.Select(item => item.Property).Distinct()
            var distinctCall = Expression.Call(typeof(Queryable), "Distinct", new[] { property.Type }, selectCall);
            // Items.Select(item => item.Property).Distinct().OrderBy(item => item)
            var param2 = Expression.Parameter(typeof(string), "item");
            var orderByCall = Expression.Call(typeof(Queryable), "OrderBy", new[] { property.Type, property.Type },
                distinctCall, Expression.Lambda<Func<string, string>>(param2, param2));

            var query = data.Provider.CreateQuery(orderByCall);

            return query.Cast<string>().ToArray();
        }

        private async void ShowPossibleWordsAsync()
        {
                var listSource = Task.Run(() => GetDistinctValues(_matchingManager.SourceData.AsQueryable()).Select(x => new { Value = x }).ToList());
                gridSource.DataSource = await listSource;

                var listImported = Task.Run(() => GetDistinctValues(_matchingManager.ImportedData.AsQueryable()).Select(x => new { Value = x }).ToList());
                gridImport.DataSource = await listImported;
        }

        private void CopyNewLine(string[] values)
        {
            foreach (var value in values)
            {
                var item = bindingSource.AddNew() as MatchingItem;
                item.Source = value;
            }
        }

        private void CopyToCells(string value)
        {
            var cells = matchGrid.SelectedCells;

            if (cells.Count == 0)
                return;

            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].Value = value;
            }
        }

        private void ClearAllTool_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите очистить список?", "XDataConv", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bindingSource.Clear();
            }
        }

        private void CopyNewLineImportTool_Click(object sender, EventArgs e)
        {
            var cells = gridImport.SelectedCells;

            if (cells.Count == 0)
                return;

            CopyNewLine(cells.Cast<DataGridViewCell>().Select(item => item.Value.ToString()).ToArray());
        }

        private void CopyCellImportTool_Click(object sender, EventArgs e)
        {
            var row = gridImport.CurrentRow;

            if (row == null)
                return;

            CopyToCells(row.Cells[0].Value.ToString());
        }

        private void CopyNewLineSourceTool_Click(object sender, EventArgs e)
        {
            var cells = gridSource.SelectedCells;

            if (cells.Count == 0)
                return;

            CopyNewLine(cells.Cast<DataGridViewCell>().Select(item => item.Value.ToString()).ToArray());
        }

        private void CopyCellSourceTool_Click(object sender, EventArgs e)
        {
            var row = gridSource.CurrentRow;

            if (row == null)
                return;

            CopyToCells(row.Cells[0].Value.ToString());
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            _originalDataSource.Clear();
            _originalDataSource.AddRange(_currentDataSource);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

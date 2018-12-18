using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schukin.XDataConv.Core;

namespace Schukin.XDataConv.UI
{
    public sealed partial class MatchSettingsForm : Form
    {
        private readonly List<MatchingItem> _currentDatasource;
        private readonly List<MatchingItem> _originalDatasource;

        private readonly SettingsMapItem _mapItem;

        public MatchSettingsForm(SettingsMapItem mapItem)
        {
            InitializeComponent();

            _originalDatasource = mapItem.MatchingItems;
            _currentDatasource = new List<MatchingItem>(_originalDatasource);

            _mapItem = mapItem;
            Text = $"Настройка соответствий для {_mapItem.FieldName}";

            clearAllTool.Click += ClearAllTool_Click;
            copyNewLineImportTool.Click += CopyNewLineImportTool_Click;
            copyCellImportTool.Click += CopyCellImportTool_Click;
            copyNewLineSourceTool.Click += CopyNewLineSourceTool_Click;
            copyCellSourceTool.Click += CopyCellSourceTool_Click;

            BindDataGrid();
            ShowPossibleWordsAsync();
        }


        private void BindDataGrid()
        {
            matchGrid.AutoGenerateColumns = false;

            matchGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Значение из файла поставщика", DataPropertyName = "SourceWord", Width = 250 },
                new DataGridViewTextBoxColumn { HeaderText = "Считать как", DataPropertyName = "AliasWord", Width = 250 }
                );

            bindingSource.DataSource = _currentDatasource;
        }

        private bool ValidateForm()
        {
            if (_currentDatasource.Any(item => String.IsNullOrWhiteSpace(item.Alias) && String.IsNullOrWhiteSpace(item.Source)))
            {
                MessageBox.Show("Список не может содержать пустые строки.", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (_currentDatasource.GroupBy(item => item.Source).Any(item => item.Count() > 1))
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
            //if (Core.Core.Instance.Store.Data != null)
            //{
            //    var list = Task.Run(() => GetDistinctValues(Core.Core.Instance.Store.Data.AsQueryable()).Select(x => new { Value = x }).ToList());
            //    gridSource.DataSource = await list;
            //}

            //if (Core.Core.Instance.Store.ImportedData != null)
            //{
            //    var list = Task.Run(() => GetDistinctValues(Core.Core.Instance.Store.ImportedData.AsQueryable()).Select(x => new { Value = x }).ToList());
            //    gridImport.DataSource = await list;
            //}
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

            _originalDatasource.Clear();
            _originalDatasource.AddRange(_currentDatasource);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

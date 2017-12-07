using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public sealed partial class MatchSettingsForm : Form
    {
        private readonly List<MatchLine> _currentDatasource;
        private readonly List<MatchLine> _originalDatasource;

        private readonly MapItem _mapItem;

        private PossibleOptionsForm _importedOptionsForm;
        private PossibleOptionsForm _sourceOptionsForm;

        public MatchSettingsForm(MapItem mapItem)
        {
            InitializeComponent();

            _originalDatasource = mapItem.ImportMatchLines;
            _currentDatasource = new List<MatchLine>(_originalDatasource);

            _mapItem = mapItem;
            Text = $"Настройка соответствий для {_mapItem.FieldName}";

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            matchGrid.AutoGenerateColumns = false;

            matchGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "Значение из файла", DataPropertyName = "SourceWord", Width = 250 },
                new DataGridViewTextBoxColumn { HeaderText = "Считать как", DataPropertyName = "AliasWord", Width = 250 }
                );

            bindingSource.DataSource = _currentDatasource;
        }

        private bool ValidateForm()
        {
            if (_currentDatasource.Any(item => String.IsNullOrWhiteSpace(item.AliasWord) && String.IsNullOrWhiteSpace(item.SourceWord)))
            {
                MessageBox.Show("Список не может содержать пустые строки.", "Внимание", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (_currentDatasource.GroupBy(item => item.SourceWord).Any(item => item.Count() > 1))
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
            var selectCall = Expression.Call(typeof(Queryable), "Select", new[] {data.ElementType, lambda.Body.Type},
                data.Expression, lambda);
            // Items.Select(item => item.Property).Distinct()
            var distinctCall = Expression.Call(typeof(Queryable), "Distinct", new[] {property.Type}, selectCall);

            var query = data.Provider.CreateQuery(distinctCall);

            return query.Cast<string>().ToArray();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            bindingSource.Clear();
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

        private void importedOptionsButton_Click(object sender, EventArgs e)
        {
            if (Core.Instance.Store.ImportedData == null || !Core.Instance.Store.ImportedData.Any())
                return;

            if (_importedOptionsForm == null || _importedOptionsForm.IsDisposed)
            {
                _importedOptionsForm = new PossibleOptionsForm
                {
                    Text = "Варианты значений из файла",
                    OptionsText = String.Join("\r\n", GetDistinctValues(Core.Instance.Store.ImportedData.AsQueryable()))
                };
            }

            _importedOptionsForm.Show();
        }

        private void sourceOptionsButton_Click(object sender, EventArgs e)
        {
            if (Core.Instance.Store.Data == null || !Core.Instance.Store.Data.Any())
                return;

            if (_sourceOptionsForm == null || _sourceOptionsForm.IsDisposed)
            {
                _sourceOptionsForm = new PossibleOptionsForm
                {
                    Text = "Варианты значений из источника",
                    OptionsText = String.Join("\r\n", GetDistinctValues(Core.Instance.Store.Data.AsQueryable()))
                };
            }

            _sourceOptionsForm.Show();
        }

        //private void GridMatching_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex != 1 && e.ColumnIndex != 3)
        //        return;

        //    if (!(matchGrid.Rows[e.RowIndex].DataBoundItem is MatchLine item))
        //        return;

        //    if (e.ColumnIndex == 1)
        //    {
        //        item.SourceWord = "111";
        //        DataGridViewEd
        //    }

        //    if (e.ColumnIndex == 3)
        //    {
        //        item.AliasWord = "222";
        //    }
        //}

        //private void MatchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    if (e.Control is DataGridViewComboBoxEditingControl combo)
        //    {
        //        // Remove an existing event-handler, if present, to avoid 
        //        // adding multiple handlers when the editing control is reused.
        //        combo.DropDownStyle = ComboBoxStyle.DropDown;
        //        combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        combo.AutoCompleteMode = AutoCompleteMode.Suggest;


        //    }
        //}

        //private void MatchGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (e.ColumnIndex == 0)
        //    {
        //        var col = matchGrid.Columns[e.ColumnIndex] as DataGridViewComboBoxColumn;
        //        object eFV = e.FormattedValue;
        //        if (!_testsource.Contains(eFV))
        //        {
        //            _testsource.Add(eFV.ToString());
        //            matchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = eFV;
        //        }
        //    }
        //}
    }
}

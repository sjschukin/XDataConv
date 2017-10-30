using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class MatchSettingsForm : Form
    {
        private readonly List<MatchLine> _currentDatasource;
        private readonly List<MatchLine> _originalDatasource;

        public MatchSettingsForm(List<MatchLine> datasource)
        {
            InitializeComponent();

            gridMatching.AutoGenerateColumns = false;
            _originalDatasource = datasource;
            _currentDatasource = new List<MatchLine>(datasource);

            bindingSource.DataSource = _currentDatasource;
        }

        private bool ValidateForm()
        {
            if (_currentDatasource.Any(item => item.AliasWord.Trim() == "" && item.SourceWord.Trim() == ""))
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
    }
}

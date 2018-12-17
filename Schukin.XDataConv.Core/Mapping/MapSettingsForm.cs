using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class MapSettingsForm : Form
    {
        private readonly SaveFileDialog _saveFileDialog;
        private readonly OpenFileDialog _openFileDialog;

        public MapSettingsForm(Settings mapSettings)
        {
            InitializeComponent();

            CurrentMapSettings = mapSettings;

            _saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Path.Combine(Application.StartupPath, "templates"),
                CheckPathExists = true,
                AddExtension = true,
                FileName = "template",
                Filter = "Файлы шаблонов XDataConv (*.xml)|*.xml",
                DefaultExt = "xml"
            };

            _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Application.StartupPath, "templates"),
                CheckFileExists = true,
                Filter = "Файлы шаблонов XDataConv (*.xml)|*.xml"
            };

            buttonOk.Click += ButtonOk_Click;
            buttonSaveTemplate.Click += ButtonSaveTemplate_Click;
            buttonLoadTemplate.Click += ButtonLoadTemplate_Click;
            gridMapping.CellClick += GridMapping_CellClick;

            // binding
            gridMapping.AutoGenerateColumns = false;
            gridMapping.DataSource = mapSettings.Mapping.ToArray();

            checkFindAllMatches.DataBindings.Add("Checked", mapSettings, "IsFindAllMatches");
        }

        public Settings CurrentMapSettings { get; }

        private bool ValidateForm()
        {
            var invalidMappingCompare = CurrentMapSettings.Mapping.Where(item =>
                item.IsUseForCompare1 | item.IsUseForCompare2 && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingCompare.Any())
            {
                Core.Instance.ShowMessage(
                    $"Для следующих столбцов не указаны наименования столбцов файла: {String.Join(",", invalidMappingCompare.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingInject =
                CurrentMapSettings.Mapping.Where(item => item.IsUseForInject && item.IsUseForCompare1 | item.IsUseForCompare2).ToArray();

            if (invalidMappingInject.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как они используются для идентификации: {String.Join(",", invalidMappingInject.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingInject2 =
                CurrentMapSettings.Mapping.Where(item => item.IsUseForInject && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingInject2.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как для них не указаны наименования столбцов загружаемого файла: {String.Join(",", invalidMappingInject2.Select(item => item.Name))}.");
                return false;
            }

            return true;
        }

        private void SaveTemplate()
        {
            if (_saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                CurrentMapSettings.SaveTemplate(_saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Core.Instance.ShowError(ex);
            }
        }

        private void LoadTemplate()
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                CurrentMapSettings.LoadTemplate(_openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                Core.Instance.ShowError(ex);
            }
            
            gridMapping.Invalidate();
        }

        private void ShowMatchSettingsForm(MapItem mapItem)
        {
            var formMatching = new MatchSettingsForm(mapItem);
            formMatching.ShowDialog();
        }

        private void GridMapping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var matchingColumn = gridMapping.Columns["colMatchingList"];

            if (matchingColumn == null)
                return;

            if (e.RowIndex < 0 || e.ColumnIndex != matchingColumn.Index)
                return;

            if (!(gridMapping.Rows[e.RowIndex].DataBoundItem is MapItem item))
                return;

            if (((System.Reflection.PropertyInfo)item.MemberInfo).PropertyType.Name != "String")
                return;

            ShowMatchSettingsForm(item);
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }

        private void ButtonLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplate();
        }
    }
}

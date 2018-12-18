using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.UI
{
    public partial class MapSettingsForm : Form
    {
        private readonly ILogger _logger;
        private readonly SaveFileDialog _saveFileDialog;
        private readonly OpenFileDialog _openFileDialog;

        public MapSettingsForm(ILogger logger, Settings settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            CurrentSettings = settings ?? throw new ArgumentNullException(nameof(settings));

            InitializeComponent();

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
            gridMapping.DataSource = settings.Mapping.ToArray();

            checkFindAllMatches.DataBindings.Add("Checked", settings, "IsFindAllMatches");
        }

        public Settings CurrentSettings { get; }

        private bool ValidateForm()
        {
            var invalidMappingCompare = CurrentSettings.Mapping.Where(item =>
                item.IsUseForCompare1 | item.IsUseForCompare2 && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingCompare.Any())
            {
                MessageBox.Show(
                    $"Для следующих столбцов не указаны наименования столбцов файла:\r\n{String.Join(",", invalidMappingCompare.Select(item => item.Name))}.",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var invalidMappingInject =
                CurrentSettings.Mapping.Where(item => item.IsUseForInject && item.IsUseForCompare1 | item.IsUseForCompare2).ToArray();

            if (invalidMappingInject.Any())
            {
                MessageBox.Show(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как они используются для идентификации:\r\n{String.Join(",", invalidMappingInject.Select(item => item.Name))}.",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var invalidMappingInject2 =
                CurrentSettings.Mapping.Where(item => item.IsUseForInject && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingInject2.Any())
            {
                MessageBox.Show(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как для них не указаны наименования столбцов загружаемого файла:\r\n{String.Join(",", invalidMappingInject2.Select(item => item.Name))}.",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _logger.Info("Perform to save matching template.");
                CurrentSettings.SaveTemplate(_saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error saving template {_saveFileDialog.FileName}", ex);
                MessageBox.Show($"Ошибка сохранения шаблона {_saveFileDialog.FileName}.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTemplate()
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _logger.Info("Perform to load matching template.");
                CurrentSettings.LoadTemplate(_openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error loading template {_openFileDialog.FileName}", ex);
                MessageBox.Show($"Ошибка загрузки шаблона {_openFileDialog.FileName}.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            gridMapping.Invalidate();
        }

        private void ShowMatchSettingsForm(SettingsMapItem mapItem)
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

            if (!(gridMapping.Rows[e.RowIndex].DataBoundItem is SettingsMapItem item))
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

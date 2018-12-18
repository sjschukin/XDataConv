﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Csv;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.UI
{
    public partial class AppForm : Form
    {
        private readonly ILogger _logger;
        private readonly IMatchingManager _matchingManager;
        private readonly IImportModule<DataItem, DataItemError>[] _importModules;
        private readonly SaveFileDialog _saveSourceFileDialog;
        private readonly OpenFileDialog _openSourceFileDialog;
        private readonly OpenFileDialog _openImportedFileDialog;

        private Settings _settings;
        // private string _currentFileName;
        // private string _currentImportFileName;

        public AppForm(ILogger logger, IMatchingManager matchingManager, IImportModule<DataItem, DataItemError>[] importModules = null)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _matchingManager = matchingManager ?? throw new ArgumentNullException(nameof(matchingManager));
            _importModules = importModules;

            InitializeComponent();

            _settings = new Settings();
            _settings.LoadDefault();

            _saveSourceFileDialog = new SaveFileDialog
            {
                CheckPathExists = true,
                AddExtension = true,
                Filter = "Файл ЭСРН (*.csv)|*.csv",
                DefaultExt = "csv"
            };
            _openSourceFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Файл ЭСРН (*.csv)|*.csv"
            };

            _openImportedFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
            };

            PopulateModules();
            InitializeEventHandlers();
            BindDataGrid();
        }

        private void PopulateModules()
        {
            _openImportedFileDialog.Filter = String.Join("|",
                _importModules.Select(item => GetFilterStringForFileDialog(item.SupportedFileExtensions.ToArray())));
        }

        private void InitializeEventHandlers()
        {
            openMenuItem.Click += OpenMenuItem_Click;
            openFileTool.Click += OpenMenuItem_Click;

            saveMenuItem.Click += SaveMenuItem_Click;
            saveFileTool.Click += SaveMenuItem_Click;

            openFileImportMenuItem.Click += OpenFileImportMenuItem_Click;
            openFileImportTool.Click += OpenFileImportMenuItem_Click;

            settingsMenuItem.Click += SettingsMenuItem_Click;
            settingsImportTool.Click += SettingsMenuItem_Click;

            injectMenuItem1.Click += InjectImportTool1_Click;
            injectImportTool1.Click += InjectImportTool1_Click;
            injectMenuItem2.Click += InjectImportTool2_Click;
            injectImportTool2.Click += InjectImportTool2_Click;

            importLogMenuItem.Click += ImportLogMenuItem_Click;
            sourceGotoLineMenuItem.Click += SourceGotoLineMenuItem_Click;
            importedGotoLineMenuItem.Click += ImportedGotoLineMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            aboutMenuItem.Click += AboutMenuItem_Click;

            gridSource.DataSourceChanged += delegate { labelSource.Text = $"Источник: (Строк: {gridSource.RowCount})"; };
            //gridImported.RowPostPaint += ImportGrid_RowPostPaint;
            gridImported.DataSourceChanged += delegate { labelImported.Text = $"Импортируемый файл: (Строк: {gridImported.RowCount})"; };
        }

        private void BindDataGrid()
        {
            gridSource.AutoGenerateColumns = false;
            gridSource.Columns.AddRange(
                new DataGridViewTextBoxColumn { HeaderText = "FAMIL", DataPropertyName = "Famil", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "IMJA", DataPropertyName = "Imja", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "OTCH", DataPropertyName = "Otch", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "DROG", DataPropertyName = "Drog", Width = 90, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "POSEL", DataPropertyName = "Posel", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "NASP", DataPropertyName = "Nasp", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "YLIC", DataPropertyName = "Ylic", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "NDOM", DataPropertyName = "Ndom", Width = 70, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "NKORP", DataPropertyName = "Nkorp", Width = 70, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "NKW", DataPropertyName = "Nkw", Width = 70, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "NKOMN", DataPropertyName = "Nkomn", Width = 70, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "ILCHET", DataPropertyName = "IlChet", Width = 90, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "ILCHET_NEW", DataPropertyName = "IlChetNew", Width = 90 },
                new DataGridViewTextBoxColumn { HeaderText = "VIDGF", DataPropertyName = "VidGf", Width = 160, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "OPL", DataPropertyName = "Opl", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "OTPL", DataPropertyName = "Otpl", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "KOLZR", DataPropertyName = "KolZr", Width = 50 },
                new DataGridViewTextBoxColumn { HeaderText = "GKU", DataPropertyName = "Gku", Width = 160, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "ORG", DataPropertyName = "Org", Width = 160, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "VIDTAR", DataPropertyName = "VidTar", Width = 50 },
                new DataGridViewTextBoxColumn { HeaderText = "TARIF", DataPropertyName = "Tarif", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "FAKT", DataPropertyName = "Fakt", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "SUMTAR", DataPropertyName = "SumTar", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "SUMDOLG", DataPropertyName = "SumDolg", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "OPLDOLG", DataPropertyName = "OplDolg", Width = 70 },
                new DataGridViewTextBoxColumn { HeaderText = "DATDOLG", DataPropertyName = "DatDolg", Width = 90 },
                new DataGridViewTextBoxColumn { HeaderText = "MONTH", DataPropertyName = "Month", Width = 70, ReadOnly = true },
                new DataGridViewTextBoxColumn { HeaderText = "YEAR", DataPropertyName = "Year", Width = 70, ReadOnly = true }
            );

            gridSource.DataSource = _matchingManager.SourceData;
            gridImported.DataSource = _matchingManager.ImportedData;
        }

        private void BindImportDataGrid()
        {
            gridImported.AutoGenerateColumns = false;
            gridImported.Columns.Clear();

            foreach (var mapItem in _settings.Mapping.GetActiveItems())
            {
                gridImported.Columns.Add(
                    new DataGridViewTextBoxColumn { HeaderText = mapItem.ImportFieldName, DataPropertyName = mapItem.Name }
                );
            }

            //importGrid.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    HeaderText = "Ошибка",
            //    DataPropertyName = "StateMessage",
            //    Width = 600,
            //    ReadOnly = true
            //});
        }

        private void OpenSourceFile()
        {
            if (_openSourceFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var fileManager = new CsvFileManager(_logger);

                var items = fileManager.LoadDataItems(_openSourceFileDialog.FileName);

                gridSource.SuspendLayout();
                _matchingManager.SourceData.Clear();
                _matchingManager.SourceMatchedData.Clear();

                foreach (var item in items)
                    _matchingManager.SourceData.Add(item);
                
                gridSource.ResumeLayout();
                fileNameStatusLabel.Text = Path.GetFileName(_openSourceFileDialog.FileName);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error opening file {_openSourceFileDialog.FileName}", ex);
                MessageBox.Show($"Ошибка открытия файла {_openSourceFileDialog.FileName}.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSourceFile()
        {
            if (!_matchingManager.SourceMatchedData.Any())
            {
                MessageBox.Show("Отсутствуют данные для сохранения.", "XDataConv", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!String.IsNullOrEmpty(_openSourceFileDialog.FileName))
                _saveSourceFileDialog.InitialDirectory = Path.GetDirectoryName(_openSourceFileDialog.FileName);

            if (_saveSourceFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var fileManager = new CsvFileManager(_logger);

                fileManager.WriteToFile(_saveSourceFileDialog.FileName, _matchingManager.SourceMatchedData);

                MessageBox.Show($"Данные сохранены в файл {_saveSourceFileDialog.FileName}.", "XDataConv",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error writing file {_saveSourceFileDialog.FileName}", ex);
                MessageBox.Show($"Ошибка сохранения файла {_saveSourceFileDialog.FileName}.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenImportedFile()
        {
            if (_openImportedFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (ShowSettingsDialog() != DialogResult.OK)
                return;

            try
            {
                // selecting module for import by file extension
                _logger.Info("Opening file for import. Trying find a situable module by file extension...");

                var fileExtension = Path.GetExtension(_openImportedFileDialog.FileName);
                var module = _importModules
                    .First(item => item.SupportedFileExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase));

                if (module == null)
                {
                    _logger.Info($"Situable module not found for '{fileExtension}' extension.");
                    MessageBox.Show("Не найден подходящий модуль для открытия данного типа файла.", "XDataConv",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var items = module.LoadDataItems(_settings.Mapping, _openImportedFileDialog.FileName);

                gridImported.SuspendLayout();
                _matchingManager.ImportedData.Clear();
                _matchingManager.ImportedMatchedData.Clear();

                foreach (var item in items)
                    _matchingManager.ImportedData.Add(item);

                BindImportDataGrid();
                gridSource.ResumeLayout();

                importFileNameStatusLabel.Text = _openImportedFileDialog.FileName;

                //importErrorLabel.Text = data.Count(item => item.State == DataItemState.ImportError).ToString();
                //injectNotFoundLabel.Text = "0";
                //injectAmbiguousLabel.Text = "0";

                MessageBox.Show($"Импорт файла {_openImportedFileDialog.FileName} завершен.", "XDataConv",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error import file {_openImportedFileDialog.FileName}", ex);
                MessageBox.Show($"Ошибка импорта файла {_openImportedFileDialog.FileName}.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InjectData(int methodNumber)
        {
            try
            {
                gridSource.SuspendLayout();
                gridImported.SuspendLayout();

                if (methodNumber == 1)
                    _matchingManager.InjectDataByIdentify1();
                else
                    _matchingManager.InjectDataByIdentify2();

                //var data = Core.Core.Instance.Store.ImportedData;
                //injectNotFoundLabel.Text = data.Count(item => item.State == DataItemState.InjectNotFound).ToString();
                //injectAmbiguousLabel.Text = data.Count(item => item.State == DataItemState.InjectAmbigous).ToString();
                //gridSource.Invalidate();
                //gridImported.Invalidate();

                gridSource.ResumeLayout(true);
                gridImported.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error matching file. Method number is {methodNumber}.", ex);
                MessageBox.Show($"Ошибка операции переноса данных.\r\n{ex.Message}",
                    "XDataConv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GotoLineNumber(DataGridView grid)
        {
            var form = new GotoLineNumberForm();

            if (form.ShowDialog() != DialogResult.OK)
                return;

            bool isFound = false;

            foreach (DataGridViewRow row in grid.Rows)
            {
                var item = (DataItem)row.DataBoundItem;

                if (item.RowId != form.LineNumber)
                    continue;

                isFound = true;

                grid.FirstDisplayedScrollingRowIndex = row.Index;
                grid.CurrentCell = row.Cells[0];
                break;
            }

            if (!isFound)
                MessageBox.Show($"Строка с номером '{form.LineNumber}' отсутствует в списке.", "XDataConv",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult ShowSettingsDialog()
        {
            var settings = (Settings) _settings.Clone();
            var mapSettingsForm = new MapSettingsForm(_logger, settings);
            var result = mapSettingsForm.ShowDialog();

            if (result == DialogResult.OK)
                _settings = mapSettingsForm.CurrentSettings;

            return result;
        }

        private void ShowAboutDialog()
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private string GetFilterStringForFileDialog(string[] fileExtensions)
        {
            if (fileExtensions == null || fileExtensions.Length == 0)
                return null;

            return String.Concat(String.Join(", ", fileExtensions.Select(item => "*." + item)), "|",
                String.Join(";", fileExtensions.Select(item => "*." + item)));
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenSourceFile();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveSourceFile();
        }

        private void OpenFileImportMenuItem_Click(object sender, EventArgs e)
        {
            OpenImportedFile();
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettingsDialog();
        }

        private void ImportLogMenuItem_Click(object sender, EventArgs e)
        {
            //Core.Core.Instance.ShowImportLog();
        }

        private void SourceGotoLineMenuItem_Click(object sender, EventArgs e)
        {
            if (_matchingManager.SourceData.Any())
                GotoLineNumber(gridSource);
        }

        private void ImportedGotoLineMenuItem_Click(object sender, EventArgs e)
        {
            if (_matchingManager.ImportedData.Any())
                GotoLineNumber(gridImported);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InjectImportTool1_Click(object sender, EventArgs e)
        {
            InjectData(1);
        }

        private void InjectImportTool2_Click(object sender, EventArgs e)
        {
            InjectData(2);
        }

        private void filterTool_Click(object sender, EventArgs e)
        {
            //if (Core.Core.Instance.Store.Data == null)
            //{
            //    Core.Core.Instance.ShowMessage("Файл источника не загружен.");
            //    return;
            //}

            //if (filterTool.Checked)
            //{
            //    if (Core.Core.Instance.ShowQuestion("Отключить фильтрацию и отобразить все строки?") != DialogResult.Yes)
            //        return;

            //    gridSource.DataSource = Core.Core.Instance.Store.Data;
            //    filterTool.Checked = !filterTool.Checked;
            //}
            //else
            //{
            //    if (Core.Core.Instance.ShowQuestion("Будут отображены только те строки, в которые не были загружены сведения в соответствии с настройкой \"Копировать в источник\". \r\n Продолжить?") != DialogResult.Yes)
            //        return;

            //    gridSource.DataSource = Core.Core.Instance.GetUnassignedRows();
            //    filterTool.Checked = !filterTool.Checked;
            //}
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        //private void ImportGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    var item = (DataItem)gridImported.Rows[e.RowIndex].DataBoundItem;
        //    var style = gridImported.Rows[e.RowIndex].DefaultCellStyle;

        //    switch (item.State)
        //    {
        //        case DataItemState.None:
        //            style.BackColor = gridImported.DefaultCellStyle.BackColor;
        //            break;
        //        case DataItemState.ImportError:
        //            style.BackColor = Color.Red;
        //            break;
        //        case DataItemState.InjectNotFound:
        //            style.BackColor = Color.Yellow;
        //            break;
        //        case DataItemState.InjectAmbigous:
        //            style.BackColor = Color.Orange;
        //            break;
        //    }
        //}
    }
}

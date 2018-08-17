using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Schukin.XDataConv.Data;

namespace Schukin.XDataConv.Core
{
    public partial class AppForm : Form
    {
        private readonly SaveFileDialog _saveStoreDialog;
        private readonly OpenFileDialog _openStoreDialog;
        private readonly OpenFileDialog _openFileImportDialog;
        private string _currentFileName;
        private string _currentImportFileName;

        public AppForm()
        {
            InitializeComponent();

            _saveStoreDialog = new SaveFileDialog
            {
                CheckPathExists = true,
                AddExtension = true,
                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv",
                DefaultExt = "csv"
            };
            _openStoreDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Текстовые файлы с разделителем (*.csv)|*.csv"
            };

            _openFileImportDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Файлы Microsoft Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            };

            openMenuItem.Click += OpenMenuItem_Click;
            openFileTool.Click += OpenMenuItem_Click;

            saveMenuItem.Click += SaveMenuItem_Click;
            saveFileTool.Click += SaveMenuItem_Click;

            saveAsMenuItem.Click += SaveAsMenuItem_Click;

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
            importGotoLineMenuItem.Click += ImportGotoLineMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            aboutMenuItem.Click += AboutMenuItem_Click;

            mainGrid.DataSourceChanged += delegate { labelSource.Text = $"Источник: (Строк: {mainGrid.RowCount})"; };
            importGrid.RowPostPaint += ImportGrid_RowPostPaint;
            importGrid.DataSourceChanged += delegate { labelImport.Text = $"Импортируемый файл: (Строк: {importGrid.RowCount})"; };

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            mainGrid.AutoGenerateColumns = false;
            mainGrid.Columns.AddRange(
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
        }

        private void BindImportDataGrid()
        {
            importGrid.AutoGenerateColumns = false;
            importGrid.Columns.Clear();

            foreach (var mapItem in Core.Instance.MapSettings.Mapping.GetActiveItems())
            {
                importGrid.Columns.Add(
                    new DataGridViewTextBoxColumn { HeaderText = mapItem.ImportFieldName, DataPropertyName = mapItem.Name }
                );
            }

            importGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ошибка",
                DataPropertyName = "StateMessage",
                Width = 600,
                ReadOnly = true
            });
        }

        private void OpenFile()
        {
            if (_openStoreDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Core.Instance.Store.Open(_openStoreDialog.FileName);

                mainGrid.DataSource = Core.Instance.Store.Data;
                _currentFileName = _openStoreDialog.FileName;
                fileNameStatusLabel.Text = Path.GetFileName(_currentFileName);
            }
            catch (Exception e)
            {
                Core.Instance.ShowError(e);
            }
        }

        private void SaveFile()
        {
            if (Core.Instance.Store.Data == null)
                return;

            try
            {
                if (Core.Instance.Store.CurrentFileName != null)
                {
                    Core.Instance.Store.Save();

                    Core.Instance.ShowMessage("Сохранение завершено.");
                }
                else
                    SaveFileAs();
            }
            catch (Exception e)
            {
                Core.Instance.ShowError(e);
            }
        }

        private void SaveFileAs()
        {
            if (_saveStoreDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Core.Instance.Store.Save(_saveStoreDialog.FileName);

                _currentFileName = _saveStoreDialog.FileName;
                fileNameStatusLabel.Text = Path.GetFileName(_currentFileName);
                Core.Instance.ShowMessage("Сохранение завершено.");
            }
            catch (Exception e)
            {
                Core.Instance.ShowError(e);
            }
        }

        private void OpenFileImport()
        {
            if (_openFileImportDialog.ShowDialog() != DialogResult.OK)
                return;

            if (ShowMapSettingsForm() != DialogResult.OK)
                return;

            try
            {
                importGrid.DataSource = null;
                Core.Instance.OpenFileImport(_openFileImportDialog.FileName);

                var data = Core.Instance.Store.ImportedData;

                if (data == null)
                    return;

                importGrid.DataSource = data;
                _currentImportFileName = _openFileImportDialog.FileName;
                importFileNameStatusLabel.Text = _currentImportFileName;
                importFileNameStatusLabel.ToolTipText = _currentImportFileName;

                BindImportDataGrid();

                importErrorLabel.Text = data.Count(item => item.State == DataItemState.ImportError).ToString();
                injectNotFoundLabel.Text = "0";
                injectAmbigousLabel.Text = "0";

                Core.Instance.ShowMessage("Импорт завершен.");
            }
            catch (Exception e)
            {
                Core.Instance.ShowError(e);
            }
        }

        private void InjectData(int id)
        {
            try
            {
                var desination = mainGrid.DataSource as SortableBindingList<DataItem>;
                
                if (id == 1)
                    Core.Instance.InjectDataByIdentify1(desination);
                else
                    Core.Instance.InjectDataByIdentify2(desination);

                var data = Core.Instance.Store.ImportedData;
                injectNotFoundLabel.Text = data.Count(item => item.State == DataItemState.InjectNotFound).ToString();
                injectAmbigousLabel.Text = data.Count(item => item.State == DataItemState.InjectAmbigous).ToString();
                mainGrid.Invalidate();
                importGrid.Invalidate();
            }
            catch (Exception e)
            {
                Core.Instance.ShowError(e);
            }
        }

        private void GotoLineNumber(DataGridView grid)
        {
            var form = new GotoLineNumberForm();

            if (form.ShowDialog() != DialogResult.OK)
                return;

            if (form.LineNumber <= 0)
            {
                Core.Instance.ShowMessage("Неверный номер строки.");
                return;
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                var item = (DataItem)row.DataBoundItem;

                if (item.LineNumber != form.LineNumber)
                    continue;

                grid.FirstDisplayedScrollingRowIndex = row.Index;
                grid.CurrentCell = row.Cells[0];
                break;
            }
        }

        private DialogResult ShowMapSettingsForm()
        {
            var settings = (MapSettings) Core.Instance.MapSettings.Clone();
            var mapSettingsForm = new MapSettingsForm(settings);

            var result = mapSettingsForm.ShowDialog();

            if (result == DialogResult.OK)
                Core.Instance.MapSettings = mapSettingsForm.CurrentMapSettings;

            return result;
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void OpenFileImportMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileImport();
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            ShowMapSettingsForm();
        }

        private void ImportLogMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowImportLog();
        }

        private void SourceGotoLineMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.Store.Data == null)
                return;

            GotoLineNumber(mainGrid);
        }

        private void ImportGotoLineMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.Store.ImportedData == null)
                return;

            GotoLineNumber(importGrid);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ExitApplication();
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
            if (Core.Instance.Store.Data == null)
            {
                Core.Instance.ShowMessage("Файл источника не загружен.");
                return;
            }

            if (filterTool.Checked)
            {
                if (Core.Instance.ShowQuestion("Отключить фильтрацию и отобразить все строки?") != DialogResult.Yes)
                    return;

                mainGrid.DataSource = Core.Instance.Store.Data;
                filterTool.Checked = !filterTool.Checked;
            }
            else
            {
                if (Core.Instance.ShowQuestion("Будут отображены только те строки, в которые не были загружены сведения в соответствии с настройкой \"Копировать в источник\". \r\n Продолжить?") != DialogResult.Yes)
                    return;

                mainGrid.DataSource = Core.Instance.GetUnassignedRows();
                filterTool.Checked = !filterTool.Checked;
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowAboutDialog();
        }

        private void ImportGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var item = (DataItem)importGrid.Rows[e.RowIndex].DataBoundItem;
            var style = importGrid.Rows[e.RowIndex].DefaultCellStyle;

            switch (item.State)
            {
                case DataItemState.None:
                    style.BackColor = importGrid.DefaultCellStyle.BackColor;
                    break;
                case DataItemState.ImportError:
                    style.BackColor = Color.Red;
                    break;
                case DataItemState.InjectNotFound:
                    style.BackColor = Color.Yellow;
                    break;
                case DataItemState.InjectAmbigous:
                    style.BackColor = Color.Orange;
                    break;
            }
        }
    }
}

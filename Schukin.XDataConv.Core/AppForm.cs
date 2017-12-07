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
        public AppForm()
        {
            InitializeComponent();

            openMenuItem.Click += OpenMenuItem_Click;
            openFileTool.Click += OpenMenuItem_Click;

            saveMenuItem.Click += SaveMenuItem_Click;
            saveFileTool.Click += SaveMenuItem_Click;

            saveAsMenuItem.Click += SaveAsMenuItem_Click;

            openFileImportMenuItem.Click += OpenFileImportMenuItem_Click;
            openFileImportTool.Click += OpenFileImportMenuItem_Click;

            settingsMenuItem.Click += SettingsMenuItem_Click;
            settingsImportTool.Click += SettingsMenuItem_Click;

            gotoNextErrorMenuItem.Click += GotoNextErrorMenuItem_Click;
            gotoNextErrorImportTool.Click += GotoNextErrorMenuItem_Click;
            injectMenuItem.Click += InjectImportTool_Click;
            injectImportTool.Click += InjectImportTool_Click;

            importLogMenuItem.Click += ImportLogMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            aboutMenuItem.Click += AboutMenuItem_Click;

            importGrid.RowPostPaint += ImportGrid_RowPostPaint;
            importGrid.CellClick += ImportGrid_CellClick;

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            mainGrid.AutoGenerateColumns = false;
            mainGrid.DataSource = mainSource;
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
            importGrid.DataSource = importSource;
            importGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Ошибки",
                Text = "...",
                Width = 50,
                UseColumnTextForButtonValue = true
            });

            foreach (var mapItem in Core.Instance.Mapping.GetActiveItems())
            {
                importGrid.Columns.Add(
                    new DataGridViewTextBoxColumn { HeaderText = mapItem.FieldName, DataPropertyName = mapItem.Name }
                );
            }
        }

        private void OpenFileImport()
        {
            importSource.DataSource = null;
            Core.Instance.OpenFileImport();

            var data = Core.Instance.Store.ImportedData;

            if (data == null)
                return;

            importSource.DataSource = data;
            importFileNameStatusLabel.Text = Core.Instance.CurrentImportFileName;
            importFileNameStatusLabel.ToolTipText = Core.Instance.CurrentImportFileName;
            BindImportDataGrid();
            var dataItems = data as DataItem[] ?? data.ToArray();
            importStatusLabel.Text = dataItems.Any(item => item.IsError) ? $"Есть ошибки: {dataItems.Count(item => item.IsError)}" : "Нет ошибок";

            Core.Instance.ShowMessage("Импорт завершен.");
        }

        private int FindNextErrorImportRowIndex()
        {
            var rowsCount = importGrid.Rows.Count;

            if (rowsCount == 0)
                return -1;

            var startIndex = importGrid.CurrentRow?.Index ?? 0;
            var currentIndex = startIndex;

            do
            {
                var dataItem = (DataItem)importGrid.Rows[currentIndex].DataBoundItem;

                if (dataItem.IsError)
                    return currentIndex;

                if (currentIndex == rowsCount - 1)
                    currentIndex = 0;

                currentIndex++;
            } while (currentIndex != startIndex);

            return -1;
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.OpenStore();

            var data = Core.Instance.Store.Data;

            if (data == null)
                return;

            mainSource.DataSource = data;
            fileNameStatusLabel.Text = Path.GetFileName(Core.Instance.CurrentFileName);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.SaveStore())
                Core.Instance.ShowMessage("Сохранение завершено.");
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.SaveStoreAs())
            {
                fileNameStatusLabel.Text = Path.GetFileName(Core.Instance.CurrentFileName);
                Core.Instance.ShowMessage("Сохранение завершено.");
            }
        }

        private void OpenFileImportMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileImport();
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowMappingForm();
        }

        private void ImportLogMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowImportLog();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ExitApplication();
        }

        private void GotoNextErrorMenuItem_Click(object sender, EventArgs e)
        {
            var foundIndex = FindNextErrorImportRowIndex();

            if (foundIndex == -1)
            {
                Core.Instance.ShowMessage("Ошибки отсутствуют.");
                return;
            }

            importGrid.CurrentCell = importGrid.Rows[foundIndex].Cells[0];
            importGrid.FirstDisplayedScrollingRowIndex = foundIndex;
        }

        private void InjectImportTool_Click(object sender, EventArgs e)
        {
            Core.Instance.InjectData();
        }


        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowAboutDialog();
        }

        private void ImportGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataItem item = (DataItem)importGrid.Rows[e.RowIndex].DataBoundItem;

            if (item.IsError)
            {
                var style = importGrid.Rows[e.RowIndex].DefaultCellStyle;
                style.BackColor = Color.Red;
            }
        }

        private void ImportGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;

            if (!(importGrid.Rows[e.RowIndex].DataBoundItem is DataItem item))
                return;

            Core.Instance.ShowMessage(item.IsError ? item.ErrorMessage : "Ошибок не найдено.");
        }
    }
}

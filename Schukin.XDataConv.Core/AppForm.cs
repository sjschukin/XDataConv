using System;
using System.Windows.Forms;

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

            importLogMenuItem.Click += ImportLogMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;
            aboutMenuItem.Click += AboutMenuItem_Click;

            BindDataGrid();
        }

        private void BindDataGrid()
        {
            mainGrid.AutoGenerateColumns = false;
            mainGrid.DataSource = mainSource;
            mainGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn {HeaderText = "FAMIL", DataPropertyName = "Famil", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "IMJA", DataPropertyName = "Imja", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "OTCH", DataPropertyName = "Otch", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "DROG", DataPropertyName = "Drog", Width = 90, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "POSEL", DataPropertyName = "Posel", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "NASP", DataPropertyName = "Nasp", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "YLIC", DataPropertyName = "Ylic", Width = 120, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "NDOM", DataPropertyName = "Ndom", Width = 70, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "NKORP", DataPropertyName = "Nkorp", Width = 70, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "NKW", DataPropertyName = "Nkw", Width = 70, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "NKOMN", DataPropertyName = "Nkomn", Width = 70, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "ILCHET", DataPropertyName = "IlChet", Width = 90, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "VIDGF", DataPropertyName = "VidGf", Width = 160, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "OPL", DataPropertyName = "Opl", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "OTPL", DataPropertyName = "Otpl", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "KOLZR", DataPropertyName = "KolZr", Width = 50},
                new DataGridViewTextBoxColumn {HeaderText = "GKU", DataPropertyName = "Gku", Width = 160, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "ORG", DataPropertyName = "Org", Width = 160, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "VIDTAR", DataPropertyName = "VidTar", Width = 50},
                new DataGridViewTextBoxColumn {HeaderText = "TARIF", DataPropertyName = "Tarif", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "FAKT", DataPropertyName = "Fakt", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "SUMTAR", DataPropertyName = "SumTar", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "SUMDOLG", DataPropertyName = "SumDolg", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "OPLDOLG", DataPropertyName = "OplDolg", Width = 70},
                new DataGridViewTextBoxColumn {HeaderText = "DATDOLG", DataPropertyName = "DatDolg", Width = 90},
                new DataGridViewTextBoxColumn {HeaderText = "MONTH", DataPropertyName = "Month", Width = 70, ReadOnly = true},
                new DataGridViewTextBoxColumn {HeaderText = "YEAR", DataPropertyName = "Year", Width = 70, ReadOnly = true}
            );
        }

        private void BindImportDataGrid()
        {
            importGrid.AutoGenerateColumns = false;
            importGrid.Columns.Clear();
            importGrid.DataSource = importSource;

            foreach (var mapItem in Core.Instance.Mapping.GetActiveItems())
            {
                importGrid.Columns.Add(
                    new DataGridViewTextBoxColumn {HeaderText = mapItem.FieldName, DataPropertyName = mapItem.Name}
                );
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.OpenStore();
            mainSource.DataSource = Core.Instance.Store.Data;
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.SaveStore())
                Core.Instance.ShowMessage("Сохранение завершено.");
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (Core.Instance.SaveStoreAs())
                Core.Instance.ShowMessage("Сохранение завершено.");
        }

        private void OpenFileImportMenuItem_Click(object sender, EventArgs e)
        {
            importSource.DataSource = null;
            Core.Instance.OpenFileImport();
            BindImportDataGrid();
            importSource.DataSource = Core.Instance.Store.ImportedData;
            Core.Instance.ShowMessage("Импорт завершен.");
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

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Core.Instance.ShowAboutDialog();
        }
    }
}

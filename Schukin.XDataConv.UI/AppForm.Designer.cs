namespace Schukin.XDataConv.UI
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportedOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSourceEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSourceGotoLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportedEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportedGotoLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusBarMain = new System.Windows.Forms.StatusStrip();
            this.importFileNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gridSource = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabSource = new System.Windows.Forms.TabControl();
            this.tbSource = new System.Windows.Forms.TabPage();
            this.tsSource = new System.Windows.Forms.ToolStrip();
            this.tbSourceMatched = new System.Windows.Forms.TabPage();
            this.gridSourceMatched = new System.Windows.Forms.DataGridView();
            this.tsSourceImported = new System.Windows.Forms.ToolStrip();
            this.labelSource = new System.Windows.Forms.Label();
            this.tabImported = new System.Windows.Forms.TabControl();
            this.tbImported = new System.Windows.Forms.TabPage();
            this.gridImported = new System.Windows.Forms.DataGridView();
            this.tsImported = new System.Windows.Forms.ToolStrip();
            this.tbImportedMatched = new System.Windows.Forms.TabPage();
            this.gridImportedMatched = new System.Windows.Forms.DataGridView();
            this.labelImported = new System.Windows.Forms.Label();
            this.tssImported1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSourceOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSourceSave = new System.Windows.Forms.ToolStripButton();
            this.tbSourceMatchedSave = new System.Windows.Forms.ToolStripButton();
            this.tbImportedOpen = new System.Windows.Forms.ToolStripButton();
            this.tbImportedSave = new System.Windows.Forms.ToolStripButton();
            this.tbImportedShowErrors = new System.Windows.Forms.ToolStripButton();
            this.tbSettings = new System.Windows.Forms.ToolStripButton();
            this.tbPerformMatching1 = new System.Windows.Forms.ToolStripButton();
            this.tbPerformMatching2 = new System.Windows.Forms.ToolStripButton();
            this.tbFilter = new System.Windows.Forms.ToolStripButton();
            this.mnuSourceOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSourceMatchedSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerformMatching1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerformMatching2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.statusBarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.tbSource.SuspendLayout();
            this.tsSource.SuspendLayout();
            this.tbSourceMatched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSourceMatched)).BeginInit();
            this.tsSourceImported.SuspendLayout();
            this.tabImported.SuspendLayout();
            this.tbImported.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImported)).BeginInit();
            this.tsImported.SuspendLayout();
            this.tbImportedMatched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImportedMatched)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(832, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSourceOpen,
            this.mnuSourceMatchedSave,
            this.toolStripSeparator2,
            this.mnuSettings,
            this.mnuPerformMatching1,
            this.mnuPerformMatching2,
            this.importLogMenuItem,
            this.toolStripSeparator3,
            this.mnuImportedOpen,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 20);
            this.mnuFile.Text = "&Файл";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // importLogMenuItem
            // 
            this.importLogMenuItem.Name = "importLogMenuItem";
            this.importLogMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.importLogMenuItem.Size = new System.Drawing.Size(239, 22);
            this.importLogMenuItem.Text = "П&ротокол импорта";
            this.importLogMenuItem.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(236, 6);
            // 
            // mnuImportedOpen
            // 
            this.mnuImportedOpen.Name = "mnuImportedOpen";
            this.mnuImportedOpen.Size = new System.Drawing.Size(239, 22);
            this.mnuImportedOpen.Text = "&Загрузить файл поставщика...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(239, 22);
            this.mnuExit.Text = "Вы&ход";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSourceEdit,
            this.mnuImportedEdit});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(59, 20);
            this.mnuEdit.Text = "&Правка";
            // 
            // mnuSourceEdit
            // 
            this.mnuSourceEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSourceGotoLine});
            this.mnuSourceEdit.Name = "mnuSourceEdit";
            this.mnuSourceEdit.Size = new System.Drawing.Size(201, 22);
            this.mnuSourceEdit.Text = "И&сточник";
            // 
            // mnuSourceGotoLine
            // 
            this.mnuSourceGotoLine.Name = "mnuSourceGotoLine";
            this.mnuSourceGotoLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.mnuSourceGotoLine.Size = new System.Drawing.Size(225, 22);
            this.mnuSourceGotoLine.Text = "&Перейти к строке...";
            // 
            // mnuImportedEdit
            // 
            this.mnuImportedEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportedGotoLine});
            this.mnuImportedEdit.Name = "mnuImportedEdit";
            this.mnuImportedEdit.Size = new System.Drawing.Size(201, 22);
            this.mnuImportedEdit.Text = "И&мпортируемый файл";
            // 
            // mnuImportedGotoLine
            // 
            this.mnuImportedGotoLine.Name = "mnuImportedGotoLine";
            this.mnuImportedGotoLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.mnuImportedGotoLine.Size = new System.Drawing.Size(225, 22);
            this.mnuImportedGotoLine.Text = "&Перейти к строке...";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(65, 20);
            this.mnuHelp.Text = "&Справка";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(158, 22);
            this.mnuAbout.Text = "&О программе...";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSettings,
            this.toolStripSeparator4,
            this.tbPerformMatching1,
            this.tbPerformMatching2,
            this.tbFilter});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(832, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // statusBarMain
            // 
            this.statusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFileNameStatusLabel,
            this.fileNameStatusLabel});
            this.statusBarMain.Location = new System.Drawing.Point(0, 554);
            this.statusBarMain.Name = "statusBarMain";
            this.statusBarMain.ShowItemToolTips = true;
            this.statusBarMain.Size = new System.Drawing.Size(832, 22);
            this.statusBarMain.TabIndex = 2;
            this.statusBarMain.Text = "statusStrip1";
            // 
            // importFileNameStatusLabel
            // 
            this.importFileNameStatusLabel.Name = "importFileNameStatusLabel";
            this.importFileNameStatusLabel.Size = new System.Drawing.Size(686, 17);
            this.importFileNameStatusLabel.Spring = true;
            this.importFileNameStatusLabel.Text = "Готов";
            this.importFileNameStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileNameStatusLabel
            // 
            this.fileNameStatusLabel.Name = "fileNameStatusLabel";
            this.fileNameStatusLabel.Size = new System.Drawing.Size(131, 17);
            this.fileNameStatusLabel.Text = "Источник не загружен";
            // 
            // gridSource
            // 
            this.gridSource.AllowUserToAddRows = false;
            this.gridSource.AllowUserToDeleteRows = false;
            this.gridSource.AllowUserToResizeRows = false;
            this.gridSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSource.Location = new System.Drawing.Point(3, 28);
            this.gridSource.Name = "gridSource";
            this.gridSource.Size = new System.Drawing.Size(818, 172);
            this.gridSource.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabSource);
            this.splitContainer1.Panel1.Controls.Add(this.labelSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabImported);
            this.splitContainer1.Panel2.Controls.Add(this.labelImported);
            this.splitContainer1.Size = new System.Drawing.Size(832, 505);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 4;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.tbSource);
            this.tabSource.Controls.Add(this.tbSourceMatched);
            this.tabSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSource.Location = new System.Drawing.Point(0, 23);
            this.tabSource.Name = "tabSource";
            this.tabSource.SelectedIndex = 0;
            this.tabSource.Size = new System.Drawing.Size(832, 229);
            this.tabSource.TabIndex = 4;
            // 
            // tbSource
            // 
            this.tbSource.Controls.Add(this.gridSource);
            this.tbSource.Controls.Add(this.tsSource);
            this.tbSource.Location = new System.Drawing.Point(4, 22);
            this.tbSource.Name = "tbSource";
            this.tbSource.Padding = new System.Windows.Forms.Padding(3);
            this.tbSource.Size = new System.Drawing.Size(824, 203);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "Не обработаны";
            this.tbSource.UseVisualStyleBackColor = true;
            // 
            // tsSource
            // 
            this.tsSource.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSourceOpen,
            this.tbSourceSave});
            this.tsSource.Location = new System.Drawing.Point(3, 3);
            this.tsSource.Name = "tsSource";
            this.tsSource.Size = new System.Drawing.Size(818, 25);
            this.tsSource.TabIndex = 4;
            this.tsSource.Text = "toolStrip1";
            // 
            // tbSourceMatched
            // 
            this.tbSourceMatched.Controls.Add(this.gridSourceMatched);
            this.tbSourceMatched.Controls.Add(this.tsSourceImported);
            this.tbSourceMatched.Location = new System.Drawing.Point(4, 22);
            this.tbSourceMatched.Name = "tbSourceMatched";
            this.tbSourceMatched.Padding = new System.Windows.Forms.Padding(3);
            this.tbSourceMatched.Size = new System.Drawing.Size(824, 203);
            this.tbSourceMatched.TabIndex = 1;
            this.tbSourceMatched.Text = "Обработаны";
            this.tbSourceMatched.UseVisualStyleBackColor = true;
            // 
            // gridSourceMatched
            // 
            this.gridSourceMatched.AllowUserToAddRows = false;
            this.gridSourceMatched.AllowUserToDeleteRows = false;
            this.gridSourceMatched.AllowUserToResizeRows = false;
            this.gridSourceMatched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSourceMatched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSourceMatched.Location = new System.Drawing.Point(3, 28);
            this.gridSourceMatched.Name = "gridSourceMatched";
            this.gridSourceMatched.Size = new System.Drawing.Size(818, 172);
            this.gridSourceMatched.TabIndex = 4;
            // 
            // tsSourceImported
            // 
            this.tsSourceImported.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSourceImported.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSourceMatchedSave});
            this.tsSourceImported.Location = new System.Drawing.Point(3, 3);
            this.tsSourceImported.Name = "tsSourceImported";
            this.tsSourceImported.Size = new System.Drawing.Size(818, 25);
            this.tsSourceImported.TabIndex = 5;
            this.tsSourceImported.Text = "toolStrip1";
            // 
            // labelSource
            // 
            this.labelSource.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSource.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSource.Location = new System.Drawing.Point(0, 0);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(832, 23);
            this.labelSource.TabIndex = 5;
            this.labelSource.Text = "Источник";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabImported
            // 
            this.tabImported.Controls.Add(this.tbImported);
            this.tabImported.Controls.Add(this.tbImportedMatched);
            this.tabImported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImported.Location = new System.Drawing.Point(0, 23);
            this.tabImported.Name = "tabImported";
            this.tabImported.SelectedIndex = 0;
            this.tabImported.Size = new System.Drawing.Size(832, 226);
            this.tabImported.TabIndex = 5;
            // 
            // tbImported
            // 
            this.tbImported.Controls.Add(this.gridImported);
            this.tbImported.Controls.Add(this.tsImported);
            this.tbImported.Location = new System.Drawing.Point(4, 22);
            this.tbImported.Name = "tbImported";
            this.tbImported.Padding = new System.Windows.Forms.Padding(3);
            this.tbImported.Size = new System.Drawing.Size(824, 200);
            this.tbImported.TabIndex = 0;
            this.tbImported.Text = "Нет соответствий";
            this.tbImported.UseVisualStyleBackColor = true;
            // 
            // gridImported
            // 
            this.gridImported.AllowUserToAddRows = false;
            this.gridImported.AllowUserToDeleteRows = false;
            this.gridImported.AllowUserToResizeRows = false;
            this.gridImported.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImported.Location = new System.Drawing.Point(3, 28);
            this.gridImported.Name = "gridImported";
            this.gridImported.Size = new System.Drawing.Size(818, 169);
            this.gridImported.TabIndex = 4;
            // 
            // tsImported
            // 
            this.tsImported.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsImported.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbImportedOpen,
            this.tbImportedSave,
            this.tssImported1,
            this.tbImportedShowErrors});
            this.tsImported.Location = new System.Drawing.Point(3, 3);
            this.tsImported.Name = "tsImported";
            this.tsImported.Size = new System.Drawing.Size(818, 25);
            this.tsImported.TabIndex = 2;
            this.tsImported.Text = "toolImport";
            // 
            // tbImportedMatched
            // 
            this.tbImportedMatched.Controls.Add(this.gridImportedMatched);
            this.tbImportedMatched.Location = new System.Drawing.Point(4, 22);
            this.tbImportedMatched.Name = "tbImportedMatched";
            this.tbImportedMatched.Padding = new System.Windows.Forms.Padding(3);
            this.tbImportedMatched.Size = new System.Drawing.Size(824, 200);
            this.tbImportedMatched.TabIndex = 1;
            this.tbImportedMatched.Text = "Обработаны";
            this.tbImportedMatched.UseVisualStyleBackColor = true;
            // 
            // gridImportedMatched
            // 
            this.gridImportedMatched.AllowUserToAddRows = false;
            this.gridImportedMatched.AllowUserToDeleteRows = false;
            this.gridImportedMatched.AllowUserToResizeRows = false;
            this.gridImportedMatched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImportedMatched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImportedMatched.Location = new System.Drawing.Point(3, 3);
            this.gridImportedMatched.Name = "gridImportedMatched";
            this.gridImportedMatched.Size = new System.Drawing.Size(818, 194);
            this.gridImportedMatched.TabIndex = 5;
            // 
            // labelImported
            // 
            this.labelImported.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelImported.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelImported.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelImported.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelImported.Location = new System.Drawing.Point(0, 0);
            this.labelImported.Name = "labelImported";
            this.labelImported.Size = new System.Drawing.Size(832, 23);
            this.labelImported.TabIndex = 6;
            this.labelImported.Text = "Данные поставщика";
            this.labelImported.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssImported1
            // 
            this.tssImported1.Name = "tssImported1";
            this.tssImported1.Size = new System.Drawing.Size(6, 25);
            this.tssImported1.Visible = false;
            // 
            // tbSourceOpen
            // 
            this.tbSourceOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSourceOpen.Image = global::Schukin.XDataConv.UI.Properties.Resources.Open;
            this.tbSourceOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSourceOpen.Name = "tbSourceOpen";
            this.tbSourceOpen.Size = new System.Drawing.Size(23, 22);
            this.tbSourceOpen.Text = "Открыть";
            // 
            // tbSourceSave
            // 
            this.tbSourceSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSourceSave.Image = global::Schukin.XDataConv.UI.Properties.Resources.Save;
            this.tbSourceSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSourceSave.Name = "tbSourceSave";
            this.tbSourceSave.Size = new System.Drawing.Size(23, 22);
            this.tbSourceSave.Text = "Сохранить";
            // 
            // tbSourceMatchedSave
            // 
            this.tbSourceMatchedSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSourceMatchedSave.Image = global::Schukin.XDataConv.UI.Properties.Resources.Save;
            this.tbSourceMatchedSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSourceMatchedSave.Name = "tbSourceMatchedSave";
            this.tbSourceMatchedSave.Size = new System.Drawing.Size(23, 22);
            this.tbSourceMatchedSave.Text = "Сохранить";
            // 
            // tbImportedOpen
            // 
            this.tbImportedOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbImportedOpen.Image = global::Schukin.XDataConv.UI.Properties.Resources.Open;
            this.tbImportedOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImportedOpen.Name = "tbImportedOpen";
            this.tbImportedOpen.Size = new System.Drawing.Size(23, 22);
            this.tbImportedOpen.Text = "Открыть";
            // 
            // tbImportedSave
            // 
            this.tbImportedSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbImportedSave.Image = global::Schukin.XDataConv.UI.Properties.Resources.Save;
            this.tbImportedSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImportedSave.Name = "tbImportedSave";
            this.tbImportedSave.Size = new System.Drawing.Size(23, 22);
            this.tbImportedSave.Text = "Сохранить";
            // 
            // tbImportedShowErrors
            // 
            this.tbImportedShowErrors.Image = global::Schukin.XDataConv.UI.Properties.Resources.Error;
            this.tbImportedShowErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImportedShowErrors.Name = "tbImportedShowErrors";
            this.tbImportedShowErrors.Size = new System.Drawing.Size(125, 22);
            this.tbImportedShowErrors.Text = "Ошибки импорта";
            this.tbImportedShowErrors.Visible = false;
            // 
            // tbSettings
            // 
            this.tbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSettings.Image = global::Schukin.XDataConv.UI.Properties.Resources.Settings;
            this.tbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Size = new System.Drawing.Size(23, 22);
            this.tbSettings.Text = "Параметры";
            // 
            // tbPerformMatching1
            // 
            this.tbPerformMatching1.Image = global::Schukin.XDataConv.UI.Properties.Resources.Import;
            this.tbPerformMatching1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPerformMatching1.Name = "tbPerformMatching1";
            this.tbPerformMatching1.Size = new System.Drawing.Size(152, 22);
            this.tbPerformMatching1.Text = "Перенос данных (ИД1)";
            this.tbPerformMatching1.ToolTipText = "Осуществить перенос, используя правила первичной идентификации";
            // 
            // tbPerformMatching2
            // 
            this.tbPerformMatching2.Image = global::Schukin.XDataConv.UI.Properties.Resources.Import;
            this.tbPerformMatching2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPerformMatching2.Name = "tbPerformMatching2";
            this.tbPerformMatching2.Size = new System.Drawing.Size(152, 22);
            this.tbPerformMatching2.Text = "Перенос данных (ИД2)";
            this.tbPerformMatching2.ToolTipText = "Осуществить перенос, используя правила вторичной идентификации";
            // 
            // tbFilter
            // 
            this.tbFilter.Image = global::Schukin.XDataConv.UI.Properties.Resources.Filter;
            this.tbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(68, 22);
            this.tbFilter.Text = "Фильтр";
            this.tbFilter.Visible = false;
            // 
            // mnuSourceOpen
            // 
            this.mnuSourceOpen.Image = global::Schukin.XDataConv.UI.Properties.Resources.Open;
            this.mnuSourceOpen.Name = "mnuSourceOpen";
            this.mnuSourceOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuSourceOpen.Size = new System.Drawing.Size(239, 22);
            this.mnuSourceOpen.Text = "&Открыть...";
            // 
            // mnuSourceMatchedSave
            // 
            this.mnuSourceMatchedSave.Image = global::Schukin.XDataConv.UI.Properties.Resources.Save;
            this.mnuSourceMatchedSave.Name = "mnuSourceMatchedSave";
            this.mnuSourceMatchedSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSourceMatchedSave.Size = new System.Drawing.Size(239, 22);
            this.mnuSourceMatchedSave.Text = "&Сохранить...";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::Schukin.XDataConv.UI.Properties.Resources.Settings;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(239, 22);
            this.mnuSettings.Text = "&Параметры...";
            // 
            // mnuPerformMatching1
            // 
            this.mnuPerformMatching1.Image = global::Schukin.XDataConv.UI.Properties.Resources.Import;
            this.mnuPerformMatching1.Name = "mnuPerformMatching1";
            this.mnuPerformMatching1.Size = new System.Drawing.Size(239, 22);
            this.mnuPerformMatching1.Text = "Перено&с данных (ИД1)";
            // 
            // mnuPerformMatching2
            // 
            this.mnuPerformMatching2.Image = global::Schukin.XDataConv.UI.Properties.Resources.Import;
            this.mnuPerformMatching2.Name = "mnuPerformMatching2";
            this.mnuPerformMatching2.Size = new System.Drawing.Size(239, 22);
            this.mnuPerformMatching2.Text = "Перено&с данных (ИД2)";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 576);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBarMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "AppForm";
            this.Text = "XDataConv";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.statusBarMain.ResumeLayout(false);
            this.statusBarMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.tbSource.ResumeLayout(false);
            this.tbSource.PerformLayout();
            this.tsSource.ResumeLayout(false);
            this.tsSource.PerformLayout();
            this.tbSourceMatched.ResumeLayout(false);
            this.tbSourceMatched.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSourceMatched)).EndInit();
            this.tsSourceImported.ResumeLayout(false);
            this.tsSourceImported.PerformLayout();
            this.tabImported.ResumeLayout(false);
            this.tbImported.ResumeLayout(false);
            this.tbImported.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImported)).EndInit();
            this.tsImported.ResumeLayout(false);
            this.tsImported.PerformLayout();
            this.tbImportedMatched.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridImportedMatched)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSourceOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSourceMatchedSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuImportedOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.StatusStrip statusBarMain;
        private System.Windows.Forms.DataGridView gridSource;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importLogMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridImported;
        private System.Windows.Forms.ToolStrip tsImported;
        private System.Windows.Forms.ToolStripButton tbImportedOpen;
        private System.Windows.Forms.ToolStripStatusLabel importFileNameStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fileNameStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuPerformMatching1;
        private System.Windows.Forms.ToolStripMenuItem mnuSourceEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuImportedEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuSourceGotoLine;
        private System.Windows.Forms.ToolStripMenuItem mnuImportedGotoLine;
        private System.Windows.Forms.ToolStripMenuItem mnuPerformMatching2;
        private System.Windows.Forms.ToolStripButton tbFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TabControl tabImported;
        private System.Windows.Forms.TabPage tbImported;
        private System.Windows.Forms.TabPage tbImportedMatched;
        private System.Windows.Forms.TabControl tabSource;
        private System.Windows.Forms.TabPage tbSource;
        private System.Windows.Forms.TabPage tbSourceMatched;
        private System.Windows.Forms.DataGridView gridSourceMatched;
        private System.Windows.Forms.DataGridView gridImportedMatched;
        private System.Windows.Forms.ToolStrip tsSource;
        private System.Windows.Forms.ToolStripButton tbSourceOpen;
        private System.Windows.Forms.ToolStripButton tbSourceSave;
        private System.Windows.Forms.ToolStrip tsSourceImported;
        private System.Windows.Forms.ToolStripButton tbSourceMatchedSave;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelImported;
        private System.Windows.Forms.ToolStripButton tbSettings;
        private System.Windows.Forms.ToolStripButton tbPerformMatching1;
        private System.Windows.Forms.ToolStripButton tbPerformMatching2;
        private System.Windows.Forms.ToolStripButton tbImportedSave;
        private System.Windows.Forms.ToolStripSeparator tssImported1;
        private System.Windows.Forms.ToolStripButton tbImportedShowErrors;
    }
}
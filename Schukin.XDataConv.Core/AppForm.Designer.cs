namespace Schukin.XDataConv.Core
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
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceGotoLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGotoLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTool = new System.Windows.Forms.ToolStrip();
            this.labelSource = new System.Windows.Forms.ToolStripLabel();
            this.statusBarMain = new System.Windows.Forms.StatusStrip();
            this.importFileNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.importErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.injectNotFoundLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.injectAmbigousLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainGrid = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.importGrid = new System.Windows.Forms.DataGridView();
            this.importTool = new System.Windows.Forms.ToolStrip();
            this.labelImport = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileTool = new System.Windows.Forms.ToolStripButton();
            this.saveFileTool = new System.Windows.Forms.ToolStripButton();
            this.filterTool = new System.Windows.Forms.ToolStripButton();
            this.openFileImportTool = new System.Windows.Forms.ToolStripButton();
            this.settingsImportTool = new System.Windows.Forms.ToolStripButton();
            this.injectImportTool1 = new System.Windows.Forms.ToolStripButton();
            this.injectImportTool2 = new System.Windows.Forms.ToolStripButton();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.injectMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.mainTool.SuspendLayout();
            this.statusBarMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importGrid)).BeginInit();
            this.importTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem,
            this.helpMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(832, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator2,
            this.settingsMenuItem,
            this.injectMenuItem1,
            this.injectMenuItem2,
            this.importLogMenuItem,
            this.toolStripSeparator3,
            this.openFileImportMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "&Файл";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(239, 22);
            this.saveAsMenuItem.Text = "Сохранить &как...";
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
            // openFileImportMenuItem
            // 
            this.openFileImportMenuItem.Name = "openFileImportMenuItem";
            this.openFileImportMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openFileImportMenuItem.Text = "&Загрузить файл поставщика...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(239, 22);
            this.exitMenuItem.Text = "Вы&ход";
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceEditMenuItem,
            this.importEditMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editMenuItem.Text = "&Правка";
            // 
            // sourceEditMenuItem
            // 
            this.sourceEditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceGotoLineMenuItem});
            this.sourceEditMenuItem.Name = "sourceEditMenuItem";
            this.sourceEditMenuItem.Size = new System.Drawing.Size(201, 22);
            this.sourceEditMenuItem.Text = "И&сточник";
            // 
            // sourceGotoLineMenuItem
            // 
            this.sourceGotoLineMenuItem.Name = "sourceGotoLineMenuItem";
            this.sourceGotoLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.sourceGotoLineMenuItem.Size = new System.Drawing.Size(225, 22);
            this.sourceGotoLineMenuItem.Text = "&Перейти к строке...";
            // 
            // importEditMenuItem
            // 
            this.importEditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importGotoLineMenuItem});
            this.importEditMenuItem.Name = "importEditMenuItem";
            this.importEditMenuItem.Size = new System.Drawing.Size(201, 22);
            this.importEditMenuItem.Text = "И&мпортируемый файл";
            // 
            // importGotoLineMenuItem
            // 
            this.importGotoLineMenuItem.Name = "importGotoLineMenuItem";
            this.importGotoLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.importGotoLineMenuItem.Size = new System.Drawing.Size(225, 22);
            this.importGotoLineMenuItem.Text = "&Перейти к строке...";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpMenuItem.Text = "&Справка";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutMenuItem.Text = "&О программе...";
            // 
            // mainTool
            // 
            this.mainTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileTool,
            this.saveFileTool,
            this.labelSource,
            this.toolStripSeparator4,
            this.filterTool});
            this.mainTool.Location = new System.Drawing.Point(0, 0);
            this.mainTool.Name = "mainTool";
            this.mainTool.Size = new System.Drawing.Size(832, 25);
            this.mainTool.TabIndex = 1;
            this.mainTool.Text = "toolStrip1";
            // 
            // labelSource
            // 
            this.labelSource.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(64, 22);
            this.labelSource.Text = "Источник:";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusBarMain
            // 
            this.statusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFileNameStatusLabel,
            this.importErrorLabel,
            this.injectNotFoundLabel,
            this.injectAmbigousLabel,
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
            this.importFileNameStatusLabel.Size = new System.Drawing.Size(647, 17);
            this.importFileNameStatusLabel.Spring = true;
            this.importFileNameStatusLabel.Text = "Готов";
            this.importFileNameStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // importErrorLabel
            // 
            this.importErrorLabel.BackColor = System.Drawing.Color.Red;
            this.importErrorLabel.Name = "importErrorLabel";
            this.importErrorLabel.Size = new System.Drawing.Size(13, 17);
            this.importErrorLabel.Text = "0";
            this.importErrorLabel.ToolTipText = "Количество ошибок импорта";
            // 
            // injectNotFoundLabel
            // 
            this.injectNotFoundLabel.BackColor = System.Drawing.Color.Yellow;
            this.injectNotFoundLabel.Name = "injectNotFoundLabel";
            this.injectNotFoundLabel.Size = new System.Drawing.Size(13, 17);
            this.injectNotFoundLabel.Text = "0";
            this.injectNotFoundLabel.ToolTipText = "Количество ненайденных  соответствий";
            // 
            // injectAmbigousLabel
            // 
            this.injectAmbigousLabel.BackColor = System.Drawing.Color.Orange;
            this.injectAmbigousLabel.Name = "injectAmbigousLabel";
            this.injectAmbigousLabel.Size = new System.Drawing.Size(13, 17);
            this.injectAmbigousLabel.Text = "0";
            this.injectAmbigousLabel.ToolTipText = "Количество неоднозначных соответствий";
            // 
            // fileNameStatusLabel
            // 
            this.fileNameStatusLabel.Name = "fileNameStatusLabel";
            this.fileNameStatusLabel.Size = new System.Drawing.Size(131, 17);
            this.fileNameStatusLabel.Text = "Источник не загружен";
            // 
            // mainGrid
            // 
            this.mainGrid.AllowUserToAddRows = false;
            this.mainGrid.AllowUserToDeleteRows = false;
            this.mainGrid.AllowUserToResizeRows = false;
            this.mainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGrid.Location = new System.Drawing.Point(0, 25);
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.Size = new System.Drawing.Size(832, 240);
            this.mainGrid.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainGrid);
            this.splitContainer1.Panel1.Controls.Add(this.mainTool);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.importGrid);
            this.splitContainer1.Panel2.Controls.Add(this.importTool);
            this.splitContainer1.Size = new System.Drawing.Size(832, 530);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 4;
            // 
            // importGrid
            // 
            this.importGrid.AllowUserToAddRows = false;
            this.importGrid.AllowUserToDeleteRows = false;
            this.importGrid.AllowUserToResizeRows = false;
            this.importGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.importGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importGrid.Location = new System.Drawing.Point(0, 25);
            this.importGrid.Name = "importGrid";
            this.importGrid.Size = new System.Drawing.Size(832, 236);
            this.importGrid.TabIndex = 4;
            // 
            // importTool
            // 
            this.importTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileImportTool,
            this.labelImport,
            this.settingsImportTool,
            this.toolStripSeparator5,
            this.injectImportTool1,
            this.injectImportTool2});
            this.importTool.Location = new System.Drawing.Point(0, 0);
            this.importTool.Name = "importTool";
            this.importTool.Size = new System.Drawing.Size(832, 25);
            this.importTool.TabIndex = 2;
            this.importTool.Text = "toolImport";
            // 
            // labelImport
            // 
            this.labelImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelImport.Name = "labelImport";
            this.labelImport.Size = new System.Drawing.Size(137, 22);
            this.labelImport.Text = "Импортируемый файл:";
            this.labelImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // openFileTool
            // 
            this.openFileTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileTool.Image = global::Schukin.XDataConv.Core.Properties.Resources.Open;
            this.openFileTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileTool.Name = "openFileTool";
            this.openFileTool.Size = new System.Drawing.Size(23, 22);
            this.openFileTool.Text = "Открыть файл";
            // 
            // saveFileTool
            // 
            this.saveFileTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileTool.Image = global::Schukin.XDataConv.Core.Properties.Resources.Save;
            this.saveFileTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileTool.Name = "saveFileTool";
            this.saveFileTool.Size = new System.Drawing.Size(23, 22);
            this.saveFileTool.Text = "Сохранить файл";
            // 
            // filterTool
            // 
            this.filterTool.Image = global::Schukin.XDataConv.Core.Properties.Resources.Filter;
            this.filterTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterTool.Name = "filterTool";
            this.filterTool.Size = new System.Drawing.Size(68, 22);
            this.filterTool.Text = "Фильтр";
            this.filterTool.Click += new System.EventHandler(this.filterTool_Click);
            // 
            // openFileImportTool
            // 
            this.openFileImportTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileImportTool.Image = global::Schukin.XDataConv.Core.Properties.Resources.Open;
            this.openFileImportTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileImportTool.Name = "openFileImportTool";
            this.openFileImportTool.Size = new System.Drawing.Size(23, 22);
            this.openFileImportTool.Text = "Открыть файл";
            this.openFileImportTool.ToolTipText = "Открыть файл";
            // 
            // settingsImportTool
            // 
            this.settingsImportTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsImportTool.Image = global::Schukin.XDataConv.Core.Properties.Resources.Settings;
            this.settingsImportTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsImportTool.Name = "settingsImportTool";
            this.settingsImportTool.Size = new System.Drawing.Size(23, 22);
            this.settingsImportTool.Text = "Параметры";
            // 
            // injectImportTool1
            // 
            this.injectImportTool1.Image = global::Schukin.XDataConv.Core.Properties.Resources.Import;
            this.injectImportTool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.injectImportTool1.Name = "injectImportTool1";
            this.injectImportTool1.Size = new System.Drawing.Size(152, 22);
            this.injectImportTool1.Text = "Перенос данных (ИД1)";
            this.injectImportTool1.ToolTipText = "Осуществить перенос, используя правила первичной идентификации";
            // 
            // injectImportTool2
            // 
            this.injectImportTool2.Image = global::Schukin.XDataConv.Core.Properties.Resources.Import;
            this.injectImportTool2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.injectImportTool2.Name = "injectImportTool2";
            this.injectImportTool2.Size = new System.Drawing.Size(152, 22);
            this.injectImportTool2.Text = "Перенос данных (ИД2)";
            this.injectImportTool2.ToolTipText = "Осуществить перенос, используя правила вторичной идентификации";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::Schukin.XDataConv.Core.Properties.Resources.Open;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openMenuItem.Text = "&Открыть...";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::Schukin.XDataConv.Core.Properties.Resources.Save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(239, 22);
            this.saveMenuItem.Text = "&Сохранить";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Image = global::Schukin.XDataConv.Core.Properties.Resources.Settings;
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(239, 22);
            this.settingsMenuItem.Text = "&Параметры...";
            // 
            // injectMenuItem1
            // 
            this.injectMenuItem1.Image = global::Schukin.XDataConv.Core.Properties.Resources.Import;
            this.injectMenuItem1.Name = "injectMenuItem1";
            this.injectMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.injectMenuItem1.Text = "Перено&с данных (ИД1)";
            // 
            // injectMenuItem2
            // 
            this.injectMenuItem2.Image = global::Schukin.XDataConv.Core.Properties.Resources.Import;
            this.injectMenuItem2.Name = "injectMenuItem2";
            this.injectMenuItem2.Size = new System.Drawing.Size(239, 22);
            this.injectMenuItem2.Text = "Перено&с данных (ИД2)";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 576);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBarMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "AppForm";
            this.Text = "XDataConv";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.mainTool.ResumeLayout(false);
            this.mainTool.PerformLayout();
            this.statusBarMain.ResumeLayout(false);
            this.statusBarMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.importGrid)).EndInit();
            this.importTool.ResumeLayout(false);
            this.importTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openFileImportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStrip mainTool;
        private System.Windows.Forms.StatusStrip statusBarMain;
        private System.Windows.Forms.DataGridView mainGrid;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importLogMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView importGrid;
        private System.Windows.Forms.ToolStrip importTool;
        private System.Windows.Forms.ToolStripLabel labelSource;
        private System.Windows.Forms.ToolStripLabel labelImport;
        private System.Windows.Forms.ToolStripButton openFileImportTool;
        private System.Windows.Forms.ToolStripButton openFileTool;
        private System.Windows.Forms.ToolStripButton saveFileTool;
        private System.Windows.Forms.ToolStripButton injectImportTool1;
        private System.Windows.Forms.ToolStripButton settingsImportTool;
        private System.Windows.Forms.ToolStripStatusLabel importFileNameStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel importErrorLabel;
        private System.Windows.Forms.ToolStripStatusLabel fileNameStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem injectMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel injectNotFoundLabel;
        private System.Windows.Forms.ToolStripStatusLabel injectAmbigousLabel;
        private System.Windows.Forms.ToolStripMenuItem sourceEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceGotoLineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGotoLineMenuItem;
        private System.Windows.Forms.ToolStripButton injectImportTool2;
        private System.Windows.Forms.ToolStripMenuItem injectMenuItem2;
        private System.Windows.Forms.ToolStripButton filterTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}
namespace Schukin.XDataConv.UI
{
    sealed partial class MatchSettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchSettingsForm));
            this.matchGrid = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.clearAllTool = new System.Windows.Forms.ToolStripButton();
            this.openExcelTool = new System.Windows.Forms.ToolStripButton();
            this.saveExcelTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabImportedWords = new System.Windows.Forms.TabPage();
            this.gridImport = new System.Windows.Forms.DataGridView();
            this.toolStripImport = new System.Windows.Forms.ToolStrip();
            this.copyNewLineImportTool = new System.Windows.Forms.ToolStripButton();
            this.copyCellImportTool = new System.Windows.Forms.ToolStripButton();
            this.tabSourceWords = new System.Windows.Forms.TabPage();
            this.gridSource = new System.Windows.Forms.DataGridView();
            this.toolStripSource = new System.Windows.Forms.ToolStrip();
            this.copyNewLineSourceTool = new System.Windows.Forms.ToolStripButton();
            this.copyCellSourceTool = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabImportedWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).BeginInit();
            this.toolStripImport.SuspendLayout();
            this.tabSourceWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            this.toolStripSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // matchGrid
            // 
            this.matchGrid.AutoGenerateColumns = false;
            this.matchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchGrid.DataSource = this.bindingSource;
            this.matchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchGrid.Location = new System.Drawing.Point(0, 48);
            this.matchGrid.Name = "matchGrid";
            this.matchGrid.Size = new System.Drawing.Size(500, 572);
            this.matchGrid.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(897, 626);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(816, 626);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.matchGrid);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 620);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 8;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.bindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.CountItemFormat = "из {0}";
            this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllTool,
            this.openExcelTool,
            this.saveExcelTool,
            this.toolStripSeparator,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 23);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(500, 25);
            this.bindingNavigator.TabIndex = 3;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить строку";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "из {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее количество элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить строку";
            // 
            // clearAllTool
            // 
            this.clearAllTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearAllTool.Image = ((System.Drawing.Image)(resources.GetObject("clearAllTool.Image")));
            this.clearAllTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearAllTool.Name = "clearAllTool";
            this.clearAllTool.Size = new System.Drawing.Size(23, 22);
            this.clearAllTool.Text = "О&чистить";
            // 
            // openExcelTool
            // 
            this.openExcelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openExcelTool.Image = ((System.Drawing.Image)(resources.GetObject("openExcelTool.Image")));
            this.openExcelTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openExcelTool.Name = "openExcelTool";
            this.openExcelTool.Size = new System.Drawing.Size(23, 22);
            this.openExcelTool.Text = "&Импорт из Excel";
            this.openExcelTool.Visible = false;
            // 
            // saveExcelTool
            // 
            this.saveExcelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveExcelTool.Image = ((System.Drawing.Image)(resources.GetObject("saveExcelTool.Image")));
            this.saveExcelTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveExcelTool.Name = "saveExcelTool";
            this.saveExcelTool.Size = new System.Drawing.Size(23, 22);
            this.saveExcelTool.Text = "&Экспорт в Excel";
            this.saveExcelTool.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "В начало";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "В начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "В конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(500, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список соответствий:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabImportedWords);
            this.tabControl1.Controls.Add(this.tabSourceWords);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 597);
            this.tabControl1.TabIndex = 0;
            // 
            // tabImportedWords
            // 
            this.tabImportedWords.Controls.Add(this.gridImport);
            this.tabImportedWords.Controls.Add(this.toolStripImport);
            this.tabImportedWords.Location = new System.Drawing.Point(4, 22);
            this.tabImportedWords.Name = "tabImportedWords";
            this.tabImportedWords.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportedWords.Size = new System.Drawing.Size(472, 571);
            this.tabImportedWords.TabIndex = 1;
            this.tabImportedWords.Text = "Файл поставщика";
            this.tabImportedWords.UseVisualStyleBackColor = true;
            // 
            // gridImport
            // 
            this.gridImport.AllowUserToAddRows = false;
            this.gridImport.AllowUserToDeleteRows = false;
            this.gridImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImport.Location = new System.Drawing.Point(3, 28);
            this.gridImport.Name = "gridImport";
            this.gridImport.ReadOnly = true;
            this.gridImport.Size = new System.Drawing.Size(466, 540);
            this.gridImport.TabIndex = 1;
            // 
            // toolStripImport
            // 
            this.toolStripImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNewLineImportTool,
            this.copyCellImportTool});
            this.toolStripImport.Location = new System.Drawing.Point(3, 3);
            this.toolStripImport.Name = "toolStripImport";
            this.toolStripImport.Size = new System.Drawing.Size(466, 25);
            this.toolStripImport.TabIndex = 0;
            this.toolStripImport.Text = "toolStrip1";
            // 
            // copyNewLineImportTool
            // 
            this.copyNewLineImportTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyNewLineImportTool.Image = ((System.Drawing.Image)(resources.GetObject("copyNewLineImportTool.Image")));
            this.copyNewLineImportTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyNewLineImportTool.Name = "copyNewLineImportTool";
            this.copyNewLineImportTool.Size = new System.Drawing.Size(23, 22);
            this.copyNewLineImportTool.Text = "Копировать в новую строку";
            // 
            // copyCellImportTool
            // 
            this.copyCellImportTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyCellImportTool.Image = ((System.Drawing.Image)(resources.GetObject("copyCellImportTool.Image")));
            this.copyCellImportTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyCellImportTool.Name = "copyCellImportTool";
            this.copyCellImportTool.Size = new System.Drawing.Size(23, 22);
            this.copyCellImportTool.Text = "Копировать в ячейки";
            // 
            // tabSourceWords
            // 
            this.tabSourceWords.Controls.Add(this.gridSource);
            this.tabSourceWords.Controls.Add(this.toolStripSource);
            this.tabSourceWords.Location = new System.Drawing.Point(4, 22);
            this.tabSourceWords.Name = "tabSourceWords";
            this.tabSourceWords.Padding = new System.Windows.Forms.Padding(3);
            this.tabSourceWords.Size = new System.Drawing.Size(472, 571);
            this.tabSourceWords.TabIndex = 0;
            this.tabSourceWords.Text = "Исходный файл";
            this.tabSourceWords.UseVisualStyleBackColor = true;
            // 
            // gridSource
            // 
            this.gridSource.AllowUserToAddRows = false;
            this.gridSource.AllowUserToDeleteRows = false;
            this.gridSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSource.Location = new System.Drawing.Point(3, 28);
            this.gridSource.Name = "gridSource";
            this.gridSource.ReadOnly = true;
            this.gridSource.Size = new System.Drawing.Size(466, 540);
            this.gridSource.TabIndex = 1;
            // 
            // toolStripSource
            // 
            this.toolStripSource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNewLineSourceTool,
            this.copyCellSourceTool});
            this.toolStripSource.Location = new System.Drawing.Point(3, 3);
            this.toolStripSource.Name = "toolStripSource";
            this.toolStripSource.Size = new System.Drawing.Size(466, 25);
            this.toolStripSource.TabIndex = 0;
            this.toolStripSource.Text = "toolStrip1";
            // 
            // copyNewLineSourceTool
            // 
            this.copyNewLineSourceTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyNewLineSourceTool.Image = ((System.Drawing.Image)(resources.GetObject("copyNewLineSourceTool.Image")));
            this.copyNewLineSourceTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyNewLineSourceTool.Name = "copyNewLineSourceTool";
            this.copyNewLineSourceTool.Size = new System.Drawing.Size(23, 22);
            this.copyNewLineSourceTool.Text = "Копировать в новую строку";
            // 
            // copyCellSourceTool
            // 
            this.copyCellSourceTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyCellSourceTool.Image = ((System.Drawing.Image)(resources.GetObject("copyCellSourceTool.Image")));
            this.copyCellSourceTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyCellSourceTool.Name = "copyCellSourceTool";
            this.copyCellSourceTool.Size = new System.Drawing.Size(23, 22);
            this.copyCellSourceTool.Text = "Копировать в ячейки";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(480, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Найденные варианты:";
            // 
            // MatchSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка соответствий";
            ((System.ComponentModel.ISupportInitialize)(this.matchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabImportedWords.ResumeLayout(false);
            this.tabImportedWords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).EndInit();
            this.toolStripImport.ResumeLayout(false);
            this.toolStripImport.PerformLayout();
            this.tabSourceWords.ResumeLayout(false);
            this.tabSourceWords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            this.toolStripSource.ResumeLayout(false);
            this.toolStripSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView matchGrid;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSourceWords;
        private System.Windows.Forms.TabPage tabImportedWords;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridSource;
        private System.Windows.Forms.ToolStrip toolStripSource;
        private System.Windows.Forms.DataGridView gridImport;
        private System.Windows.Forms.ToolStrip toolStripImport;
        private System.Windows.Forms.ToolStripButton clearAllTool;
        private System.Windows.Forms.ToolStripButton openExcelTool;
        private System.Windows.Forms.ToolStripButton saveExcelTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton copyNewLineImportTool;
        private System.Windows.Forms.ToolStripButton copyCellImportTool;
        private System.Windows.Forms.ToolStripButton copyNewLineSourceTool;
        private System.Windows.Forms.ToolStripButton copyCellSourceTool;
    }
}
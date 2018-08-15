namespace Schukin.XDataConv.Core
{
    partial class MapSettingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapSettingsForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabMappingSettings = new System.Windows.Forms.TabPage();
            this.gridMapping = new System.Windows.Forms.DataGridView();
            this.tabAdditionalSettings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.checkFindAllMatches = new System.Windows.Forms.CheckBox();
            this.buttonSaveTemplate = new System.Windows.Forms.Button();
            this.buttonLoadTemplate = new System.Windows.Forms.Button();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsConvertImportToUpperCase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsUseForCompare1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsUseForCompare2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsUseForInject = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatchingList = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabSettings.SuspendLayout();
            this.tabMappingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).BeginInit();
            this.tabAdditionalSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(708, 423);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(627, 423);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tabMappingSettings);
            this.tabSettings.Controls.Add(this.tabAdditionalSettings);
            this.tabSettings.Location = new System.Drawing.Point(12, 12);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(771, 405);
            this.tabSettings.TabIndex = 2;
            // 
            // tabMappingSettings
            // 
            this.tabMappingSettings.Controls.Add(this.gridMapping);
            this.tabMappingSettings.Location = new System.Drawing.Point(4, 22);
            this.tabMappingSettings.Name = "tabMappingSettings";
            this.tabMappingSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabMappingSettings.Size = new System.Drawing.Size(763, 379);
            this.tabMappingSettings.TabIndex = 0;
            this.tabMappingSettings.Text = "Соответствия";
            this.tabMappingSettings.UseVisualStyleBackColor = true;
            // 
            // gridMapping
            // 
            this.gridMapping.AllowUserToAddRows = false;
            this.gridMapping.AllowUserToDeleteRows = false;
            this.gridMapping.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMapping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFieldName,
            this.colImportFieldName,
            this.colIsConvertImportToUpperCase,
            this.colIsUseForCompare1,
            this.colIsUseForCompare2,
            this.colIsUseForInject,
            this.colMatchingList});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMapping.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMapping.Location = new System.Drawing.Point(3, 3);
            this.gridMapping.Name = "gridMapping";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMapping.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridMapping.Size = new System.Drawing.Size(757, 373);
            this.gridMapping.TabIndex = 0;
            // 
            // tabAdditionalSettings
            // 
            this.tabAdditionalSettings.Controls.Add(this.label1);
            this.tabAdditionalSettings.Controls.Add(this.checkFindAllMatches);
            this.tabAdditionalSettings.Location = new System.Drawing.Point(4, 22);
            this.tabAdditionalSettings.Name = "tabAdditionalSettings";
            this.tabAdditionalSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdditionalSettings.Size = new System.Drawing.Size(859, 379);
            this.tabAdditionalSettings.TabIndex = 1;
            this.tabAdditionalSettings.Text = "Дополнительно";
            this.tabAdditionalSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(847, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // checkFindAllMatches
            // 
            this.checkFindAllMatches.AutoSize = true;
            this.checkFindAllMatches.Checked = true;
            this.checkFindAllMatches.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFindAllMatches.Location = new System.Drawing.Point(6, 26);
            this.checkFindAllMatches.Name = "checkFindAllMatches";
            this.checkFindAllMatches.Size = new System.Drawing.Size(225, 17);
            this.checkFindAllMatches.TabIndex = 0;
            this.checkFindAllMatches.Text = "Искать соответствия по всем строкам";
            this.checkFindAllMatches.UseVisualStyleBackColor = true;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveTemplate.Location = new System.Drawing.Point(12, 423);
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.Size = new System.Drawing.Size(80, 23);
            this.buttonSaveTemplate.TabIndex = 3;
            this.buttonSaveTemplate.Text = "Сохранить...";
            this.buttonSaveTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTemplate
            // 
            this.buttonLoadTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadTemplate.Location = new System.Drawing.Point(98, 423);
            this.buttonLoadTemplate.Name = "buttonLoadTemplate";
            this.buttonLoadTemplate.Size = new System.Drawing.Size(80, 23);
            this.buttonLoadTemplate.TabIndex = 4;
            this.buttonLoadTemplate.Text = "Загрузить...";
            this.buttonLoadTemplate.UseVisualStyleBackColor = true;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldName";
            this.colFieldName.HeaderText = "Поле";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            this.colFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colImportFieldName
            // 
            this.colImportFieldName.DataPropertyName = "ImportFieldName";
            this.colImportFieldName.HeaderText = "Поле в импортируемом файле";
            this.colImportFieldName.Name = "colImportFieldName";
            // 
            // colIsConvertImportToUpperCase
            // 
            this.colIsConvertImportToUpperCase.DataPropertyName = "IsConvertImportToUpperCase";
            this.colIsConvertImportToUpperCase.HeaderText = "Преобразовать при импорте в верхний регистр";
            this.colIsConvertImportToUpperCase.Name = "colIsConvertImportToUpperCase";
            // 
            // colIsUseForCompare1
            // 
            this.colIsUseForCompare1.DataPropertyName = "IsUseForCompare1";
            this.colIsUseForCompare1.HeaderText = "Использовать для первичной идентификации";
            this.colIsUseForCompare1.Name = "colIsUseForCompare1";
            // 
            // colIsUseForCompare2
            // 
            this.colIsUseForCompare2.DataPropertyName = "IsUseForCompare2";
            this.colIsUseForCompare2.HeaderText = "Использовать для вторичной идентификации";
            this.colIsUseForCompare2.Name = "colIsUseForCompare2";
            // 
            // colIsUseForInject
            // 
            this.colIsUseForInject.DataPropertyName = "IsUseForInject";
            this.colIsUseForInject.HeaderText = "Копировать в источник";
            this.colIsUseForInject.Name = "colIsUseForInject";
            // 
            // colMatchingList
            // 
            this.colMatchingList.DataPropertyName = "ImportMatchLinesCount";
            this.colMatchingList.HeaderText = "Справочник соответствий";
            this.colMatchingList.Name = "colMatchingList";
            this.colMatchingList.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMatchingList.Text = "Список...";
            this.colMatchingList.Width = 90;
            // 
            // MapSettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(795, 458);
            this.Controls.Add(this.buttonLoadTemplate);
            this.Controls.Add(this.buttonSaveTemplate);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки импорта";
            this.tabSettings.ResumeLayout(false);
            this.tabMappingSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).EndInit();
            this.tabAdditionalSettings.ResumeLayout(false);
            this.tabAdditionalSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabMappingSettings;
        private System.Windows.Forms.Button buttonSaveTemplate;
        private System.Windows.Forms.Button buttonLoadTemplate;
        private System.Windows.Forms.DataGridView gridMapping;
        private System.Windows.Forms.TabPage tabAdditionalSettings;
        private System.Windows.Forms.CheckBox checkFindAllMatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportFieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsConvertImportToUpperCase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsUseForCompare1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsUseForCompare2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsUseForInject;
        private System.Windows.Forms.DataGridViewButtonColumn colMatchingList;
    }
}
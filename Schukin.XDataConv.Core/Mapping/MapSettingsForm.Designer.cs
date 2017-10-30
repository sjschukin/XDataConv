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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabMappingSettings = new System.Windows.Forms.TabPage();
            this.gridMapping = new System.Windows.Forms.DataGridView();
            this.buttonSaveTemplate = new System.Windows.Forms.Button();
            this.buttonLoadTemplate = new System.Windows.Forms.Button();
            this.colDestColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUseForCompare1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUseForCompare2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUseForImport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUseForLog = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatchingList = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabSettings.SuspendLayout();
            this.tabMappingSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(709, 284);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(628, 284);
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
            this.tabSettings.Location = new System.Drawing.Point(12, 12);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(772, 266);
            this.tabSettings.TabIndex = 2;
            // 
            // tabMappingSettings
            // 
            this.tabMappingSettings.Controls.Add(this.gridMapping);
            this.tabMappingSettings.Location = new System.Drawing.Point(4, 22);
            this.tabMappingSettings.Name = "tabMappingSettings";
            this.tabMappingSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabMappingSettings.Size = new System.Drawing.Size(764, 240);
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
            this.colDestColumnName,
            this.colSourceColumnName,
            this.colUseForCompare1,
            this.colUseForCompare2,
            this.colUseForImport,
            this.colUseForLog,
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
            this.gridMapping.Size = new System.Drawing.Size(758, 234);
            this.gridMapping.TabIndex = 0;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveTemplate.Location = new System.Drawing.Point(12, 284);
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.Size = new System.Drawing.Size(80, 23);
            this.buttonSaveTemplate.TabIndex = 3;
            this.buttonSaveTemplate.Text = "Сохранить...";
            this.buttonSaveTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTemplate
            // 
            this.buttonLoadTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadTemplate.Location = new System.Drawing.Point(98, 284);
            this.buttonLoadTemplate.Name = "buttonLoadTemplate";
            this.buttonLoadTemplate.Size = new System.Drawing.Size(80, 23);
            this.buttonLoadTemplate.TabIndex = 4;
            this.buttonLoadTemplate.Text = "Загрузить...";
            this.buttonLoadTemplate.UseVisualStyleBackColor = true;
            // 
            // colDestColumnName
            // 
            this.colDestColumnName.DataPropertyName = "AliasName";
            this.colDestColumnName.HeaderText = "Поле";
            this.colDestColumnName.Name = "colDestColumnName";
            this.colDestColumnName.ReadOnly = true;
            this.colDestColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDestColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSourceColumnName
            // 
            this.colSourceColumnName.DataPropertyName = "SourceColumnName";
            this.colSourceColumnName.HeaderText = "Поле из файла";
            this.colSourceColumnName.Name = "colSourceColumnName";
            // 
            // colUseForCompare1
            // 
            this.colUseForCompare1.DataPropertyName = "UseForCompare1";
            this.colUseForCompare1.HeaderText = "Использовать для первичной идентификации";
            this.colUseForCompare1.Name = "colUseForCompare1";
            // 
            // colUseForCompare2
            // 
            this.colUseForCompare2.DataPropertyName = "UseForCompare2";
            this.colUseForCompare2.HeaderText = "Использовать для вторичной идентификации";
            this.colUseForCompare2.Name = "colUseForCompare2";
            // 
            // colUseForImport
            // 
            this.colUseForImport.DataPropertyName = "UseForImport";
            this.colUseForImport.HeaderText = "Использовать для импорта";
            this.colUseForImport.Name = "colUseForImport";
            // 
            // colUseForLog
            // 
            this.colUseForLog.DataPropertyName = "UseForLog";
            this.colUseForLog.HeaderText = "Отображать в протоколе";
            this.colUseForLog.Name = "colUseForLog";
            // 
            // colMatchingList
            // 
            this.colMatchingList.DataPropertyName = "MatchLinesCount";
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
            this.ClientSize = new System.Drawing.Size(796, 319);
            this.Controls.Add(this.buttonLoadTemplate);
            this.Controls.Add(this.buttonSaveTemplate);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки импорта";
            this.tabSettings.ResumeLayout(false);
            this.tabMappingSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMapping)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUseForCompare1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUseForCompare2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUseForImport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUseForLog;
        private System.Windows.Forms.DataGridViewButtonColumn colMatchingList;
    }
}
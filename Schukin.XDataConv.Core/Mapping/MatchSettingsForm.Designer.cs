namespace Schukin.XDataConv.Core
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
            this.matchGrid = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.sourceOptionsButton = new System.Windows.Forms.Button();
            this.aliasOptionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.matchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // matchGrid
            // 
            this.matchGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchGrid.AutoGenerateColumns = false;
            this.matchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchGrid.DataSource = this.bindingSource;
            this.matchGrid.Location = new System.Drawing.Point(0, 0);
            this.matchGrid.Name = "matchGrid";
            this.matchGrid.Size = new System.Drawing.Size(575, 268);
            this.matchGrid.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(662, 278);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(581, 278);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearAll.Location = new System.Drawing.Point(12, 278);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 5;
            this.buttonClearAll.Text = "Очистить";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // sourceOptionsButton
            // 
            this.sourceOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceOptionsButton.Location = new System.Drawing.Point(581, 12);
            this.sourceOptionsButton.Name = "sourceOptionsButton";
            this.sourceOptionsButton.Size = new System.Drawing.Size(156, 23);
            this.sourceOptionsButton.TabIndex = 6;
            this.sourceOptionsButton.Text = "Варианты из имп. файла";
            this.sourceOptionsButton.UseVisualStyleBackColor = true;
            this.sourceOptionsButton.Click += new System.EventHandler(this.importedOptionsButton_Click);
            // 
            // aliasOptionsButton
            // 
            this.aliasOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aliasOptionsButton.Location = new System.Drawing.Point(581, 41);
            this.aliasOptionsButton.Name = "aliasOptionsButton";
            this.aliasOptionsButton.Size = new System.Drawing.Size(156, 23);
            this.aliasOptionsButton.TabIndex = 7;
            this.aliasOptionsButton.Text = "Варианты из источника";
            this.aliasOptionsButton.UseVisualStyleBackColor = true;
            this.aliasOptionsButton.Click += new System.EventHandler(this.sourceOptionsButton_Click);
            // 
            // MatchSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 313);
            this.Controls.Add(this.aliasOptionsButton);
            this.Controls.Add(this.sourceOptionsButton);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.matchGrid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка соответствий";
            ((System.ComponentModel.ISupportInitialize)(this.matchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView matchGrid;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button sourceOptionsButton;
        private System.Windows.Forms.Button aliasOptionsButton;
    }
}
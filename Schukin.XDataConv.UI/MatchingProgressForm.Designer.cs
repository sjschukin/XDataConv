namespace Schukin.XDataConv.UI
{
    partial class MatchingProgressForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblMatchedCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 52);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(364, 23);
            this.progressBar.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(301, 81);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(12, 33);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(178, 16);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "Строка 0 из 0";
            // 
            // lblMatchedCount
            // 
            this.lblMatchedCount.Location = new System.Drawing.Point(196, 33);
            this.lblMatchedCount.Name = "lblMatchedCount";
            this.lblMatchedCount.Size = new System.Drawing.Size(180, 16);
            this.lblMatchedCount.TabIndex = 3;
            this.lblMatchedCount.Text = "Найдено соответствий: 0";
            this.lblMatchedCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MatchingProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 116);
            this.ControlBox = false;
            this.Controls.Add(this.lblMatchedCount);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatchingProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Процесс сверки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblMatchedCount;
    }
}
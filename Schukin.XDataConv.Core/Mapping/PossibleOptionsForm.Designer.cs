namespace Schukin.XDataConv.Core
{
    partial class PossibleOptionsForm
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
            this.richText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richText
            // 
            this.richText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText.HideSelection = false;
            this.richText.Location = new System.Drawing.Point(0, 0);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.Size = new System.Drawing.Size(353, 265);
            this.richText.TabIndex = 0;
            this.richText.Text = "";
            // 
            // PossibleOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 265);
            this.Controls.Add(this.richText);
            this.Name = "PossibleOptionsForm";
            this.Text = "Возможные варианты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richText;
    }
}
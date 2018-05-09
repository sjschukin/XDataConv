using System;
using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class GotoLineNumberForm : Form
    {
        public GotoLineNumberForm()
        {
            InitializeComponent();
        }

        public int LineNumber{get; private set; }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textLineNumber.Text,out var lineNumber))
                return;

            LineNumber = lineNumber;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

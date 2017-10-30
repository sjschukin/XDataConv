using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void ShowLog(List<IdentifyResultItem> results)
        {
            logTextBox.Clear();
            logTextBox.SuspendLayout();

            foreach (var item in results)
            {
                Color color = SystemColors.ControlText;

                switch (item.ResultType)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Green;
                        break;
                    case 2:
                        color = Color.Yellow;
                        break;
                }

                logTextBox.AppendText(item.Name + "\r\n", color);
                foreach (var itemDetail in item.Details)
                {
                    logTextBox.AppendText($"    {itemDetail}\r\n");
                }
            }

            logTextBox.PerformLayout();
        }
    }
}

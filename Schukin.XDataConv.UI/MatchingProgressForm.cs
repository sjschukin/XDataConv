using System.Windows.Forms;

namespace Schukin.XDataConv.UI
{
    public partial class MatchingProgressForm : Form
    {
        public MatchingProgressForm()
        {
            InitializeComponent();
        }

        public void InitProcess(int maxValue)
        {
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            progressBar.Maximum = maxValue;
            
        }

        public void UpdateProcess(int currentValue, int matchedFound)
        {
            lblProcess.Text = $"Строка {progressBar.Value} из {progressBar.Maximum}";
            lblMatchedCount.Text = $"Найдено соответствий: {matchedFound}";
            progressBar.Value = currentValue;
        }

        public void EndProcess()
        {
            progressBar.Value = progressBar.Maximum;
            lblProcess.Text = $"Строка {progressBar.Value} из {progressBar.Maximum}";
        }
    }
}

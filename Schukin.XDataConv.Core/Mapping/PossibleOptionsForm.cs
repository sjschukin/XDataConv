using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class PossibleOptionsForm : Form
    {
        public PossibleOptionsForm()
        {
            InitializeComponent();
        }

        public string OptionsText
        {
            get => richText.Text;
            set => richText.Text = value;
        }
    }
}

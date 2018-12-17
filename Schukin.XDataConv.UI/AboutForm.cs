using System.Reflection;
using System.Windows.Forms;

namespace Schukin.XDataConv.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            labelApplicationName.Text= assemblyName.Name;
            labelVersion.Text = assemblyName.Version.ToString();
            labelLinkSources.Click += delegate { System.Diagnostics.Process.Start("https://github.com/sjschukin/XDataConv"); };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schukin.XDataConv.Core
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            labelApplicationName.Text= assemblyName.Name;
            labelVersion.Text = assemblyName.Version.ToString();
        }
    }
}

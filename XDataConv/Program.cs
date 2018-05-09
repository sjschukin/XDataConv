using System;
using System.Windows.Forms;
using Schukin.XDataConv.Core;

namespace Schukin.XDataConv
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new AppForm());
        }
    }
}

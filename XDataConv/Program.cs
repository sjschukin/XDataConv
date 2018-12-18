using System;
using System.Windows.Forms;
using Schukin.XDataConv.Core;
using Schukin.XDataConv.Core.Interfaces;
using Schukin.XDataConv.Excel;
using Schukin.XDataConv.UI;

namespace Schukin.XDataConv
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            var logger = new Logger();
            var matchingManager = new MatchingManager(logger);
            IImportModule<DataItem, DataItemError>[] modules = {new ExcelImport<DataItem, DataItemError>(logger)};

            Application.Run(new AppForm(logger, matchingManager, modules));
        }
    }
}

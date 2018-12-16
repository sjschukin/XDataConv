using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schukin.XDataConv.UI
{
    public sealed class AppCore
    {
        private static AppCore _instance;

        public AppCore()
        {
            
        }

        public static AppCore Instance => _instance ?? (_instance = new AppCore());
    }
}

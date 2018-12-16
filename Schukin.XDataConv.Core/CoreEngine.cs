using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.Core
{
    public class CoreEngine
    {
        private readonly ILogger _logger;

        public CoreEngine(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopInterfaceGroup
{
    public class LogManager
    {
        private ILogger _logger;
        
        public LogManager(ILogger logger)
        {
            _logger = logger;
        }

        public void LogMessage(string message, DateTime timeStamp)
        {
            _logger.Log(message, timeStamp);
        }
    }
}

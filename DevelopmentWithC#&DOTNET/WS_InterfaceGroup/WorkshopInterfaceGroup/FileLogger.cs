using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopInterfaceGroup
{
    public class FileLogger : ILogger
    {
        public void Log(string message, DateTime timeStamp)
        {
            Console.WriteLine($"File: {message} at {timeStamp}");
        }
    }
}

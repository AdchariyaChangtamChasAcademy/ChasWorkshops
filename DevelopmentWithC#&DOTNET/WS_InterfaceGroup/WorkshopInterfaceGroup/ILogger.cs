using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopInterfaceGroup
{
    public interface ILogger
    {
        void Log(string message, DateTime timeStamp);
    }
}

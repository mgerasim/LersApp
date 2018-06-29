using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LersAppHelper.Loggers
{
    public class LoggerConsole: ILogger
    {
        void ILogger.Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

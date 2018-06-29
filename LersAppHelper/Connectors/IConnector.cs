using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LersAppHelper.Connectors
{
    public interface IConnector
    {
        void Run();
        void Log(string msg);
    }
}

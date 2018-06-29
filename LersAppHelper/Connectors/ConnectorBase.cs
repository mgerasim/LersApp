using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LersAppHelper.Connectors
{
    public class ConnectorBase : IConnector
    {
        string Appname = "LersApp: Отопление и ГВС в ТСЖ Семь ветров (Тестовое задание)";
        public string _Username = "demo";
        public string _Password = "dem1o";
        public string _Hostname = "my.lers.ru";
        public ushort _Port = 10000;

        public Lers.LersServer theServer = null;
        protected Loggers.ILogger theLogger = null;

        public ConnectorBase(Loggers.ILogger theLogger)
        {
            this.theLogger = theLogger;

            theServer = new Lers.LersServer();

            theServer.VersionMismatch += (sender, e) => e.Ignore = true;
        }

        void IConnector.Run()
        {

        }

        void IConnector.Log(string msg)
        {
            if (this.theLogger != null)
            {
                theLogger.Log(msg);
            }
        }
    }
}

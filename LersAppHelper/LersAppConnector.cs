using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppHelper
{
    public class LersAppConnector
    {
        string Appname = "LersApp: Отопление и ГВС в ТСЖ Семь ветров (Тестовое задание)";
        string ConnectUsername = "demo";
        string ConnectPassword = "demo";
        ushort ConnectPort = 10000;
        string ConnectServer = "my.lers.ru";

        Loggers.ILogger theLogger = null;

        private Lers.LersServer Server = null;

        public LersAppConnector(Loggers.ILogger theLogger)
        {
            Server = new Lers.LersServer(this.Appname);
            Server.Connected += this.server_Connected;
            this.Server.VersionMismatch += (sender, e) => e.Ignore = true;
            this.theLogger = theLogger;
        }

        private void Log(string msg)
        {
            if (theLogger != null)
            {
                theLogger.Log(msg);
            }
            return;
        }

        private void server_Connected(object sender, object e)
        {
            Log("server_Connected");
            if (this.Server.IsConnected)
            {

                Log(this.Server.Version.Title);
                var measurePoint = this.Server.MeasurePoints.GetByNumber(727);


                Log(measurePoint.Title);

                Log("server_Connected: Disconnet");

                this.Server.Disconnect(2000);
            }
            else
            {
                Log("server_Connected: Error: Server is not be connected");
            }

            Application.ExitThread();
 
       }

        public void Run()
        {
            Log("Run");
            var th = new Thread(() =>
            {
                var authInfo = new Lers.Networking.BasicAuthenticationInfo(this.ConnectUsername, 
                            Lers.Networking.SecureStringHelper.ConvertToSecureString(this.ConnectPassword));

                // Устанавливаем подключение к серверу
                this.Server.ConnectAsync(this.ConnectServer, this.ConnectPort, authInfo, null, null);
                //this.Server.Connect(this.ConnectServer, this.ConnectPort, authInfo);
                //var measurePoint = this.Server.MeasurePoints.GetByNumber(727);

                //Log(measurePoint.FullTitle);

                Application.DoEvents();
            });

            //th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
    }
}

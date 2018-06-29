using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lers;
using Lers.Networking;

namespace LersAppConsole
{
    class Program
    {

        

        static void Main(string[] args)
        {
            //TestSample();
            //TestConnect();
            //TestConnectorSync();
            TestConnectASync();
            Console.ReadKey();

        }
        async static void TestConnectASync()
        {
            // Создаём объект для подключения к серверу
            var server = new Lers.LersServer();

            server.VersionMismatch += (sender, e) => e.Ignore = true;

            // Информация для аутентификации (логин и пароль учётной записи)
            var authInfo = new Lers.Networking.BasicAuthenticationInfo("demo", Lers.Networking.SecureStringHelper.ConvertToSecureString("demo"));

            // Устанавливаем подключение к серверу
            server.Connect("my.lers.ru", 10000, authInfo);

            // Ищем точку учёта. В этом примере мы получем её по номеру.
            var measurePoint = server.MeasurePoints.GetByNumber(727);

            Console.WriteLine(measurePoint.FullTitle);

            // Определяем интервал за который запрашиваются данные. В данном случае - за один месяц.
            var endDate = DateTime.Now;
            var startDate = endDate.AddMonths(-1);

            
        }
        static void TestSample()
        {
            // Создаём объект для подключения к серверу
            var server = new Lers.LersServer();

            server.VersionMismatch += (sender, e) => e.Ignore = true;

            // Информация для аутентификации (логин и пароль учётной записи)
            var authInfo = new Lers.Networking.BasicAuthenticationInfo("demo", Lers.Networking.SecureStringHelper.ConvertToSecureString("demo"));

            // Устанавливаем подключение к серверу
            ProxySettings proxySettings = ProxySettings.GetSystemDefaultProxy(); ;
            var connectCancellation = new CancellationTokenSource();

            TaskAwaiter<RestoreSessionToken> awaiter;
            awaiter = server.ConnectAsync("my.lers.ru", 10000, proxySettings, authInfo, connectCancellation.Token).GetAwaiter();

            if (!awaiter.IsCompleted)
            {
                Console.WriteLine("Not completed");
            }


            // Ищем точку учёта. В этом примере мы получем её по номеру.
            var measurePoint = server.MeasurePoints.GetByNumber(727);

            Console.WriteLine(measurePoint.FullTitle);

            // Определяем интервал за который запрашиваются данные. В данном случае - за один месяц.
            var endDate = DateTime.Now;
            var startDate = endDate.AddMonths(-1);

            
        }

        static void TestConnect()
        {
            LersAppHelper.Loggers.ILogger theLoggerConsole = new LersAppHelper.Loggers.LoggerConsole();
            LersAppHelper.LersAppConnector theConnector = new LersAppHelper.LersAppConnector(theLoggerConsole);

            theConnector.Run();
            while (true)
            {

            }
        }

    }
}

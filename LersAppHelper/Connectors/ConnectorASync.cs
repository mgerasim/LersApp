using Lers.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppHelper.Connectors
{
    public class ConnectorASync : ConnectorBase
    {
        ListView theListView;
        Form theSplash;
        public CancellationTokenSource connectCancellation = null; 
        public ConnectorASync(Loggers.ILogger theLogger, ListView theListView, Form theSplash) : base(theLogger)
        {
            this.theListView = theListView;
            this.theSplash = theSplash;
            connectCancellation = new CancellationTokenSource();
        }

        public void Log(string msg)
        {
            if (this.theLogger != null)
            {
                theLogger.Log(msg);
            }
        }

        public async void Run(DateTime dateBgn, DateTime dateEnd)
        {
            ProxySettings proxySettings = ProxySettings.GetSystemDefaultProxy();
            var authInfo = new Lers.Networking.BasicAuthenticationInfo(this._Username, 
                                    Lers.Networking.SecureStringHelper.ConvertToSecureString(this._Password));

            theSplash.Show();
            await this.theServer.ConnectAsync(this._Hostname, this._Port, proxySettings, authInfo, connectCancellation.Token);

            // Ищем точку учёта. В этом примере мы получем её по номеру.
            var measurePoint = this.theServer.MeasurePoints.GetByNumber(727);

            Log(measurePoint.FullTitle);

            // Запрашиваем суточные данные за указанный интервал
            var consumptionData = measurePoint.Data.GetConsumption(dateBgn, dateEnd, Lers.Data.DeviceDataType.Day);

            // Выводим на экран массовый расход
            foreach (var consumptionRecord in consumptionData)
            {
                double? valueT = consumptionRecord.GetValue(Lers.Data.DataParameter.T_in.ToString());
                string stringValueT = valueT.HasValue ? valueT.Value.ToString() : "<нет данных>";


                double? valueP = consumptionRecord.GetValue(Lers.Data.DataParameter.P_in.ToString());
                string stringValueP = valueP.HasValue ? valueP.Value.ToString() : "<нет данных>";


                if (theListView != null)
                {
                    ListViewItem Item = new ListViewItem(consumptionRecord.DateTime.ToLongDateString());
                    Item.SubItems.Add(stringValueT);
                    Item.SubItems.Add(stringValueP);

                    theListView.Items.Add(Item);
                }
            }


            this.connectCancellation.CancelAfter(1000);
            theSplash.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppHelper.Connectors
{
    public class ConnectorSync : ConnectorBase
    {
        ListView theListView;
        public ConnectorSync(Loggers.ILogger theLogger, ListView theListView) : base(theLogger)
        {
            this.theListView = theListView;
        }

        public void Log(string msg)
        {
            if (this.theLogger != null)
            {
                theLogger.Log(msg);
            }
        }
        
        public void Run(DateTime dateBgn, DateTime dateEnd)
        {

            // Информация для аутентификации (логин и пароль учётной записи)
            var authInfo = new Lers.Networking.BasicAuthenticationInfo(this._Username, 
                                Lers.Networking.SecureStringHelper.ConvertToSecureString(this._Password));

            // Устанавливаем подключение к серверу
            this.theServer.Connect(this._Hostname, this._Port, authInfo);

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



        }

    }
}

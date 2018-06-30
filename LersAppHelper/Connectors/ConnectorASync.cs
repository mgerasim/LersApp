using Lers;
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
            string err = "";
            try
            {
                ProxySettings proxySettings = ProxySettings.GetSystemDefaultProxy();
                var authInfo = new Lers.Networking.BasicAuthenticationInfo(this._Username,
                                        Lers.Networking.SecureStringHelper.ConvertToSecureString(this._Password));

                theSplash.Show();
                await this.theServer.ConnectAsync(this._Hostname, this._Port, proxySettings, authInfo, connectCancellation.Token);

                this.Log("Ищем точку учёта.");
                var measurePoint = this.theServer.MeasurePoints.GetByNumber(727);

                this.Log(measurePoint.FullTitle);

                this.Log("Запрашиваем суточные данные за указанный интервал");
                var consumptionData = measurePoint.Data.GetConsumption(dateBgn, dateEnd, Lers.Data.DeviceDataType.Day);

                this.Log("Выводим на экран массовый расход");
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
            catch (AuthorizationFailedException ex)
            {
                err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }

            }
            catch (ServerConnectionException ex)
            {
                err = "Ошибка подключения" + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
            }
            catch (TimeoutException ex)
            {
                err = "Превышено время ожидания!" + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
                err += Environment.NewLine + 
                    Environment.NewLine +
                    "Убедитесь, что сервер ЛЭРС УЧЕТ запущен, работает правильно и имеет соединение с базой данных.";
            }
            catch (RequestDisconnectException ex)
            {
                err = "Разрыв соединения!" + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
                err += Environment.NewLine +
                    Environment.NewLine +
                    "Проверьте параметры подключения, настройки прокси и брэндмауэра.";
            }
            catch (OperationCanceledException ex)
            {
                err = "Операция отменена!" + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
            }
            catch (VersionMismatchException ex)
            {
                err = "Версии клиента и сервера отличаются!" + Environment.NewLine + ex.Message + Environment.NewLine;
                err += "Версия клиента: " + ex.ClientVersion.BuildNumber.ToString() + Environment.NewLine;
                err += "Версия сервера: " + ex.ServerVersion.BuildNumber.ToString() + Environment.NewLine;

                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
            }
            catch (Exception ex)
            {
                err = "Неизвестная ошибка!" + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    err += Environment.NewLine + ex.InnerException.Message;
                }
            }
            finally
            {
                this.connectCancellation.CancelAfter(1000);
                this. theSplash.Hide();
                if (err.Length > 0)
                {
                    MessageBox.Show(err, "Ошибка подключения!");
                    this.Log(err);
                }
            }
        }
    }
}

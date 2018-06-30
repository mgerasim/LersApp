using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppUI
{
    public partial class FormMain : Form
    {
        LersAppHelper.Loggers.ILogger theLoggerForm = null;

        Splash theSplash = null;
        LersAppHelper.Connectors.ConnectorASync theConnectorASync = null;

        public FormMain()
        {
            InitializeComponent();
            this.dateTimePickerBgn.Value = DateTime.Now.AddMonths(-1);
            this.dateTimePickerEnd.Value = DateTime.Now;
            theLoggerForm = new LersAppHelper.Loggers.LoggerForm(this.textBoxLog);
            theSplash = new Splash();
            theConnectorASync = new LersAppHelper.Connectors.ConnectorASync(theLoggerForm,
                                                                            this.listViewMeasure,
                                                                            theSplash);
            theSplash.connectCancellation = theConnectorASync.connectCancellation;

            this.textBoxUsername.Text = theConnectorASync._Username;
            this.textBoxHostname.Text = theConnectorASync._Hostname;
            this.numericUpDownPort.Value = theConnectorASync._Port;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (this.dateTimePickerBgn.Value.Date >= this.dateTimePickerEnd.Value.Date)
            {
                string err = "Дата начало периода должна быть меньше даты завершения периода";
                theLoggerForm.Log(err);
                MessageBox.Show(err);
                return;
            }

            this.theConnectorASync.connectCancellation = new System.Threading.CancellationTokenSource();
            this.theSplash.connectCancellation = this.theConnectorASync.connectCancellation;

            this.theConnectorASync._Username = this.textBoxUsername.Text;
            this.theConnectorASync._Hostname = this.textBoxHostname.Text;
            this.theConnectorASync._Port = (ushort)this.numericUpDownPort.Value;

            theLoggerForm.Log("Очистка предыдущих данных");
            this.listViewMeasure.Items.Clear();

            theLoggerForm.Log("Установливаем соединение с сервером");
            theConnectorASync.Run(this.dateTimePickerBgn.Value.Date, this.dateTimePickerEnd.Value.Date);
            
        }
    }
}

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
        public FormMain()
        {
            InitializeComponent();
            this.dateTimePickerBgn.Value = DateTime.Now.AddMonths(-1);
            this.dateTimePickerEnd.Value = DateTime.Now;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (this.dateTimePickerBgn.Value.Date >= this.dateTimePickerEnd.Value.Date)
            {
                MessageBox.Show("Дата начало периода должна быть меньше даты завершения периода");
                return;
            }

            this.listViewMeasure.Items.Clear();

            LersAppHelper.Loggers.ILogger theLoggerForm = new LersAppHelper.Loggers.LoggerForm();
            LersAppHelper.Connectors.ConnectorSync theConnectorSync = new LersAppHelper.Connectors.ConnectorSync(theLoggerForm, this.listViewMeasure);

            Splash theSplash = new Splash();
            LersAppHelper.Connectors.ConnectorASync theConnectorASync = new LersAppHelper.Connectors.ConnectorASync(theLoggerForm,
                this.listViewMeasure, 
                theSplash);
            theSplash.connectCancellation = theConnectorASync.connectCancellation;
            theConnectorASync.Run(this.dateTimePickerBgn.Value.Date, this.dateTimePickerEnd.Value.Date);
        }
    }
}

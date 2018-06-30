using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppHelper.Loggers
{
    public class LoggerForm : ILogger
    {
        TextBox theTextBox = null;
        public LoggerForm(TextBox theTextBox)
        {
            this.theTextBox = theTextBox;
        }
        void ILogger.Log(string msg)
        {
            if (theTextBox != null)
            {
                string strDate = DateTime.Now.ToLongTimeString();
                theTextBox.Text = strDate + " " + msg + Environment.NewLine + theTextBox.Text;
            }
        }
    }
}

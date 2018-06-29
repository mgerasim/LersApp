using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LersAppUI
{
    public partial class Splash : Form
    {
        public CancellationTokenSource connectCancellation = null;
        public Splash()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (this.connectCancellation != null)
            {
                this.connectCancellation.CancelAfter(1000);
            }
            this.Hide();
        }
    }
}

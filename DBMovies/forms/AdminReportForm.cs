using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class AdminReportForm : Form
    {
        public AdminReportForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (rtbMessagetoAdmin.Text != "")
                sendData();
            else
                MessageBox.Show("Message is incomplete.\nPlease try again.", "FAIL");
        }

        private void sendData()
        {
            // Předává ze současného formuláře do metody Hlavního okna
            ((MovieWindow)System.Windows.Application.Current.MainWindow).registerReport(rtbMessagetoAdmin.Text);
        }
    }
}

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
    public partial class ReportForm : Form
    {
        string recipient;
        public ReportForm(string recipient)
        {
            InitializeComponent();
            this.recipient = recipient;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (rtbMessage.Text != "")
            {
                // TODO
                if (recipient == "admin")
                    // Předává ze současného formuláře do metody Hlavního okna
                    ((MovieWindow)System.Windows.Application.Current.MainWindow).registerReport(rtbMessage.Text);
                else if (recipient == "movie")
                    ((MovieWindow)System.Windows.Application.Current.MainWindow).registerComment(rtbMessage.Text);
            }
            else
                MessageBox.Show("Message is incomplete.\nPlease try again.", "FAIL");
        }
    }
}

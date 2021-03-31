using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(MovieWindow))
                {
                    if (rtbMessage.Text != "")
                    {
                        if (recipient == "admin")
                            (window as MovieWindow).registerReport(rtbMessage.Text);
                        else if (recipient == "movie")
                            (window as MovieWindow).registerComment(rtbMessage.Text);
                    }
                    else 
                        System.Windows.MessageBox.Show("Message is incomplete.\nPlease try again.", "FAIL");
                }
            }
            Close();
        }
    }
}

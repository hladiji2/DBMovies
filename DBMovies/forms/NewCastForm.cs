using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMovies.forms
{
    public partial class NewCastForm : Form
    {
        public NewCastForm()
        {
            InitializeComponent();
        }

        private void btnRegisterCast_Click(object sender, EventArgs e)
        {
            
            if (tbFullName.Text != "")
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
                {
                    try
                    {
                        cnn.Open();
                        string INSERT = "INSERT INTO \"Cast\" (FullName) Values ('" + tbFullName.Text.Trim() + "'); SELECT SCOPE_IDENTITY()";
                        
                        SqlCommand cmd = new SqlCommand(INSERT, cnn);

                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException b)
                    {
                        Console.WriteLine(b.Message);
                    }
                }
            }
            else
                MessageBox.Show("Genre is incomplete.\nPlease try again.", "FAIL");
            
        }
    }
    
}

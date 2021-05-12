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
    public partial class NewGenreForm : Form
    {
        public NewGenreForm()
        {
            InitializeComponent();
        }

        private void btnRegisterGenre_Click(object sender, EventArgs e)
        {
            if (tbGenre.Text != "")
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO \"Genre\" (Name) Values ('" + tbGenre.Text.Trim() + "')", cnn);
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

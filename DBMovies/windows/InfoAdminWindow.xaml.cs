using DBMovies.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBMovies.windows
{
    /// <summary>
    /// Interaction logic for InfoAdminWindow.xaml
    /// </summary>
    public partial class InfoAdminWindow : Window
    {
        List<Cast> dataCast;
        List<Genre> dataGenre;
        public InfoAdminWindow(string s)
        {
            InitializeComponent();

            if (s == "cast")
            {
                dataCast = new List<Cast>();
                fillDataCast();
                dgSimple.ItemsSource = dataCast;
            }
                
            else if (s == "genre")
            {
                dataGenre = new List<Genre>();
                fillDataGenre();
                dgSimple.ItemsSource = dataGenre;
            }
        }
        private void fillDataGenre()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT GenreID, Name FROM \"Genre\"", cnn);
                    cnn.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            dataGenre.Add(new Genre(dataReader.GetDecimal(0), dataReader.GetString(1)));
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void fillDataCast()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    List<decimal> Ids = new List<decimal>();

                    string SELECT = "SELECT CastID FROM \"Cast\"";
                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            Ids.Add(dataReader.GetDecimal(0));

                    Cast c;

                    for (int i = 0; i < Ids.Count; i++)
                    {
                        c = new Cast();
                        c.CastID = Ids[i];
                        cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + Ids[i] + "'";
                        c.FullName = Convert.ToString(cmd.ExecuteScalar());
                        cmd.CommandText = "SELECT Name FROM \"Role\" WHERE CastID='" + Ids[i] + "'";
                        c.Role = Convert.ToString(cmd.ExecuteScalar());
                        cmd.CommandText = "SELECT Salary FROM \"Role\" WHERE CastID='" + Ids[i] + "'";
                        c.Salary = Convert.ToDecimal(cmd.ExecuteScalar());
                        dataCast.Add(c);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace DBMovies
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Access_Window access_Window;
        private Movie_Window movie_Window;

        public string cnns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            access_Window = new Access_Window(this);
        }

        public bool isDBConnected(string cnns)
        {
            using (SqlConnection cnn = new SqlConnection(cnns))
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
        }

        private void addMovie(object sender, RoutedEventArgs e)
        {

        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {

        }

    }
}

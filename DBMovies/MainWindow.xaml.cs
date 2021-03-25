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
        public static Access_Window access_Window;
        public static Movie_Window movie_Window;
        static public SqlConnection cnn;

        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            // Skryje se hlavní okno
            Hide();
            // Připojení do databáze
            cnn = new SqlConnection();
            access_Window = new Access_Window(this);
            access_Window.ResizeMode = ResizeMode.NoResize;
            access_Window.Show();
            
            if (PripojDB())
                access_Window.status.Background = Brushes.Green;
        }
        
        bool PripojDB()
        {
            try
            {
                // Potřebuju Connection String PC
                //string cnns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                // Potřebuju Connection String NTB
                string cnns = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MovieDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                // Připojím string k objektu connection
                cnn.ConnectionString = cnns;
                // Pokusím se připojit k DB
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                    return true;
                else throw new Exception();
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                return false;
            }
        } 

        private void Add_Movie(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Movie(object sender, RoutedEventArgs e)
        {

        }

    }
}

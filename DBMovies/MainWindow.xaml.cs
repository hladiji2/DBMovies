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
using System.ComponentModel;

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
            // Skrýt hlavní okno pro autorizaci
            Hide();
            access_Window = new Access_Window(this);
        }

        
        private void addMovie(object sender, RoutedEventArgs e)
        {

        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Metoda pro zajištění přístupu do oken
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Mění vypínací tlačíko (Právý horní křížek) tak,
            // že Hlavní okno bude pouze skryto a znovu se zobrazí
            // Autorizační okno.
            if (access_Window.mainWindowAccessed)
            {
                e.Cancel = true;
                Hide();
                access_Window = new Access_Window(this);
            }
        }
    }
}

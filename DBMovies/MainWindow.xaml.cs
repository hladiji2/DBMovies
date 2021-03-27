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
using System.Windows.Forms;
using DBMovies.model;

namespace DBMovies
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Access_Window access_Window;
        private Movie_Window movie_Window;

        public bool wasAccessed;
        public byte privileges;

        public string cnns = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public MainWindow()
        {
            InitializeComponent();
            start();
            Movie m = new Movie("Terminator");
            m.
        }

        void start()
        {
            wasAccessed = false;
            // Skrýt hlavní okno pro autorizaci
            Hide();
            access_Window = new Access_Window(this);
        }

        
        private void addMovie(object sender, RoutedEventArgs e)
        {
            new NewMovieForm();
        }

        // TODO Zápis nového filmu do databáze
        /* 
         * object[0] String     - Název Filmu
         * object[1] String     - Název Režiséra
         * object[2] string[]   - Názvy Herců
         * object[3] string[]   - Názvy Žánrů
         * object[...] ...     - ...
         * 
         * Volá se ve Formuláři NewMovieWindow,
         * až se nastaví informace o novém filmu.
        */
        public void registerMovie(object[] movieData)
        {

        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {

        }

        // Metoda pro zajištění přístupu do oken
        protected override void OnClosing(CancelEventArgs e)
        {
            // Mění vlastnost vypínacího tlačíka (Právý horní křížek) tak,
            // že Hlavní okno bude pouze skryto a znovu se zobrazí Autorizační okno.
            if (wasAccessed)
            {
                e.Cancel = true;
                Hide();
                access_Window = new Access_Window(this);
            }
        }
    }
}

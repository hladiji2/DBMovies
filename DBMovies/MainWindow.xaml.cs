using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using DBMovies.model;
using System.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using DBMovies;
using System.Windows.Controls;

namespace DBMovies
{
    public partial class MainWindow : Window
    {
        private AccessWindow accessWindow;
        private MovieWindow movieWindow;

        private NewMovieForm f;

        public bool wasAccessed;
        public User user;
        public ObservableCollection<Movie> movies { get; set; }

        public MainWindow()
        {
            movies = new ObservableCollection<Movie>
            {
                new Movie("Terminator", "1984"),
                new Movie("Blabla", "2021"),
                new Movie("The Room", "2006")
            };



            InitializeComponent();

            // MUSÍ BÝT VŽDY
            lsbMovies.ItemsSource = movies;
            
            start();
        }

        void start()
        {
            // Skrýt hlavní okno pro autorizaci
            wasAccessed = false;
            ResizeMode = ResizeMode.NoResize;
            accessWindow = new AccessWindow(this);

            //movieWindow = new MovieWindow(this);
        }


        private void addMovie(object sender, RoutedEventArgs e)
        {
            if (f == null)
            {
                f = new NewMovieForm();
                f.Show();
            }
            else
            {
                f.Dispose();
                f = null;
            }
        }

        /* 
         * object[0] String     - Název Filmu
         * object[1] String     - Rok Vydání
         * object[2] String     - Název Režiséra
         * object[3] string[]   - Názvy Herců
         * object[4] string[]   - Názvy Žánrů
         * object[...] ...     - ...
         * 
         * Volá se ve Formuláři NewMovieForm.
        */
        public void registerMovie(object[] movieData)
        {
            // TODO INSERT INTO DATABASE
            string nazev = (string)movieData[0];
            string rok = (string)movieData[1];
            string reziser = (string)movieData[2];
            string[] herci = (string[])movieData[3];
            string[] zanry = (string[])movieData[4];

            
        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {
            // TODO DELETE FROM DATABASE
            

        }

        // HEAVY TODO
        private void displayMovie(object sender, SelectionChangedEventArgs args)
        {
            new MovieWindow(this, (Movie)args.AddedItems[0]);
        }

        public void setGuiElements()
        {
            switch (user.privilegeLevel)
            {
                // TODO změnit viditelnost prvků gui podle oprávnění
                case 1: // Moderator
                case 2: // User
                    btnAddMovie.IsEnabled = false;
                    btnDeleteMovie.IsEnabled = false;
                    break;
            }
            txtKarma.Text = user.karma.ToString();
            txtUserLogin.Text = user.login.ToString();
            switch (user.privilegeLevel)
            {
                case 0: txtUserMode.Text = "Admin"; break;
                case 1: txtUserMode.Text = "Moderator"; break;
                case 2: txtUserMode.Text = "Uživatel"; break;
            }
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
                accessWindow = new AccessWindow(this);
            }
            else
                System.Windows.Application.Current.Shutdown();
        }

    }
}

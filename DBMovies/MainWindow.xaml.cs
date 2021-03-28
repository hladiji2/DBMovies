using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using DBMovies.model;
using System.Configuration;

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
        public User user;
        private List<Movie> movieList;

        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        void start()
        {
            wasAccessed = false;
            movieList = new List<Movie>();
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
         * object[1] String     - Rok Vydání
         * object[2] String     - Název Režiséra
         * object[3] string[]   - Názvy Herců
         * object[4] string[]   - Názvy Žánrů
         * object[...] ...     - ...
         * 
         * Volá se ve Formuláři NewMovieWindow,
         * až se nastaví informace o novém filmu.
        */
        public void registerMovie(object[] movieData)
        {
            // TODO INSERT INTO DATABASE

        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {
            // TODO DELETE FROM DATABASE
            

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

            movie_Window.setGuiElements();
        }
    }
}

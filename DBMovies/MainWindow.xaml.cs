using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using DBMovies.model;
using System.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Data.SqlClient;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DBMovies
{
    public partial class MainWindow : Window
    {
        AccessWindow accessWindow;
        MovieWindow movieWindow;

        private NewMovieForm f;

        public bool wasAccessed;
        public User user;
        public ObservableCollection<Movie> movies { get; set; }

        public MainWindow()
        {
            movies = new ObservableCollection<Movie>();

            InitializeComponent();

            lsbMovies.ItemsSource = movies;
            
            start();
        }
        private void start()
        {
            // Skrýt hlavní okno pro autorizaci
            wasAccessed = false;
            ResizeMode = ResizeMode.NoResize;
            accessWindow = new AccessWindow(this);
        }
        public  void setReports()
        {
            // Pouze pro admina
            if (user.privilege == 3)
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
                {
                    string SELECT = "SELECT TOP 1 * FROM \"Report\"";

                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            decimal reportID = dataReader.GetDecimal(0); // ID
                            decimal userID = dataReader.GetDecimal(1); // UserID
                            string message = Convert.ToString(dataReader.GetValue(2)); // Message
                            string sourceName = Convert.ToString(dataReader.GetValue(3)); // Username

                            MessageBox.Show(sourceName  + " (" + "ID: " + userID + "):\n\n" + message, "ReportID: " + reportID);
                        }
                    }
                    cmd.CommandText = "DELETE TOP(1) FROM \"Report\"";
                    cmd.ExecuteNonQuery();
                }
            }
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
         * object[1] DateTime   - Rok Vydání
         * object[2] String     - Název Režiséra
         * object[3] string[]   - Názvy Herců
         * object[4] string[]   - Názvy Žánrů
         * 
         * Volá se ve Formuláři NewMovieForm.
        */
        public void registerMovie(object[] movieData)
        {
            // TODO INSERT INTO DATABASE
            string nazev = (string)movieData[0];
            DateTime rok = (DateTime)movieData[1];
            string reziser = (string)movieData[2];
            string[] herci = (string[])movieData[3];
            string[] zanry = (string[])movieData[4];
            
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                string INSERT = "INSERT INTO \"Movie\" (Name, Releasedate) Values ('" + nazev + "','" + rok + "')";
                try
                {
                    SqlCommand cmd = new SqlCommand(INSERT, cnn);
                    cnn.Open();

                    // ověřit, jestli existuje
                    cmd.CommandText = "SELECT MovieID FROM \"Movie\" WHERE Name='" + nazev + "'";
                    
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 0)
                    {
                        System.Windows.MessageBox.Show("Movie already exists.\nPlease try again.", "FAIL");
                        return;
                    }

                    cmd.CommandText = INSERT;
                    // přidá film do Movie tabulky
                    cmd.ExecuteNonQuery();
                    // zjistíme nově vytvořené id filmu a přidáme film do naší kolekce
                    cmd.CommandText = "SELECT MovieID FROM \"Movie\" WHERE Name='" + nazev + "'";
                    decimal movieId = Convert.ToDecimal(cmd.ExecuteScalar());

                    Movie m = new Movie(movieId, nazev, rok);
                    m.director = reziser;
                    m.cast = herci;
                    m.genre = zanry;
                    movies.Add(m);

                    cmd.CommandText = "INSERT INTO \"Cast\" (FullName) Values ('" + reziser + "')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT CastID FROM \"Cast\" WHERE FullName='" + reziser + "'";
                    decimal castId = Convert.ToDecimal(cmd.ExecuteScalar());

                    cmd.CommandText = "INSERT INTO \"Role\" (MovieID, Name, Salary, CastID) Values ('" + movieId + "','director','130000','" + castId + "')";
                    cmd.ExecuteNonQuery();
                    
                    foreach (string name in herci)
                    {
                        cmd.CommandText = "INSERT INTO \"Cast\" (FullName) Values ('" + name + "')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "SELECT CastID FROM \"Cast\" WHERE FullName='" + name + "'";
                        castId = Convert.ToDecimal(cmd.ExecuteScalar());

                        cmd.CommandText = "INSERT INTO \"Role\" (MovieID, Name, Salary, CastID) Values ('" + movieId + "','actor','50000','" + castId + "')";
                        cmd.ExecuteNonQuery();
                    }
                    decimal genreId;

                    foreach (string genre in zanry)
                    {
                        cmd.CommandText = "INSERT INTO \"Genre\" (Name) Values ('" + genre + "')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "SELECT GenreID FROM \"Genre\" WHERE Name='" + genre + "'";
                        genreId = Convert.ToDecimal(cmd.ExecuteScalar());

                        cmd.CommandText = "INSERT INTO \"Genremix\" (MovieID, GenreID) Values ('" + movieId + "','" + genreId + "')";
                        cmd.ExecuteNonQuery();
                    }

                    f.Dispose();
                    f = null;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void deleteMovie(object sender, RoutedEventArgs e)
        {
            // TODO DELETE FROM DATABASE
            

        }

        private void displayMovie(object sender, SelectionChangedEventArgs args)
        {
            movieWindow = new MovieWindow(this, (Movie)args.AddedItems[0]);
        }

        public void setGuiElements()
        {
            switch (user.privilege)
            {
                case 3: // Admin
                    txtUserMode.Text = "Admin"; break;
                case 2: // Moderator
                    btnAddMovie.IsEnabled = false;
                    btnDeleteMovie.IsEnabled = false;
                    txtUserMode.Text = "Moderator";
                    break;
                case 1: // User
                    btnAddMovie.IsEnabled = false;
                    btnDeleteMovie.IsEnabled = false;
                    txtUserMode.Text = "Uživatel";
                    break;
            }
            txtKarma.Text = user.karma.ToString();
            txtUserLogin.Text = user.login;
        }
        public void setMovies()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    string SELECT = "SELECT * FROM \"Movie\"";

                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (movies.Count != 0)
                        {
                            while (dataReader.Read())
                            {
                                decimal movieId = dataReader.GetDecimal(0); // ID
                                string name = dataReader.GetString(1); // Název
                                DateTime d = dataReader.GetDateTime(2); // Datum vydání

                                bool exists = false;

                                foreach (Movie m in movies)
                                    if (movieId == m.id)
                                        exists = true;
                                if(!exists)
                                    movies.Add(new Movie(movieId, name, d));
                            }
                        }
                        else
                        {
                            while (dataReader.Read())
                            {
                                decimal movieId = dataReader.GetDecimal(0); // ID
                                string name = dataReader.GetString(1); // Název
                                DateTime d = dataReader.GetDateTime(2); // Datum vydání
                                movies.Add(new Movie(movieId, name, d));
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
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

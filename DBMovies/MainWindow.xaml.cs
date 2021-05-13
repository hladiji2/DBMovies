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
         * object[2] String     - ID Režiséra
         * object[3] string[]   - IDs Herců
         * object[4] string[]   - Názvy Žánrů
         * 
         * Volá se ve Formuláři NewMovieForm.
        */
        public void registerMovie(object[] movieData)
        {
            string nazev = (string) movieData[0];
            DateTime rok = (DateTime) movieData[1];
            decimal reziserID = (decimal) movieData[2];
            List<decimal> herciID = (List<decimal>) movieData[3];
            List<decimal> zanryID = (List<decimal>) movieData[4];
            
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

                    cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + reziserID + "'";
                    m.director = Convert.ToString(cmd.ExecuteScalar());

                    cmd.CommandText = "INSERT INTO \"Role\" (MovieID, CastID, Salary, Name) values ('" + movieId + "','" + reziserID + "','250000','director')";
                    cmd.ExecuteNonQuery();

                    string[] herci = new string[herciID.Count];
                    for (int i = 0; i < herciID.Count; i++)
                    {
                        cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + herciID[i] + "'";
                        herci[i] = Convert.ToString(cmd.ExecuteScalar());

                        cmd.CommandText = "INSERT INTO \"Role\" (MovieID, CastID, Salary, Name) values ('" + movieId + "','" + herciID[i] + "','100000','actor')";
                        cmd.ExecuteNonQuery();
                    }
                    m.cast = herci;

                    string[] zanry = new string[zanryID.Count];
                    for (int i = 0; i < zanryID.Count; i++)
                    {
                        cmd.CommandText = "SELECT Name FROM \"Genre\" WHERE GenreID='" + zanryID[i] + "'";
                        zanry[i] = Convert.ToString(cmd.ExecuteScalar());

                        cmd.CommandText = "INSERT INTO \"Genremix\" (MovieID, GenreID) Values ('" + movieId + "','" + zanryID[i] + "')";
                        cmd.ExecuteNonQuery();
                    }
                    m.genre = zanry;

                    movies.Add(m);

                    f.Dispose();
                    f = null;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO
        private void deleteMovie(object sender, RoutedEventArgs e)
        {
            

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

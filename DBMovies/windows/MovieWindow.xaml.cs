using DBMovies.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class MovieWindow : Window
    {
        MainWindow mainWindow;

        ReportForm f;
        Movie movie;


        public MovieWindow(MainWindow mainWindow, Movie movie)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.movie = movie;

            lsbComments.ItemsSource = movie.comments;

            Title = movie.name.ToString();
            tbName.Text = movie.name.ToString();

            updateFromDBS();
            
            mainWindow.Hide();
            setGuiElements();
            Show();
        }

        private void updateFromDBS() 
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    List<decimal> Ids = new List<decimal>();

                    string SELECT = "SELECT GenreID FROM \"Genremix\" WHERE MovieID='" + movie.id + "'";

                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    // ---------------------- Actors AND Genres --------------------------------
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            Ids.Add(dataReader.GetDecimal(0)); // IDs

                    string[] genreById = new string[Ids.Count];

                    for (int i = 0; i < Ids.Count; i++)
                    {
                        cmd.CommandText = "SELECT Name FROM \"Genre\" WHERE GenreID='" + Ids[i] + "'";
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                            while (dataReader.Read())
                                genreById[i] = dataReader.GetString(0);
                    }

                    string tmp = "";
                    foreach (string s in genreById)
                        tmp += s + ", ";

                    movie.genre = genreById;
                    tbGenres.Text = tmp;

                    Ids = new List<decimal>();
                    cmd.CommandText = "SELECT CastID FROM \"Role\" WHERE MovieID='" + movie.id + "'";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            Ids.Add(dataReader.GetDecimal(0)); // IDs

                    string[] castById = new string[Ids.Count];

                    for (int i = 0; i < Ids.Count; i++)
                    {
                        cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + Ids[i] + "'";
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                            while (dataReader.Read())
                                castById[i] = dataReader.GetString(0);
                    }

                    tmp = "";
                    for (int i = 1; i < castById.Length; i++)
                    {
                        tmp += castById[i] + ", ";
                    }
                    movie.cast = genreById;
                    tbActors.Text = tmp;
                    tbDirector.Text = castById[0];
                    // ---------------------------------------------------------------------------

                    // TODO



                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void rateMovie(object sender, SelectionChangedEventArgs e)
        {
            // Při změně hodnocení v ComboBoxu
            // TODO změna v databázi
            // UPDATE DATABASE
            //cmbRating.SelectedIndex;


            /*
            scoreArray[1] = cmbRating.SelectedIndex;
            tbScore.Text = ((double)(scoreArray[0] + scoreArray[1])/2).ToString();
            */
        }

        private void addComment(object sender, RoutedEventArgs e)
        {
            if (f == null)
            {
                f = new ReportForm("movie");
                f.lblMessage.Text = "Přidej komentář";
                f.Text = "Komentář";
                f.Show();
            }
            else
            {
                f.Dispose();
                f = null;
            }
        }

        public void registerComment(string newComment)
        {
            // TODO INSERT INTO DATABASE
            movie.comments.Add(newComment);

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                string INSERT = "INSERT INTO \"Comment\" (Content) Values ('" + newComment  + "')";
                try
                {
                    SqlCommand cmd = new SqlCommand(INSERT, cnn);
                    cnn.Open();

                    // přidá film do Movie tabulky
                    cmd.ExecuteNonQuery();
                    // zjistíme nově vytvořené id filmu a přidáme film do naší kolekce
                    cmd.CommandText = "SELECT CommentID FROM \"Comment\" WHERE Content='" + newComment + "'";
                    decimal commentId = Convert.ToDecimal(cmd.ExecuteScalar());

                    cmd.CommandText = "INSERT INTO \"Review\" (UserID, CommentID, MovieID, DateCreated) Values ('" + mainWindow.user.id + "','" + commentId + "','" + movie.id + "','" + DateTime.Now.ToString("dd.MM.yyyy") +  "')";
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            btnAddComment.IsEnabled = false;
        }

        private void deleteComment(object sender, RoutedEventArgs e)
        {
            // TODO ListBox metoda (asi) Selected
            // pokud nebude označený prvek v komentářích GUI, tak zobraz Warning Zprávu
            // pokud je označený komentář, tak
            
        }

        private void adminReport(object sender, RoutedEventArgs e)
        {
            if (f == null)
            {
                f = new ReportForm("admin");
                f.Show();
            }
            else
            {
                f.Dispose();
                f = null;
            }
        }

        public void registerReport(string report)
        {
            // TODO INSERT INTO DATABASE

        }

        public void setGuiElements()
        {
            switch (mainWindow.user.privilege)
            {
                // TODO změnit viditelnost prvků gui podle oprávnění
                case 3: // Admin
                    cmbRating.IsEnabled = false;
                    btnAddComment.IsEnabled = false;
                    btnAdminReport.IsEnabled = false;
                    btnDeleteComment.IsEnabled = false;
                    break;
                case 2: // Moderator
                    cmbRating.IsEnabled = false;
                    btnAddComment.IsEnabled = false;
                    break;
                case 1: // Uživatel
                    btnAdminReport.IsEnabled = false;
                    btnDeleteComment.IsEnabled = false;
                    break;
            }
        }

        // Metoda pro zajištění přístupu do oken
        protected override void OnClosing(CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}

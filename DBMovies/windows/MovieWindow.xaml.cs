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

            Title = tbName.Text = movie.name.ToString();

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
                    cnn.Open();
                    updateGenres(cnn);
                    updateActors(cnn);
                    updateDirector(cnn);
                    updateComments(cnn);
                    updateScore(cnn);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void updateGenres(SqlConnection cnn)
        {
            List<decimal> Ids = new List<decimal>();
            SqlCommand cmd = new SqlCommand("SELECT GenreID FROM \"Genremix\" WHERE MovieID='" + movie.id + "'", cnn);

            using (SqlDataReader dataReader = cmd.ExecuteReader())
                while (dataReader.Read())
                    Ids.Add(dataReader.GetDecimal(0));

            string[] genresById = new string[Ids.Count];

            for (int i = 0; i < Ids.Count; i++)
            {
                cmd.CommandText = "SELECT Name FROM \"Genre\" WHERE GenreID='" + Ids[i] + "'";
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        genresById[i] = dataReader.GetString(0);
            }

            movie.genre = genresById;
            tbGenres.Text = movie.getGenreNames();
        }
        private void updateActors(SqlConnection cnn)
        {
            List<decimal> Ids = new List<decimal>();
            SqlCommand cmd = new SqlCommand("SELECT CastID FROM \"Role\" WHERE MovieID='" + movie.id + "' AND Name='actor'", cnn);

            using (SqlDataReader dataReader = cmd.ExecuteReader())
                while (dataReader.Read())
                    Ids.Add(dataReader.GetDecimal(0));

            string[] castById = new string[Ids.Count];

            for (int i = 0; i < Ids.Count; i++)
            {
                cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + Ids[i] + "'";
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        castById[i] = dataReader.GetString(0);
            }

            movie.cast = castById;
            tbActors.Text = movie.getActorsNames();
        }
        private void updateDirector(SqlConnection cnn)
        {
            SqlCommand cmd = new SqlCommand("SELECT CastID FROM \"Role\" WHERE MovieID='" + movie.id + "' AND Name='director'", cnn);
            decimal directorID = Convert.ToDecimal(cmd.ExecuteScalar());

            cmd.CommandText = "SELECT FullName FROM \"Cast\" WHERE CastID='" + directorID + "'";
            movie.director = cmd.ExecuteScalar().ToString();
            tbDirector.Text = movie.director;
        }
        private void updateComments(SqlConnection cnn)
        {
            List<decimal> Ids = new List<decimal>();
            SqlCommand cmd = new SqlCommand("SELECT CommentID FROM \"Review\" WHERE Review.MovieID='" + movie.id + "'", cnn);

            using (SqlDataReader dataReader = cmd.ExecuteReader())
                while (dataReader.Read())
                    Ids.Add(dataReader.GetDecimal(0));

            if (Ids.Count == 0) return;

            if(movie.comments.Count == 0)
            {
                for (int i = 0; i < Ids.Count; i++)
                {
                    cmd.CommandText = "SELECT Content FROM \"Comment\" WHERE Comment.CommentID='" + Ids[i] + "'";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            movie.comments.Add(dataReader.GetString(0));
                }
            }
            else
            {
                for (int i = Ids.Count; i < Ids.Count; i++)
                {
                    cmd.CommandText = "SELECT Content FROM \"Comment\" WHERE Comment.CommentID='" + Ids[i] + "'";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            movie.comments.Add(dataReader.GetString(0));
                }
            }
        }
        private void updateScore(SqlConnection cnn)
        {
            List<decimal> Ids = new List<decimal>();
            SqlCommand cmd = new SqlCommand("SELECT RatingID FROM \"Review\" WHERE Review.MovieID='" + movie.id + "' AND RatingID IS NOT NULL", cnn);

            using (SqlDataReader dataReader = cmd.ExecuteReader())
                while (dataReader.Read())
                    Ids.Add(dataReader.GetDecimal(0));
                
            if (Ids.Count == 0)
            {
                tbScore.Text = "0";
                return;
            }

            decimal sum = 0;

            for (int i = 0; i < Ids.Count; i++)
            {
                cmd.CommandText = "SELECT Numberrating FROM \"Rating\" WHERE Rating.RatingID='" + Ids[i] + "'";
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        sum += dataReader.GetDecimal(0);
            }

            decimal avg = sum / Ids.Count;

            tbScore.Text = Convert.ToString(avg);
        }
        private void rateMovie(object sender, SelectionChangedEventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    cnn.Open();
                    List<decimal> Ids = new List<decimal>();
                    SqlCommand cmd = new SqlCommand("SELECT ReviewID FROM \"Review\" WHERE Review.UserID='" + mainWindow.user.id + "' AND Review.MovieID='" + movie.id + "' AND RatingID IS NULL", cnn);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            Ids.Add(dataReader.GetDecimal(0));

                    if (Ids.Count != 0)
                    {
                        // INSERT INTO Rating -> UPDATE DATABASE
                        cmd.CommandText = "INSERT INTO \"Rating\" (Numberrating) Values ('" + cmbRating.SelectedIndex + "'); SELECT SCOPE_IDENTITY()";
                        decimal id = Convert.ToDecimal(cmd.ExecuteScalar());
                        cmd.CommandText = "UPDATE \"Review\" SET RatingID='" + id + "' WHERE Review.UserID='" + mainWindow.user.id + "' AND Review.MovieID='" + movie.id + "'";
                        cmd.ExecuteNonQuery();
                        cmbRating.IsEnabled = false;
                    }
                }
                catch (SqlException b)
                {
                    Console.WriteLine(b.Message);
                }
                finally
                {
                    updateScore(cnn);
                }
            }
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
            string formattedMessage = mainWindow.user.login + ": " + newComment;

            movie.comments.Add(formattedMessage);

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    string INSERT = "INSERT INTO \"Comment\" (Content) Values ('" + formattedMessage + "')";
                    SqlCommand cmd = new SqlCommand(INSERT, cnn);
                    cnn.Open();

                    // přidá film do Movie tabulky
                    cmd.ExecuteNonQuery();
                    // zjistíme nově vytvořené id filmu a přidáme film do naší kolekce
                    cmd.CommandText = "SELECT CommentID FROM \"Comment\" WHERE Content='" + formattedMessage + "'";
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
            cmbRating.IsEnabled = true;
        }
        // TODO
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
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO \"Report\" (UserID, Name, Message) Values ('"+ mainWindow.user.id + "','" + mainWindow.user.name + "','Name: " + movie.name + "\n" + report +  "')", cnn);
                    cmd.ExecuteNonQuery();
                    btnAdminReport.IsEnabled = false;
                }
                catch (SqlException b)
                {
                    Console.WriteLine(b.Message);
                }
            }
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

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    string SELECT = "SELECT ReviewID FROM \"Review\" WHERE Review.UserID='" + mainWindow.user.id + "' AND Review.MovieID='" + movie.id + "'";

                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 0)
                        btnAddComment.IsEnabled = false;

                    List<decimal> Id = new List<decimal>();
                    cmd.CommandText = "SELECT ReviewID FROM \"Review\" WHERE Review.UserID='" + mainWindow.user.id + "' AND Review.MovieID='" + movie.id + "' AND RatingID IS NULL";

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            Id.Add(dataReader.GetDecimal(0));

                    if (Id.Count != 0)
                        cmbRating.IsEnabled = true;
                    else
                        cmbRating.IsEnabled = false;
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
            mainWindow.Show();
        }
    }
}

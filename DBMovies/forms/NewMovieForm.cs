using System;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class NewMovieForm : Form
    {
        public NewMovieForm()
        {
            InitializeComponent();
            txtMovieName.Text = "Matrix";
            txtReleaseDate.Text = "1.1.1999";
            txtDirector.Text = "Wachowski";
            txtActors.Text = "Keanu Revees, Laurence Fishburne";
            txtGenre.Text = "Akční, Sci-fi";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtMovieName.Text != "" && txtDirector.Text != "" &&
               txtActors.Text != "" && txtGenre.Text != "" && txtReleaseDate.Text != "")
                processData();
            else
                MessageBox.Show("Movie parameters are incomplete.\nPlease try again.", "FAIL");
        }

        private void processData()
        {
            // TODO Kolik jednotek dat do databáze?
            object[] newMovieData = new object[5];
            // Název Filmu
            newMovieData[0] = txtMovieName.Text;
            // Rok Vydání
            newMovieData[1] = getRelaseDateTime();
            // Jméno Režiséra
            newMovieData[2] = txtDirector.Text;

            // KOLEKCE Herců
            newMovieData[3] = getActorsNames();

            // KOLEKCE Žánrů
            newMovieData[4] = getGenreNames();

            // Předává ze současného formuláře do metody Hlavního okna
            ((MainWindow) System.Windows.Application.Current.MainWindow).registerMovie(newMovieData);
        }
        private DateTime getRelaseDateTime() 
        {
            string[] release = txtReleaseDate.Text.Split('.');
            return new DateTime(Convert.ToInt32(release[2]), Convert.ToInt32(release[1]), Convert.ToInt32(release[0]));
        }

        private string[] getActorsNames()
        {
            string[] tmpLsActors = txtActors.Text.Split(',');
            string[] lsActors = new string[tmpLsActors.Length];

            for (int i = 0; i < tmpLsActors.Length; i++)
                lsActors[i] = tmpLsActors[i].Trim();

            return lsActors;
        }
        private string[] getGenreNames()
        {
            string[] tmpLsGenres = txtGenre.Text.Split(',');
            string[] lsGenres = new string[tmpLsGenres.Length];

            for (int i = 0; i < tmpLsGenres.Length; i++)
                lsGenres[i] = tmpLsGenres[i].Trim();

            return lsGenres;
        }
    }
}

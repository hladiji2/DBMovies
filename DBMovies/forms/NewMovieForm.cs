using DBMovies.forms;
using DBMovies.windows;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class NewMovieForm : Form
    {
        public NewMovieForm()
        {
            InitializeComponent();
            txtMovieName.Text = "Matrix 2";
            txtReleaseDate.Text = "1.1.2003";
            txtDirector.Text = "12";
            txtActors.Text = "13, 14";
            txtGenre.Text = "3, 11";
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
            // ID Režiséra
            newMovieData[2] = Convert.ToDecimal(txtDirector.Text);

            // KOLEKCE ID Herců
            newMovieData[3] = getActorIds();

            // KOLEKCE ID Žánrů
            newMovieData[4] = getGenreIds();

            // Předává ze současného formuláře do metody Hlavního okna
            ((MainWindow) System.Windows.Application.Current.MainWindow).registerMovie(newMovieData);
        }
        private DateTime getRelaseDateTime() 
        {
            string[] release = txtReleaseDate.Text.Split('.');
            return new DateTime(Convert.ToInt32(release[2]), Convert.ToInt32(release[1]), Convert.ToInt32(release[0]));
        }

        private List<decimal> getActorIds()
        {
            List<decimal> Ids = new List<decimal>();
            string[] tmpLsActors = txtActors.Text.Split(',');

            for (int i = 0; i < tmpLsActors.Length; i++)
                Ids.Add(Convert.ToDecimal(tmpLsActors[i].Trim()));

            return Ids;
        }
        private List<decimal> getGenreIds()
        {
            List<decimal> Ids = new List<decimal>();
            string[] tmpLsGenres = txtGenre.Text.Split(',');

            for (int i = 0; i < tmpLsGenres.Length; i++)
                Ids.Add(Convert.ToDecimal(tmpLsGenres[i].Trim()));

            return Ids;
        }

        private void btnHelp1_Click(object sender, EventArgs e)
        {
            new InfoAdminWindow("cast").Show();
        }
        private void btnHelp2_Click(object sender, EventArgs e)
        {
            new InfoAdminWindow("genre").Show();
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            new NewGenreForm().Show();
        }

        private void btnAddCast_Click(object sender, EventArgs e)
        {
            new NewCastForm().Show();
        }
    }
}

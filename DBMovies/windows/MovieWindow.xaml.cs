using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class MovieWindow : Window
    {
        MainWindow mainWindow;

        AdminReportForm f;

        public MovieWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            mainWindow.Hide();
            Show();
            setGuiElements();
        }

        private void rateMovie(object sender, SelectionChangedEventArgs e)
        {
            // Při změně hodnocení v ComboBoxu
            // TODO změna v databázi
            // UPDATE DATABASE

            //cmbRating.SelectedIndex;
        }

        private void addComment(object sender, RoutedEventArgs e)
        {
            // Jednoduchý dialog pouze s textboxem jako oblast pro komentář
            // Nesmí být prázdný 

            // Po stisknutí Ok se přidá do filmu, na který se zrovna kouká
            // aktualizace databáze komentářů
        }

        private void deleteComment(object sender, RoutedEventArgs e)
        {

        }

        private void adminReport(object sender, RoutedEventArgs e)
        {
            if (f == null)
            {
                f = new AdminReportForm();
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
            switch (mainWindow.user.privilegeLevel)
            {
                // TODO změnit viditelnost prvků gui podle oprávnění
                case 0: // Admin
                    cmbRating.IsEnabled = false;
                    btnAddComment.IsEnabled = false;
                    btnAdminReport.IsEnabled = false;
                    btnDeleteComment.IsEnabled = false;
                    break;
                case 1: // Moderator
                    cmbRating.IsEnabled = false;
                    btnAddComment.IsEnabled = false;
                    break;
                case 3: // Uživatel
                    btnAdminReport.IsEnabled = false;
                    btnDeleteComment.IsEnabled = false;
                    break;
            }
        }
    }
}

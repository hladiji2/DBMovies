using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DBMovies
{
    public partial class MovieWindow : Window
    {
        MainWindow mainWindow;

        ReportForm f;

        public MovieWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            mainWindow.Hide();
            Show();
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

        // Metoda pro zajištění přístupu do oken
        protected override void OnClosing(CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}

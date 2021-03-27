using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBMovies
{
    /// <summary>
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class Access_Window : Window
    {
        private MainWindow mainWindow;
        public bool mainWindowAccessed { get; private set; }
        public Access_Window(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            mainWindowAccessed = false;
            ResizeMode = ResizeMode.NoResize;

            Show();
            if (isDBConnected(mainWindow.cnns))
                status.Background = Brushes.Green;
        }
        public bool isDBConnected(string cnns)
        {
            using (SqlConnection cnn = new SqlConnection(cnns))
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
        }

        private void authorize(object sender, RoutedEventArgs e)
        {
            object[] userData = getUserDataIfExists(txtUserLogin.Text, txtUserPassword.Password);

            if (userData.GetValue(0) != null)
            {
                //TODO SWITCH předat informace o uživateli Hlavnímu oknu
                switch (userData.GetValue(0))
                {
                    case 0: mainWindow.txtUserMode.Text = "Admin"; break;
                    case 1: mainWindow.txtUserMode.Text = "Moderator"; break;
                    case 2: mainWindow.txtUserMode.Text = "Uživatel"; break;
                }
                mainWindow.txtUserLogin.Text = txtUserLogin.Text;
                mainWindowAccessed = true;

                Hide();
                mainWindow.Show();
            }
            else
            {
                txtUserLogin.Text = "";
                txtUserPassword.Password = "";
                MessageBox.Show("Wrong username or password.\nPlease try again.","FAIL");
            }
        }

        //TODO
        private object[] getUserDataIfExists(string userName, string password)
        {
            // PRO TEST
            return new object[4];
            using (SqlConnection connection = new SqlConnection(mainWindow.cnns))
            {
                connection.Open();
                string SELECT = @"SELECT * FROM !!! WHERE !!!=" + userName + " AND !!!=" + password;
                // TODO              ??počet sloupců dat uživatele??
                object[] userData = new object[4];

                using (SqlCommand command = new SqlCommand(SELECT, connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // TODO       ??počet sloupců dat uživatele??
                        userData[0] = dataReader.GetValue(0);
                        userData[1] = dataReader.GetValue(1);
                        userData[2] = dataReader.GetValue(2);
                    }
                }
                return userData;
            }
        }
        /// <summary>
        /// Metoda pro zajištění přístupu do oken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            // Pokud nebylo zpřístupněno hlavní okno přes autorizaci, tak manuálně vypne Hlavní okno a tím i celou aplikaci
            // Pokud bylo zpřístupněno ==>
            // TODO na zajištění tlačítka pro autorizaci jiného uživatele, ať není nutno restartovat aplikaci
            if (!mainWindowAccessed)
                mainWindow.Close();
            else
                mainWindow.Show();
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            mainWindowAccessed = false;
            Close();
        }

        
    }
}

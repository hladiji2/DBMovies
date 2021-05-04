using DBMovies.model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using System.Diagnostics;

namespace DBMovies
{
    public partial class AccessWindow : Window
    {
        private MainWindow mainWindow;
        public User s;
        public AccessWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            mainWindow.Hide();
            ResizeMode = ResizeMode.NoResize;

            Show();
            if (isDBConnected())
                status.Background = Brushes.Green;
        }
        public bool isDBConnected()
        {
            txtUserLogin.Text = "hladiji2";
            txtUserPassword.Password = "pwd";

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    cnn.Open();
                    if (cnn.State == ConnectionState.Open)
                        return true;
                    else
                        return false;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        private void authorize(object sender, RoutedEventArgs e)
        {
            object[] userData = getUserDataIfExists(txtUserLogin.Text, txtUserPassword.Password);
            
            if (userData.GetValue(0) != null)
            {
                switch (userData.GetValue(1))
                {
                    case 1: mainWindow.txtUserMode.Text = "Uživatel"; break;
                    case 2: mainWindow.txtUserMode.Text = "Moderátor"; break;
                    case 3: mainWindow.txtUserMode.Text = "Admin"; break;
                }
                mainWindow.txtUserLogin.Text = (string) userData.GetValue(2);
                mainWindow.wasAccessed = true;
                //TODO informace o uživateli pro ostatní okna
                mainWindow.user = new User((decimal)userData.GetValue(0),(string) userData.GetValue(2) ,(decimal)userData.GetValue(3), (decimal)userData.GetValue(1));

                Hide();
                mainWindow.setGuiElements();
                mainWindow.setMovies();
                mainWindow.Show();
            }
            else
            {
                txtUserLogin.Text = "";
                MessageBox.Show("Wrong username or password.\nPlease try again.", "FAIL");
            }
            
        }

        private object[] getUserDataIfExists(string login, string password)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    object[] userData = new object[4];
                    
                    string SELECT = "SELECT UserID, PermissionID, Username, Karma FROM \"User\" WHERE Username='" + login + "' AND Password='" + password + "'";
                   
                    SqlCommand cmd = new SqlCommand(SELECT, cnn);
                    cnn.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            userData[0] = dataReader.GetDecimal(0); // ID
                            userData[1] = dataReader.GetDecimal(1); // Úroveň práv
                            userData[2] = dataReader.GetString(2); // Login
                            userData[3] = dataReader.GetDecimal(3); // Karma
                        }
                    }
                    return userData;
                }
                catch (SqlException)
                {
                    return new object[] { null };
                }
            }
        }

        // Metoda pro zajištění přístupu do oken
        private void Window_Closed(object sender, EventArgs e)
        {
            // Pokud nebylo zpřístupněno hlavní okno přes autorizaci, tak manuálně vypne Hlavní okno a tím i celou aplikaci
            if (!mainWindow.wasAccessed)
                mainWindow.Close();
            else
                mainWindow.Show();
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            mainWindow.wasAccessed = false;
            Close();
        }
    }
}

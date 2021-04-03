using DBMovies.model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace DBMovies
{
    public partial class AccessWindow : Window
    {
        private MainWindow mainWindow;
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
            using (OracleConnection cnn = new OracleConnection(ConfigurationManager.ConnectionStrings["cnns1"].ConnectionString))
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
            // PRO TEST
            object[] userData = new object[3] { txtUserLogin.Text.ToString(), 42, null};
            switch (txtUserLogin.Text)
            {
                case "Admin": userData.SetValue((byte)0, 2); break;
                case "Mod": userData.SetValue((byte)1, 2); break;
                case "User": userData.SetValue((byte)2, 2); break;
            }
            


            //object[] userData = getUserDataIfExists(txtUserLogin.Text, txtUserPassword.Password);

            if (userData.GetValue(0) != null)
            {
                //TODO SWITCH předat informace o uživateli Hlavnímu oknu
                switch (userData.GetValue(2))
                {
                    case 0: mainWindow.txtUserMode.Text = "Admin"; break;
                    case 1: mainWindow.txtUserMode.Text = "Moderátor"; break;
                    case 2: mainWindow.txtUserMode.Text = "Uživatel"; break;
                }
                mainWindow.txtUserLogin.Text = txtUserLogin.Text;
                mainWindow.wasAccessed = true;
                //TODO informace o uživateli pro ostatní okna
                mainWindow.user = new User((string)userData.GetValue(0), (int)userData.GetValue(1), (byte)userData.GetValue(2)); ;

                Hide();
                mainWindow.setGuiElements();
                mainWindow.Show();
            }
            else
            {
                txtUserLogin.Text = "";
                txtUserPassword.Password = "";
                MessageBox.Show("Wrong username or password.\nPlease try again.", "FAIL");
            }
        }

        //TODO
        private object[] getUserDataIfExists(string login, string password)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnns0"].ConnectionString))
            {
                try
                {
                    object[] userData = new object[3];
                    cnn.Open();
                    string SELECT = @"SELECT * FROM !!! WHERE !!!=" + login + " AND !!!=" + password;
                    // TODO              ??počet sloupců dat uživatele??
                    
                    using (SqlCommand cmd = new SqlCommand(SELECT, cnn))
                    {
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            // TODO       ??počet sloupců dat uživatele??
                            userData[0] = dataReader.GetString(0); // Login
                            userData[1] = dataReader.GetInt32(1); // Karma
                            userData[2] = dataReader.GetByte(2); // Úroveň práv
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

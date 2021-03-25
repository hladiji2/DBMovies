using System;
using System.Collections.Generic;
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
        MainWindow mainWindow;
        public Access_Window(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            // Skrýt hlavní okno pro autorizaci
            mainWindow.Hide();

            ResizeMode = ResizeMode.NoResize;
            Show();
            if (mainWindow.isDBConnected(mainWindow.cnns))
                status.Background = Brushes.Green;
        }

        private void authorize(object sender, RoutedEventArgs e)
        {
            object[] userData = getUserDataIfExists(txtUserLogin.Text, txtUserPassword.Password);

            if (userData.GetValue(0) != null)
            {
                //TODO předat informace o uživateli Hlavnímu oknu
                switch (userData.GetValue(0))
                {
                    case 0: mainWindow.txtUserMode.Text = "Admin"; break;
                    case 1: mainWindow.txtUserMode.Text = "Moderator"; break;
                    case 2: mainWindow.txtUserMode.Text = "Uživatel"; break;
                }
                mainWindow.txtUserLogin.Text = txtUserLogin.Text;

                Close();
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
            // return new object[4];
            using (SqlConnection connection = new SqlConnection(mainWindow.cnns))
            {
                connection.Open();
                string SELECT = @"SELECT * FROM !!! WHERE !!!=" + userName + " AND !!!=" + password;
                // TODO              ??počet sloupců dat??
                object[] userData = new object[4];

                using (SqlCommand command = new SqlCommand(SELECT, connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // TODO              ??počet sloupců dat??
                        userData[0] = dataReader.GetValue(0);
                        userData[1] = dataReader.GetValue(1);
                        userData[2] = dataReader.GetValue(2);
                    }
                }
                return userData;
            }
        }
    }
}

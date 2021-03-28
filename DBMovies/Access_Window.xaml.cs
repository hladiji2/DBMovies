﻿using DBMovies.model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media;
using System.Configuration;

namespace DBMovies
{
    public partial class Access_Window : Window
    {
        private MainWindow mainWindow;
        public Access_Window(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            ResizeMode = ResizeMode.NoResize;

            Show();
            if (isDBConnected())
                status.Background = Brushes.Green;
        }
        public bool isDBConnected()
        {
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

            if (userData.GetValue(2) != null)
            {
                //TODO SWITCH předat informace o uživateli Hlavnímu oknu
                switch (userData.GetValue(2))
                {
                    case 0: mainWindow.txtUserMode.Text = "Admin"; break;
                    case 1: mainWindow.txtUserMode.Text = "Moderator"; break;
                    case 2: mainWindow.txtUserMode.Text = "Uživatel"; break;
                }
                mainWindow.txtUserLogin.Text = txtUserLogin.Text;
                mainWindow.wasAccessed = true;
                //TODO informace o uživateli pro ostatní okna
                mainWindow.user = new User((string) userData.GetValue(0), (int) userData.GetValue(1), (byte) userData.GetValue(2)); ;
                
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
                cnn.Open();
                string SELECT = @"SELECT * FROM !!! WHERE !!!=" + login + " AND !!!=" + password;
                // TODO              ??počet sloupců dat uživatele??
                object[] userData = new object[3];

                using (SqlCommand command = new SqlCommand(SELECT, cnn))
                {
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // TODO       ??počet sloupců dat uživatele??
                        userData[0] = (string) dataReader.GetValue(0); // Login
                        userData[1] = (int) dataReader.GetValue(1); // Karma
                        userData[2] = (byte) dataReader.GetValue(2); // Úroveň práv
                    }
                }
                return userData;
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

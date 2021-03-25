using System;
using System.Collections.Generic;
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
        public Access_Window()
        {
            InitializeComponent();
        }

        public static bool userExists;
        public static byte userPrivileges;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* TODO
             * Pokud existuje uživatel se správným loginem/heslem v databázi, vrátí true 
            if (txtUser == .... && txtPass == ....)
                ...
             */
            if (true)
            {
                userExists = true;
                Close();
            }
            else
            {
                txtUser.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Wrong Password or Username");
            }
        }

        private void AW_Closed(object sender, EventArgs e)
        {
            // TODO
            // Zjisti správné oprávnění pro uživatele (Správce, Mod, Uživatel)
            // userPrivileges == GET FROM DATABASE
            userPrivileges = 0;
        }

    }
}

﻿using System;
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
    public partial class Movie_Window : Window
    {
        public Movie_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Comment()
        {
            // Jednoduchý dialog pouze s textboxem jako oblast pro komentář
            // Nesmí být prázdný 

            // Po stisknutí Ok se přidá do filmu, na který se zrovna kouká
            // aktualizace databáze komentářů
        }
        
        private void Rate_MovieCombo()
        {
            // Při změně hodnocení v ComboBoxu
            // 
            ComboBox.
        }

    }
}

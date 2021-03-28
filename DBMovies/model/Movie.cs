using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DBMovies.model
{
    class Movie
    {
        private string name { get; set; }
        private byte avgScore { get; set; }
        private ObservableCollection<string> comments { get; set; }
        private string[] cast { get; set; }
        private string[] genre { get; set; }
        private string releaseDate { get; set; }

        private string titleWithYear { get; set; }
        private Image image;

        // TODO, Image
        public Movie(string name, ObservableCollection<string> comments, string[] cast, string[] genre, string releaseDate)
        {
            this.name = name;
            avgScore = 0;
            this.comments = comments;
            this.cast = cast;
            this.genre = genre;
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        // Pouze základní informace
        public Movie(string name, string releaseDate)
        {
            this.name = name;
            avgScore = 0;
            comments = new ObservableCollection<string>();
            cast = new string[0];
            genre = new string[0];
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        // RANDOM
        public Movie()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i+=10)
            {
                char ch = (char)r.Next(i, i+2);
                name += char.ToString(ch);
            }
            avgScore = 0;
            comments = new ObservableCollection<string> { "Super", "Pecka", "Fuuuuj", "Mohlo by být lepší" };
            cast = new string[0];
            genre = new string[0];
            releaseDate = r.Next(1900, 2022).ToString();
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        public char getFirstLetter()
        {
            return char.Parse(name.Substring(0, 1));
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}\nAverage Score: {1}\n# of comments: {2}\n# of cast: {3}\n# of genre: {4}\nRelease Date: {5}",
                name, avgScore, comments.Count, cast.Length, genre.Length, releaseDate);
        }
    }
}

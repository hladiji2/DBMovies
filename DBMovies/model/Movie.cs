using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DBMovies.model
{
    public class Movie
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public byte avgScore { get; set; }
        public ObservableCollection<string> comments { get; set; }
        public string[] cast { get; set; }
        public string[] genre { get; set; }
        public DateTime releaseDate { get; set; }
        public string titleWithYear { get; set; }

        public static Random r = new Random();


        public Movie(decimal id, string name, DateTime releaseDate)
        {
            this.id = id;
            this.name = name;
            avgScore = 0;
            this.comments = null;
            this.cast = null;
            this.genre = null;
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        public Movie(int id, string name, ObservableCollection<string> comments, string[] cast, string[] genre, DateTime releaseDate)
        {
            this.id = id;
            this.name = name;
            avgScore = 0;
            this.comments = comments;
            this.cast = cast;
            this.genre = genre;
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        // RANDOM - základní informace
        public Movie(string name, DateTime releaseDate)
        {
            this.name = name;
            avgScore = (byte)r.Next(0, 11);
            // comments = new string[0];
            comments = new ObservableCollection<string> { "Super", "Pecka", "Fuuuuj", "Mohlo být lepší" };
            cast = new string[0];
            genre = new string[0];
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        // RANDOM
        public Movie()
        {
            id = r.Next(0, int.MaxValue);
            for (int i = 0; i < 100; i+=10)
            {
                char ch = (char)r.Next(1, i+2);
                name += char.ToString(ch);
            }
            avgScore = (byte)r.Next(0,11);
            comments = new ObservableCollection<string> { "Super", "Pecka", "Fuuuuj", "Mohlo být lepší" };
            cast = new string[0];
            genre = new string[0];
            releaseDate = new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 30));
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        public override string ToString()
        {
            return string.Format(
                "ID: {0}\nName: {1}\nAverage Score: {2}\n# of comments: {3}\n# of cast: {4}\n# of genre: {5}\nRelease Date: {6}",
                id, name, avgScore, comments.Count, cast.Length, genre.Length, releaseDate);
        }
    }
}

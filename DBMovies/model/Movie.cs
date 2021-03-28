using System;
using System.Collections.Generic;
using System.Drawing;

namespace DBMovies.model
{
    class Movie
    {
        private string name { get {return name; } set { name = value; } }
        private byte avgScore { get { return avgScore; } set { avgScore = value; } }
        private List<string> comments { get { return comments; } set { comments = value; } }
        private string[] cast { get { return cast; } set { cast = value; } }
        private string[] genre { get { return genre; } set { genre = value; } }
        private string releaseDate { get { return releaseDate; } set { releaseDate = value; } }

        public string titleWithYear { get { return titleWithYear; } set { titleWithYear = value; } }
        public Image image;

        // TODO, Image
        public Movie(string name, List<string> comments, string[] cast, string[] genre, string releaseDate)
        {
            this.name = name;
            avgScore = 0;
            this.comments = comments;
            this.cast = cast;
            this.genre = genre;
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1)}", name, releaseDate);
        }

        // Pouze základní informace
        public Movie(string name, string releaseDate)
        {
            this.name = name;
            avgScore = 0;
            comments = new List<string>();
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1)}", name, releaseDate);
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
            releaseDate = r.Next(1900, 2022).ToString();
            comments = new List<string> {"Super", "Pecka", "Fuuuuj", "Mohlo by být lepší" };
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

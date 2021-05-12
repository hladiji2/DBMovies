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
        public ObservableCollection<string> comments { get; set; }
        public string director { get; set; }
        public string[] cast { get; set; }
        public string[] genre { get; set; }
        public DateTime releaseDate { get; set; }
        public string titleWithYear { get; set; }

        public Movie(decimal id, string name, DateTime releaseDate)
        {
            this.id = id;
            this.name = name;
            comments = new ObservableCollection<string>();
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        public Movie(int id, string name, ObservableCollection<string> comments, string[] cast, string[] genre, DateTime releaseDate)
        {
            this.id = id;
            this.name = name;
            this.comments = comments;
            this.cast = cast;
            this.genre = genre;
            this.releaseDate = releaseDate;
            titleWithYear = string.Format("{0} ({1})", name, releaseDate);
        }

        public string getGenreNames()
        {
            string tmp = "";
            for (int i = 0; i < genre.Length; i++)
                tmp += genre[i] + ", ";
            return tmp;
        }

        public string getActorsNames()
        {
            string tmp = "";
            for (int i = 0; i < cast.Length; i++)
                tmp += cast[i] + ", ";
            return tmp;
        }
    }
}

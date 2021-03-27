using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DBMovies.model
{
    class Movie
    {
        public string name { get {return name; } set { name = value; } }
        public byte avgScore { get { return avgScore; } set { avgScore = value; } }
        public ArrayList comments { get { return comments; } set { comments = value; } }
        public string[] cast { get { return cast; } set { cast = value; } }
        public string[] genre { get { return genre; } set { genre = value; } }

        // TODO
        public Movie(string name)
        {
            this.name = name;
            avgScore = 0;
            comments = new ArrayList();
        }

        public Movie()
        {
            Random r = new Random();
            for (int i = 0; i < 1000; i+=10)
            {
                char ch = (char)r.Next(i, i+2);
                name += char.ToString(ch);
            }
            avgScore = 0;
            comments = new ArrayList() {"Super", "Pecka", "Fuuuuj", "Mohlo by být lepší" };
        }

        // TODO
        public char getFirstLetter()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}\nAverage Score: {1}\n# of comments: {2}\n# of cast: {3}\n# of genre: {4}",
                name, avgScore, comments.Count, cast.Length, genre.Length);
        }
    }
}

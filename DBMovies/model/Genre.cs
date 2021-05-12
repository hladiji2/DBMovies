namespace DBMovies.model
{
    class Genre
    {
        public decimal GenreID { get; set; }
        public string Name { get; set; }
        public Genre(decimal id, string name) 
        {
            GenreID = id;
            Name = name;
        }
    }
}

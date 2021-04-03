namespace DBMovies.model
{
    class Cast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string role { get; set; }

        public Cast(int id, string name, string surname, string role)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.role = role;
        }

        public string getFullName()
        {
            return string.Format("{0} {1}", name, surname);
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}\nSurname: {1}\nRole: {2}",
                name, surname, role);
        }

    }
}

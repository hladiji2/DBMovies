namespace DBMovies.model
{
    class Member
    {
        private string name { get; set; }
        private string surname { get; set; }
        private string role { get; set; }

        public Member(string name, string surname, string role)
        {
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

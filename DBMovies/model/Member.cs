namespace DBMovies.model
{
    class Member
    {
        private string name { get { return name; } set { name = value; } }
        private string surname { get { return surname; } set { surname = value; } }
        private string role { get { return role; } set { role = value; } }

        public Member(string name, string surname, string role)
        {
            this.name = name;
            this.surname = surname;
            this.role = role;
        }

        public string getFullName()
        {
            return name + " " + surname;
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}\nSurname: {1}\nRole: {2}",
                name, surname, role);
        }

    }
}

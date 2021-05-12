using System;

namespace DBMovies.model
{
    public class User
    {
        public decimal id;
        public string login { get; set; }
        public string name { get; set; }
        public decimal karma { get; set; }
        public decimal privilege { get; set; }

        // Úplná tvorba
        public User(decimal id, string login, decimal karma, decimal privilege, string name)
        {
            this.id = id;
            this.login = login;
            this.karma = karma;
            this.privilege = privilege;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format(
                "Login: {0}\nLevel Access: {1}\nKarma: {2}",
                login, privilege, karma);
        }
    }
}

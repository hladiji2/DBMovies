using System;

namespace DBMovies.model
{
    public class User
    {
        public int id;
        public string login { get; set; }
        public int karma { get; set; }
        public int privilege { get; set; }

        // Úplná tvorba
        public User(string login, int karma, int privilege)
        {
            this.login = login;
            this.karma = karma;
            this.privilege = privilege;
        }

        // Admin
        public User(string adminLogin)
        {
            login = adminLogin;
            karma = 9000;
            // TODO Může se změnit
            privilege = 2;
        }

        // Náhodně generovaný
        public User()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                char ch = (char)r.Next(0, 65536);
                login += char.ToString(ch);
            }
            karma = r.Next(0, 9000);
            // TODO může se změnit
            privilege = Convert.ToInt32(r.Next(0,3));
        }
        public override string ToString()
        {
            return string.Format(
                "Login: {0}\nLevel Access: {1}\nKarma: {2}",
                login, privilege, karma);
        }
    }
}

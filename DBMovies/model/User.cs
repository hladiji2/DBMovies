using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMovies.model
{
    class User
    {
        private string login { get { return login; } set { login = value; } }
        private int karma { get { return karma; } set { karma = value; } }
        private byte privilegeLevel 
        {   get { return privilegeLevel; } 
            set 
            { 
                // TODO, pokud bude změna
                if (!(value < 0 && value > 3))
                    privilegeLevel = value; 
            } 
        }

        // Úplná tvorba
        public User(string login, int karma, byte privilegeLevel)
        {
            this.login = login;
            this.karma = karma;
            this.privilegeLevel = privilegeLevel;
        }

        // Admin
        public User(string adminLogin)
        {
            login = adminLogin;
            karma = 9000;
            // TODO Může se změnit
            privilegeLevel = 0;
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
            login += r.Next(1, 100);
            karma = r.Next(0, 9000);
            // TODO může se změnit
            privilegeLevel = (byte) r.Next(0,3);
        }
        public override string ToString()
        {
            return string.Format(
                "Login: {0}\nLevel Access: {1}\nKarma: {2}",
                login, privilegeLevel, karma);
        }
    }
}

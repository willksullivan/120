using System;
using System.Collections.Generic;
using System.Text;

namespace pa3_jollyJackpotLand
{
    class User
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int Gil { get; set; }

        public User (string userName, string password, int gil)
        {
            UserName = userName;
            Password = password;
            Gil = gil;
        }
    }
}

using System;
using System.IO;

namespace pa3_jollyJackpotLand
{
    class Program
    {
        static void Main(string[] args)
        {
            User currentUser = loginPrompt();

        }

        public static User loginPrompt()
        {
            User currentUser = new User("", "", 0);
            int decision;

            Console.WriteLine("Welcome to Jolly Jackpot Land");

            do
            {
                Console.WriteLine("1. New Player 2. Existing user");
                decision = int.Parse(Console.ReadLine());
            } while (decision != 1 && decision != 2);

            //New Player creation
            if (decision == 1)
            {
                currentUser = newUser();
                saveNewUser(currentUser);
            }
            else
            {
                //currentUser = existingUser();

            }




            return currentUser;
        }

        public static User newUser()
        {
            string currentUserName, currentPassword;
            User currentUser;

            Console.WriteLine("Please enter your username");
            currentUserName = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            currentPassword = Console.ReadLine();

            currentUser = new User(currentUserName, currentPassword, 500);

            return currentUser;
        }

        //public static User existingUser()
        //{
        //    User existingUser;
        //    return existingUser;
        //}

        public static void saveNewUser(User currentuser)
        {

            string path = @"C:\Users\willk\Documents\GitHub\120\pa3_jollyJackpotLand\players.txt";

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(User.UserName);
                sw.WriteLine(User.Password);
                sw.WriteLine(User.Gil);
                sw.WriteLine();
            }
        }
    }
}

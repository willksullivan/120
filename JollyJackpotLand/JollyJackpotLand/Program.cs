using System;

namespace JollyJackpotLand
{
    class Program
    {
        static void Main(string[] args)
        {

            int gil = 500;

            string[] lines = { "sully", "password", "0" };
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
            do
            {
                //login
                // - new user
                // - load user

                //main menu
                // --  choose game
                // -- opportunity to exit

                //slot

                //blackjack

                //roulette
            } while (gil <= 1000);
        }
    }
}

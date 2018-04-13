using System;
using System.IO;

namespace pa3_jollyJackpotLand
{
    class Program
    {
        static void Main(string[] args)
        {
            int gil = 50;
            gil = login(gil);

            
        }

        public static int login(int gil)
        {
            int playerStatus = 0;
            bool fileEmpty = false;

            Console.WriteLine("Welcome to Jolly Jackpot Land");
            playerStatus = playerDecision();

            //New Player
            if (playerStatus == 1)
            {
                gil = 500;
                saveGil(gil);
            }
            //current player
            else
            {
                gil = LoadGil();
            }
            
            return gil;
        }

        public static int playerDecision()
        {
            int decision;
            do
            {
                Console.WriteLine("1. New Game 2. Load Game");
                decision = int.Parse(Console.ReadLine());
            } while (decision != 1 && decision != 2);
            return decision;
        }
        public static int LoadGil()
        {
            int gil;

            gil = int.Parse(System.IO.File.ReadAllText(@"C:\Users\WKS Desktop\Documents\GitHub\120\pa3_jollyJackpotLand\players.txt"));
            return gil;
        }
        public static void saveGil(int gil)
        {
            System.IO.File.WriteAllText(@"C:\Users\WKS Desktop\Documents\GitHub\120\pa3_jollyJackpotLand\players.txt", gil.ToString());
        }



    }
}

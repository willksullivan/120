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
            do
            {
                mainMenu(gil);
            } while (gil < 1000 && gil > 0);


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
        public static void mainMenu(int gil)
        {
            int menuDecision;
            do
            {
                Console.WriteLine("1.Slot Machine 2.Dice Toss 3.Roulette Wheel 4.Restart Game 5.Save and Exit");
                menuDecision = int.Parse(Console.ReadLine());
            } while (menuDecision != 1 && menuDecision != 2 && menuDecision != 3 && menuDecision != 4 && menuDecision != 5);


            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!check gil
            switch (menuDecision)
            {
                case 1:
                    gil = slotMachine(gil);
                    break;
                case 2:
                    gil = diceToss(gil);
                    break;
                case 3:
                    gil = rouletteWheel(gil);
                    break;
                case 4:
                    saveGil(500);
                    Console.Clear();
                    Console.WriteLine("Your gil is now at 500");
                    break;
                case 5:
                    saveGil(gil);
                    System.Environment.Exit(1);
                    break;
            }

        }

        public static int slotMachine(int gil)
        {
            int wager, decision1, decision2, decision3,slot1,slot2,slot3,matches = 0;
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            


            displayGil(gil);
            wager = wagerAmount(gil);

            //display instructions
            Console.WriteLine("This is the slot machine game. You will pick three words.");
            Console.WriteLine("If none of the words match, you will lose your wager");
            Console.WriteLine("If 1 of your words match, you will break even");
            Console.WriteLine("If 2 of your words match, you will double your wager");
            Console.WriteLine("If all 3 of your words match, you will triple your wager");

            //read user choices
            do
            {
                Console.WriteLine("1.Elephant 2. Computer 3.Football 4. Resume 5. Capstone 6. Crimson");
                decision1 = int.Parse(Console.ReadLine());
            } while (decision1 != 1 && decision1 != 2 && decision1 != 3 && decision1 != 4 && decision1 != 5 && decision1 != 6);
            
            do
            {
                Console.WriteLine("1.Elephant 2. Computer 3.Football 4. Resume 5. Capstone 6. Crimson");
                decision2 = int.Parse(Console.ReadLine());
            } while ((decision2 != 1 && decision2 != 2 && decision2 != 3 && decision2 != 4 && decision2 != 5 && decision2 != 6) || decision2 == decision1);
            do
            {
                Console.WriteLine("1.Elephant 2. Computer 3.Football 4. Resume 5. Capstone 6. Crimson");
                decision3 = int.Parse(Console.ReadLine());
            }
            while ((decision3 != 1 && decision3 != 2 && decision3 != 3 && decision3 != 4 && decision3 != 5 && decision3 != 6) || (decision3 == decision1) || (decision3 ==decision2));

            //display user choices
            Console.WriteLine("Your three decision are:");
            Console.WriteLine(decision1);
            Console.WriteLine(decision2);
            Console.WriteLine(decision3);

            //run slot machine
            slot1 = rnd1.Next(1, 6);
            slot2 = rnd2.Next(1, 6);
            slot3 = rnd3.Next(1, 6);

            //compare numbers

            if (decision1 == slot1)
            {
                matches++;
            }
            if (decision1 == slot2)
            {
                matches++;
            }
            if (decision1 == slot3)
            {
                matches++;
            }

            if (decision2 == slot1)
            {
                matches++;
            }
            if (decision2 == slot2)
            {
                matches++;
            }
            if (decision2 == slot3)
            {
                matches++;
            }

            if (decision3 == slot1)
            {
                matches++;
            }
            if (decision3 == slot2)
            {
                matches++;
            }
            if (decision3 == slot3)
            {
                matches++;
            }

            if(matches == 0)
            {
                gil -= wager;
            }

            if(matches == 2)
            {
                gil = gil + (wager * 2);
            }

            if(matches == 3)
            {
                gil = gil + (wager * 3);
            }

            Console.WriteLine("You chose " + decision1 + "," + decision2 + "," + decision3);
            Console.WriteLine("the machine chose " + slot1 + "," + slot2 + "," + slot3);
            Console.WriteLine("You have " + matches + "matches");
            displayGil(gil);
            return gil;
        }

        public static int diceToss(int gil)
        {
            return gil;
        }

        public static int rouletteWheel(int gil)
        {
            return gil;
        }

        public static void displayGil(int gil)
        {
            Console.WriteLine("Your current Gil amount is " + gil);
        }

        public static int wagerAmount(int gil)
        {
            int wager;
            do
            {
                Console.WriteLine("How much gil would you like to wager");
                wager = int.Parse(Console.ReadLine());
            } while (wager > gil || wager < 0);

            return wager;
        }


    }
}

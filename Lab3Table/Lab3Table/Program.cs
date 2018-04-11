using System;

namespace Lab3Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i <5; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j <= 9; j++)
                {
                    Console.Write(i*j + " ");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
    }
}

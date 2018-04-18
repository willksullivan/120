using System;
using System.Collections.Generic;
using System.Text;


namespace pa5_movie
{
    class Transactions
    {
        public static string path = @"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\movies.txt";
        //private string path = @"C:\Users\willk\Documents\GitHub\120\pa5_movie\movies.txt";

        public int transactionID { get; set; }
        public string userEmail { get; set; }
        public int movieID { get; set; }
        public DateTime rentalDate { get; set; }
        public DateTime returnDate { get; set; }

        public Transactions (int _transactionID, string _userEmail, int _movieID, DateTime _rentalDate, DateTime _returnDate)
        {
            this.transactionID = _transactionID;
            this.userEmail = _userEmail;
            this.movieID = _movieID;
            this.rentalDate = _rentalDate;
            this.returnDate = _returnDate;
        }

        public static List<Transactions> loadTransactions()
        {
            string line;
            List<Transactions> transactionsList = new List<Transactions>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                transactionsList.Add(new Transactions(int.Parse(words[0]), words[1], int.Parse(words[2]), DateTime.Parse(words[3]), DateTime.Parse(words[4])));
            }

            file.Close();
            return movieList;
        }

        public static List<Transactions> makeTransaction(int rentalID)
        {
            List<Transactions> transactionsList = new List<Transactions>();
            Transactions transactions = null;

            transactions.transactionID = transactionsList[transactionsList.Count - 1].transactionID + 1;
            Console.WriteLine("Please enter your email");
            transactions.userEmail = Console.ReadLine();
            transactions.movieID = rentalID;
            transactions.rentalDate = makeDate();
            transactions.returnDate = null;

            return transationsList;

            saveTransactions();
        }

        public static DateTime makeDate()
        {
            DateTime dateAndTime = DateTime.Now;
            Console.WriteLine(dateAndTime.ToString("MM/dd/yyyy"));
        }

        public static void saveTransactions(List<Transactions> transactionList)
        {
            using (TextWriter tw = new StreamWriter((path)))
            {

                foreach (var transaction in transactionList)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", transaction.transactionID.ToString(), transaction.userEmail,transaction.movieID.ToString(), transaction.rentalDate.ToString(), transaction.returnDate.ToString()));
                }
            }
        }
















        //rent a movie
        //return a movie


    }
}

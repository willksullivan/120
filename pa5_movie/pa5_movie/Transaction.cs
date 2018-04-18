using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pa5_movie
{
    class Transaction
    {
        public static string path = @"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\transactions.txt";
        //private string path = @"C:\Users\willk\Documents\GitHub\120\pa5_movie\movies.txt";

        public int transactionID { get; set; }
        public string userEmail { get; set; }
        public int movieID { get; set; }
        public DateTime rentalDate { get; set; }
        public DateTime returnDate { get; set; }

        public Transaction(int _transactionID, string _userEmail, int _movieID, DateTime _rentalDate, DateTime _returnDate)
        {
            this.transactionID = _transactionID;
            this.userEmail = _userEmail;
            this.movieID = _movieID;
            this.rentalDate = _rentalDate;
            this.returnDate = _returnDate;
        }

        public static List<Transaction> loadTransaction()
        {
            string line;
            List<Transaction> TransactionList = new List<Transaction>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                TransactionList.Add(new Transaction(int.Parse(words[0]), words[1], int.Parse(words[2]), DateTime.Parse(words[3]), DateTime.Parse(words[4])));
            }

            file.Close();
            return TransactionList;
        }

        public static List<Transaction> makeTransaction(int rentalID)
        {
            List<Transaction> transactionList = new List<Transaction>();
            transactionList = Transaction.loadTransaction();
            Transaction transaction = new Transaction(0," ",0,DateTime.Now,DateTime.Now);

            transaction.transactionID = transactionList[transactionList.Count - 1].transactionID + 1;
            Console.WriteLine("Please enter your email");
            transaction.userEmail = Console.ReadLine();
            transaction.movieID = rentalID;
            transaction.rentalDate = makeDate();
            transaction.returnDate = DateTime.MinValue;
            transactionList.Add(transaction);
            saveTransaction(transactionList);

            return transactionList;

            
        }

        public static DateTime makeDate()
        {
            DateTime dateAndTime = DateTime.Now;
            string date = dateAndTime.ToString("MM/dd/yyyy");
            return dateAndTime;
        }

        public static void saveTransaction(List<Transaction> transactionList)
        {
            using (TextWriter tw = new StreamWriter((path)))
            {

                foreach (var transaction in transactionList)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", transaction.transactionID.ToString(), transaction.userEmail, transaction.movieID.ToString(), transaction.rentalDate.ToString(), transaction.returnDate.ToString()));
                }
            }
        }
    }
}

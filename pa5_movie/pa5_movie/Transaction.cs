using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace pa5_movie
{
    class Transaction
    {
        //public static string path = @"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\transactions.txt";
        public static string path = @"C:\Users\willk\Documents\GitHub\120\pa5_movie\transactions.txt";

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

        public static List<Transaction> makeTransaction(int rentalID, string email)
        {
            //initialize variables
            List<Transaction> transactionList = new List<Transaction>();
            transactionList = Transaction.loadTransaction();
            Transaction transaction = new Transaction(0, " ", 0, DateTime.Now, DateTime.Now);

            //populate the transaction
            transaction.transactionID = transactionList[transactionList.Count - 1].transactionID + 1;
            transaction.userEmail = email;
            transaction.movieID = rentalID;
            transaction.rentalDate = makeDate();
            transaction.returnDate = DateTime.MinValue;

            //add the transaction to a list and save
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

        public static void viewRentedMovies(string email, List<Transaction> transactionList, List<Movie> movieList)
        {

            foreach (Transaction transaction in transactionList)
            {
                if (transaction.userEmail.Equals(email))
                {
                    Console.WriteLine(transaction.movieID);
                    foreach (Movie movie in movieList)
                    {
                        if (transaction.movieID == movie.movieID)
                        {
                            Console.WriteLine(movie.movieTitle);
                        }
                    }
                }
            }

        }

        //public static void returnTransaction(int rentalID, string email, List<Transaction> transactionList)
        //{
        //    //initialize variables
        //    transactionList = Transaction.loadTransaction();
        //    Transaction transaction = new Transaction(0, " ", 0, DateTime.Now, DateTime.Now);



        //    //populate the transaction
        //    transaction.transactionID = transactionList[transactionList.Count - 1].transactionID + 1;
        //    transaction.userEmail = email;
        //    transaction.movieID = rentalID;
        //    foreach (Transaction t in transactionList)
        //    {
        //        if (t.userEmail.Equals(email) && t.movieID == rentalID)
        //        {
        //            transaction.rentalDate = t.rentalDate;
        //        }
        //    }
        //    transaction.returnDate = makeDate();
        //    transactionList.Add(transaction);

        //    saveTransaction(transactionList);
        //}
        public static void returnTransaction(int movieID,string email)
        {
            List<Movie> movieList = new List<Movie>();
            List<Transaction> transactionList = loadTransaction();

            Transaction transaction = new Transaction(0," ",54,DateTime.Today,DateTime.Today);

            transaction.transactionID = transactionList[transactionList.Count - 1].transactionID + 1;
            transaction.userEmail = email;
            transaction.movieID = movieID;
            foreach(Transaction t in transactionList)
            {
                if(t.movieID == movieID && t.userEmail.Equals(email))
                {
                    transaction.rentalDate = t.rentalDate;
                }
            }
            transaction.returnDate = Transaction.makeDate();
            transactionList.Add(transaction);

            saveTransaction(transactionList);


        }

    }

}

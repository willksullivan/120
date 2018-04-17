using System;
using System.Collections.Generic;
using System.Text;

namespace pa5_movie
{
    class Transactions
    {
        public int transactionID { get; set; }
        public string userEmail { get; set; }
        public int movieID { get; set; }
        public DateTime rentalDate { get; set; }
        public DateTime returnDate { get; set; }

        public Transactions (int _transactionID, string _userEmail, int _movieID, DateTime _rentalDate, DateTime _returnDate)
        {
            transactionID = _transactionID;
            userEmail = _userEmail;
            movieID = _movieID;
            rentalDate = _rentalDate;
            returnDate = _returnDate;
        }

        public static void makeTransaction(int rentalID)
        {
            using (TextWriter tw = new StreamWriter((@"C:\Users\willk\Documents\GitHub\120\pa5_movie\transactions.txt")))
            {
                //get transactions list
                //make transaction id +1 of the last transaction



                foreach (var movie in myList)
                {
                    //tw.WriteLine(string.Format("{0},{1},{2},{3}\n", movie.movieID, movie.movieTitle, movie.genre, movie.inStock));
                    tw.WriteLine(string.Format("{0},{1},{2},{3}", movie.movieID, movie.movieTitle, movie.genre, movie.inStock));

                }
            }
        }
















        //rent a movie
        //return a movie


    }
}

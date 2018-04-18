using System;
using System.Collections.Generic;
using System.IO;

namespace pa5_movie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            List<Transaction> transactionList = new List<Transaction>();

            Console.WriteLine("What is your email?");
            string userEmail = Console.ReadLine();
            movieList = Movie.loadMovies();
            transactionList = Transaction.loadTransaction();


            Movie.returnMovie(movieList, userEmail, transactionList); ;
            
            
            /*
            //rent movie and make transaction
            int id = Movie.rentMovie(movieList);
            Transaction.makeTransaction(id,userEmail);
            

           */



            Console.ReadLine();

           
            
            






            
        }
    }


}

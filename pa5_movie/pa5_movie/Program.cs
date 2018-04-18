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

            movieList = Movie.loadMovies();

            int id = Movie.rentMovie(movieList);
            Transaction.makeTransaction(id);
            

           



            Console.ReadLine();

            Movie.viewMoviesToRent(movieList);
            int rentedID = Movie.rentMovie(movieList);
            
            






            Console.ReadLine();



            Console.ReadLine();
            
        }
    }


}

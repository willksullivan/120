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

            movieList = Movie.loadMovies();

            Movie.viewMoviesToRent(movieList);
            int rentedID = Movie.rentMovie(movieList);






            Console.ReadLine();



            Console.ReadLine();
            
        }
    }
}

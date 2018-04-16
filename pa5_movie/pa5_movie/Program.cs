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

            //delete movie
              //error check if a non int is entered




            movieList = Movie.loadMovies();

            movieList = Movie.deleteMovie(movieList);
            Console.ReadLine();
            
        }
    }
}

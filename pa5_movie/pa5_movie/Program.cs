using System;
using System.Collections.Generic;
using System.IO;

namespace pa5_movie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Movie> myList = new List<Movie>();
            Movie newMovie = new Movie(0, "Rambo", "Action", true);

            myList.Add(newMovie);
            myList.Add(new Movie(1, "American", "Comedy", false));
            myList.Add(new Movie(2, "Barney", "Genius", true));


            using (TextWriter tw = new StreamWriter(@"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\movies.txt"))
            {
                foreach (var movie in myList)
                {
                    tw.WriteLine(string.Format("# {0} {1} {2} {3}\n", movie.movieID, movie.movieTitle, movie.genre, movie.inStock));
                }
            }
        }
    }
}

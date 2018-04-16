using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace pa5_movie
{
    class Movie
    {
        public int movieID { get; set; }
        public string movieTitle { get; set; }
        public string genre { get; set; }
        public bool inStock { get; set; }

        public Movie(int _movieID, string _movieTitle, string _genre, bool _inStock)
        {
            this.movieID = _movieID;
            this.movieTitle = _movieTitle;
            this.genre = _genre;
            this.inStock = _inStock;
        }

        public static List<Movie> loadMovies()
        {

            string line;
            List<Movie> movieList = new List<Movie>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\movies.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                movieList.Add(new Movie(int.Parse(words[0]), words[1], words[2], bool.Parse(words[3])));
            }

            file.Close();
            return movieList;


        }

        public static void saveMovies(List<Movie> myList)
        {
            using (TextWriter tw = new StreamWriter(@"C:\Users\WKS Desktop\Documents\GitHub\120\pa5_movie\movies.txt"))
            {
                foreach (var movie in myList)
                {
                    //tw.WriteLine(string.Format("{0},{1},{2},{3}\n", movie.movieID, movie.movieTitle, movie.genre, movie.inStock));
                    tw.WriteLine(string.Format("{0},{1},{2},{3}", movie.movieID, movie.movieTitle, movie.genre, movie.inStock));

                }
            }
        }

        public static List<Movie> addMovie(List<Movie> list)
        {
            Movie newMovie = new Movie(67, " ", " ", true);

            newMovie.movieID = makeMovieId(list, newMovie);
            Console.WriteLine("What is the title of the movie?");
            newMovie.movieTitle = Console.ReadLine();
            newMovie.genre = getMovieGenre();
            newMovie.inStock = getMovieInStock();
            list.Add(newMovie);
            saveMovies(list);

            return list;
        }

        public static List<Movie> deleteMovie(List<Movie> list)
        {
            int decision;
            //displays movies
            foreach (Movie movie in list)
            {
                Console.WriteLine(movie.movieID + " " + movie.movieTitle + " " + movie.genre + " " + movie.inStock);
            }

            //accepts user's desired movie to be deleted
            do
            {
                Console.WriteLine("\nPlease press enter the ID of the movie that you would like to delete");
                Int32.TryParse(Console.ReadLine(),out decision);               
            } while (decision < 0 || decision > list.Count);

            //remove movie
            foreach (Movie m in list)
            {
                if(m.movieID == decision)
                {
                    list.Remove(m);
                    break;
                }
            }

            saveMovies(list);
            return list;
        }

        public static string getMovieGenre()
        {
            string genre;
            do
            {
                Console.WriteLine("A.action F.Family H.Horror S.Sci-Fi C.Comedy O.Other ");
                genre = Console.ReadLine();
            } while (genre != "A" && genre != "a" && genre != "F" && genre != "F" && genre != "H" && genre != "h" && genre != "S" && genre != "s" && genre != "C" && genre != "c" && genre != "O" && genre != "o");

            switch (genre)
            {
                case "A":
                case "a":
                    genre = "Action";
                    break;
                case "F":
                case "f":
                    genre = "Family";
                    break;
                case "H":
                case "h":
                    genre = "Horror";
                    break;
                case "S":
                case "s":
                    genre = "Sci-Fi";
                    break;
                case "C":
                case "c":
                    genre = "Comedy";
                    break;
                case "O":
                case "o":
                    genre = "Other";
                    break;
            }
            return genre;
        }

        public static bool getMovieInStock()
        {
            bool inStock = true;
            string reader;
            do
            {
                Console.WriteLine("In Stock? Y. N.");
                reader = Console.ReadLine();
            } while (reader != "Y" && reader != "y" && reader != "N" && reader != "n");

            if (reader == "Y" || reader == "y")
            {
                inStock = true;
            }
            else
            {
                inStock = false;
            }
            return inStock;
        }

        public static int makeMovieId(List<Movie> movieList, Movie movie)
        {
            movie.movieID = movieList[movieList.Count - 1].movieID + 1;
            return movie.movieID;
        }
    }
}



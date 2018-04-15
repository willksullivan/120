using System;
using System.Collections.Generic;
using System.Text;

namespace pa5_movie
{
    class Movie
    {
        public int movieID { get; private set; }
        public string movieTitle { get; set; }
        public string genre{ get; set; }
        public bool inStock { get; set; }

        public Movie(int _movieID, string _movieTitle, string _genre, bool _inStock)
        {
            this.movieID++;
            this.movieTitle = _movieTitle;
            this.genre = _genre;
            this.inStock = _inStock;
        }

    }
}



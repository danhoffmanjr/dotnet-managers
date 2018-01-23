using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    public class MovieRepo
    {
        private static List<Movie> _movies = new List<Movie>();
        private static int nextId = 0;

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
                return _movies.Find(movie => movie.Id == id);
        }

        public void AddMovie(Movie newMovie)
        {
            newMovie.Id = nextId++;
            _movies.Add(newMovie);
        }
    }
}

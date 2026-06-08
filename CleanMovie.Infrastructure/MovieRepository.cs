using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        //public static List<Movie> movies = new List<Movie>()
        //{
        //    new Movie {Id = 1, Name = "Baagbaan", Cost = 2},
        //    new Movie {Id = 2, Name = "Ham Aapke Hai Kon ?", Cost = 1},
    
        //};

        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return movie;
        }

        public Movie Delete(int id)
        {
            var data = _movieDbContext.Movies.Where(e => e.Id == id).SingleOrDefault();
            if(data != null)
            {
                _movieDbContext.Movies.Remove(data);
            }
            return null;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieDbContext.Movies.ToList();
            //_movieDbContext.Movies.ToList().ForEach(movie => {
            //return movies;
        }

        public Movie UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        Movie IMovieRepository.GetMovieById(int id)
        {
            var data = _movieDbContext.Movies.Where(e => e.Id == id).SingleOrDefault();
            return data;
            //if (data == null)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    return Ok(data);
            //}
        }
    }
}

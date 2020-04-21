using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Movie GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            return movie;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            var movies = _movieRepository.GetMoviesByGenre(genreId);
            return movies;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title,int pageIndex)
        {
            var movies = _movieRepository.GetMoviesByTitle(title,pageIndex);
            return movies;
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {


            return _movieRepository.GetTopGrossingMovies();
        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {
            var movies = _movieRepository.GetTopRatedMovies();
            return movies;
        }
    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        Movie GetMovieDetails(int id);

        IEnumerable<Movie> GetTopRatedMovies();

        IEnumerable<Movie> GetMoviesByTitle(string title,int pageIndex);
    }
}

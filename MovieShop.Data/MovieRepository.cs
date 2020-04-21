 using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        //because it inherits from repository<Movie>, which implement the 8 method in
        //the IRepository, so we just need to implement 2 method in the IMovieRepository
        public MovieRepository(MovieShopDbContext context) : base(context)
        {

        }
        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            var movies = _context.Genres.Where(g => g.Id == genreId).SelectMany(g=>g.Movies).ToList();
            return movies;
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            var movies = _context.Movies.OrderByDescending(m => m.Revenue).Include(m=>m.Genres).Take(20).ToList();
            return movies;
        }

        public override Movie GetById(int id)
        {
            //Get Movie by Id and also include Average Rating of that Movie
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null) return null;
            //Get average rating also later
            //var rating = movie.Reviews.Average(r => r.Rating);
            var rating = _context.Reviews.Where(r => r.MovieId == id).Average(r => r.Rating);
            if (rating > 0) movie.Rating = Math.Ceiling(rating * 100) / 100;

            return movie;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title, int pageIndex = 0)
        {
            var movies = _context.Movies.Where(m => m.Title.StartsWith(title)).OrderBy(m=>m.Title).Skip(20 * pageIndex).Take(20);
            return movies;
        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {
            var movies = _context.Movies.OrderByDescending(m => m.Reviews.Average(r => r.Rating)).Take(20);
            return movies;
        }
    }

    public interface IMovieRepository: IRepository<Movie>
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);

        IEnumerable<Movie> GetMoviesByTitle(string title, int pageIndex);

        IEnumerable<Movie> GetTopRatedMovies();

    }
}

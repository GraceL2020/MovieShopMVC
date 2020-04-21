using MovieShop.Data;
using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieShopDbContext())
            {
                //var genres = db.Genres.ToList();
                //var movies = db.Movies.Where(m => m.Title.StartsWith("a")).ToList();
                //var movies = db.Movies.ToList().Where(m => m.Title.StartsWith("A")).ToList();
                var movieService = new MovieService();

                var movie = movieService.GetMovieDetails(2);

                Console.WriteLine(movie.Id +" " + movie.Title);

                var movies = movieService.GetMoviesByGenre(4);
                Console.WriteLine(movies.Count());

                movies = movieService.GetMoviesByTitle("abc", 1);
                Console.WriteLine(movies.Count());

                movies = movieService.GetTopRatedMovies();
                Console.WriteLine(movies.Count());

                movies = movieService.GetTopGrossingMovies();
                Console.WriteLine(movies.Count());

                var genreService = new GenreService();
                var genres = genreService.GetAllGenres();
                Console.WriteLine(genres.Count());

                var castService = new CastService();
                var cast = castService.GetCastDetails(3);
                Console.WriteLine(cast.Name + " " + cast.MovieCasts.Count());

                var crewService = new CrewService();
                var crew = crewService.GetCrewDetails(3);
                Console.WriteLine(crew.Name + " " + crew.MovieCrews.Count());

                Console.ReadKey();
            }
             
        }
    }
}

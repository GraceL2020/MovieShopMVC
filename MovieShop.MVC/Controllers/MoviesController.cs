using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            //pass a object that implements the interface
            //MVC 5 requires parameterless constructor
            //but we need DI
            _movieService = movieService;
        }
        // GET: Movies
        //Routing
        [HttpGet]
        //[Route("")]
        public ActionResult Index()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
            //return View("test"); //return the view with different name
        }

        
        //[HttpGet]
        [Route("genres/{genreId}")]
        public ActionResult GenreMovies(int genreId)
        {
            //take genre id from url and then call movie service to get a list of movies
            //belonging to that genre.
            // return movies to the View and display as Imagetags inside the
            //bootstrap card with image urls as posterUrl from Movie table column
            // Create GetMoviesByGenre(int genreId) inside IMovieService and
            // implement that method call Movies Repository to get movies of that genre
            var movies = _movieService.GetMoviesByGenre(genreId).OrderBy(m=>m.Title).ToList();
            return View("MoviesByGenre",movies);
        }
    }
}
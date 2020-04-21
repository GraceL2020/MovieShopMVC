using MovieShop.MVC.Filters;
using MovieShop.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    [MovieShopExceptionFilter]
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //[LogActionFilter]
        //[MovieShopExceptionFilter]
        //[HandleError]
        public ActionResult Index()
        {
            //int x = 0;
            //int y = 5;
            //int z = y / x;

            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
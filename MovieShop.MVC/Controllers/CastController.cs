using MovieShop.Entities;
using MovieShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        // GET: Cast
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        [HttpPost]
        //public ActionResult Create(string castname, string profilePath, string gender, string tmdbUrl)
        public ActionResult Create(Cast cast)
        {
            _castService.AddCast(cast);
            return View();
        }
    }
}
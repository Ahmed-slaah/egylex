using egylex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Controllers
{
    public class UserController : Controller
    {
        IlogedInUser _db;
        public UserController(IlogedInUser db)
        {
            _db = db;
        }
        public IActionResult Home()
        {
            var AllMovies = _db.GetAllMovies().Take(10);
            ViewBag.AllMovies = AllMovies;

            var latestMovies = _db.GetLatestMovies().Take(10);
            ViewBag.latestMovies = latestMovies;

            var ActionMovies = _db.GetMovieByCategory("Action").Take(10);
            ViewBag.ActionMovies = ActionMovies;


            var AllSeries = _db.GetAllSeries().Take(10);
            ViewBag.AllSeries = AllSeries;

            var latestSeries = _db.GetLatestSeries().Take(10);
            ViewBag.latestSeries = latestSeries;

            var ActionSeries = _db.GetSerieByCategory("Action").Take(10);
            ViewBag.ActionSeries = ActionSeries;

            return View();
        }
        public IActionResult Movies()
        {
            var categories = _db.GetAllCategories();
            ViewBag.categories = categories;
            return View(_db.GetAllMovies());
        }
        public IActionResult MovieDetails(int id)
        {
            var movie = _db.Movie(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult MovieName(string movieName)
        {
            var movies = _db.GetMovieByName(movieName);
            return PartialView("~/Views/Shared/MoviePartialView.cshtml",movies);
        }
        public IActionResult MovieType(string tagName)
        {
            var movies = _db.GetMovieByCategory(tagName);
            return PartialView("~/Views/Shared/MoviePartialView.cshtml", movies);
        }

        public IActionResult Series()
        {
            var categories = _db.GetAllCategories();
            ViewBag.categories = categories;
            return View(_db.GetAllSeries());
        }
        public IActionResult SerieDetails(int id)
        {
            return View(_db.Seri(id));
        }
        [HttpPost]
        public IActionResult SerieName(string serirName)
        {
            var serie = _db.GetSerieByName(serirName);
            return PartialView("~/Views/Shared/SeriePartialView.cshtml", serie);
        }
        public IActionResult SerieType(string tagName)
        {
            var series = _db.GetSerieByCategory(tagName);
            return PartialView("~/Views/Shared/SeriePartialView.cshtml", series);
        }

        public IActionResult Season(int id)
        {
            var season = _db.Season(id);
            return PartialView("~/Views/Shared/SeasonPartialView.cshtml", season);
        }

        public IActionResult Episode(int id)
        {
            var episode = _db.Episode(id);
            return PartialView("~/Views/Shared/EpisodePartialView.cshtml", episode);
        }

    }
}

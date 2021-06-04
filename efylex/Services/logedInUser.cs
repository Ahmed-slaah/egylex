using efylex.Data;
using egylex.Models.Categories;
using egylex.Models.episodes;
using egylex.Models.Movies;
using egylex.Models.Seasons;
using egylex.Models.Series;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Services
{
    public interface IlogedInUser
    {
        //for movies operations
        public List<Movie> GetAllMovies();
        public List<Movie> GetLatestMovies();
        public Movie Movie(int MovieId);
        public List<Category> GetAllCategories();
        public List<Movie> GetMovieByName(string name);
        public List<Movie> GetMovieByCategory(string category);

        //for series operations
        public List<Serie> GetAllSeries();
        public Serie Seri(int id);
        public List<Serie> GetLatestSeries();
        public List<Serie> GetSerieByName(string name);
        public List<Serie> GetSerieByCategory(string category);

        //for season operations
        public Season Season(int id);

        //for episode operations
        public Episodes Episode(int id);


    }
    public class logedInUser: IlogedInUser
    {
        readonly ApplicationDbContext _db;
        public logedInUser(ApplicationDbContext db)
        {
            _db = db;
        }

        //start movies methods
        public List<Movie> GetAllMovies()
        {
            return _db.Movies.Include(a=>a.MoviesCategories).ThenInclude(a=>a.Category).ToList();
        }
        public List<Movie> GetLatestMovies()
        {
            return _db.Movies.Include(a => a.MoviesCategories)
                             .ThenInclude(a => a.Category)
                             .OrderBy(a => a.Date)
                             .ThenBy(a => a.Date).ToList();
                      //       .Where(a=>a.Date.Year == DateTime.Now.Year).ToList();
        }
        public Movie Movie(int MovieId)
        {
           
            return GetAllMovies().SingleOrDefault(m => m.MovieId == MovieId);
        }
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
        public List<Movie> GetMovieByName(string name)
        {
            
            return GetAllMovies().Where(m => m.MovieName.Contains(name)).ToList();
        }
        public List<Movie> GetMovieByCategory(string category)
        {
            return _db.MoviesCategories.Include(m => m.Movie)
                                .Include(c => c.Category)
                                .Where(m => m.Category.CategoryName == category)
                                .Select(a => a.Movie).ToList();
        }


        //start series methods
        public List<Serie> GetAllSeries()
        {
            return _db.Series.Include(s => s.SeriesCategories).ThenInclude(c => c.Category)
                       .Include(s => s.seasons)
                       .ToList();
        }
        public Serie Seri(int id)
        {
            return GetAllSeries().SingleOrDefault(a => a.SeriesId == id);
        }
        public List<Serie> GetLatestSeries()
        {
            return _db.Series.Include(s => s.SeriesCategories)
                             .ThenInclude(c => c.Category)
                             .Include(s => s.seasons)
                             .OrderBy(a => a.Date)
                             .ThenBy(a => a.Date).ToList();
        }
        public List<Serie> GetSerieByName(string name)
        {
            return GetAllSeries().Where(s=>s.SeriesName.Contains(name)).ToList();
        }
        public List<Serie> GetSerieByCategory(string category)
        {
            return _db.SeriesCategories.Include(s=>s.Serie)
                                .Include(c => c.Category)
                                .Where(m => m.Category.CategoryName == category)
                                .Select(a => a.Serie).ToList();
        }

        //start season methods
        public Season Season(int id)
        {
           return _db.Seasons.Include(a => a.Episodes).SingleOrDefault(s => s.SeasonId == id);
        }

        //start obiside methods 
        
        public Episodes Episode(int id)
        {
            return _db.Episodes.Include(s=>s.Season).ThenInclude(a=>a.Episodes).SingleOrDefault(a => a.EpisodeId == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieDatabaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMovieDatabaseRepository
{
    public class MovieRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;

        public MovieRepository()
        {
                BuildOptions();
        }

        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieDatabase"));
        }
        public bool AddMovie(Movie movieToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                
                Movie existingItem = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingItem == null)
                {
                    // doesn't exist, add it
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }

        }
        public List<Movie> GetAllMovies()
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.ToList();
            }
        }
        public Movie GetMovieById(int itemId)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.FirstOrDefault(x => x.Id == itemId);
            }
        }
        public List<Movie> GetMovieByTitle(string itemTitle)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                List<Movie> moviesReturned = new List<Movie>();

                foreach(Movie movie in db.Movies.Where(x => x.Title.Contains(itemTitle)))
                {
                    moviesReturned.Add(movie);
                }
               return moviesReturned;
            }
        }
        public List<Movie> GetMovieByGenre(string itemGenre)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                List<Movie> moviesReturned = new List<Movie>();

                foreach (Movie movie in db.Movies.Where(x => x.Genre == itemGenre))
                {
                    moviesReturned.Add(movie);
                }
                return moviesReturned;
            }
        }
        public void UpdateMovie(Movie itemToUpdate)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                db.Movies.Update(itemToUpdate);
                db.SaveChanges();
            }
        }
        public void DeleteMovie(Movie itemToDelete)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                db.Movies.Remove(itemToDelete);
                db.SaveChanges();
            }
        }
    }
}

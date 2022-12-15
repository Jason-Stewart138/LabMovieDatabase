using LabMovieDatabaseRepository;
using MovieDatabaseDTO;

namespace LabMovieDatabaseDomain
{
    public class MovieInteracter
    {
        private MovieRepository _repo;

        public MovieInteracter()
        {
            _repo = new MovieRepository();
        }

        public bool AddNewMovie(Movie movieToAdd)
        {
            if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
            {
                throw new ArgumentException("Title and Genre must contain valid text.");
            }
            return _repo.AddMovie(movieToAdd);
        }
        public List<Movie> GetAllMovies()
        {
            return _repo.GetAllMovies();
        }
        public bool GetMovieByIdIfExists(int movieId, out Movie movieToReturn)
        {
            Movie item = _repo.GetMovieById(movieId);
            movieToReturn = item;
            return movieToReturn != null;
        }
        public bool GetMovieByTitleIfExists(string movieTitle, out List<Movie> moviesOut)
        {
            List<Movie> movies = new List<Movie>(_repo.GetMovieByTitle(movieTitle));
            if(movies.Count == 0)
            {
                moviesOut = movies;
                return false;
            }
            else
            {
                moviesOut = movies;
                return true;
            }
            
        }
        public bool GetMovieByGenreIfExists(string movieGenre, out List<Movie> moviesOut)
        {
            List<Movie> movies = new List<Movie>(_repo.GetMovieByGenre(movieGenre));
            if (movies.Count == 0)
            {
                moviesOut = movies;
                return false;
            }
            else
            {
                moviesOut = movies;
                return true;
            }

        }
        public bool UpdateMovie(Movie movieToUpdate)
        {
            if (string.IsNullOrEmpty(movieToUpdate.Title) || string.IsNullOrEmpty(movieToUpdate.Genre))
            {
                throw new ArgumentException("Title and Genre must contain valid text.");
            }

            Movie item = _repo.GetMovieById(movieToUpdate.Id);

            if (item == null)
            {
                return false;
            }
            _repo.UpdateMovie(movieToUpdate);
            return true;
        }
        public bool DeleteMovie(int movieId)
        {
            Movie item = _repo.GetMovieById(movieId);
            if (item == null)
            {
                return false;
            }
            _repo.DeleteMovie(item);
            return true;
        }




    }
}
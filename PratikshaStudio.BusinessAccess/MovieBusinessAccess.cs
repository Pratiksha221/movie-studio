using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PratikshaStudio.BusinessEntities;
using PratikshaStudio.DataAccess;

namespace PratikshaStudio.BusinessAccess
{
   public class MovieBusinessAccess
    {
        private MovieDataAccess _movieDA;

        public MovieBusinessAccess()
        {
            _movieDA = new MovieDataAccess();
        }

        public List<MovieResponseBE> GetAllGenreId(MovieRequestBE movieRequest)
        {
            try
            {
                return _movieDA.GetMovies(movieRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MovieResponseBE GetMovieById(int MovieId)
        {
            try
            {
                return _movieDA.GetMovieById(MovieId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MovieCastBE> GetCastDetails(int MovieId)
        {
           
            try
            {
                return _movieDA.GetCastDetails(MovieId);
            }
            catch
            {
                throw;
            }
        }

        public void AddMovie(MovieRequestBE movieRequestBE)
        {
            try
            {
               _movieDA.AddMovie(movieRequestBE);
            }
            catch
            {
                throw;
            }
        }
    }
}

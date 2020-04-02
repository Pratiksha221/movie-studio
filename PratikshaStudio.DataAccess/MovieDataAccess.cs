using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PratikshaStudio.BusinessEntities;

namespace PratikshaStudio.DataAccess
{
   public class MovieDataAccess
    {
        private SqlConnection _connection;
        private string _connectionString;
        public MovieDataAccess()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=PratikshaDB;Integrated Security=true";
        }
        public List<MovieResponseBE> GetMovies(MovieRequestBE movieRequest)
        {
            List<MovieResponseBE> movieResponseList = new List<MovieResponseBE>();

            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var procedureName = "USP_GetMovieDetails";
                    _connection.Open();
                    SqlCommand command = new SqlCommand(procedureName, _connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Title", movieRequest.Title);
                    command.Parameters.AddWithValue("@GenreId", movieRequest.GenreId);
                    command.Parameters.AddWithValue("@DateOfRelease", movieRequest.DateOfRelease);
                    command.Parameters.AddWithValue("@Ratingid", movieRequest.RatingId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MovieResponseBE movieResponse = new MovieResponseBE();

                        movieResponse.MovieId = Convert.ToInt32(reader["MovieId"]);
                        movieResponse.Title = Convert.ToString(reader["Title"]);
                        movieResponse.GenreName = Convert.ToString(reader["GenreName"]);
                        movieResponse.RatingName = Convert.ToString(reader["RatingName"]);
                        movieResponse.DateOfRelease = Convert.ToDateTime(reader["DateOfRelease"]);

                        movieResponseList.Add(movieResponse);

                    }
                    reader.Close();
                    _connection.Close();
                    return movieResponseList;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void AddMovie(MovieRequestBE movieRequestBE)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                  
                    var query = " INSERT into Movie(Title,Description,DateOfRelease,GenreId,RatingId,length) values(@Title,@Description,@DateOfRelease,@GenreId,@RatingId,@length)";
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@Title", movieRequestBE.Title);
                    command.Parameters.AddWithValue("@Description", movieRequestBE.Description);
                    command.Parameters.AddWithValue("@GenreId", movieRequestBE.GenreId);
                    command.Parameters.AddWithValue("@DateOfRelease", movieRequestBE.DateOfRelease);
                    command.Parameters.AddWithValue("@Ratingid", movieRequestBE.RatingId);
                    command.Parameters.AddWithValue("@length", movieRequestBE.length);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }

            }
        }

        public MovieResponseBE GetMovieById(int MovieId)
        {
            MovieResponseBE movieResponse = new MovieResponseBE();
            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {


                    var query = "SELECT Title, Description , DateOfRelease ,length, GenreName, RatingName FROM Movie m INNER JOIN Genre g ON m.GenreId=g.GenreId INNER JOIN Rating r ON r.RatingId=m.RatingId WHERE MovieId=@MovieId";
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@MovieId", MovieId);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    movieResponse.Title = Convert.ToString(reader["Title"]);
                    movieResponse.GenreName = Convert.ToString(reader["GenreName"]);
                    movieResponse.DateOfRelease = Convert.ToDateTime(reader["DateOfRelease"]);
                    movieResponse.RatingName = Convert.ToString(reader["RatingName"]);
                    movieResponse.Description = Convert.ToString(reader["Description"]);
                    movieResponse.length = Convert.ToInt32(reader["length"]);
                    reader.Close();
                    return movieResponse;
                }
                catch
                {
                    throw;
                }
            }
        }
        public List<MovieCastBE> GetCastDetails(int MovieId)
        {
            //MovieCastBE movieCastBE = new MovieCastBE();
            List<MovieCastBE> movieCastList = new List<MovieCastBE>();
            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var query = "SELECT FirstName, LastName, Gender , Role  FROM Actor a INNER JOIN MovieCast mc ON mc.ActorId= a.ActorId INNER JOIN Movie m ON m.MovieId= mc.MovieId WHERE m.MovieId=@MovieId";

                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@MovieId", MovieId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MovieCastBE movieCastBE = new MovieCastBE();
                        movieCastBE.FirstName = Convert.ToString(reader["FirstName"]);
                        movieCastBE.LastName = Convert.ToString(reader["LastName"]);
                        movieCastBE.Gender = Convert.ToString(reader["Gender"]);
                        movieCastBE.role = Convert.ToString(reader["Role"]);
                        movieCastList.Add(movieCastBE);
                    }
                    reader.Close();
                    _connection.Close();
                    return movieCastList;
                }

                catch
                {
                    throw;
                }
            }

        }

    }
}

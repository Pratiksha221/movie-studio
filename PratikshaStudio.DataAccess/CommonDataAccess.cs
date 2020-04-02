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
    public class CommonDataAccess
    {
        private SqlConnection _connection;
        private string _connectionString;

        public CommonDataAccess()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=PratikshaDB;Integrated Security=true";

        }

        public List<CommonBE> GetAllGenreId()
        {       
            List<CommonBE> genreList = new List<CommonBE>();

            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var query = "SELECT * FROM Genre";
                    SqlCommand command = new SqlCommand(query, _connection);
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    
                        while (reader.Read())
                        {
                        CommonBE genre = new CommonBE();
                        
                        genre.GenreId = Convert.ToInt32(reader["GenreId"]);
                        genre.GenreName = Convert.ToString(reader["GenreName"]);
                        genreList.Add(genre);
                    }
                    
                    reader.Close();
                    return genreList;
                }


        
                catch (Exception)
                {
                    throw;
                }


            }
        }

        public List<CommonBE> GetAllActorId()
        {
            List<CommonBE> actorList = new List<CommonBE>();

            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var query = "SELECT ActorId, (FirstName + ' ' + LastName) AS Name FROM Actor";
                    SqlCommand command = new SqlCommand(query, _connection);
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        CommonBE actor = new CommonBE();

                        actor.ActorId = Convert.ToInt32(reader["ActorId"]);
                        actor.FirstName = Convert.ToString(reader["Name"]);
                        actorList.Add(actor);
                    }

                    reader.Close();
                    return actorList;
                }



                catch (Exception)
                {
                    throw;
                }

            }
        }

            public List<CommonBE> GetAllRatingId()
        {
            List<CommonBE> ratingList = new List<CommonBE>();

            using (_connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var query = "SELECT * FROM Rating";
                    SqlCommand command = new SqlCommand(query, _connection);
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        CommonBE rating = new CommonBE();

                        rating.RatingId = Convert.ToInt32(reader["RatingId"]);
                        rating.RatingName = Convert.ToString(reader["RatingName"]);
                        ratingList.Add(rating);
                    }

                    reader.Close();
                    return ratingList;
                }



                catch (Exception)
                {
                    throw;
                }


            }
        }
    }
}

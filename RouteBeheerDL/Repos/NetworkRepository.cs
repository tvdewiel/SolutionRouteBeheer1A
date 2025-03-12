using Microsoft.Data.SqlClient;
using RouteBeheerBL.Interfaces;
using RouteBeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RouteBeheerDL.Repos
{
    public class NetworkRepository : INetworkRepository
    {
        private string connectionString;

        public NetworkRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddLocation(Location location)
        {
            string query = "INSERT INTO locatie(naam) output INSERTED.ID VALUES(@naam)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.Parameters.AddWithValue("@naam", location.Name);
                    command.CommandText = query;
                    connection.Open();
                    location.Id = (int)command.ExecuteScalar(); 
                }
                catch (Exception e)
                {
                    throw new Exception("VoegLocatieToe", e);
                }
            }
        }
        public bool HasLocationName(string name)
        {
            string query = "SELECT count(*) FROM locatie WHERE naam=@naam";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.Parameters.AddWithValue("@naam",name);
                    command.CommandText = query;
                    connection.Open();
                    if ((int)command.ExecuteScalar() == 0) return false; else return true;
                }
                catch (Exception e)
                {
                    throw new Exception("HasLocation", e);
                }
            }
        }
        public bool HasLocationId(int id)
        {
            string query = "SELECT count(*) FROM locatie WHERE id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandText = query;
                    connection.Open();
                    if ((int)command.ExecuteScalar() == 0) return false; else return true;
                }
                catch (Exception e)
                {
                    throw new Exception("HasLocation", e);
                }
            }
        }
        public void UpdateLocation(Location location)
        {
            string query = "UPDATE locatie SET naam=@naam WHERE id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.Parameters.AddWithValue("@naam", location.Name);
                    command.Parameters.AddWithValue("@id", location.Id);
                    command.CommandText = query;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("UpdateLocatie", e);
                }
            }
        }
        public List<Location> GetLocations()
        {
            List<Location> locations = new();
            string query = "SELECT * FROM locatie";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.CommandText = query;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            locations.Add(new Location((int)reader["id"], (string)reader["naam"]));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("VoegLocatieToe", e);
                }
            }
            return locations;
        }
    }
}

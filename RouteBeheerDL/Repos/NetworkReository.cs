using Microsoft.Data.SqlClient;
using RouteBeheerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RouteBeheerDL.Repos
{
    public class NetworkReository
    {
        private string connectionString;

        public NetworkReository(string connectionString)
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
        public bool HasLocation(Location location)
        {
            string query = "SELECT count(*) FROM locatie WHERE naam=@naam";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    command.Parameters.AddWithValue("@naam",location.Name);
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
    }
}

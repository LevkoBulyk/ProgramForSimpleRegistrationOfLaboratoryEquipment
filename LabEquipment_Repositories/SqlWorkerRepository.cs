using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabEquipment.Entities;
using System.Data.SqlClient;
using System.Data;

namespace LabEquipment.Repositories
{
    public class SqlWorkerRepository : SqlBaseRepository, IWorkerRepository
    {
        #region Queries and procedures names

        private const string _getAllWorkerQuery = "SELECT Id, FirstName, LastName, Post, PhoneNumber FROM tblWorker;";

        private const string _getViolatorsQuery = "SELECT w.Id, w.FirstName, w.LastName, w.Post, w.PhoneNumber FROM tblWorker w INNER JOIN tblUsage u ON w.Id = u.WorkerId WHERE u.ReturningDate IS NULL;";

        private const string _insertWorkerProcedure = "spInsertWorker";

        private const string _getWorkerByIdQuery = "SELECT Id, FirstName, LastName, Post, PhoneNumber FROM tblWorker WHERE Id = @Id;";

        #endregion

        #region Constructor

        public SqlWorkerRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region Realisation of IUsageRepository methods

        public IEnumerable<Worker> GetWorkerList()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getAllWorkerQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Worker>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            string post = (string)reader["Post"];
                            string phoneNumber = (string)(reader["PhoneNumber"].GetType().ToString() == "System.DBNull" ? "null" : reader["PhoneNumber"]);

                            list.Add(new Worker(id, firstName, lastName, post, phoneNumber));
                        }
                        return list;
                    }
                }
            }
        }

        public IEnumerable<Worker> GetViolatorList()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getViolatorsQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Worker>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            string post = (string)reader["Post"];
                            string phoneNumber = (string)(reader["PhoneNumber"].GetType().ToString() == "System.DBNull" ? "null" : reader["PhoneNumber"]);

                            list.Add(new Worker(id, firstName, lastName, post, phoneNumber));
                        }
                        return list;
                    }
                }
            }
        }

        #endregion

        #region Helping methods

        public Worker GetWorkerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getWorkerByIdQuery, connection))
                {
                    SqlParameter idParameter = cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string post = (string)reader["Post"];
                    string phoneNumber = (string)reader["PhoneNumber"];

                    return new Worker(id, firstName, lastName, post, phoneNumber);
                }
            }
        }

        public Worker InsertWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_insertWorkerProcedure, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", worker.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", worker.LastName);
                    cmd.Parameters.AddWithValue("@Post", worker.Post);
                    cmd.Parameters.AddWithValue("@PhoneNumber", worker.PhoneNumber);
                    SqlParameter idParameter = cmd.Parameters.Add("@Id", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return GetWorkerById((int)cmd.Parameters["@Id"].Value);
                }
            }
        }
        
        #endregion
    }
}

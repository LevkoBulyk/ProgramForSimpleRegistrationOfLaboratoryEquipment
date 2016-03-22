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

        private const string _getAllWorkersQuery = "SELECT Id, ManagerId, FirstName, LastName, Post, PhoneNumber, Login, Password FROM tblWorker WHERE [Disabled] = 0;";

        private const string _insertWorkerQuery = "INSERT INTO tblWorker (ManagerId, FirstName, LastName, Post, PhoneNumber, [Login], [Password], [Disabled]) VALUES(@ManagerId, @FirstName, @LastName, @Post, @PhoneNumber, @Login, @Password, 0); SET @Id = @@IDENTITY;";

        private const string _getWorkerByIdQuery = "SELECT Id, ManagerId, FirstName, LastName, Post, PhoneNumber, [Login], [Password] FROM tblWorker WHERE Id = @Id AND [Disabled] = 0;";

        private string _getWorkerByLogin = "SELECT Id, ManagerId, FirstName, LastName, Post, PhoneNumber, [Login], [Password] FROM tblWorker WHERE [Login] = @Login AND [Password] = @Password AND [Disabled] = 0;";

        #endregion

        #region Constructor

        public SqlWorkerRepository(string connectionString)
            : base(connectionString)
        { }

        #endregion

        #region Realisation of IUsageRepository methods

        public IEnumerable<Worker> GetAllWorkers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getAllWorkersQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Worker>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            int managerId = (int)reader["ManagerId"];
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            string post = (string)reader["Post"];
                            string phoneNumber = (string)(reader["PhoneNumber"].GetType().ToString() == "System.DBNull" ? "null" : reader["PhoneNumber"]);
                            string login = (string)reader["Login"];
                            string password = (string)reader["Password"];

                            list.Add(new Worker(id, managerId, firstName, lastName, post, phoneNumber, login, password));
                        }
                        return list;
                    }
                }
            }
        }

        public Worker InsertWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_insertWorkerQuery, connection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@ManagerId", worker.ManagerId);
                    cmd.Parameters.AddWithValue("@FirstName", worker.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", worker.LastName);
                    cmd.Parameters.AddWithValue("@Post", worker.Post);
                    cmd.Parameters.AddWithValue("@PhoneNumber", worker.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Login", worker.Login);
                    cmd.Parameters.AddWithValue("@Password", worker.Password);
                    SqlParameter idParameter = cmd.Parameters.Add("@Id", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return GetWorkerById((int)cmd.Parameters["@Id"].Value);
                }
            }
        }


        #endregion

        #region Helping methods

        internal Worker GetWorkerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getWorkerByIdQuery, connection))
                {
                    SqlParameter idParameter = cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int managerId = (int)reader["ManagerId"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string post = (string)reader["Post"];
                        string phoneNumber = (string)(reader["PhoneNumber"].GetType().ToString() == "System.DBNull" ? "null" : reader["PhoneNumber"]);
                        string login = (string)reader["Login"];
                        string password = (string)reader["Password"];

                        return new Worker(id, managerId, firstName, lastName, post, phoneNumber, login, password);
                    }
                    return null;
                }
            }
        }

        public Worker GetUserByLogin(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getWorkerByLogin, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        int managerId = (int)reader["ManagerId"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string post = (string)reader["Post"];
                        string phoneNumber = (string)(reader["PhoneNumber"].GetType().ToString() == "System.DBNull" ? "null" : reader["PhoneNumber"]);

                        return new Worker(id, managerId, firstName, lastName, post, phoneNumber, login, password);
                    }
                    return null;
                }
            }
        }

        #endregion
    }
}

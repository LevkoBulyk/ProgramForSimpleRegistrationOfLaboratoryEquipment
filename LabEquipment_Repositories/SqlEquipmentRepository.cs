using System.Collections.Generic;
using LabEquipment.Entities;
using System.Data.SqlClient;
using System.Data;

namespace LabEquipment.Repositories
{
    public class SqlEquipmentRepository : SqlBaseRepository, IEquipmentRepository
    {
        #region Queries and procedures names

        private const string _getAllEquipmentQuery = "SELECT Id, Name, PermanentLocation FROM tblEquipment;";

        private const string _insertEquipmentProcedure = "spInsertEquipment";

        private const string _getEquipmentByIdQuery = "SELECT Id, Name, PermanentLocation FROM tblEquipment WHERE Id = @Id";

        #endregion

        #region Constructor

        public SqlEquipmentRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region Realisation of IUsageRepository methods

        public IEnumerable<Equipment> GetEquipmentList()
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(_getAllEquipmentQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Equipment>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            string name = (string)reader["Name"];
                            string permanentLocation = (string)reader["PermanentLocation"];
                            list.Add(new Equipment(id, name, permanentLocation));
                        }
                        return list;
                    }
                }
            }
        }

        #endregion

        #region Helping methods

        public Equipment InsertEquipment(Equipment equipment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_insertEquipmentProcedure, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", equipment.Name);
                    cmd.Parameters.AddWithValue("@PermanentLocation", equipment.PermanentLocation);
                    SqlParameter Id = cmd.Parameters.Add("@Id", SqlDbType.Int);
                    Id.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return GetEquipmentById((int)cmd.Parameters["@Id"].Value);
                }
            }
        }

        private Equipment GetEquipmentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getEquipmentByIdQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string name = (string)reader["Name"];
                    string permanentLocation = (string)reader["PermanentLocation"];
                    return new Equipment(id, name, permanentLocation);
                }
            }
        }
        
        #endregion
    }
}

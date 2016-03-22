using System.Collections.Generic;
using LabEquipment.Entities;
using System.Data.SqlClient;
using System.Data;

namespace LabEquipment.Repositories
{
    public class SqlEquipmentRepository : SqlBaseRepository, IEquipmentRepository
    {
        #region Queries and procedures names

        private const string _getAllEquipmentQuery = "SELECT Id, Name, PermanentLocation FROM tblEquipment WHERE [Disabled] = 0;";

        private const string _insertEquipmentQuery = "INSERT INTO tblEquipment (Name, PermanentLocation, [Disabled]) VALUES(@Name, @PermanentLocation, 0) SET @Id =@@IDENTITY;";

        private const string _getEquipmentByIdQuery = "SELECT Id, Name, PermanentLocation FROM tblEquipment WHERE Id = @Id AND [Disabled] = 0;";

        #endregion

        #region Constructor

        public SqlEquipmentRepository(string connectionString)
            : base(connectionString)
        { }

        #endregion

        #region Realisation of IUsageRepository methods

        public IEnumerable<Equipment> GetAllEquipment()
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

        public Equipment InsertEquipment(Equipment equipment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_insertEquipmentQuery, connection))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", equipment.Name);
                    cmd.Parameters.AddWithValue("@PermanentLocation", equipment.PermanentLocation);
                    SqlParameter Id = cmd.Parameters.Add("@Id", SqlDbType.Int);
                    Id.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    return GetEquipmentById((int)cmd.Parameters["@Id"].Value);
                }
            }
        }

        #endregion

        #region Helping methods

        internal Equipment GetEquipmentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getEquipmentByIdQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        string permanentLocation = (string)reader["PermanentLocation"];
                        return new Equipment(id, name, permanentLocation);
                    }
                    return null;
                }
            }
        }

        #endregion
    }
}

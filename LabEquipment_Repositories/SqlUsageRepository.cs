using System;
using System.Collections.Generic;
using LabEquipment.Entities;
using System.Data;
using System.Data.SqlClient;

namespace LabEquipment.Repositories
{
    public class SqlUsageRepository : SqlBaseRepository, IUsageRepository
    {
        #region Queries and procedures names

        private const string _insertUsageProcedure = "spWrittingAboutTaking";

        private const string _getUsageByIdQuery = "SELECT u.Id, u.EquipmentId, u.WorkerId, u.TakeingDate, u.ReturningDate, e.Name AS 'EquipmentName', w.FirstName + ' ' + w.LastName AS 'WorkerName' FROM tblUsage u INNER JOIN tblEquipment e ON e.Id = u.EquipmentId INNER JOIN tblWorker w ON w.Id = u.WorkerId WHERE u.Id = @Id;";

        private const string _returnEquipmentQuery = "IF (SELECT ReturningDate FROM tblUsage WHERE Id = @Id) IS NOT NULL RAISERROR('This act of returning is already closed.', 16, 1); UPDATE tblUsage SET ReturningDate = GETDATE() WHERE Id = @Id;";

        private const string _getAllUsageQuery = "SELECT u.Id, u.EquipmentId, u.WorkerId, u.TakeingDate, u.ReturningDate, e.Name AS 'EquipmentName', w.FirstName + ' ' + w.LastName AS 'WorkerName' FROM tblUsage u INNER JOIN tblEquipment e ON e.Id = u.EquipmentId INNER JOIN tblWorker w ON w.Id = u.WorkerId;";
        
        #endregion

        #region Constructor

        public SqlUsageRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region Realisation of IUsageRepository methods

        public IEnumerable<Usage> GetUsageList()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getAllUsageQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Usage>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            int equipmentId = (int)reader["EquipmentId"];
                            int workerId = (int)reader["WorkerID"];
                            DateTime takeingDate = (DateTime)reader["TakeingDate"];
                            DateTime? returningDate = reader["ReturningDate"] == DBNull.Value ? null : (DateTime?)reader["ReturningDate"];
                            string equipmentName = (string)reader["EquipmentName"];
                            string workerName = (string)reader["WorkerName"];
                            list.Add(new Usage(id, equipmentId, workerId, takeingDate, returningDate, equipmentName, workerName));
                        }
                        return list;
                    }
                }
            }
        }

        public Usage TakePieceOfEquipment(int workerId, int equipmentId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_insertUsageProcedure, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EquipmentId", equipmentId);
                    cmd.Parameters.AddWithValue("@WorkerId", workerId);
                    SqlParameter UsageId = cmd.Parameters.Add("@UsageId", SqlDbType.Int);
                    UsageId.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int usageId = (int)cmd.Parameters["@UsageId"].Value;
                    return GetUsageById(usageId);
                }
            }
        }

        public Usage ReturnPieceOfEquipment(int usageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(_returnEquipmentQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", usageId);
                    cmd.ExecuteNonQuery();
                }
            }
            return GetUsageById(usageId);
        }

        #endregion

        #region Helping methods

        private Usage GetUsageById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(_getUsageByIdQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        int equipmentId = (int)reader["EquipmentId"];
                        int workerId = (int)reader["WorkerId"];
                        DateTime takeingDate = (DateTime)reader["TakeingDate"];
                        DateTime? returningDate = reader["ReturningDate"] == DBNull.Value ? null : (DateTime?)reader["ReturningDate"];
                        string equipmentName = (string)reader["EquipmentName"];
                        string workerName = (string)reader["WorkerName"];
                        return (new Usage(id, equipmentId, workerId, takeingDate, returningDate, equipmentName, workerName));
                    }
                }
            }
        }
        
        #endregion
    }
}

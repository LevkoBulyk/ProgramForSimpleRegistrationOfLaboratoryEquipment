using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabEquipment.Repositories;
using LabEquipment.Entities;
using System.Data.SqlClient;

namespace LabEquipment.Repositories
{
    public class SqlViolatorRepository : SqlUsageRepository
    {
        #region Queries and procedures names

        private string _getAllViolatorsQuery = "SELECT u.Id, u.TakeingDate, e.Name AS EquipmentName, w.FirstName + ' ' + w.LastName AS ViolatorName, w.PhoneNumber FROM tblUsage u INNER JOIN tblEquipment e ON e.Id = u.EquipmentId INNER JOIN tblWorker w ON w.Id = u.WorkerId WHERE u.ReturningDate IS NULL;";

        #endregion

        #region Constructor

        public SqlViolatorRepository(string connectionString)
            : base(connectionString)
        { }

        #endregion

        #region Methods

        public IEnumerable<Violator> GetAllViolators()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(_getAllViolatorsQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new List<Violator>();
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            DateTime takingDate = (DateTime)reader["TakeingDate"];
                            string equipmentName = (string)reader["EquipmentName"];
                            string workerName = (string)reader["ViolatorName"];
                            string phoneNumber = (string)reader["PhoneNumber"];

                            list.Add(new Violator(id, workerName, equipmentName, phoneNumber, takingDate));
                        }
                        return list;
                    }
                }
            }
        }

        #endregion
    }
}

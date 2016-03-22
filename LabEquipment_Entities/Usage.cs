using System;

namespace LabEquipment.Entities
{
    public class Usage : Table
    {
        #region Bare SQL-table properties

        public int EquipmentId { get; set; }

        public int WorkerId { get; set; }

        public DateTime TakingDate { get; set; }

        public DateTime? ReturningDate { get; set; }
        
        #endregion

        #region Helping properties

        public Equipment EquipmentInfo { get; set; }

        public Worker WorkerInfo { get; set; }
        
        #endregion

        #region Constructors

        public Usage(int id, int equipmentId, int workerId, DateTime takingDate, DateTime? returningDate)
        {
            this.Id = id;
            this.EquipmentId = equipmentId;
            this.WorkerId = workerId;
            this.TakingDate = takingDate;
            this.ReturningDate = returningDate;
        }

        public Usage(int id, int equipmentId, int workerId, DateTime takingDate, DateTime? returningDate, Equipment equipmentInfo, Worker workerInfo)
            : this(id, equipmentId, workerId, takingDate, returningDate)
        {
            this.EquipmentInfo = equipmentInfo;
            this.WorkerInfo = workerInfo;
        }
        
        #endregion
    }
}

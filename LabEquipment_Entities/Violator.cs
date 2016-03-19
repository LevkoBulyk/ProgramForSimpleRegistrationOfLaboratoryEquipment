using System;

namespace LabEquipment.Entities
{
    public class Violator : Table
    {
        #region Properties

        public string EquipmentName { get; set; }

        public string ViolatorName { get; set; }

        public DateTime TakeingDate { get; set; }

        public string PhoneNumber { get; set; }
        
        #endregion

        #region Constructor

        public Violator(int id, string violatorName, string equipmentName, string phoneNumber, DateTime takingDate)
        {
            this.Id = id;
            this.EquipmentName = equipmentName;
            this.ViolatorName = violatorName;
            this.PhoneNumber = phoneNumber;
            this.TakeingDate = takingDate;
        }

        #endregion
    }
}

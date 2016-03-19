namespace LabEquipment.Entities
{
    public class Equipment : Table
    {
        #region Bare SQL-table parameters

        public string Name { get; set; }

        public string PermanentLocation { get; set; }

        #endregion

        #region Constructor

        public Equipment(int id, string name, string permanentLocation)
        {
            this.Id = id;
            this.Name = name;
            this.PermanentLocation = permanentLocation;
        }
      
        #endregion
    }
}

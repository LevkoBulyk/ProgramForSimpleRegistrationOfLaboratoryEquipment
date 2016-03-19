namespace LabEquipment.Entities
{
    public class Worker : Table
    {
        #region Bare SQL-table properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Post { get; set; }

        public string PhoneNumber { get; set; }

        #endregion

        #region Constructor

        public Worker(int id, string firstName, string lastName, string post, string phoneNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Post = post;
            this.PhoneNumber = phoneNumber;
        }
        
        #endregion
    }
}

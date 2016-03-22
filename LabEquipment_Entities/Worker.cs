namespace LabEquipment.Entities
{
    public class Worker : Table
    {
        #region Bare SQL-table properties

        public int ManagerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Post { get; set; }

        public string PhoneNumber { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructor

        public Worker(int id, int managerId, string firstName, string lastName, string post, string phoneNumber, string login, string password)
        {
            this.Id = id;
            this.ManagerId = managerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Post = post;
            this.PhoneNumber = phoneNumber;
            this.Login = login;
            this.Password = null;
        }
        
        #endregion
    }
}

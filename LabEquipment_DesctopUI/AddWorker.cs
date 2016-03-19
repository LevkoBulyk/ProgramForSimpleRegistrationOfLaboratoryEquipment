using System;
using System.Windows.Forms;
using LabEquipment.Repositories;
using System.Configuration;
using LabEquipment.Entities;

namespace LabEquipment.DesctopUI
{
    public partial class AddWorker : Form
    {
        public Worker rezultWorker;

        public AddWorker()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbxFirstName.Text == "" || this.tbxLastName.Text == "" || this.tbxPost.Text == "")
            {
                throw new Exception("First an last names as well as post values must be specified.");
            }

            SqlWorkerRepository workerRepository = new SqlWorkerRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);
            rezultWorker = workerRepository.InsertWorker(new Worker(0, this.tbxFirstName.Text, this.tbxLastName.Text, this.tbxPost.Text, (this.tbxPhoneNumber.Text == "" ? "null" : this.tbxPhoneNumber.Text)));
            this.DialogResult = DialogResult.OK;
        }

        private void tbxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            this.ttNumber.Show("Format: (000)0000000", this.tbxPhoneNumber);
        }
    }
}

using System;
using System.Windows.Forms;
using LabEquipment.Repositories;
using System.Configuration;
using LabEquipment.Entities;
using System.Security.Cryptography;
using System.Text;

namespace LabEquipment.DesctopUI
{
    public partial class AddWorker : Form
    {
        public Worker rezultWorker;

        public AddWorker()
        {
            InitializeComponent();
            this.lblManager.Text = $"Manager:\t{CurrentWorker.FirstName} {CurrentWorker.LastName}";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbxFirstName.Text == "" || this.tbxLastName.Text == "" || this.tbxPost.Text == "")
            {
                this.tbxPassword.Text = "";
                throw new Exception("First an last names as well as post values must be specified.");
            }
            if (this.tbxLogin.Text == "" || this.tbxPassword.Text.Length <= 4)
            {
                this.tbxPassword.Text = "";
                throw new Exception("Login must be specified and paswodr must be not shoter than 4 symbols.");
            }

            SqlWorkerRepository workerRepository = new SqlWorkerRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);
            Worker worker = new Worker(0, CurrentWorker.Id, this.tbxFirstName.Text, this.tbxLastName.Text, this.tbxPost.Text, (this.tbxPhoneNumber.Text == "" ? "null" : this.tbxPhoneNumber.Text), this.tbxLogin.Text, null);
            worker.Password = MD5Hash(this.tbxPassword.Text);
            rezultWorker = workerRepository.InsertWorker(worker);
            this.DialogResult = DialogResult.OK;
        }

        private void tbxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            this.ttNumber.Show("Format: (000)0000000", this.tbxPhoneNumber);
        }

        private static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}

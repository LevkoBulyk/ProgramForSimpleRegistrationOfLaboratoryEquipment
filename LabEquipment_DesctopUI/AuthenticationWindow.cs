using LabEquipment.Entities;
using LabEquipment.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabEquipment.DesctopUI
{
    public partial class AuthenticationWindow : Form
    {
        private SqlWorkerRepository _workerRepository = new SqlWorkerRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);
        
        public AuthenticationWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string login = tbxLogin.Text;
            string password = MD5Hash(tbxPassword.Text);
            Worker worker = _workerRepository.GetUserByLogin(login, password);
            if (worker == null)
            {
                MessageBox.Show(this, "Invalid user name or password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentWorker.Initialize(worker);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
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

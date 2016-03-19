using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabEquipment.Repositories;
using System.Configuration;
using LabEquipment.Entities;

namespace LabEquipment.DesctopUI
{
    public partial class AddEquipment : Form
    {
        public Equipment rezultEquipment;

        public AddEquipment()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.tbxName.Text == "" || this.tbxPermanentLocation.Text == "")
            {
                throw new Exception("Name and permanent location values must be specified.");
            }
            SqlEquipmentRepository euipmentRepository = new SqlEquipmentRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);
            rezultEquipment = euipmentRepository.InsertEquipment(new Equipment(0, this.tbxName.Text, this.tbxPermanentLocation.Text));
            this.DialogResult = DialogResult.OK;
        }
    }
}

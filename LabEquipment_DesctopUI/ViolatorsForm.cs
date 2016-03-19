using System;
using System.Drawing;
using System.Windows.Forms;
using LabEquipment.Repositories;
using System.Configuration;

namespace LabEquipment.DesctopUI
{
    public partial class ViolatorsForm : Form
    {
        #region SQL Repository variables

        private SqlViolatorRepository _violatorRepository = new SqlViolatorRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);
        
        #endregion

        #region Helping variables
        private int _index = 0;
        #endregion

        public ViolatorsForm()
        {
            InitializeComponent();
            this.RefreshInfo();
        }

        #region Methods

        private void RefreshInfo()
        {
            this.List.Items.Clear();
            _index = 0;

            foreach (var item in this._violatorRepository.GetAllViolators())
            {
                this.List.Items.Add(item.ViolatorName).SubItems.AddRange(new string[] { item.EquipmentName, item.TakeingDate.ToString(), item.PhoneNumber, item.Id.ToString() });
                _index++;
            }

            if (this.List.Items.Count == 0)
            {
                this.List.Items.Add("There are no workers with debts :)");
                this.List.Items[0].ForeColor = Color.Red;
            }
        }
        #endregion
    }
}

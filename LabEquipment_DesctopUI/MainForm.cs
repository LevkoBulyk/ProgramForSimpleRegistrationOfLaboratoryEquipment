using System;
using System.Drawing;
using System.Windows.Forms;
using LabEquipment.Repositories;
using LabEquipment.Entities;
using System.Configuration;

namespace LabEquipment.DesctopUI
{
    public partial class MainForm : Form
    {
        #region SQL Repository variables

        private SqlWorkerRepository _workerRepository = new SqlWorkerRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);

        private SqlEquipmentRepository _equipmentRepository = new SqlEquipmentRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);

        private SqlUsageRepository _usageRepository = new SqlUsageRepository(ConfigurationManager.ConnectionStrings["LabEquipmentDatabase"].ConnectionString);

        #endregion

        #region Helping variables

        private int _selectedEquipmentId = 0;

        private int _selectedWorkerId = 0;

        private int _index = 3;
        
        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.RefreshInfo();
        }

        #region Methods 

        private void List_Click(object sender, EventArgs e)
        {
            if (this.List.SelectedItems[0] == null || this.List.SelectedItems[0].Group == null)
            {
                return;
            }
            if (this.List.SelectedItems[0].Group == this.List.Groups[0])
            {
                SelectedLabel.Text = string.Format("Selected: {0}", this.List.SelectedItems[0].Text);
                int.TryParse(this.List.SelectedItems[0].SubItems[4].Text, out this._selectedEquipmentId);
            }
            else if (this.List.SelectedItems[0].Group == this.List.Groups[1])
            {
                ByLabel.Text = string.Format("By: {0}", this.List.SelectedItems[0].Text);
                int.TryParse(this.List.SelectedItems[0].SubItems[4].Text, out this._selectedWorkerId);
            }
        }

        private void TakeButton_Click(object sender, EventArgs e)
        {
            if (this._selectedEquipmentId == 0 || this._selectedWorkerId == 0)
            {
                throw new Exception("Equipment or Worker is not selected!");
            }
            Usage newUsage = this._usageRepository.TakePieceOfEquipment(this._selectedWorkerId, this._selectedEquipmentId);
            if (newUsage != null)
            {
                MessageBox.Show("Record about act of taking is successfully added.", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.InsertInfo(newUsage, 2);
            this.SelectedLabel.Text = "Selected: click on the equipment list to select...";
            this.ByLabel.Text = "By: click on workers list...";
            this._selectedEquipmentId = 0;
            this._selectedWorkerId = 0;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (this.List.SelectedItems[0] == null || this.List.SelectedItems[0].Group == null || this.List.SelectedItems[0].Group != this.List.Groups[2])
            {
                throw new Exception("Act of usage is not selected.");
            }
            int usageId = 0;
            int.TryParse(this.List.SelectedItems[0].SubItems[4].Text, out usageId);
            Usage newUsage = this._usageRepository.ReturnPieceOfEquipment(usageId);
            this.List.Items[Convert.ToInt32(this.List.SelectedItems[0].Index)].SubItems[3].Text = newUsage.ReturningDate.ToString();
            MessageBox.Show("Record about act of taking is successfully closed.", "Record Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowViolatorsButton_Click(object sender, EventArgs e)
        {
            ViolatorsForm violators = new ViolatorsForm();
            violators.Show();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RefreshInfo();
        }

        private void AddEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEquipment addEquipment = new AddEquipment();
            addEquipment.ShowDialog();
            if (addEquipment.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("New equipment was successfuly added.", "Equipment Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.InsertInfo(addEquipment.rezultEquipment, 0);
                addEquipment.Dispose();
            }
            else
            {
                MessageBox.Show("Process was canceled by user.", "Equipment Adding Cancel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                addEquipment.Dispose();
            }
        }

        private void AddWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWorker addWorker = new AddWorker();
            addWorker.ShowDialog();
            if (addWorker.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("New worker was successfuly added to the list.", "Worker Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.InsertInfo(addWorker.rezultWorker, 1);
                addWorker.Dispose();
            }
            else
            {
                MessageBox.Show("Process was canceled by user.", "Wprker Adding Cancel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                addWorker.Dispose();
            }
        }

        #endregion

        #region Helping Methods

        private void RefreshInfo()
        {
            this.List.Items.Clear();
            _index = 3;

            this.List.Items.Add("Name").SubItems.Add("Permanent Location");
            this.List.Items[0].ForeColor = Color.Blue;
            this.List.Items[0].Group = this.List.Groups[0];

            this.List.Items.Add("First name").SubItems.AddRange(new string[] { "Last name", "Post", "Phone number" });
            this.List.Items[1].ForeColor = Color.Blue;
            this.List.Items[1].Group = this.List.Groups[1];

            this.List.Items.Add("Equipment name").SubItems.AddRange(new string[] { "Worker name", "Taking Date", "Returning Date" });
            this.List.Items[2].ForeColor = Color.Blue;
            this.List.Items[2].Group = this.List.Groups[2];

            foreach (var item in this._equipmentRepository.GetEquipmentList())
            {
                this.List.Items.Add(item.Name).SubItems.AddRange(new string[] { item.PermanentLocation, "", "", item.Id.ToString() });
                this.List.Items[_index].Group = this.List.Groups[0];
                _index++;
            }

            foreach (var item in this._workerRepository.GetWorkerList())
            {
                this.List.Items.Add(item.FirstName).SubItems.AddRange(new string[] { item.LastName, item.Post, item.PhoneNumber, item.Id.ToString() });
                this.List.Items[_index].Group = this.List.Groups[1];
                _index++;
            }

            foreach (var item in this._usageRepository.GetUsageList())
            {
                this.List.Items.Add(item.EquipmentName).SubItems.AddRange(new string[] { item.WorkerName, item.TakingDate.ToString(), item.ReturningDate.ToString(), item.Id.ToString(), item.EquipmentId.ToString(), item.WorkerId.ToString() });
                this.List.Items[_index].Group = this.List.Groups[2];
                _index++;
            }
        }

        private void InsertInfo(Table info, int groupNumber)
        {
            switch (groupNumber)
            {
                case 0:
                    Equipment newEquipment = info as Equipment;
                    this.List.Items.Add(newEquipment.Name).SubItems.AddRange(new string[] { newEquipment.PermanentLocation, "", "", newEquipment.Id.ToString() });
                    break;
                case 1:
                    Worker newWorker = info as Worker;
                    this.List.Items.Add(newWorker.FirstName).SubItems.AddRange(new string[] { newWorker.LastName, newWorker.Post, newWorker.PhoneNumber, newWorker.Id.ToString() });
                    break;
                case 2:
                    Usage newUsage = info as Usage;
                    this.List.Items.Add(newUsage.EquipmentName).SubItems.AddRange(new string[] { newUsage.WorkerName, newUsage.TakingDate.ToString(), newUsage.ReturningDate.ToString(), newUsage.Id.ToString(), newUsage.EquipmentId.ToString(), newUsage.WorkerId.ToString() });
                    break;
                default:
                    break;
            }
            this.List.Items[this.List.Items.Count - 1].Group = this.List.Groups[groupNumber];
        }

        #endregion
    }
}

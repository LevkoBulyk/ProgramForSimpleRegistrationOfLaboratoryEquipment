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

        // Info that is displaying:
        // 0 - Equipment;
        // 1 - Workers;
        // 2 - Usage;
        // 3 - Violators;
        private int _dgvListState = 0;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.Text = $"Laboratory Equipment: {CurrentWorker.FirstName} {CurrentWorker.LastName}";
            this.RefreshInfo();
        }

        #region Methods 

        private void List_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedCells == null)
            {
                return;
            }
            SelectedLabel.Text = string.Format("Selected: {0}", this.dgvList.Rows[this.dgvList.SelectedCells[0].RowIndex].Cells[1].Value);
            int.TryParse(this.dgvList.Rows[this.dgvList.SelectedCells[0].RowIndex].Cells[0].Value.ToString(), out this._selectedEquipmentId);
        }

        private void TakeButton_Click(object sender, EventArgs e)
        {
            if (this._dgvListState != 0)
            {
                throw new Exception("Go to 'Equipment' table first.");
            }
            if (this._selectedEquipmentId == 0)
            {
                throw new Exception("Equipment is not selected!");
            }
            Usage newUsage = this._usageRepository.TakePieceOfEquipment(CurrentWorker.Id, this._selectedEquipmentId);
            if (newUsage != null)
            {
                this._dgvListState = 2;
                this.RefreshInfo();
                MessageBox.Show("Record about act of taking is successfully added.", "Record Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (!(this._dgvListState == 2 || this._dgvListState == 3))
            {
                throw new Exception("Go to table 'Usage' or 'Violators' first.");
            }
            if (this.dgvList.SelectedCells == null)
            {
                throw new Exception("Act of usage is not selected.");
            }
            int usageId = 0;
            int.TryParse(this.dgvList.Rows[this.dgvList.SelectedCells[0].RowIndex].Cells[0].Value.ToString(), out usageId);
            Usage newUsage = this._usageRepository.ReturnPieceOfEquipment(usageId);
            this._dgvListState = 2;
            this.RefreshInfo();
            MessageBox.Show("Record about act of taking is successfully closed.", "Record Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowViolatorsButton_Click(object sender, EventArgs e)
        {
            if (this._dgvListState == 3)
            {
                this.showViolatorsButton.Text = "Show violators";
                this._dgvListState = 0;
                this.RefreshInfo();
            }
            else
            {
                this.showViolatorsButton.Text = "Show equipment";
                this._dgvListState = 3;
                this.RefreshInfo();
            }
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
                this._dgvListState = 0;
                this.RefreshInfo();
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
                addWorker.Dispose();
            }
            else
            {
                MessageBox.Show("Process was canceled by user.", "Wprker Adding Cancel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                addWorker.Dispose();
            }
            this.workersToolStripMenuItem_Click(this, new EventArgs());
        }

        private void workersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dgvList.Rows.Clear();

            this.dgvList.Columns[0].HeaderText = "Id";
            this.dgvList.Columns[0].Visible = false;
            this.dgvList.Columns[0].Width = 50;

            this.dgvList.Columns[1].HeaderText = "First name";
            this.dgvList.Columns[1].Width = 150;

            this.dgvList.Columns[2].HeaderText = "Last name";
            this.dgvList.Columns[2].Width = 150;

            this.dgvList.Columns[3].HeaderText = "Post";
            this.dgvList.Columns[3].Visible = true;
            this.dgvList.Columns[3].Width = 150;

            this.dgvList.Columns[4].HeaderText = "Phone number";
            this.dgvList.Columns[4].Visible = true;
            this.dgvList.Columns[4].Width = 120;

            this.dgvList.Columns[5].Visible = false;

            foreach (var item in this._workerRepository.GetAllWorkers())
            {
                this.dgvList.Rows.Add(item.Id.ToString(), item.FirstName, item.LastName, item.Post, item.PhoneNumber);
            }
            this._dgvListState = 1;
            this.lblTableName.Text = "Workers:";
        }

        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dgvList.Rows.Clear();

            this.dgvList.Columns[1].HeaderText = "Name of worker";
            this.dgvList.Columns[1].Width = 200;

            this.dgvList.Columns[2].HeaderText = "Name of equipment";
            this.dgvList.Columns[2].Width = 200;

            this.dgvList.Columns[3].HeaderText = "Takeing date";
            this.dgvList.Columns[3].Visible = true;
            this.dgvList.Columns[3].Width = 150;

            this.dgvList.Columns[4].HeaderText = "Returning date";
            this.dgvList.Columns[4].Visible = true;
            this.dgvList.Columns[4].Width = 150;

            this.dgvList.Columns[5].HeaderText = "Phone number";
            this.dgvList.Columns[5].Visible = true;
            this.dgvList.Columns[5].Width = 150;

            foreach (var item in this._usageRepository.GetAllUsage())
            {
                this.dgvList.Rows.Add(item.Id.ToString(), item.EquipmentInfo.Name, item.WorkerInfo.FirstName + " " + item.WorkerInfo.LastName, item.TakingDate.ToString(), item.ReturningDate.ToString(), item.WorkerInfo.PhoneNumber);
            }
            this._dgvListState = 2;
            this.lblTableName.Text = "Usage:";
        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._dgvListState = 0;
            this.RefreshInfo();
        }

        private void violatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._dgvListState = 3;
            this.RefreshInfo();
        }

        #endregion

        #region Helping Methods

        private void RefreshInfo()
        {
            this.dgvList.Rows.Clear();
            if (this._dgvListState == 2)
            {
                this.usageToolStripMenuItem_Click(null, null);
            }
            else if (this._dgvListState == 3)
            {
                this.dgvList.Columns[1].HeaderText = "Name of violator";
                this.dgvList.Columns[1].Width = 200;

                this.dgvList.Columns[2].HeaderText = "Name of equipment";
                this.dgvList.Columns[2].Width = 200;

                this.dgvList.Columns[3].HeaderText = "Takeing date";
                this.dgvList.Columns[3].Visible = true;
                this.dgvList.Columns[3].Width = 150;

                this.dgvList.Columns[4].HeaderText = "Phone number";
                this.dgvList.Columns[4].Visible = true;
                this.dgvList.Columns[4].Width = 150;

                this.dgvList.Columns[5].Visible = false;

                foreach (var item in this._usageRepository.GetAllViolators())
                {
                    this.dgvList.Rows.Add(item.Id.ToString(), item.EquipmentInfo.Name, item.WorkerInfo.FirstName + " " + item.WorkerInfo.LastName, item.TakingDate.ToString(), item.WorkerInfo.PhoneNumber);
                }
                this.lblTableName.Text = "Violators:";
            }
            else if (this._dgvListState == 1)
            {
                this.workersToolStripMenuItem_Click(null, null);
            }
            else
            {
                this.dgvList.Columns[0].HeaderText = "Id";
                this.dgvList.Columns[0].Visible = false;
                this.dgvList.Columns[0].Width = 50;

                this.dgvList.Columns[1].HeaderText = "Name of equipment";
                this.dgvList.Columns[1].Width = 200;

                this.dgvList.Columns[2].HeaderText = "Permanent location of equipment";
                this.dgvList.Columns[2].Width = 500;

                this.dgvList.Columns[3].Visible = false;

                this.dgvList.Columns[4].Visible = false;

                this.dgvList.Columns[5].Visible = false;

                foreach (var item in this._equipmentRepository.GetAllEquipment())
                {
                    this.dgvList.Rows.Add(item.Id.ToString(), item.Name, item.PermanentLocation);
                }
                this.lblTableName.Text = "Equipment:";
            }
        }

        #endregion

    }
}

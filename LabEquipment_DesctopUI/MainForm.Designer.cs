namespace LabEquipment.DesctopUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Equipment:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Workers:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Acts of using:", System.Windows.Forms.HorizontalAlignment.Left);
            this.List = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.ByLabel = new System.Windows.Forms.Label();
            this.TakeButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.showViolatorsButton = new System.Windows.Forms.Button();
            this.cmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.List.ContextMenuStrip = this.cmsList;
            listViewGroup1.Header = "Equipment:";
            listViewGroup1.Name = "Equipment";
            listViewGroup2.Header = "Workers:";
            listViewGroup2.Name = "Worker";
            listViewGroup3.Header = "Acts of using:";
            listViewGroup3.Name = "Usage";
            this.List.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.List.Location = new System.Drawing.Point(12, 12);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(808, 359);
            this.List.TabIndex = 0;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Details;
            this.List.Click += new System.EventHandler(this.List_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 200;
            // 
            // cmsList
            // 
            this.cmsList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.showToolStripMenuItem,
            this.toolStripSeparator1,
            this.addEquipmentToolStripMenuItem,
            this.addWorkerToolStripMenuItem});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(189, 142);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem,
            this.workersToolStripMenuItem,
            this.usageToolStripMenuItem,
            this.toolStripSeparator2,
            this.allToolStripMenuItem});
            this.showToolStripMenuItem.Enabled = false;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            // 
            // workersToolStripMenuItem
            // 
            this.workersToolStripMenuItem.Name = "workersToolStripMenuItem";
            this.workersToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.workersToolStripMenuItem.Text = "Workers";
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            this.usageToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.usageToolStripMenuItem.Text = "Usage";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.allToolStripMenuItem.Text = "All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // addEquipmentToolStripMenuItem
            // 
            this.addEquipmentToolStripMenuItem.Name = "addEquipmentToolStripMenuItem";
            this.addEquipmentToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.addEquipmentToolStripMenuItem.Text = "Add Equipment";
            this.addEquipmentToolStripMenuItem.Click += new System.EventHandler(this.AddEquipmentToolStripMenuItem_Click);
            // 
            // addWorkerToolStripMenuItem
            // 
            this.addWorkerToolStripMenuItem.Name = "addWorkerToolStripMenuItem";
            this.addWorkerToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.addWorkerToolStripMenuItem.Text = "Add Worker";
            this.addWorkerToolStripMenuItem.Click += new System.EventHandler(this.AddWorkerToolStripMenuItem_Click);
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedLabel.Location = new System.Drawing.Point(12, 374);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(359, 20);
            this.SelectedLabel.TabIndex = 1;
            this.SelectedLabel.Text = "Selected: click on the equipment list to select...";
            // 
            // ByLabel
            // 
            this.ByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ByLabel.AutoSize = true;
            this.ByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ByLabel.Location = new System.Drawing.Point(12, 394);
            this.ByLabel.Name = "ByLabel";
            this.ByLabel.Size = new System.Drawing.Size(199, 20);
            this.ByLabel.TabIndex = 2;
            this.ByLabel.Text = "By: click on workers list...";
            // 
            // TakeButton
            // 
            this.TakeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TakeButton.AutoSize = true;
            this.TakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TakeButton.Location = new System.Drawing.Point(12, 417);
            this.TakeButton.Name = "TakeButton";
            this.TakeButton.Size = new System.Drawing.Size(75, 27);
            this.TakeButton.TabIndex = 3;
            this.TakeButton.Text = "Take";
            this.TakeButton.UseVisualStyleBackColor = true;
            this.TakeButton.Click += new System.EventHandler(this.TakeButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnButton.AutoSize = true;
            this.returnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.returnButton.Location = new System.Drawing.Point(93, 417);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 27);
            this.returnButton.TabIndex = 4;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // showViolatorsButton
            // 
            this.showViolatorsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showViolatorsButton.AutoSize = true;
            this.showViolatorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showViolatorsButton.Location = new System.Drawing.Point(697, 417);
            this.showViolatorsButton.Name = "showViolatorsButton";
            this.showViolatorsButton.Size = new System.Drawing.Size(123, 27);
            this.showViolatorsButton.TabIndex = 5;
            this.showViolatorsButton.Text = "Show violators";
            this.showViolatorsButton.UseVisualStyleBackColor = true;
            this.showViolatorsButton.Click += new System.EventHandler(this.ShowViolatorsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 455);
            this.Controls.Add(this.showViolatorsButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.TakeButton);
            this.Controls.Add(this.ByLabel);
            this.Controls.Add(this.SelectedLabel);
            this.Controls.Add(this.List);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratory Equipment";
            this.cmsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.Label SelectedLabel;
        private System.Windows.Forms.Label ByLabel;
        private System.Windows.Forms.Button TakeButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button showViolatorsButton;
        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem addEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}


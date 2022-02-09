namespace CSProject1
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
            this.mainViewTable = new System.Windows.Forms.DataGridView();
            this.gbCurrentView = new System.Windows.Forms.GroupBox();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnLoans = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.lbLogin = new System.Windows.Forms.Label();
            this.btnShowItems = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMarkLost = new System.Windows.Forms.Button();
            this.btnReturned = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainViewTable)).BeginInit();
            this.gbCurrentView.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainViewTable
            // 
            this.mainViewTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainViewTable.Location = new System.Drawing.Point(30, 33);
            this.mainViewTable.Name = "mainViewTable";
            this.mainViewTable.Size = new System.Drawing.Size(1058, 396);
            this.mainViewTable.TabIndex = 0;
            this.mainViewTable.DoubleClick += new System.EventHandler(this.mainViewTable_DoubleClick);
            // 
            // gbCurrentView
            // 
            this.gbCurrentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCurrentView.Controls.Add(this.btnStock);
            this.gbCurrentView.Controls.Add(this.btnCustomers);
            this.gbCurrentView.Controls.Add(this.btnLoans);
            this.gbCurrentView.Controls.Add(this.btnRepair);
            this.gbCurrentView.Location = new System.Drawing.Point(30, 432);
            this.gbCurrentView.Name = "gbCurrentView";
            this.gbCurrentView.Size = new System.Drawing.Size(413, 115);
            this.gbCurrentView.TabIndex = 1;
            this.gbCurrentView.TabStop = false;
            this.gbCurrentView.Text = "View";
            // 
            // btnStock
            // 
            this.btnStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStock.Location = new System.Drawing.Point(268, 19);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(131, 40);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "View Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomers.Location = new System.Drawing.Point(137, 19);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(131, 40);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "View Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnLoans
            // 
            this.btnLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoans.Location = new System.Drawing.Point(6, 19);
            this.btnLoans.Name = "btnLoans";
            this.btnLoans.Size = new System.Drawing.Size(131, 40);
            this.btnLoans.TabIndex = 0;
            this.btnLoans.Text = "View Loans";
            this.btnLoans.UseVisualStyleBackColor = true;
            this.btnLoans.Click += new System.EventHandler(this.btnLoans_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Location = new System.Drawing.Point(443, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(137, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(268, 16);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(125, 40);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(30, 4);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(143, 25);
            this.btnStaff.TabIndex = 3;
            this.btnStaff.Text = "Manage Users";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(179, 15);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(71, 13);
            this.lbLogin.TabIndex = 4;
            this.lbLogin.Text = "Logged in as:";
            // 
            // btnShowItems
            // 
            this.btnShowItems.Location = new System.Drawing.Point(101, 16);
            this.btnShowItems.Name = "btnShowItems";
            this.btnShowItems.Size = new System.Drawing.Size(93, 23);
            this.btnShowItems.TabIndex = 5;
            this.btnShowItems.Text = "Show Items";
            this.btnShowItems.UseVisualStyleBackColor = true;
            this.btnShowItems.Click += new System.EventHandler(this.btnShowItems_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMarkLost);
            this.groupBox1.Controls.Add(this.btnReturned);
            this.groupBox1.Controls.Add(this.btnShowItems);
            this.groupBox1.Location = new System.Drawing.Point(856, 435);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functions";
            // 
            // btnMarkLost
            // 
            this.btnMarkLost.Location = new System.Drawing.Point(6, 39);
            this.btnMarkLost.Name = "btnMarkLost";
            this.btnMarkLost.Size = new System.Drawing.Size(89, 23);
            this.btnMarkLost.TabIndex = 7;
            this.btnMarkLost.Text = "Mark Lost";
            this.btnMarkLost.UseVisualStyleBackColor = true;
            this.btnMarkLost.Click += new System.EventHandler(this.btnMarkLost_Click);
            // 
            // btnReturned
            // 
            this.btnReturned.Location = new System.Drawing.Point(6, 16);
            this.btnReturned.Name = "btnReturned";
            this.btnReturned.Size = new System.Drawing.Size(89, 23);
            this.btnReturned.TabIndex = 6;
            this.btnReturned.Text = "Mark Returned";
            this.btnReturned.UseVisualStyleBackColor = true;
            this.btnReturned.Click += new System.EventHandler(this.btnReturned_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(6, 65);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(393, 44);
            this.btnRepair.TabIndex = 7;
            this.btnRepair.Text = "Repair Queue";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(795, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 20);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1016, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(695, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(94, 23);
            this.btnClearSearch.TabIndex = 10;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 605);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCurrentView);
            this.Controls.Add(this.mainViewTable);
            this.Name = "MainForm";
            this.Text = "Hire Management V0.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainViewTable)).EndInit();
            this.gbCurrentView.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainViewTable;
        private System.Windows.Forms.GroupBox gbCurrentView;
        private System.Windows.Forms.Button btnLoans;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Button btnShowItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReturned;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Button btnMarkLost;
    }
}


namespace CSProject1
{
    partial class FormAddLoan
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
            this.btnConfirmAddLoan = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.cbAddLoanCustomer = new System.Windows.Forms.ComboBox();
            this.dtAddLoan = new System.Windows.Forms.DateTimePicker();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkCustomPrice = new System.Windows.Forms.CheckBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmAddLoan
            // 
            this.btnConfirmAddLoan.Location = new System.Drawing.Point(115, 314);
            this.btnConfirmAddLoan.Name = "btnConfirmAddLoan";
            this.btnConfirmAddLoan.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmAddLoan.TabIndex = 0;
            this.btnConfirmAddLoan.Text = "Confirm";
            this.btnConfirmAddLoan.UseVisualStyleBackColor = true;
            this.btnConfirmAddLoan.Click += new System.EventHandler(this.btnConfirmAddLoan_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.Location = new System.Drawing.Point(273, 314);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAdd.TabIndex = 1;
            this.btnCancelAdd.Text = "Cancel";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // cbAddLoanCustomer
            // 
            this.cbAddLoanCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddLoanCustomer.FormattingEnabled = true;
            this.cbAddLoanCustomer.Location = new System.Drawing.Point(115, 45);
            this.cbAddLoanCustomer.Name = "cbAddLoanCustomer";
            this.cbAddLoanCustomer.Size = new System.Drawing.Size(233, 21);
            this.cbAddLoanCustomer.TabIndex = 2;
            // 
            // dtAddLoan
            // 
            this.dtAddLoan.Location = new System.Drawing.Point(115, 88);
            this.dtAddLoan.Name = "dtAddLoan";
            this.dtAddLoan.Size = new System.Drawing.Size(233, 20);
            this.dtAddLoan.TabIndex = 3;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(115, 228);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(233, 23);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Add Items";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDelItem
            // 
            this.btnDelItem.Location = new System.Drawing.Point(376, 114);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(75, 23);
            this.btnDelItem.TabIndex = 8;
            this.btnDelItem.Text = "Delete Item";
            this.btnDelItem.UseVisualStyleBackColor = true;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Enabled = false;
            this.nudPrice.Location = new System.Drawing.Point(115, 279);
            this.nudPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(233, 20);
            this.nudPrice.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loan Cost:";
            // 
            // checkCustomPrice
            // 
            this.checkCustomPrice.AutoSize = true;
            this.checkCustomPrice.Location = new System.Drawing.Point(371, 282);
            this.checkCustomPrice.Name = "checkCustomPrice";
            this.checkCustomPrice.Size = new System.Drawing.Size(94, 17);
            this.checkCustomPrice.TabIndex = 11;
            this.checkCustomPrice.Text = "Custom Price?";
            this.checkCustomPrice.UseVisualStyleBackColor = true;
            this.checkCustomPrice.CheckedChanged += new System.EventHandler(this.checkCustomPrice_CheckedChanged);
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(115, 114);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(233, 108);
            this.lbItems.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Customer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Date Rented:";
            // 
            // FormAddLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 368);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.checkCustomPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.btnDelItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dtAddLoan);
            this.Controls.Add(this.cbAddLoanCustomer);
            this.Controls.Add(this.btnCancelAdd);
            this.Controls.Add(this.btnConfirmAddLoan);
            this.Name = "FormAddLoan";
            this.Text = "New Loan";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmAddLoan;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.ComboBox cbAddLoanCustomer;
        private System.Windows.Forms.DateTimePicker dtAddLoan;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkCustomPrice;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
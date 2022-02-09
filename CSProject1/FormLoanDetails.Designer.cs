namespace CSProject1
{
    partial class FormLoanDetails
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
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnRemoveDetail = new System.Windows.Forms.Button();
            this.btnCancelDetail = new System.Windows.Forms.Button();
            this.btnConfirmDetail = new System.Windows.Forms.Button();
            this.dataGridLoan = new System.Windows.Forms.DataGridView();
            this.dataGridDetails = new System.Windows.Forms.DataGridView();
            this.cbCustomerDetail = new System.Windows.Forms.ComboBox();
            this.txtEditOverrideCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxOverrideCost = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(12, 303);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(206, 23);
            this.btnAddDetail.TabIndex = 1;
            this.btnAddDetail.Text = "Add";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnRemoveDetail
            // 
            this.btnRemoveDetail.Location = new System.Drawing.Point(475, 303);
            this.btnRemoveDetail.Name = "btnRemoveDetail";
            this.btnRemoveDetail.Size = new System.Drawing.Size(206, 23);
            this.btnRemoveDetail.TabIndex = 2;
            this.btnRemoveDetail.Text = "Remove";
            this.btnRemoveDetail.UseVisualStyleBackColor = true;
            this.btnRemoveDetail.Click += new System.EventHandler(this.btnRemoveDetail_Click);
            // 
            // btnCancelDetail
            // 
            this.btnCancelDetail.Location = new System.Drawing.Point(606, 436);
            this.btnCancelDetail.Name = "btnCancelDetail";
            this.btnCancelDetail.Size = new System.Drawing.Size(75, 23);
            this.btnCancelDetail.TabIndex = 4;
            this.btnCancelDetail.Text = "Cancel";
            this.btnCancelDetail.UseVisualStyleBackColor = true;
            this.btnCancelDetail.Click += new System.EventHandler(this.btnCancelDetail_Click);
            // 
            // btnConfirmDetail
            // 
            this.btnConfirmDetail.Location = new System.Drawing.Point(12, 436);
            this.btnConfirmDetail.Name = "btnConfirmDetail";
            this.btnConfirmDetail.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmDetail.TabIndex = 5;
            this.btnConfirmDetail.Text = "OK";
            this.btnConfirmDetail.UseVisualStyleBackColor = true;
            this.btnConfirmDetail.Click += new System.EventHandler(this.btnConfirmDetail_Click);
            // 
            // dataGridLoan
            // 
            this.dataGridLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLoan.Location = new System.Drawing.Point(12, 12);
            this.dataGridLoan.Name = "dataGridLoan";
            this.dataGridLoan.ReadOnly = true;
            this.dataGridLoan.Size = new System.Drawing.Size(669, 62);
            this.dataGridLoan.TabIndex = 6;
            // 
            // dataGridDetails
            // 
            this.dataGridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetails.Location = new System.Drawing.Point(12, 89);
            this.dataGridDetails.Name = "dataGridDetails";
            this.dataGridDetails.ReadOnly = true;
            this.dataGridDetails.Size = new System.Drawing.Size(669, 208);
            this.dataGridDetails.TabIndex = 7;
            // 
            // cbCustomerDetail
            // 
            this.cbCustomerDetail.FormattingEnabled = true;
            this.cbCustomerDetail.Location = new System.Drawing.Point(12, 377);
            this.cbCustomerDetail.Name = "cbCustomerDetail";
            this.cbCustomerDetail.Size = new System.Drawing.Size(206, 21);
            this.cbCustomerDetail.TabIndex = 8;
            // 
            // txtEditOverrideCost
            // 
            this.txtEditOverrideCost.Enabled = false;
            this.txtEditOverrideCost.Location = new System.Drawing.Point(475, 377);
            this.txtEditOverrideCost.Name = "txtEditOverrideCost";
            this.txtEditOverrideCost.Size = new System.Drawing.Size(100, 20);
            this.txtEditOverrideCost.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Change Customer:";
            // 
            // checkBoxOverrideCost
            // 
            this.checkBoxOverrideCost.AutoSize = true;
            this.checkBoxOverrideCost.Location = new System.Drawing.Point(475, 357);
            this.checkBoxOverrideCost.Name = "checkBoxOverrideCost";
            this.checkBoxOverrideCost.Size = new System.Drawing.Size(96, 17);
            this.checkBoxOverrideCost.TabIndex = 14;
            this.checkBoxOverrideCost.Text = "Override Cost?";
            this.checkBoxOverrideCost.UseVisualStyleBackColor = true;
            this.checkBoxOverrideCost.CheckedChanged += new System.EventHandler(this.checkBoxOverrideCost_CheckedChanged);
            // 
            // FormLoanDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 471);
            this.Controls.Add(this.checkBoxOverrideCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEditOverrideCost);
            this.Controls.Add(this.cbCustomerDetail);
            this.Controls.Add(this.dataGridDetails);
            this.Controls.Add(this.dataGridLoan);
            this.Controls.Add(this.btnConfirmDetail);
            this.Controls.Add(this.btnCancelDetail);
            this.Controls.Add(this.btnRemoveDetail);
            this.Controls.Add(this.btnAddDetail);
            this.Name = "FormLoanDetails";
            this.Text = "Loan Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnRemoveDetail;
        private System.Windows.Forms.Button btnCancelDetail;
        private System.Windows.Forms.Button btnConfirmDetail;
        private System.Windows.Forms.DataGridView dataGridLoan;
        private System.Windows.Forms.DataGridView dataGridDetails;
        private System.Windows.Forms.ComboBox cbCustomerDetail;
        private System.Windows.Forms.TextBox txtEditOverrideCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxOverrideCost;
    }
}
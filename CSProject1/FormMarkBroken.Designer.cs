namespace CSProject1
{
    partial class FormMarkBroken
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
            this.dataGridLoan = new System.Windows.Forms.DataGridView();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnConfMarkBroken = new System.Windows.Forms.Button();
            this.btnCancelMarkBroken = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridLoan
            // 
            this.dataGridLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLoan.Location = new System.Drawing.Point(12, 23);
            this.dataGridLoan.Name = "dataGridLoan";
            this.dataGridLoan.Size = new System.Drawing.Size(465, 88);
            this.dataGridLoan.TabIndex = 0;
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(12, 140);
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(120, 20);
            this.nudQty.TabIndex = 2;
            this.nudQty.ValueChanged += new System.EventHandler(this.nudQty_ValueChanged);
            // 
            // btnConfMarkBroken
            // 
            this.btnConfMarkBroken.Location = new System.Drawing.Point(15, 175);
            this.btnConfMarkBroken.Name = "btnConfMarkBroken";
            this.btnConfMarkBroken.Size = new System.Drawing.Size(120, 23);
            this.btnConfMarkBroken.TabIndex = 3;
            this.btnConfMarkBroken.Text = "Mark Broken";
            this.btnConfMarkBroken.UseVisualStyleBackColor = true;
            this.btnConfMarkBroken.Click += new System.EventHandler(this.btnConfMarkBroken_Click);
            // 
            // btnCancelMarkBroken
            // 
            this.btnCancelMarkBroken.Location = new System.Drawing.Point(357, 177);
            this.btnCancelMarkBroken.Name = "btnCancelMarkBroken";
            this.btnCancelMarkBroken.Size = new System.Drawing.Size(120, 23);
            this.btnCancelMarkBroken.TabIndex = 4;
            this.btnCancelMarkBroken.Text = "Cancel";
            this.btnCancelMarkBroken.UseVisualStyleBackColor = true;
            this.btnCancelMarkBroken.Click += new System.EventHandler(this.btnCancelMarkBroken_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "How many?";
            // 
            // cbItem
            // 
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(138, 139);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(339, 21);
            this.cbItem.TabIndex = 6;
            this.cbItem.SelectedIndexChanged += new System.EventHandler(this.cbItem_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item:";
            // 
            // FormMarkBroken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 214);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelMarkBroken);
            this.Controls.Add(this.btnConfMarkBroken);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.dataGridLoan);
            this.Name = "FormMarkBroken";
            this.Text = "Mark an Item as Broken";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridLoan;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnConfMarkBroken;
        private System.Windows.Forms.Button btnCancelMarkBroken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
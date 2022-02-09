namespace CSProject1
{
    partial class FormAddOldStock
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
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnConfAddOldStock = new System.Windows.Forms.Button();
            this.btnCancelAddOldStock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOldItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(224, 34);
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(76, 20);
            this.nudQty.TabIndex = 0;
            // 
            // btnConfAddOldStock
            // 
            this.btnConfAddOldStock.Location = new System.Drawing.Point(12, 105);
            this.btnConfAddOldStock.Name = "btnConfAddOldStock";
            this.btnConfAddOldStock.Size = new System.Drawing.Size(62, 23);
            this.btnConfAddOldStock.TabIndex = 1;
            this.btnConfAddOldStock.Text = "Confirm";
            this.btnConfAddOldStock.UseVisualStyleBackColor = true;
            this.btnConfAddOldStock.Click += new System.EventHandler(this.btnConfAddOldStock_Click);
            // 
            // btnCancelAddOldStock
            // 
            this.btnCancelAddOldStock.Location = new System.Drawing.Point(238, 105);
            this.btnCancelAddOldStock.Name = "btnCancelAddOldStock";
            this.btnCancelAddOldStock.Size = new System.Drawing.Size(62, 23);
            this.btnCancelAddOldStock.TabIndex = 2;
            this.btnCancelAddOldStock.Text = "Cancel";
            this.btnCancelAddOldStock.UseVisualStyleBackColor = true;
            this.btnCancelAddOldStock.Click += new System.EventHandler(this.btnCancelAddOldStock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantity*:";
            // 
            // cbOldItem
            // 
            this.cbOldItem.FormattingEnabled = true;
            this.cbOldItem.Location = new System.Drawing.Point(12, 33);
            this.cbOldItem.Name = "cbOldItem";
            this.cbOldItem.Size = new System.Drawing.Size(162, 21);
            this.cbOldItem.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item*:";
            // 
            // txtInfo
            // 
            this.txtInfo.Enabled = false;
            this.txtInfo.Location = new System.Drawing.Point(12, 79);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(288, 20);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.Text = "*All fields marked with an asterisk must be filled in.";
            // 
            // FormAddOldStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 140);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbOldItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelAddOldStock);
            this.Controls.Add(this.btnConfAddOldStock);
            this.Controls.Add(this.nudQty);
            this.Name = "FormAddOldStock";
            this.Text = "Add New Stock";
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnConfAddOldStock;
        private System.Windows.Forms.Button btnCancelAddOldStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOldItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInfo;
    }
}
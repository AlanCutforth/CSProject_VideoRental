namespace CSProject1
{
    partial class FormAddNewStock
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
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnConfAddNewItem = new System.Windows.Forms.Button();
            this.btnCancelAddNewItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(12, 36);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(166, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(205, 37);
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(120, 20);
            this.nudQty.TabIndex = 1;
            // 
            // btnConfAddNewItem
            // 
            this.btnConfAddNewItem.Location = new System.Drawing.Point(12, 147);
            this.btnConfAddNewItem.Name = "btnConfAddNewItem";
            this.btnConfAddNewItem.Size = new System.Drawing.Size(75, 23);
            this.btnConfAddNewItem.TabIndex = 3;
            this.btnConfAddNewItem.Text = "Confirm";
            this.btnConfAddNewItem.UseVisualStyleBackColor = true;
            this.btnConfAddNewItem.Click += new System.EventHandler(this.btnConfAddNewItem_Click);
            // 
            // btnCancelAddNewItem
            // 
            this.btnCancelAddNewItem.Location = new System.Drawing.Point(250, 147);
            this.btnCancelAddNewItem.Name = "btnCancelAddNewItem";
            this.btnCancelAddNewItem.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAddNewItem.TabIndex = 4;
            this.btnCancelAddNewItem.Text = "Cancel";
            this.btnCancelAddNewItem.UseVisualStyleBackColor = true;
            this.btnCancelAddNewItem.Click += new System.EventHandler(this.btnCancelAddNewItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item Name*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantity*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cost*:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(313, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "*All fields marked with an asterisk must be filled in.";
            // 
            // nudCost
            // 
            this.nudCost.Location = new System.Drawing.Point(12, 99);
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(120, 20);
            this.nudCost.TabIndex = 9;
            // 
            // FormAddNewStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 182);
            this.Controls.Add(this.nudCost);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelAddNewItem);
            this.Controls.Add(this.btnConfAddNewItem);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.txtItemName);
            this.Name = "FormAddNewStock";
            this.Text = "New Item";
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnConfAddNewItem;
        private System.Windows.Forms.Button btnCancelAddNewItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown nudCost;
    }
}
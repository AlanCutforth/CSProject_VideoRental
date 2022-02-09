namespace CSProject1
{
    partial class FormEditItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfEditItem = new System.Windows.Forms.Button();
            this.btnCancelEditItem = new System.Windows.Forms.Button();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(12, 32);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(125, 20);
            this.txtItemName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Name:";
            // 
            // btnConfEditItem
            // 
            this.btnConfEditItem.Location = new System.Drawing.Point(12, 63);
            this.btnConfEditItem.Name = "btnConfEditItem";
            this.btnConfEditItem.Size = new System.Drawing.Size(61, 23);
            this.btnConfEditItem.TabIndex = 2;
            this.btnConfEditItem.Text = "Confirm";
            this.btnConfEditItem.UseVisualStyleBackColor = true;
            this.btnConfEditItem.Click += new System.EventHandler(this.btnConfEditItem_Click);
            // 
            // btnCancelEditItem
            // 
            this.btnCancelEditItem.Location = new System.Drawing.Point(230, 63);
            this.btnCancelEditItem.Name = "btnCancelEditItem";
            this.btnCancelEditItem.Size = new System.Drawing.Size(58, 23);
            this.btnCancelEditItem.TabIndex = 3;
            this.btnCancelEditItem.Text = "Cancel";
            this.btnCancelEditItem.UseVisualStyleBackColor = true;
            this.btnCancelEditItem.Click += new System.EventHandler(this.btnCancelEditItem_Click);
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(163, 32);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(125, 20);
            this.txtCost.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cost:";
            // 
            // FormEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 98);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.btnCancelEditItem);
            this.Controls.Add(this.btnConfEditItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtItemName);
            this.Name = "FormEditItem";
            this.Text = "Edit Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfEditItem;
        private System.Windows.Forms.Button btnCancelEditItem;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label2;
    }
}
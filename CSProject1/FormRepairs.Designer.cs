namespace CSProject1
{
    partial class FormRepairs
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
            this.lbRepairQueue = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnConfRepairQueue = new System.Windows.Forms.Button();
            this.btnMarkRepaired = new System.Windows.Forms.Button();
            this.btnMarkDestroyed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRepairQueue
            // 
            this.lbRepairQueue.FormattingEnabled = true;
            this.lbRepairQueue.Location = new System.Drawing.Point(152, 25);
            this.lbRepairQueue.Name = "lbRepairQueue";
            this.lbRepairQueue.Size = new System.Drawing.Size(120, 212);
            this.lbRepairQueue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Repair Queue:";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(30, 117);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(96, 40);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Move Item Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(30, 163);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(96, 40);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Move Item Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnConfRepairQueue
            // 
            this.btnConfRepairQueue.Location = new System.Drawing.Point(106, 276);
            this.btnConfRepairQueue.Name = "btnConfRepairQueue";
            this.btnConfRepairQueue.Size = new System.Drawing.Size(75, 23);
            this.btnConfRepairQueue.TabIndex = 4;
            this.btnConfRepairQueue.Text = "Done";
            this.btnConfRepairQueue.UseVisualStyleBackColor = true;
            this.btnConfRepairQueue.Click += new System.EventHandler(this.btnConfRepairQueue_Click);
            // 
            // btnMarkRepaired
            // 
            this.btnMarkRepaired.Location = new System.Drawing.Point(30, 25);
            this.btnMarkRepaired.Name = "btnMarkRepaired";
            this.btnMarkRepaired.Size = new System.Drawing.Size(96, 40);
            this.btnMarkRepaired.TabIndex = 5;
            this.btnMarkRepaired.Text = "Mark Top Item Repaired";
            this.btnMarkRepaired.UseVisualStyleBackColor = true;
            this.btnMarkRepaired.Click += new System.EventHandler(this.btnMarkRepaired_Click);
            // 
            // btnMarkDestroyed
            // 
            this.btnMarkDestroyed.Location = new System.Drawing.Point(30, 71);
            this.btnMarkDestroyed.Name = "btnMarkDestroyed";
            this.btnMarkDestroyed.Size = new System.Drawing.Size(96, 40);
            this.btnMarkDestroyed.TabIndex = 6;
            this.btnMarkDestroyed.Text = "Mark Top Item Destroyed";
            this.btnMarkDestroyed.UseVisualStyleBackColor = true;
            this.btnMarkDestroyed.Click += new System.EventHandler(this.btnMarkDestroyed_Click);
            // 
            // FormRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.btnMarkDestroyed);
            this.Controls.Add(this.btnMarkRepaired);
            this.Controls.Add(this.btnConfRepairQueue);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRepairQueue);
            this.Name = "FormRepairs";
            this.Text = "Repair Queue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRepairQueue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnConfRepairQueue;
        private System.Windows.Forms.Button btnMarkRepaired;
        private System.Windows.Forms.Button btnMarkDestroyed;
    }
}
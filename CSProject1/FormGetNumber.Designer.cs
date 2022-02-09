namespace CSProject1
{
    partial class FormGetNumber
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
            this.labelText = new System.Windows.Forms.Label();
            this.btnOKGetNum = new System.Windows.Forms.Button();
            this.btnCancelGetNum = new System.Windows.Forms.Button();
            this.nudNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(12, 9);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(29, 13);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "label";
            // 
            // btnOKGetNum
            // 
            this.btnOKGetNum.Location = new System.Drawing.Point(15, 60);
            this.btnOKGetNum.Name = "btnOKGetNum";
            this.btnOKGetNum.Size = new System.Drawing.Size(56, 23);
            this.btnOKGetNum.TabIndex = 2;
            this.btnOKGetNum.Text = "OK";
            this.btnOKGetNum.UseVisualStyleBackColor = true;
            this.btnOKGetNum.Click += new System.EventHandler(this.btnOKGetNum_Click);
            // 
            // btnCancelGetNum
            // 
            this.btnCancelGetNum.Location = new System.Drawing.Point(77, 60);
            this.btnCancelGetNum.Name = "btnCancelGetNum";
            this.btnCancelGetNum.Size = new System.Drawing.Size(56, 23);
            this.btnCancelGetNum.TabIndex = 3;
            this.btnCancelGetNum.Text = "Cancel";
            this.btnCancelGetNum.UseVisualStyleBackColor = true;
            this.btnCancelGetNum.Click += new System.EventHandler(this.btnCancelGetNum_Click);
            // 
            // nudNum
            // 
            this.nudNum.Location = new System.Drawing.Point(18, 34);
            this.nudNum.Name = "nudNum";
            this.nudNum.Size = new System.Drawing.Size(115, 20);
            this.nudNum.TabIndex = 4;
            this.nudNum.ValueChanged += new System.EventHandler(this.nudNum_ValueChanged);
            // 
            // FormGetNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 99);
            this.Controls.Add(this.nudNum);
            this.Controls.Add(this.btnCancelGetNum);
            this.Controls.Add(this.btnOKGetNum);
            this.Controls.Add(this.labelText);
            this.Name = "FormGetNumber";
            this.Text = "Enter Number";
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button btnOKGetNum;
        private System.Windows.Forms.Button btnCancelGetNum;
        private System.Windows.Forms.NumericUpDown nudNum;
    }
}
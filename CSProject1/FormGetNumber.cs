using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject1
{
    public partial class FormGetNumber : Form
    {
        public string Message { get; set; }
        public int Input { get; set; }
        public int MaxInput { get; set; }
        public int MinInput { get; set; }
        public int InitialInput { get; set; }

        public FormGetNumber(string _Message, int _MinInput, int _MaxInput, int _InitialInput)
        {
            //Allows the passed in variables to be used in the rest of the methods in this Form, and sets the text displayed on the screen to the specified
            //message andd the value to the specified initial value.
            InitializeComponent();

            Message = _Message;
            MinInput = _MinInput;
            MaxInput = _MaxInput;
            InitialInput = _InitialInput;

            labelText.Text = Message;

            nudNum.Value = InitialInput;
        }

        //Closes the form.
        private void btnCancelGetNum_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Confirms the input of the number.
        private void btnOKGetNum_Click(object sender, EventArgs e)
        {
            //Checks to see if the number input is valid.
            try
            {
                Input = Convert.ToInt32(nudNum.Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter a numeric, non decimal number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Closes the form.
            this.DialogResult = DialogResult.OK;
        }

        //Ensures the value does not go lower or higher than the specified parameters.
        private void nudNum_ValueChanged(object sender, EventArgs e)
        {
            if (nudNum.Value > MaxInput)
            {
                nudNum.Value = MaxInput;
            }
            else if (nudNum.Value < MinInput)
            {
                nudNum.Value = MinInput;
            }
        }
    }
}

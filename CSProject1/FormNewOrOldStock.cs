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
    //Checks if the user wishes to add a new or existing item to the stock table of the database when the 'Add' button is pressed on stock
    //on the main table.
    public partial class FormNewOrOldStock : Form
    {
        public FormNewOrOldStock()
        {
            InitializeComponent();
        }

        private void btnCancelNewOrExisting_Click(object sender, EventArgs e)
        {
            //Cancels the addition of a new item.
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //Confirms the user's choice to add a new item.
            this.DialogResult = DialogResult.Yes;
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            //Confirms the user's choice to add quantity to an existing item.
            this.DialogResult = DialogResult.No;
        }
    }
}

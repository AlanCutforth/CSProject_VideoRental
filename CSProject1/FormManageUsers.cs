using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject1
{
    public partial class FormManageUsers : Form
    {
        private SqlConnection _DBCon;

        public FormManageUsers(SqlConnection DBCon)
        {
            //Sets up the database connection and loads the list of users.
            InitializeComponent();

            _DBCon = DBCon;

            refreshUserList();
        }

        //Changes the password of a user.
        private void btnMasterPasswordChange_Click(object sender, EventArgs e)
        {
            FormPasswordField passwordChanger = new FormPasswordField(_DBCon);

            //Checks to see if the user pressed OK on the New Password form.
            if (passwordChanger.ShowDialog() == DialogResult.OK)
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Updates the password field of the chosen user in the database with the new password.
                    SqlCommand cmdPasswordUpdate = new SqlCommand("update Users set Password = '" + passwordChanger.NewPassword + "' where Password = '" + passwordChanger.OldPassword +
                        "' and Username = '" + Session.User + "'", _DBCon, tran);
                    cmdPasswordUpdate.ExecuteNonQuery();

                    tran.Commit();
                }
                catch(Exception ex)
                {
                    //An error occured, hence the transaction is rolled back to protect data integrity.
                    tran.Rollback();

                    throw;
                }
            }

        }

        //Adds a new user.
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAddUser newUser = new FormAddUser();

            //Checks if the user pressed OK on the New User form.
            if (newUser.ShowDialog() == DialogResult.OK)
            {
                //Loads any records from the users table in the database with the specified username and checks if more than one record was loaded.
                SqlCommand cmdCheckUnique = new SqlCommand("select * from Users where Username = '" + newUser.Username + "'", _DBCon);
                SqlDataAdapter Adpt = new SqlDataAdapter(cmdCheckUnique);
                DataTable Table = new DataTable();
                Adpt.Fill(Table);

                if (Table.Rows.Count > 0)
                {
                    MessageBox.Show("Error: There is already an account with this username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Adds the new user with the specified username and password into the users table in the database.
                        SqlCommand cmdAddUser = new SqlCommand("insert into Users (Username, Password, Admin) values ('" + newUser.Username + "', '" + newUser.Password + "', '" + newUser.IsAdmin + "')", _DBCon);
                        cmdAddUser.ExecuteNonQuery();

                        tran.Commit();

                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        refreshUserList();
                    }
                    catch(Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }                
            }
        }

        //Deletes a user.
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result;

            DataRowView RowView = (DataRowView)lbUsers.SelectedItem;

            //Loads a list of administrators from the users table of the database.
            SqlCommand CmdCheckAdminCount = new SqlCommand("select * from Users where Admin = 'Yes'", _DBCon);
            SqlDataAdapter AdptCheckAdminCount = new SqlDataAdapter(CmdCheckAdminCount);
            DataTable TableCheckAdminCount = new DataTable();
            AdptCheckAdminCount.Fill(TableCheckAdminCount);

            //Checks if the user is attempting to delete the last administrator (effectively locking the staff out of some parts of the system) or if the user is trying to delete themselves.
            if (((RowView.Row["Admin"].ToString() == "Yes") && (TableCheckAdminCount.Rows.Count != 1)) || (RowView.Row["Username"].ToString() == Session.User))
            {
                MessageBox.Show("This user cannot be deleted at this time. This may be because they are the last admin, or they are the user currently logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                result = MessageBox.Show("Are you sure you want to delete user " + (RowView.Row["Username"].ToString()).Replace(" ", "") + "? Their name will still show up on transactions they dealt with.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        string deletedUser = (RowView.Row["Username"].ToString()).Replace(" ", "");

                        //Deletes the specified user from the database.
                        SqlCommand cmdDeleteUser = new SqlCommand("delete from Users where Username = '" + deletedUser + "'", _DBCon);
                        cmdDeleteUser.ExecuteNonQuery();

                        MessageBox.Show("User " + deletedUser + " deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tran.Commit();

                        refreshUserList();
                    }
                    catch(Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
            }
        }

        //Loads the list of users into the listbox on the form.
        private void refreshUserList()
        {
            SqlCommand cmd = new SqlCommand("select UserID, Username from Users", _DBCon);
            SqlDataAdapter Adpt = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable();
            Adpt.Fill(Table);

            lbUsers.DataSource = Table;
            lbUsers.DisplayMember = "Username";
        }
    }
}

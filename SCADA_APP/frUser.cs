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

namespace SCADA_APP
{
    public partial class frUser : Form
    {
        
        public frUser()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void frUser_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(Properties.Settings.Default.SQLPath);
            con.Open();
            //Show_Infor();

            lbDisplayName.Text = Properties.Settings.Default.DisplayName;
            lbPosition.Text = Properties.Settings.Default.Position;
            lbPhone.Text = Properties.Settings.Default.Phone;

            //Properties.Settings.Default.Position = lbPosition.Text;
            //Properties.Settings.Default.Save();
            if (lbPosition.Text == "Admin")
            {
                Show_data();
            }
            else if (lbPosition.Text == "Operator")
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnReset.Enabled = false;
                btnSearch.Enabled = false;
            }
        }

        public void Show_data()
        {
            string sqlSelect = "SELECT *FROM tbl_User";
            SqlCommand sqlCmd = new SqlCommand(sqlSelect, con);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlRead);   
            dgvUser.DataSource = dt;
        }

        private void frUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPosition.Text == "" || txtPhone.Text == "")
                MessageBox.Show("Please complete all information ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string sqlAdd = "INSERT INTO tbl_User VALUES(@UserName, @DisplayName, @Password, @Position, @Phone)";
                SqlCommand sqlCmd = new SqlCommand(sqlAdd, con);
                sqlCmd.Parameters.AddWithValue("Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("DisplayName", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Password", txtPassword.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Position", txtPosition.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Phone", txtPhone.Text.Trim());
                sqlCmd.ExecuteNonQuery();
              
                Show_data();
                MessageBox.Show("Add User successfully !", "Notification",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtPosition.Text = "";
                txtPhone.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                MessageBox.Show("Please fill in the information to delete ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string sqlDelete = "DELETE FROM tbl_User WHERE Username = @Username";
                SqlCommand sqlCmd = new SqlCommand(sqlDelete, con);
                sqlCmd.Parameters.AddWithValue("Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("DisplayName", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Password", txtPassword.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Position", txtPosition.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Phone", txtPhone.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                Show_data();

                MessageBox.Show("Delete User successfully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPosition.Text == "" || txtPhone.Text == "")
                MessageBox.Show("Please complete all information ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string sqlUpdate = "UPDATE tbl_User SET DisplayName = @DisplayName, Password = @Password, " +
                "Position = @Position, Phone = @Phone WHERE Username = @Username";
                SqlCommand sqlCmd = new SqlCommand(sqlUpdate, con);
                sqlCmd.Parameters.AddWithValue("Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("DisplayName", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Password", txtPassword.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Position", txtPosition.Text.Trim());
                sqlCmd.Parameters.AddWithValue("Phone", txtPhone.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                Show_data();

                MessageBox.Show("Update User successfully !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlSearch = "SELECT *FROM tbl_User WHERE Username = @Username";
            SqlCommand sqlCmd = new SqlCommand(sqlSearch, con);
            sqlCmd.Parameters.AddWithValue("Username", txtSearch.Text.Trim());
            sqlCmd.Parameters.AddWithValue("DisplayName", txtName.Text.Trim());       
            sqlCmd.Parameters.AddWithValue("Password", txtPassword.Text.Trim());
            sqlCmd.Parameters.AddWithValue("Position", txtPosition.Text.Trim());
            sqlCmd.Parameters.AddWithValue("Phone", txtPhone.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlRead);
            dgvUser.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //Properties.Settings.Default.Save();
        }



        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            panel2.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Show_data();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbPosition_Click(object sender, EventArgs e)
        {

        }
    }
}

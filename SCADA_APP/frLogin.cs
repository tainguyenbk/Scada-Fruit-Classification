using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCADA_APP
{
    public partial class frLogin : Form
    {
        public frLogin()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.SQLPath);

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            picUername.Image = Properties.Resources.username2;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtUsername.ForeColor = Color.FromArgb(78, 184, 206);

            picPassword.Image = Properties.Resources.lock1;
            panel2.BackColor = Color.WhiteSmoke;
            txtPassword.ForeColor = Color.White;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
            picPassword.Image = Properties.Resources.lock2;
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtPassword.ForeColor = Color.FromArgb(78, 184, 206);

            picUername.Image = Properties.Resources.username1;
            panel1.BackColor = Color.WhiteSmoke;
            txtUsername.ForeColor = Color.White;
        }


        private void btnSingIn_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Username = txtUsername.Text;
            //Properties.Settings.Default.Save();
            Show_Infor();
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM tbl_User WHERE Username = @Username AND Password = @Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    //Thread _Thread = new Thread(new ThreadStart(Show_frHome));
                    //_Thread.Start();
                    //this.Close();
                    //Show_frHome();
                    frHome frhome = new frHome();
                    frhome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect, Please login again !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
           
        }
        public void Show_Infor()
        {
            sqlCon.Open();
            string sql = "SELECT * FROM tbl_User WHERE Username = '" + txtUsername.Text + "'";
            
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    Properties.Settings.Default.DisplayName = dr["DisplayName"].ToString();
                    Properties.Settings.Default.Position = dr["Position"].ToString();
                    Properties.Settings.Default.Phone = dr["Phone"].ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

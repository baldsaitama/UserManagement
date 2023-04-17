using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagement
{
    public partial class frmLogin : Form
    {
        static string connectionString = "Server=SAGAR-PC;Initial Catalog=UserManagementDB;Integrated Security=True;Encrypt=False;";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegisterForm_Click(object sender, EventArgs e)
        {
            frmUser frmuser = new frmUser();
            frmuser.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "Select * from pl_users where username = @username and password = @password";
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["fk_role_id"].ToString() == "9")
                            {
                                frmUserAdmin admin = new frmUserAdmin();
                                admin.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Login Sucessful!", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"arning", MessageBoxButtons.OK);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

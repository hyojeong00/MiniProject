using MetroFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((!rdbtnAdmin.Checked && !rdbtnMember.Checked))
            {
                MetroMessageBox.Show(this,"관리자/사용자 모드를 선택해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoginProcess();
        }

        private void LoginProcess()
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MetroMessageBox.Show(this,"아이디/패스워드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                txtID.Focus();
                return;
            }

            if (rdbtnMember.Checked)
            { 
                try
                {
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING)) 
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT userID, userSearch FROM userTbl " +
                                          " WHERE userID = @userID " +
                                            " AND userPassword = @userPassword ";
                        SqlParameter paramUserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                        paramUserID.Value = txtID.Text;
                        cmd.Parameters.Add(paramUserID);

                        SqlParameter paramUserPassword = new SqlParameter("@userPassword", SqlDbType.VarChar, 50);
                        paramUserPassword.Value = txtPassword.Text;
                        cmd.Parameters.Add(paramUserPassword);

                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        string struserID = reader["userID"] != null ? reader["userID"].ToString() : "";


                        if (struserID != "")
                        {
                            MetroMessageBox.Show(this,"접속성공", "로그인성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Commons.LOGINUSERID = struserID;
                            this.Close();
                        }
                        else
                        {
                            MetroMessageBox.Show(this,"접속실패", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(this,"로그인에 실패했습니다.\n아이디/비밀번호를 확인해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Clear();
                    txtPassword.Clear();
                    txtID.Focus();
                }
            }

            if(rdbtnAdmin.Checked)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING)) //commons.cs 로 만들었어요
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT masterID FROM masterTbl " +
                                          " WHERE masterID = @masterID " +
                                            " AND masterPassword = @masterPassword ";
                        SqlParameter paramMasterID = new SqlParameter("@masterID", SqlDbType.VarChar, 50);
                        paramMasterID.Value = txtID.Text;
                        cmd.Parameters.Add(paramMasterID);

                        SqlParameter paramPassword = new SqlParameter("@masterPassword", SqlDbType.VarChar, 50);
                        paramPassword.Value = txtPassword.Text;
                        cmd.Parameters.Add(paramPassword);

                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        string strMasterID = reader["masterID"] !=null? reader["masterID"].ToString():"";

                        if(strMasterID !="")
                        {
                            MetroMessageBox.Show(this,"접속성공", "로그인성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //HJ 수정 [20200703 16:40] : form.showDialog()를 하게 되면 Login창이 꺼지지 않음, 코드 위치 수정
                            //HJ 추가 [20200703 20:55] : Program.cs에 미리 창을 만들어 놓음으로서 Login창이 꺼지더라도 관리자 창이 안꺼지도록 수정
                            Commons.LOGINUSERID = strMasterID;
                            //AdministrationForm form = new AdministrationForm();
                            //form.Show();
                            this.Close();
                        }
                        else
                        {
                            MetroMessageBox.Show(this,"접속실패", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                catch(Exception)
                {
                    MetroMessageBox.Show(this,"로그인에 실패했습니다.\n아이디 / 비밀번호를 확인해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Clear();
                    txtPassword.Clear();
                    txtID.Focus ();
                }
                
            }

        }
       
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                txtPassword.Focus();
        
                txtID.BackColor = SystemColors.Control;
                panel4.BackColor = SystemColors.Control;
                txtPassword.BackColor = Color.White;
                panel7.BackColor = SystemColors.Window;
            }
            if (e.KeyChar == (char)9)
            {
                

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
               btnOK.Focus();
                txtID.BackColor = SystemColors.Control;
                panel4.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                panel7.BackColor = SystemColors.Control;
            }
        }

        private void rdbtnMember_MouseClick(object sender, MouseEventArgs e)
        {
            btnOK.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewMemberForm form = new NewMemberForm();
            form.ShowDialog();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
            panel4.BackColor = SystemColors.Window;
            txtPassword.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtID.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
            txtPassword.BackColor = Color.White;
            panel7.BackColor = SystemColors.Window;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
            panel4.BackColor = SystemColors.Window;
            txtPassword.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel7.BackColor = SystemColors.Window;
            txtID.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
            panel4.BackColor = SystemColors.Window;
            txtPassword.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel7.BackColor = SystemColors.Window;
            txtID.BackColor = SystemColors.Control;
            panel4.BackColor = SystemColors.Control;
        }

        private void rdbtnAdmin_CheckedChanged(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
            panel4.BackColor = SystemColors.Window;
            txtPassword.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
        }

        private void rdbtnMember_CheckedChanged(object sender, EventArgs e)
        {
            txtID.BackColor = Color.White;
            panel4.BackColor = SystemColors.Window;
            txtPassword.BackColor = SystemColors.Control;
            panel7.BackColor = SystemColors.Control;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

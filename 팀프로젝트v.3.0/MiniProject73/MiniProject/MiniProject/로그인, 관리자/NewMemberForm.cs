using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using MetroFramework;

namespace MiniProject
{
    public partial class NewMemberForm : Form
    { 
        bool overlapcheck = false;
        
        public NewMemberForm()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewMemberForm_Load(object sender, EventArgs e)
        {
            UpdateCbo();
            txtName.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(txtAge.Text)
                || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text)
                || (!rdbtnFemale.Checked && !rdbtnMale.Checked) || (cboUSCallPlan.SelectedIndex == -1))
            {
                MetroMessageBox.Show(this,"빈 값은 저장할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (overlapcheck == false)
            {
                MetroMessageBox.Show(this,"중복확인을 해주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveProcess();
            this.Close();

          

        }

        private void SaveProcess()
        {
            int std1, std2, std3;

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string strQuery = " SELECT STD1, STD2, STD3 "
                                  + " FROM productTbl "
                                 + " WHERE CallingPlan = @CallingPlan";

                cmd.CommandText = strQuery;
                SqlParameter paramCalling = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
            
                paramCalling.Value = cboUSCallPlan.Text;
                cmd.Parameters.Add(paramCalling);

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                std1 = int.Parse(reader[0].ToString());
                std2 = int.Parse(reader[1].ToString());
                std3 = int.Parse(reader[2].ToString());

            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string strQuery = "INSERT INTO userTbl "
                                           + " (userID, userName, userPassword, userAge, userGender, userMobile, userUSCallPlan, userSearch, STD1, STD2, STD3) "
                                    + " VALUES (@userID, @userName, @userPassword, @userAge, @userGender, @userMobile, @userUSCallPlan, @userSearch, @STD1, @STD2, @STD3)";

                cmd.CommandText = strQuery;
                SqlParameter paramUserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                paramUserID.Value = txtID.Text;
                cmd.Parameters.Add(paramUserID);

                SqlParameter paramName = new SqlParameter("@userName", SqlDbType.NVarChar, 20);
                paramName.Value = txtName.Text;
                cmd.Parameters.Add(paramName);

                SqlParameter paramPassword = new SqlParameter("@userPassword", SqlDbType.VarChar, 50);
                paramPassword.Value = txtPassword.Text;
                cmd.Parameters.Add(paramPassword);

                SqlParameter paramAge = new SqlParameter("@userAge", SqlDbType.Int);
                paramAge.Value = txtAge.Text;
                cmd.Parameters.Add(paramAge);

                SqlParameter paramGender = new SqlParameter("@userGender", SqlDbType.NChar, 10);
                if (rdbtnMale.Checked)
                {
                    paramGender.Value = rdbtnMale.Text;
                }
                if (rdbtnFemale.Checked)
                {
                    paramGender.Value = rdbtnFemale.Text;
                }
                cmd.Parameters.Add(paramGender);

                SqlParameter paramMobile = new SqlParameter("@userMobile", SqlDbType.VarChar, 13);
                paramMobile.Value = txtMobile.Text;
                cmd.Parameters.Add(paramMobile);

                SqlParameter paramUSCallPlan = new SqlParameter("@userUSCallPlan", SqlDbType.NVarChar, 50);
                paramUSCallPlan.Value = cboUSCallPlan.Text;
                cmd.Parameters.Add(paramUSCallPlan);

                //3
                SqlParameter paramUserSearch = new SqlParameter("@userSearch", SqlDbType.Bit);
                paramUserSearch.Value = 0;
                cmd.Parameters.Add(paramUserSearch);

                SqlParameter paramSTD1 = new SqlParameter("@STD1", SqlDbType.Int);
                paramSTD1.Value = std1.ToString();
                cmd.Parameters.Add(paramSTD1);

                SqlParameter paramSTD2 = new SqlParameter("@STD2", SqlDbType.Int);
                paramSTD2.Value = std2.ToString();
                cmd.Parameters.Add(paramSTD2);

                SqlParameter paramSTD3 = new SqlParameter("@STD3", SqlDbType.Int);
                paramSTD3.Value = std3.ToString();
                cmd.Parameters.Add(paramSTD3);

                cmd.ExecuteNonQuery();

                MetroMessageBox.Show(this,"회원가입이 완료되었습니다.", "환영합니다.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void UpdateCbo()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = " SELECT CallingPlan, Company FROM dbo.productTbl";
                SqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[1].ToString());
                }

                cboUSCallPlan.DataSource = new BindingSource(temps, null);
                cboUSCallPlan.DisplayMember = "Key";
                cboUSCallPlan.ValueMember = "Value";
                cboUSCallPlan.SelectedIndex = -1;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if(e.KeyChar==(char)13)
            {
                rdbtnMale.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = Color.White;
                pnlGender.BackColor = Color.White;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if(e.KeyChar == (char)13)
            {
                cboUSCallPlan.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = Color.White;
                cboUSCallPlan.BackColor = Color.White;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            Checking();
        }

        private void Checking()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = "SELECT userID FROM userTbl WHERE userID=@userID ";
                SqlCommand command = new SqlCommand(strQuery, conn);
                string temp = "";

                SqlParameter paramUserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                paramUserID.Value = txtID.Text;
                command.Parameters.Add(paramUserID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        MetroMessageBox.Show(this,"이미 사용중인 아이디입니다.\n아이디를 확인해 주세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Clear();
                        txtID.Focus();
                        return;
                    }
                    else if(string.IsNullOrEmpty(txtID.Text))
                    {
                        MetroMessageBox.Show(this,"아이디가 입력되지 않았습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Clear();
                        txtID.Focus();
                        return;
                    }
                    else
                    {
                        overlapcheck = true;
                        MetroMessageBox.Show(this,"사용 가능한 아이디입니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;
            pnlName.BackColor = Color.White;
            lblName.BackColor = Color.White;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = Color.White;
            txtID.BackColor = Color.White;
            lblID.BackColor = Color.White;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            lblPassword.BackColor = Color.White;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void rdbtnMale_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = Color.White;
            pnlGender.BackColor = Color.White;
        }

        private void rdbtnFemale_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = Color.White;
            pnlGender.BackColor = Color.White;
        }

        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = Color.White;
            txtMobile.BackColor = Color.White;
            lblMobile.BackColor = Color.White;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void txtAge_Click(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = Color.White;
            txtAge.BackColor = Color.White;
            lblAge.BackColor = Color.White;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void cboUSCallPlan_DropDown(object sender, EventArgs e)
        {
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
            lblPassword.BackColor = SystemColors.Control;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = Color.White;
            cboUSCallPlan.BackColor = Color.White;
            lblPlan.BackColor = Color.White;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                txtID.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = Color.White;
                txtID.BackColor = Color.White;
                lblID.BackColor = Color.White;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }

            if (e.KeyChar == (char)11)
            {
                txtID.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = Color.White;
                txtID.BackColor = Color.White;
                lblID.BackColor = Color.White;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnID.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
                lblPassword.BackColor = Color.White;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
            if (e.KeyChar == (char)11)
            {
                btnID.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
                lblPassword.BackColor = Color.White;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtAge.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = Color.White;
                txtAge.BackColor = Color.White;
                lblAge.BackColor = Color.White;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
            if (e.KeyChar == (char)11)
            {
                txtAge.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = Color.White;
                txtAge.BackColor = Color.White;
                lblAge.BackColor = Color.White;
                pnlMobile.BackColor = SystemColors.Control;
                txtMobile.BackColor = SystemColors.Control;
                lblMobile.BackColor = SystemColors.Control;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
        }

        private void rdbtnMale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtMobile.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = Color.White;
                txtMobile.BackColor = Color.White;
                lblMobile.BackColor = Color.White;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
            if (e.KeyChar == (char)11)
            {
                txtMobile.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = Color.White;
                txtMobile.BackColor = Color.White;
                lblMobile.BackColor = Color.White;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
        }

        private void rdbtnFemale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                txtMobile.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = Color.White;
                txtMobile.BackColor = Color.White;
                lblMobile.BackColor = Color.White;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
            if (e.KeyChar == (char)11)
            {
                txtMobile.Focus();
                txtName.BackColor = SystemColors.Control;
                pnlName.BackColor = SystemColors.Control;
                lblName.BackColor = SystemColors.Control;
                pnlID.BackColor = SystemColors.Control;
                txtID.BackColor = SystemColors.Control;
                lblID.BackColor = SystemColors.Control;
                pnlPassword.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                lblPassword.BackColor = SystemColors.Control;
                pnlAge.BackColor = SystemColors.Control;
                txtAge.BackColor = SystemColors.Control;
                lblAge.BackColor = SystemColors.Control;
                pnlMobile.BackColor = Color.White;
                txtMobile.BackColor = Color.White;
                lblMobile.BackColor = Color.White;
                pnlPlan.BackColor = SystemColors.Control;
                cboUSCallPlan.BackColor = SystemColors.Control;
                lblPlan.BackColor = SystemColors.Control;
                lblGender.BackColor = SystemColors.Control;
                pnlGender.BackColor = SystemColors.Control;
            }
        }

        private void cboUSCallPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Focus();
        }

        private void btnID_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtID_AcceptsTabChanged(object sender, EventArgs e)
        {
            btnID.Focus();
            txtName.BackColor = SystemColors.Control;
            pnlName.BackColor = SystemColors.Control;
            lblName.BackColor = SystemColors.Control;
            pnlID.BackColor = SystemColors.Control;
            txtID.BackColor = SystemColors.Control;
            lblID.BackColor = SystemColors.Control;
            pnlPassword.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            lblPassword.BackColor = Color.White;
            pnlAge.BackColor = SystemColors.Control;
            txtAge.BackColor = SystemColors.Control;
            lblAge.BackColor = SystemColors.Control;
            pnlMobile.BackColor = SystemColors.Control;
            txtMobile.BackColor = SystemColors.Control;
            lblMobile.BackColor = SystemColors.Control;
            pnlPlan.BackColor = SystemColors.Control;
            cboUSCallPlan.BackColor = SystemColors.Control;
            lblPlan.BackColor = SystemColors.Control;
            lblGender.BackColor = SystemColors.Control;
            pnlGender.BackColor = SystemColors.Control;
        }
    }
}

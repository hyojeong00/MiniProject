using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class AdListForm : Form
    {
        string mode = "";
        public AdListForm()
        {
            InitializeComponent();

        }

        private void AdListForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = "SELECT p.CallingPlan, p.Company, p.Price, p.Datas, p.Benefit, " +
                                        " p.STD1, p.STD2, p.STD3, d.Benefit AS '혜택 내용', p.SoldCallPlan " +
                                    " FROM productTbl AS p" +
                                    " INNER JOIN detailProductTbl AS d ON p.CallingPlan = d.CallingPlan ";
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet productlist = new DataSet();
                dataAdapter.Fill(productlist, "productTbl");

                GrdProductTbl.DataSource = productlist;
                GrdProductTbl.DataMember = "productTbl";
            }
            DataGridViewColumn column = GrdProductTbl.Columns[5];
            column.Width = 40;
            column = GrdProductTbl.Columns[6];
            column.Width = 40;
            column = GrdProductTbl.Columns[7];
            column.Width = 40;
            column = GrdProductTbl.Columns[4];
            column.Width = 20;
            column = GrdProductTbl.Columns[3];
            column.Width = column.Width / 2 + 20;
            column = GrdProductTbl.Columns[2];
            column.Width = column.Width / 2 + 20;
            column = GrdProductTbl.Columns[8];
            column.Width = column.Width + 50;
            
        }


        private void GrdProductTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdProductTbl.Rows[e.RowIndex];
                txtPlans.Text = data.Cells[0].Value.ToString();
                txtCompany.Text = data.Cells[1].Value.ToString();
                txtPrice.Text = data.Cells[2].Value.ToString();
                txtData.Text = data.Cells[3].Value.ToString();
                txtBenefits.Text = data.Cells[4].Value.ToString();
                txtStd1.Text = data.Cells[5].Value.ToString();
                txtStd2.Text = data.Cells[6].Value.ToString();
                txtStd3.Text = data.Cells[7].Value.ToString();
                txtBf.Text = data.Cells[8].Value.ToString();
                txtPlans.ReadOnly = true;
                mode = "UPDATE";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearText();
            txtPlans.ReadOnly = false;
            mode = "INSERT";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlans.Text) || string.IsNullOrEmpty(txtCompany.Text)
                || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtData.Text)
                || string.IsNullOrEmpty(txtBenefits.Text) || string.IsNullOrEmpty(txtStd1.Text)
                || string.IsNullOrEmpty(txtStd2.Text)||string.IsNullOrEmpty(txtStd3.Text))
            {
                MessageBox.Show("빈 값은 저장할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!(int.Parse(txtStd1.Text)>-1&&int.Parse(txtStd1.Text)<101)|| !(int.Parse(txtStd2.Text) > -1 && int.Parse(txtStd2.Text) < 101)|| !(int.Parse(txtStd3.Text) > -1 && int.Parse(txtStd3.Text) < 101))
            {
                MessageBox.Show("기준 값은 0~100사이의 값만 들어갈 수 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveProcess();
            UpdateData();
            ClearText();
        }

        private void ClearText()
        {
            txtPlans.Clear();
            txtPrice.Clear();
            txtData.Clear();
            txtCompany.Clear();
            txtBenefits.Clear();
            txtStd1.Clear();
            txtStd2.Clear();
            txtStd3.Clear();
            txtBf.Clear();
            txtPlans.Focus();
            txtPlans.ReadOnly = true;
        }

        private void SaveProcess()
        {
            if(mode == "INSERT")
            {
                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT CallingPlan FROM productTbl WHERE CallingPlan = @CallingPlan ";

                    SqlParameter paramPlan = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                    paramPlan.Value = txtPlans.Text;
                    cmd.Parameters.Add(paramPlan);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("이미 사용중인 요금제명입니다.\n요금제명을 확인해 주세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE  dbo.productTbl " +
                             " SET  Company = @Company, Price = @Price, " +
                             " Datas = @Datas, Benefit = @Benefit, STD1 = @STD1, STD2 = @STD2, STD3 = @STD3 " +
                             " WHERE CallingPlan = @CallingPlan";
                }
                else
                {
                    strQuery = "INSERT INTO  productTbl " +
                                " (CallingPlan, Company, Price, Datas, Benefit, STD1, STD2, STD3, SelectedPrice, SelectedDatas, SelectedBenefit, SoldCallPlan ) " +
                                " VALUES (@CallingPlan, @Company, @Price, @Datas, @Benefit, @STD1, @STD2, @STD3, 0, 0, 0, 0) ";
                }

 
                cmd.CommandText = strQuery;
                SqlParameter paramPlans = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramPlans.Value = txtPlans.Text;
                cmd.Parameters.Add(paramPlans);

                SqlParameter paramCompany = new SqlParameter("@Company", SqlDbType.NVarChar, 20);
                paramCompany.Value = txtCompany.Text;
                cmd.Parameters.Add(paramCompany);

                SqlParameter paramPrice = new SqlParameter("@Price", SqlDbType.NVarChar, 20);
                paramPrice.Value = txtPrice.Text;
                cmd.Parameters.Add(paramPrice);

                SqlParameter paramData = new SqlParameter("@Datas", SqlDbType.NVarChar, 10);
                paramData.Value = txtData.Text;
                cmd.Parameters.Add(paramData);

                SqlParameter paramBenefit = new SqlParameter("@Benefit", SqlDbType.NVarChar, 50);
                paramBenefit.Value = txtBenefits.Text;
                cmd.Parameters.Add(paramBenefit);

                SqlParameter paramSTD1 = new SqlParameter("@STD1", SqlDbType.Int);
                paramSTD1.Value = txtStd1.Text;
                cmd.Parameters.Add(paramSTD1);

                SqlParameter paramSTD2 = new SqlParameter("@STD2", SqlDbType.Int);
                paramSTD2.Value = txtStd2.Text;
                cmd.Parameters.Add(paramSTD2);

                SqlParameter paramSTD3 = new SqlParameter("@STD3", SqlDbType.Int);
                paramSTD3.Value = txtStd3.Text;
                cmd.Parameters.Add(paramSTD3);

                cmd.ExecuteNonQuery();

                if(mode == "UPDATE")
                {
                    strQuery = "UPDATE detailProductTbl "
                        + " SET Benefit = @Benefit "
                        + " WHERE CallingPlan = @CallingPlan";
                }
                else
                {
                    strQuery = "INSERT INTO detailProductTbl "
                        + " (CallingPlan, Benefit) "
                        + " VALUES (@CallingPlan, @Benefit) " ;
                }
                
                cmd.Parameters.Clear();
                cmd.CommandText = strQuery;

                cmd.Parameters.Add(paramPlans);

                SqlParameter paramBf = new SqlParameter("@Benefit", SqlDbType.NVarChar, 50);
                if(string.IsNullOrEmpty(txtBf.Text))
                {
                    paramBf.Value = DBNull.Value;
                }
                else
                {
                    paramBf.Value = txtBf.Text;
                }
                cmd.Parameters.Add(paramBf);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlans.Text))
            {
                MessageBox.Show("빈 값은 삭제할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (MessageBox.Show("정말" + txtPlans.Text + "를 삭제하시겠습니까?","삭제",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DeleteProcess();
                UpdateData();
                ClearText();
            }
            else
            {
                return;
            }
            
        }
        private void DeleteProcess()
        {
            using(SqlConnection conn=new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM detailProductTbl " +
                                 " WHERE CallingPlan = @CallingPlan ";
                

                SqlParameter paramPlans = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramPlans.Value = txtPlans.Text;
                cmd.Parameters.Add(paramPlans);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM productTbl " +
                                " WHERE CallingPlan = @CallingPlan ";

                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

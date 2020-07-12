using MetroFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class BuyForm : MetroFramework.Forms.MetroForm
    {
        private string strProductName;
        private RmdForm rmdform;
        public BuyForm()
        {
            InitializeComponent();
        }

        //폼과 폼사이 데이터 전송
        public string PassValue
        {
            get { return this.strProductName; }
            set { this.strProductName = value; }
        }

        // HJ 추가 [20200703 12:45] : 추천창을 끄기 위해 데이터 전송
        public RmdForm ActiveRmdForm
        {
            get { return this.rmdform; }
            set { this.rmdform = value; }
        }

        /// <summary>
        /// 클릭한 요금제에 대한 정보 출력 메서드
        /// </summary>
        private void LoadData()
        {
            using(SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlDataReader reader;

                cmd.CommandText = "SELECT p.Company, REPLACE(CONVERT(VARCHAR,CONVERT(MONEY,p.Price),1),'.00',''), p.Datas, d.Benefit "
                                 + " FROM productTbl AS p "
                                + " INNER JOIN detailProductTbl AS d ON p.CallingPlan = d.CallingPlan "
                                + " WHERE p.CallingPlan = @CallingPlan ";

                SqlParameter paramCalling = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramCalling.Value = strProductName;
                cmd.Parameters.Add(paramCalling);

                reader = cmd.ExecuteReader();
                reader.Read();

                lblCompany.Text = reader[0].ToString();
                lblPrice.Text = reader[1].ToString();
                lblDatas.Text = reader[2].ToString().Replace(" ","");
                lblBenefit.Text = reader[3].ToString();
            }    
        }

        /// <summary>
        /// 조회하는 경우 유저의 성향값이 바뀌는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyForm_Load(object sender, EventArgs e)
        {
            lblCallngPlan.Text = strProductName;
            LoadData();
            // 해당 유저의 성향값 바뀜
            TendencyUpdate(10);
        }

        /// <summary>
        /// 해당 유저의 성향값 바뀌게 해주는 메서드
        /// </summary>
        /// <param 나누는 값="ratio"></param>
        private void TendencyUpdate(int ratio)
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT STD1,STD2,STD3 "
                                + " FROM userTbl "
                               + " WHERE userID = @userID ";
                SqlParameter paramUserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                paramUserID.Value = Commons.LOGINUSERID;
                cmd.Parameters.Add(paramUserID);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Commons.Tendency Ten;
                Ten.iStd1 = int.Parse(reader[0].ToString());
                Ten.iStd2 = int.Parse(reader[1].ToString());
                Ten.iStd3 = int.Parse(reader[2].ToString());

                reader.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "SELECT STD1,STD2,STD3 "
                                 + " FROM dbo.productTbl "
                                + " WHERE CallingPlan = @CallingPlan";
                SqlParameter paramCalling = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramCalling.Value = strProductName;
                cmd.Parameters.Add(paramCalling);

                reader = cmd.ExecuteReader();
                reader.Read();

                Commons.Tendency ProdTen;
                ProdTen.iStd1 = int.Parse(reader[0].ToString());
                ProdTen.iStd2 = int.Parse(reader[1].ToString());
                ProdTen.iStd3 = int.Parse(reader[2].ToString());

                reader.Close();
                cmd.Parameters.Clear();

                if (Ten.iStd1 + (ProdTen.iStd1 - Ten.iStd1) / ratio > 100)
                {
                    Ten.iStd1 = 100;
                }
                else if (Ten.iStd1 + (ProdTen.iStd1 - Ten.iStd1) / ratio < 0)
                {
                    Ten.iStd1 = 0;
                }
                else
                {
                    Ten.iStd1 = Ten.iStd1 + (ProdTen.iStd1 - Ten.iStd1) / ratio;
                }

                if (Ten.iStd2 + (ProdTen.iStd2 - Ten.iStd2) / ratio > 100)
                {
                    Ten.iStd2 = 100;
                }
                else if (Ten.iStd2 + (ProdTen.iStd2 - Ten.iStd2) / ratio < 0)
                {
                    Ten.iStd2 = 0;
                }
                else
                {
                    Ten.iStd2 = Ten.iStd2 + (ProdTen.iStd2 - Ten.iStd2) / ratio;
                }

                if (Ten.iStd3 + (ProdTen.iStd3 - Ten.iStd3) / ratio > 100)
                {
                    Ten.iStd3 = 100;
                }
                else if (Ten.iStd3 + (ProdTen.iStd3 - Ten.iStd3) / ratio < 0)
                {
                    Ten.iStd3 = 0;
                }
                else
                {
                    Ten.iStd3 = Ten.iStd3 + (ProdTen.iStd3 - Ten.iStd3) / ratio;
                }

                cmd.CommandText = "UPDATE userTbl "
                                  + " SET STD1 = @STD1, STD2 = @STD2, STD3 = @STD3 "
                                + " WHERE userID = @userID ";
                cmd.Parameters.Add(paramUserID);
                SqlParameter paramSTD1 = new SqlParameter("@STD1", SqlDbType.Int);
                paramSTD1.Value = Ten.iStd1.ToString();
                cmd.Parameters.Add(paramSTD1);
                SqlParameter paramSTD2 = new SqlParameter("@STD2", SqlDbType.Int);
                paramSTD2.Value = Ten.iStd2.ToString();
                cmd.Parameters.Add(paramSTD2);
                SqlParameter paramSTD3 = new SqlParameter("@STD3", SqlDbType.Int);
                paramSTD3.Value = Ten.iStd3.ToString();
                cmd.Parameters.Add(paramSTD3);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 취소버튼 클릭시 구매화면이 꺼짐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 구매버튼 클릭시 해당 유저의 성향값 바뀜/요금제 바뀜 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //해당 유저의 결과값 바뀜
            TendencyUpdate(5);

            //해당 유저의 요금제 바뀜
            using(SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE userTbl "
                                  + " SET userUSCallPlan = @userUSCallPlan "
                                + " WHERE userID = @userID";

                SqlParameter paramCallplan = new SqlParameter("@userUSCallPlan", SqlDbType.NVarChar, 50);
                paramCallplan.Value = strProductName;
                cmd.Parameters.Add(paramCallplan);

                SqlParameter paramuserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                paramuserID.Value = Commons.LOGINUSERID;
                cmd.Parameters.Add(paramuserID);
                cmd.ExecuteNonQuery();
            }

            if(MetroMessageBox.Show(this,"구매가 완료되었습니다.", "구매 완료", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE productTbl SET SoldCallPlan = SoldCallPlan +1 WHERE CallingPlan = @CallingPlan ";

                    SqlParameter paramplan = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                    paramplan.Value = strProductName;
                    cmd.Parameters.Add(paramplan);
                    cmd.ExecuteNonQuery();
                }
                // HJ 추가 [20200703 12:48] : 구매창에서 구매할 경우 구매창, 추천창 꺼지도록
                ActiveRmdForm.Close();
                this.Close();
            }
        }
    }
}

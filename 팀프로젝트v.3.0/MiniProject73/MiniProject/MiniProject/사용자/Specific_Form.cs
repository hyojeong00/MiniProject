using MetroFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Specific_Form : MetroFramework.Forms.MetroForm
    {
        public Specific_Form()
        {
            InitializeComponent();
        }

        private void Specific_Form_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                DataSet ds = new DataSet();
                conn.Open();

                // 2개의 파라미터 정의 (항상 @로 시작)
                string sql = " SELECT p.CallingPlan , p.Company , REPLACE(CONVERT(VARCHAR, CAST(p.Price AS MONEY), 1), '.00', '') AS Price, " +
                                  " p.Datas, d.Benefit " +
                                  " FROM productTbl AS p " +
                                  " INNER JOIN detailProductTbl AS d " +
                                  "  ON p.CallingPlan = d.CallingPlan " +
                                  "  WHERE p.CallingPlan =  @CallingPlan";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // 각 파라미터 타입 및 값 입력
                SqlParameter paramCity = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramCity.Value = Commons.SELECTED_PLAN;
                // SqlCommand 객체의 Parameters 속성에 추가
                cmd.Parameters.Add(paramCity);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "User_Information");

                conn.Close();
                infoTbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                infoTbl.DataMember = "User_Information";
            }
            
            lblModel.Text = infoTbl[0, 0].Value.ToString();
            lblModelNumber.Text = infoTbl[1, 0].Value.ToString();
            lblPrice.Text = infoTbl[2, 0].Value.ToString();
            lblProcesser.Text = infoTbl[3, 0].Value.ToString();
            lblMemory.Text = infoTbl[4, 0].Value.ToString();

            infoTbl.Visible = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            int p_std1 = 0,p_std2=0,p_std3=0;
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                DataSet ds = new DataSet();
                conn.Open();

                // 2개의 파라미터 정의 (항상 @로 시작)
                string sql = " SELECT STD1,STD2,STD3 " +
                                  " FROM productTbl AS p " +
                                  "  WHERE CallingPlan =  @CallingPlan";

                SqlCommand cmd = new SqlCommand(sql, conn);

         
                SqlParameter paramCity = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramCity.Value = Commons.SELECTED_PLAN;
                cmd.Parameters.Add(paramCity);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "User_Information");

                conn.Close();
                infoTbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                infoTbl.DataMember = "User_Information";


            }
            p_std1 = int.Parse(infoTbl[0, 0].Value.ToString());
            p_std2 = int.Parse(infoTbl[1, 0].Value.ToString());
            p_std3 = int.Parse(infoTbl[2, 0].Value.ToString());


            int a=0, b=0, c=0;
            if(Commons.USER_STD_1>0 && Commons.USER_STD_1<100)
            {
                if (Commons.USER_STD_1 != p_std1)
                {
                    a = Commons.USER_STD_1 + (p_std1 - Commons.USER_STD_1) / 5;
                }
                
            }

            if (Commons.USER_STD_2 > 0 && Commons.USER_STD_2 < 100)
            {
                if (Commons.USER_STD_2 != p_std2)
                {
                   
                        b = Commons.USER_STD_2 + (p_std2 - Commons.USER_STD_2) / 5;
           
                    
                }
            }
            if (Commons.USER_STD_3 > 0 && Commons.USER_STD_3 < 100)
            {
                if (Commons.USER_STD_3 != p_std3)
                {

                    c = Commons.USER_STD_3 + (p_std3 - Commons.USER_STD_3) / 5;


                }
            }


            MetroMessageBox.Show(this,"구매가 완료되었습니다. ", "구매 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //추가
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE productTbl SET SoldCallPlan = SoldCallPlan +1 WHERE CallingPlan = @CallingPlan ";

                SqlParameter paramplan = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                paramplan.Value = Commons.SELECTED_PLAN;
                cmd.Parameters.Add(paramplan);
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;


                cmd.CommandText = " UPDATE dbo.userTbl " +
                                  " SET userUSCallPlan = @userUSCallPlan, " +
                                  " STD1 = @STD1, STD2 = @STD2, STD3 = @STD3 " +
                                  " WHERE userID = @userID";

                SqlParameter parmuserUSCallPlan = new SqlParameter("@userUSCallPlan", SqlDbType.NVarChar, 50);
                parmuserUSCallPlan.Value = Commons.SELECTED_PLAN;
                cmd.Parameters.Add(parmuserUSCallPlan);

                SqlParameter parmSTD1 = new SqlParameter("@STD1", SqlDbType.Int);
                parmSTD1.Value = a;
                cmd.Parameters.Add(parmSTD1);

                SqlParameter parSTD2 = new SqlParameter("@STD2", SqlDbType.Int);
                parSTD2.Value = b;
                cmd.Parameters.Add(parSTD2);

                SqlParameter parmSTD3 = new SqlParameter("@STD3", SqlDbType.Int);
                parmSTD3.Value = c;
                cmd.Parameters.Add(parmSTD3);

                SqlParameter parmuserID = new SqlParameter("@userID", SqlDbType.VarChar,50);
                parmuserID.Value = Commons.LOGINUSERID;
                cmd.Parameters.Add(parmuserID);

                cmd.ExecuteNonQuery();//excute는 넣을 때 쓰는건 NonQuery 그 외에건 가져올 때

                Close();
               
            }

        }
    }
}

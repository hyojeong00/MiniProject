using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace MiniProject
{
    public partial class RmdForm : MetroForm
    {
        //DB 연결경로
        
        private int rmdamount = 5;
        public RmdForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 사용자의 성향을 파악 후 성향에 따라 추천하는 버튼을 생성한다.
        /// </summary>
        void GetData()
        {
            Commons.Tendency Ten;
            
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

               cmd.CommandText = "SELECT STD1,STD2,STD3,userUSCallPlan "
                                + " FROM userTbl "
                               + " WHERE userID = @userID ";
               SqlParameter paramUserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
               paramUserID.Value = Commons.LOGINUSERID;
               cmd.Parameters.Add(paramUserID);

               SqlDataReader reader = cmd.ExecuteReader();
               reader.Read();
               Ten.iStd1 = int.Parse(reader[0].ToString());
               Ten.iStd2 = int.Parse(reader[1].ToString());
               Ten.iStd3 = int.Parse(reader[2].ToString());
               Ten.strUserCall = reader[3].ToString();
               reader.Close();
            }

            int iRmdCount = 0;

            iRmdCount = CreateButton(Ten, iRmdCount, 1);

            //성향 선호 순
            if (iRmdCount < rmdamount)
            {
                int iNum1 = Math.Abs(Ten.iStd1 - 50);
                int iNum2 = Math.Abs(Ten.iStd2 - 50);
                int iNum3 = Math.Abs(Ten.iStd3 - 50);
                if (iNum1 <= iNum2)
                {
                    if (iNum1 <= iNum3)
                    {
                        iRmdCount = CreateButton(Ten, iRmdCount, 2);
                        if (iRmdCount < rmdamount && iNum2 <= iNum3)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 3);
                            if (iRmdCount < rmdamount)
                            {
                                iRmdCount = CreateButton(Ten, iRmdCount, 4);
                            }
                        }
                        else if (iRmdCount < rmdamount)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 4);
                            if (iRmdCount < rmdamount)
                            {
                                iRmdCount = CreateButton(Ten, iRmdCount, 3);
                            }
                        }
                    }
                    else if (iNum3 <= iNum2)
                    {
                        iRmdCount = CreateButton(Ten, iRmdCount, 4);
                        if (iRmdCount < rmdamount)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 2);
                            if (iRmdCount < rmdamount)
                            {
                                iRmdCount = CreateButton(Ten, iRmdCount, 3);
                            }
                        }
                    }
                }
                else if (iNum2 <= iNum3)
                {
                    iRmdCount = CreateButton(Ten, iRmdCount, 3);
                    if (iRmdCount < rmdamount && iNum1 <= iNum3)
                    {
                        iRmdCount = CreateButton(Ten, iRmdCount, 2);
                        if (iRmdCount < rmdamount)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 4);
                        }
                    }
                    else if (iRmdCount < rmdamount)
                    {
                        iRmdCount = CreateButton(Ten, iRmdCount, 4);
                        if (iRmdCount < rmdamount)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 2);
                        }

                    }
                }
                else
                {
                    iRmdCount = CreateButton(Ten, iRmdCount, 4);
                    if (iRmdCount < rmdamount)
                    {
                        iRmdCount = CreateButton(Ten, iRmdCount, 3);
                        if (iRmdCount < rmdamount)
                        {
                            iRmdCount = CreateButton(Ten, iRmdCount, 2);
                        }
                    }
                }
            }

            //선호 성향 관계없이
            if (iRmdCount < rmdamount)
            {
                iRmdCount = CreateButton(Ten, iRmdCount, 5);
            }

        }

        /// <summary>
        /// 유형별로 추천하는 버튼과 레이블을 생성한다.
        /// </summary>
        /// <param name="Ten"></param>
        /// <param name="iRmdCount"></param>
        /// <param 추천 유형="n"></param>
        /// <returns></returns>
        int CreateButton(Commons.Tendency Ten, int iRmdCount, int n)
        {
            using(SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlDataReader reader;

                SqlParameter paramTen1;
                SqlParameter paramTen2;
                SqlParameter paramTen3;
                SqlParameter paramTen4;
                SqlParameter paramTen10;
                SqlParameter paramTen11;
                switch (n)
                {
                    case 1: //  정확히 일치하는 경우
                        cmd.CommandText = "SELECT CallingPlan "
                                 + " FROM productTbl "
                                + " WHERE STD1 = @STD1 AND STD2 = @STD2 AND STD3 = @STD3 AND CallingPlan  != @CallingPlan ";

                        paramTen1 = new SqlParameter("@STD1", SqlDbType.Int);
                        paramTen2 = new SqlParameter("@STD2", SqlDbType.Int);
                        paramTen3 = new SqlParameter("@STD3", SqlDbType.Int);
                        paramTen10 = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                        paramTen1.Value = Ten.iStd1.ToString();
                        paramTen2.Value = Ten.iStd2.ToString();
                        paramTen3.Value = Ten.iStd3.ToString();
                        paramTen10.Value = Ten.strUserCall;

                        cmd.Parameters.Add(paramTen1);
                        cmd.Parameters.Add(paramTen2);
                        cmd.Parameters.Add(paramTen3);
                        cmd.Parameters.Add(paramTen10);
                        break;

                    case 2: // 첫번째 기준이 가장 높은 경우 근처 추천 // case 1번 중복제거
                    case 3: // 두번째 기준이 가장 높은 경우 근처 추천 // case 1번 중복제거
                    case 4: // 세번째 기준이 가장 높은 경우 근처 추천 // case 1번 중복제거
                        if (n == 2)
                        {
                            cmd.CommandText = "SELECT CallingPlan "
                                 + " FROM productTbl "
                                + " WHERE (STD1 BETWEEN @STD11 AND @STD12 ) AND STD2 = @STD2 AND STD3 = @STD3 AND CallingPlan != @CallingPlan "
                                       + "AND NOT CallingPlan IN (SELECT CallingPlan FROM productTbl WHERE STD1 = @STD1 AND STD2 = @STD2 AND STD3 = @STD3 )";

                            paramTen1 = new SqlParameter("@STD11", SqlDbType.Int);
                            paramTen2 = new SqlParameter("@STD2", SqlDbType.Int);
                            paramTen3 = new SqlParameter("@STD3", SqlDbType.Int);
                            paramTen4 = new SqlParameter("@STD12", SqlDbType.Int);
                            paramTen10 = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                            paramTen11 = new SqlParameter("@STD1", SqlDbType.Int);

                            paramTen11.Value = Ten.iStd1.ToString();
                            paramTen1.Value = ((Ten.iStd1 - 10) > -1? (Ten.iStd1 - 10) : 0).ToString();
                            paramTen2.Value = Ten.iStd2.ToString();
                            paramTen3.Value = Ten.iStd3.ToString();
                            paramTen4.Value = ((Ten.iStd1 + 10) < 101 ? (Ten.iStd1 + 10) : 100).ToString();
                            paramTen10.Value = Ten.strUserCall;
                        }
                        else if(n == 3)
                        {
                            cmd.CommandText = "SELECT CallingPlan "
                                 + " FROM productTbl "
                                + " WHERE STD1 = @STD1 AND (STD2 BETWEEN @STD21 AND @STD22 ) AND STD3 = @STD3 AND CallingPlan != @CallingPlan "
                                       + "AND NOT CallingPlan IN(SELECT CallingPlan FROM productTbl WHERE STD1 = @STD1 AND STD2 = @STD2 AND STD3 = @STD3 )";

                            paramTen1 = new SqlParameter("@STD1", SqlDbType.Int);
                            paramTen2 = new SqlParameter("@STD21", SqlDbType.Int);
                            paramTen3 = new SqlParameter("@STD3", SqlDbType.Int);
                            paramTen4 = new SqlParameter("@STD22", SqlDbType.Int);
                            paramTen10 = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                            paramTen11 = new SqlParameter("@STD2", SqlDbType.Int);

                            paramTen11.Value = Ten.iStd2.ToString();
                            paramTen1.Value = Ten.iStd1.ToString();
                            paramTen2.Value = ((Ten.iStd2 - 10) > -1 ? (Ten.iStd2 - 10) : 0).ToString();
                            paramTen3.Value = Ten.iStd3.ToString();
                            paramTen4.Value = ((Ten.iStd2 + 10) < 101 ? (Ten.iStd2 + 10) : 100).ToString();
                            paramTen10.Value = Ten.strUserCall;
                        }
                        else
                        {
                            cmd.CommandText = "SELECT CallingPlan "
                                 + " FROM productTbl "
                                + " WHERE STD1 = @STD1 AND STD2 = @STD2 AND ( STD3 BETWEEN @STD31 AND @STD32 ) AND CallingPlan  != @CallingPlan "
                                        +"AND NOT CallingPlan IN(SELECT CallingPlan FROM productTbl WHERE STD1 = @STD1 AND STD2 = @STD2 AND STD3 = @STD3 )";
                            paramTen1 = new SqlParameter("@STD1", SqlDbType.Int);
                            paramTen2 = new SqlParameter("@STD2", SqlDbType.Int);
                            paramTen3 = new SqlParameter("@STD31", SqlDbType.Int);
                            paramTen4 = new SqlParameter("@STD32", SqlDbType.Int);
                            paramTen10 = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                            paramTen11 = new SqlParameter("@STD3", SqlDbType.Int);

                            paramTen11.Value = Ten.iStd3.ToString();
                            paramTen1.Value = Ten.iStd1.ToString();
                            paramTen2.Value = Ten.iStd2.ToString();
                            paramTen3.Value = ((Ten.iStd3 - 10) > -1 ? (Ten.iStd3 - 10) : 0).ToString();
                            paramTen4.Value = ((Ten.iStd3 + 10) < 101 ? (Ten.iStd3 + 10) : 100).ToString();
                            paramTen10.Value = Ten.strUserCall;
                        }

                        cmd.Parameters.Add(paramTen1);
                        cmd.Parameters.Add(paramTen2);
                        cmd.Parameters.Add(paramTen3);
                        cmd.Parameters.Add(paramTen4);
                        cmd.Parameters.Add(paramTen10);
                        cmd.Parameters.Add(paramTen11);
                        break;
                    case 5: // case 1,2,3,4 중복제거
                        cmd.CommandText = "SELECT CallingPlan " 
                                         + " FROM productTbl "
                                        + " WHERE (STD1 BETWEEN @STD11 AND @STD12) AND (STD2 BETWEEN @STD21 AND @STD22) AND (STD3 BETWEEN @STD31 AND @STD32) AND "
                                               + "NOT CallingPlan IN(SELECT CallingPlan FROM productTbl WHERE STD1 = @STD1 AND STD2 = @STD2 AND STD3 = @STD3) AND "
                                              + " NOT CallingPlan IN(SELECT CallingPlan FROM productTbl WHERE ( STD1 BETWEEN @STD11 AND @STD12) AND STD2 = @STD2 AND STD3 = @STD3) AND "
                                              + " NOT CallingPlan IN(SELECT CallingPlan FROM productTBL WHERE STD1 = @STD1 AND (STD2 BETWEEN @STD21 AND @STD22) AND STD3 = @STD3) AND "
                                              + " NOT CallingPlan IN(SELECT CallingPlan FROM productTBL WHERE STD1 = @STD1 AND STD2 = @STD2 AND (STD3 BETWEEN @STD31 AND @STD32) ) AND CallingPlan  != @CallingPlan ";

                        paramTen1 = new SqlParameter("@STD1", SqlDbType.Int);
                        paramTen2 = new SqlParameter("@STD2", SqlDbType.Int);
                        paramTen3 = new SqlParameter("@STD31", SqlDbType.Int);
                        SqlParameter paramTen5 = new SqlParameter("@STD3",SqlDbType.Int);
                        paramTen4 = new SqlParameter("@STD32", SqlDbType.Int);
                        SqlParameter paramTen6 = new SqlParameter("@STD11", SqlDbType.Int);
                        SqlParameter paramTen7 = new SqlParameter("@STD12", SqlDbType.Int);
                        SqlParameter paramTen8 = new SqlParameter("@STD21", SqlDbType.Int);
                        SqlParameter paramTen9 = new SqlParameter("@STD22", SqlDbType.Int);
                        paramTen10 = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);

                        paramTen1.Value = Ten.iStd1.ToString();
                        paramTen2.Value = Ten.iStd2.ToString();
                        paramTen5.Value = Ten.iStd3.ToString();
                        paramTen6.Value = ((Ten.iStd1 - 10) > -1 ? (Ten.iStd1 - 10) : 0).ToString();
                        paramTen7.Value = ((Ten.iStd1 + 10) < 101 ? (Ten.iStd1 + 10) : 100).ToString();
                        paramTen8.Value = ((Ten.iStd2 - 10) > -1 ? (Ten.iStd2 - 10) : 0).ToString();
                        paramTen9.Value = ((Ten.iStd2 + 10) < 101 ? (Ten.iStd2 + 10) : 100).ToString();
                        paramTen3.Value = ((Ten.iStd3 - 10) > -1 ? (Ten.iStd3 - 10) : 0).ToString();
                        paramTen4.Value = ((Ten.iStd3 + 10) < 101 ? (Ten.iStd3 + 10) : 100).ToString();
                        paramTen10.Value = Ten.strUserCall;

                        cmd.Parameters.Add(paramTen1);
                        cmd.Parameters.Add(paramTen2);
                        cmd.Parameters.Add(paramTen3);
                        cmd.Parameters.Add(paramTen4);
                        cmd.Parameters.Add(paramTen5);
                        cmd.Parameters.Add(paramTen6);
                        cmd.Parameters.Add(paramTen7);
                        cmd.Parameters.Add(paramTen8);
                        cmd.Parameters.Add(paramTen9);
                        cmd.Parameters.Add(paramTen10);
                        break;
                }
                    
                reader = cmd.ExecuteReader();

                List<string> names = new List<string>();

                //Tendency ten;
                while (reader.Read())
                {
                    names.Add(reader[0].ToString());
                }
                
                for (int i = 0; i < names.Count; i++)
                {
                    Button btn = new Button();
                    btn.Name = "Btn" + names[i];
                    btn.Size = new Size((FlpRmd.Size.Width - 50) / 5, FlpRmd.Size.Height - 10);
                    btn.BackgroundImage = imgList.Images[iRmdCount];
                    btn.BackgroundImageLayout = ImageLayout.Center;
                    btn.Click += RmdBtn_Click;
                    FlpRmd.Controls.Add(btn);

                    Label lbl = new Label();
                    lbl.Text = names[i];
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Size = new Size((FlpRmdName.Size.Width - 50) / 5, FlpRmdName.Size.Height);
                    FlpRmdName.Controls.Add(lbl);
                    iRmdCount++;

                    if (iRmdCount >= rmdamount)
                    {
                        break;
                    }
                }
            }
            return iRmdCount;
        }

        /// <summary>
        /// 동적으로 만들어지는 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RmdBtn_Click(object sender, EventArgs e)
        {
            BuyForm form = new BuyForm();
            Button btn = (Button)sender;
            form.PassValue = btn.Name.Substring(3);
            form.ActiveRmdForm = this; // HJ 추가 [20200703 12:45] : 추천창 끄기 위해 데이터 전달
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void RmdForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            FlpRmd.Controls.Clear();
            FlpRmdName.Controls.Clear();
            GetData();
        }

        /// <summary>
        /// 추천창 꺼지는 방법
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

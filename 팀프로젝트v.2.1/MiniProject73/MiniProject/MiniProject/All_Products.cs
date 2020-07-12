using MetroFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class All_Products : Form
    {

        public int User_std1;
        public int User_std2;
        public int User_std3;

        public int Product_std1;
        public int Product_std2;
        public int Product_std3;

        public string SELECTED_MODEL = "";
        
        public All_Products()
        {
            InitializeComponent();
        }

        private void All_Products_Load(object sender, EventArgs e)
        {
            UpdateData();
            label2.Text = Commons.LOGINUSERID;

            // HJ 추가(임시) [20200703 12:40]: 화면크기 조정
            this.WindowState = FormWindowState.Maximized;

            string Price_Convert = "";
            UpdateCboPrice(); //가격 콤보박스의 초기값 가져오기
            for(int i=0;i<64;i++)
            {
                try
                {
                    if (priceTbl[0, i].Value == null)
                    {
                        cboPrice.Items.Add("");
                        break;
                    }
                    else
                    {
                      
                        cboPrice.Items.Add(priceTbl[0, i].Value);

                    }
                }
                catch (Exception)
                {
                }  
            } //콤보박스에 값 넣기 
            UpdateCboData(); //데이터 콤보박스의 초기값 가져오기
            for (int i = 0; i < 64; i++)
            {
                try
                {
                    if (priceTbl[0, i].Value == null)
                    {
                        cboPrice.Items.Add("");
                        break;
                    }
                    else
                        CboData.Items.Add(priceTbl[0, i].Value);
                }
                catch (Exception)
                {
                }

            }//콤보박스에 값 넣기
            UpdateCboBenefit(); //혜택 콤보박스의 초기값 가져오기
            for (int i = 0; i < 300; i++)//콤보박스에 값 넣기
            {
                try
                {
                    if (priceTbl[0, i].Value == null)
                    {
                        cboPrice.Items.Add("");
                        break;
                    }
                    else
                        cboService.Items.Add(priceTbl[0, i].Value);
                }
                catch (Exception)
                {
                }

            }//콤보박스에 값 넣기


            cboService.SelectedIndex = -1; 
            cboPrice.SelectedIndex =-1;
            CboData.SelectedIndex = -1;

            priceTbl.Visible = true;

            UpdateUser();

            // HJ 추가 [20200703 12:40] : 추천창 켜기
            RmdForm form = new RmdForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void UpdateUser()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                DataSet ds = new DataSet();
                conn.Open();

                // 2개의 파라미터 정의 (항상 @로 시작)
                string sql = " SELECT userID ,userPassword ,userAge ,userGender " +
                                  " , userMobile, userUSCallPlan, STD1,STD2,STD3 " +
                                  " FROM dbo.userTbl WHERE userID = @userID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // 각 파라미터 타입 및 값 입력
                SqlParameter paramCity = new SqlParameter("@userID", SqlDbType.NVarChar, 15);
                paramCity.Value = Commons.LOGINUSERID;
                // SqlCommand 객체의 Parameters 속성에 추가
                cmd.Parameters.Add(paramCity);

                

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "User_Information");

                conn.Close();
                priceTbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                priceTbl.DataMember = "User_Information";


            }
            User_std1= int.Parse(priceTbl[6, 0].Value.ToString());
            User_std2 = int.Parse(priceTbl[7, 0].Value.ToString());
            User_std3 = int.Parse(priceTbl[8, 0].Value.ToString());

        }

        private void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); //DB접속
                //데이터 그리드 뷰에 간단 정보 출력

                string strQuery = " SELECT CallingPlan AS [요금제],  REPLACE(CONVERT(VARCHAR, CAST(Price AS MONEY), 1), '.00', '') AS Price, Company AS [회사], " +
                                  " Datas AS [데이터], Benefit AS [혜택] " +
                                  " FROM productTbl";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "General_Phone_Information");
                
                grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                grdPhonetbl.DataMember = "General_Phone_Information";

            }

            //for (int i = 0; i < 4; i++) //데이터 그리드 뷰 열과 행 크기 자동 조절
            //{
            //    grdPhonetbl.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    int widthCol = grdPhonetbl.Columns[i].Width;
            //    grdPhonetbl.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    grdPhonetbl.Columns[i].Width = widthCol;
            //}
        }
        private void UpdateCboData() //data 콤보박스 값 가져오기
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); //DB접속

                string strQuery = "SELECT DISTINCT Datas  FROM productTbl ORDER BY Datas ASC";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "datas");

                priceTbl.DataSource = ds;
                priceTbl.DataMember = "datas";
            }
        }
        private void UpdateCboBenefit() //혜택 콤보박스 값 가져오기
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); //DB접속

                string strQuery = "SELECT DISTINCT Benefit  FROM productTbl ORDER BY Benefit DESC";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Benefits");

                priceTbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                priceTbl.DataMember = "Benefits";
            }
        }
        private void UpdateCboPrice() //가격 콤보박스 값 가져오기
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); //DB접속

                string strQuery = "SELECT DISTINCT Price  FROM productTbl ORDER BY Price ASC";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "price");

                priceTbl.DataSource = ds;
                priceTbl.DataMember = "price";
            }
        }
        private void metroButton1_Click(object sender, EventArgs e) //자세한 정보 창 띄우기와 회원정보에서 값 ++, --
        {
           

        }

        private void InitChildForm(Specific_Form form, string v)
        {
            form.Show();
            form.WindowState = FormWindowState.Normal;
        }

        private void grdPhonetbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = grdPhonetbl.Rows[e.RowIndex];

                SELECTED_MODEL = data.Cells[0].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (cboPrice.Text == "" && cboService.Text == "" && CboData.Text == "")
            {
                MetroMessageBox.Show(this,"빈 값은 검색할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //메세지 박스 빠져 나오기 뭐 안되면 리턴하자
            }
            else
            {

                if(cboPrice.SelectedIndex!=-1&& CboData.SelectedIndex == -1&& cboService.SelectedIndex == -1) //첫번째 콤보박스만 입력했을 때 검색
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedPrice = 1 " +
                                          " WHERE Price = @Price "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.NVarChar, 20);
                        parmPrice.Value = cboPrice.SelectedItem;
                        cmd.Parameters.Add(parmPrice);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedPrice =1 ";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }

                } //첫번째 콤보박스만 입력했을 때 검색

                if (cboPrice.SelectedIndex == -1 && CboData.SelectedIndex != -1 && cboService.SelectedIndex == -1) //첫번째 콤보박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    
                        using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = conn;


                            cmd.CommandText = " UPDATE dbo.productTbl " +
                                              " SET SelectedDatas = 1 " +
                                              "  WHERE Datas = @Datas "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                            SqlParameter parmDatas = new SqlParameter("@Datas", SqlDbType.NChar, 10);
                            parmDatas.Value = CboData.SelectedItem;
                            cmd.Parameters.Add(parmDatas);

                            cmd.ExecuteNonQuery();
                        }
                    
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedDatas =1 ";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }

                }//두번째 콤보박스만 입력했을 때 검색

                if (cboPrice.SelectedIndex == -1 && CboData.SelectedIndex == -1 && cboService.SelectedIndex != -1) //세번째 콤보박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedBenefit = 1 " +
                                          "  WHERE Benefit = @Benefits "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmBenefits = new SqlParameter("@Benefits", SqlDbType.NVarChar, 50);
                        parmBenefits.Value = cboService.SelectedItem;
                        cmd.Parameters.Add(parmBenefits);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedBenefit =1 ";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }

                } //세번째 콤보박스만 입력했을 때 검색

                if (cboPrice.SelectedIndex != -1 && CboData.SelectedIndex != -1 && cboService.SelectedIndex == -1) //첫번째 두번째 박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING)) 
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedPrice = 1 " +
                                          " WHERE Price = @Price "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.NVarChar, 20);
                        parmPrice.Value = cboPrice.SelectedItem;
                        cmd.Parameters.Add(parmPrice);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedDatas = 1 " +
                                          "  WHERE Datas = @Datas "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmDatas = new SqlParameter("@Datas", SqlDbType.NChar, 10);
                        parmDatas.Value = CboData.SelectedItem;
                        cmd.Parameters.Add(parmDatas);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedPrice =1 AND SelectedDatas=1";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }

                }//첫번째 두번째 콤보박스만 입력했을 때 검색

                if (cboPrice.SelectedIndex != -1 && CboData.SelectedIndex == -1 && cboService.SelectedIndex != -1) //첫번째 세번째 박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedPrice = 1 " +
                                          " WHERE Price = @Price "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.NVarChar, 20);
                        parmPrice.Value = cboPrice.SelectedItem;
                        cmd.Parameters.Add(parmPrice);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedBenefit = 1 " +
                                          "  WHERE Benefit = @Benefits "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmBenefits = new SqlParameter("@Benefits", SqlDbType.NVarChar, 50);
                        parmBenefits.Value = cboService.SelectedItem;
                        cmd.Parameters.Add(parmBenefits);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedPrice =1 AND SelectedBenefit=1";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }
                }//첫번째 세번째 박스만 입력했을 때

                if (cboPrice.SelectedIndex == -1 && CboData.SelectedIndex != -1 && cboService.SelectedIndex != -1) //두번째 세번째 박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedDatas = 1 " +
                                          "  WHERE Datas = @Datas "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmDatas = new SqlParameter("@Datas", SqlDbType.NChar, 10);
                        parmDatas.Value = CboData.SelectedItem;
                        cmd.Parameters.Add(parmDatas);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedBenefit = 1 " +
                                          "  WHERE Benefit = @Benefits "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmBenefits = new SqlParameter("@Benefits", SqlDbType.NVarChar, 50);
                        parmBenefits.Value = cboService.SelectedItem;
                        cmd.Parameters.Add(parmBenefits);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedDatas =1 AND SelectedBenefit=1";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }
                }//두번째 세번째 박스만 입력했을 때

                if (cboPrice.SelectedIndex == -1 && CboData.SelectedIndex != -1 && cboService.SelectedIndex != -1) //두번째 세번째 박스만 입력했을 때
                {
                    //검색어 조건에 입력한 내용에 대한 행의 Selected 를 1로
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedPrice = 1 " +
                                          " WHERE Price = @Price "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmPrice = new SqlParameter("@Price", SqlDbType.NVarChar, 20);
                        parmPrice.Value = cboPrice.SelectedItem;
                        cmd.Parameters.Add(parmPrice);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedDatas = 1 " +
                                          "  WHERE Datas = @Datas "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmDatas = new SqlParameter("@Datas", SqlDbType.NChar, 10);
                        parmDatas.Value = CboData.SelectedItem;
                        cmd.Parameters.Add(parmDatas);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;


                        cmd.CommandText = " UPDATE dbo.productTbl " +
                                          " SET SelectedBenefit = 1 " +
                                          "  WHERE Benefit = @Benefits "; //Selected 열 만들어 놓고 이벤트 실행되는 순간 해당 열 1로 세트


                        SqlParameter parmBenefits = new SqlParameter("@Benefits", SqlDbType.NVarChar, 50);
                        parmBenefits.Value = cboService.SelectedItem;
                        cmd.Parameters.Add(parmBenefits);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                    {
                        conn.Open(); //DB접속
                                     //Selected가 1이 된 부분만 출력
                        string strQuery = " SELECT CallingPlan AS [요금제], Price AS [가격], Company AS [회사], " +
                                          " Datas AS [데이터], Benefit AS [혜택] " +
                                          " FROM productTbl WHERE SelectedDatas =1 AND SelectedBenefit=1 AND SelectedPrice=1";

                        SqlCommand cmd = new SqlCommand(strQuery, conn);
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "Price_data");

                        grdPhonetbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                        grdPhonetbl.DataMember = "Price_data";
                    }
                }//모든 콤보박스만 입력했을 때 검색

                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING)) //화면에 띄워주고 난 후엔 Selected값을 0으로 바꿔줌
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    cmd.CommandText = " UPDATE dbo.productTbl " +
                                      " SET SelectedPrice = 0,SelectedDatas=0,SelectedBenefit=0 " +
                                      "  WHERE SelectedBenefit=1 OR SelectedDatas=1 OR SelectedPrice=1";
                    cmd.ExecuteNonQuery();
                }//Selected 값 0으로 초기화
            }
            CboData.SelectedIndex = -1;
            cboPrice.SelectedIndex = -1;
            cboService.SelectedIndex = -1;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            CboData.SelectedIndex = -1;
            cboPrice.SelectedIndex = -1;
            cboService.SelectedIndex = -1;
            UpdateData();
        }

        private void btnSpecific_Click(object sender, EventArgs e)
        {
            Commons.SELECTED_PLAN = SELECTED_MODEL;

            Commons.USER_STD_1 = User_std1;
            Commons.USER_STD_2 = User_std2;
            Commons.USER_STD_3 = User_std3;

            try
            {
                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                {
                    DataSet ds = new DataSet();
                    conn.Open();

                    // 2개의 파라미터 정의 (항상 @로 시작)
                    string sql = " SELECT  STD1,STD2,STD3 " +
                                      " FROM dbo.productTbl WHERE CallingPlan = @CallingPlan";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // 각 파라미터 타입 및 값 입력
                    SqlParameter paramCity = new SqlParameter("@CallingPlan", SqlDbType.NVarChar, 50);
                    paramCity.Value = SELECTED_MODEL;
                    // SqlCommand 객체의 Parameters 속성에 추가
                    cmd.Parameters.Add(paramCity);



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds, "User_Information");

                    conn.Close();
                    priceTbl.DataSource = ds; //그리드의 데이터 소스에다가 붓는다.
                    priceTbl.DataMember = "User_Information";


                }
                Commons.SELECTED_PLAN = SELECTED_MODEL;

                Product_std1 = int.Parse(priceTbl[0, 0].Value.ToString());
                Product_std2 = int.Parse(priceTbl[1, 0].Value.ToString());
                Product_std3 = int.Parse(priceTbl[2, 0].Value.ToString());

                

                Specific_Form form = new Specific_Form();
                InitChildForm(form, "");
                SELECTED_MODEL = "";

                Calculate_Favor_Specific();
            }
            catch (Exception)
            {

            }
            
                using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    cmd.CommandText = " UPDATE dbo.userTbl " +
                                      " SET STD1 = @STD1, STD2 = @STD2, STD3 = @STD3 " +
                                      " WHERE userID = @userID";

                    SqlParameter parmSTD1 = new SqlParameter("@STD1", SqlDbType.Int);
                    parmSTD1.Value = User_std1;
                    cmd.Parameters.Add(parmSTD1);

                    SqlParameter parSTD2 = new SqlParameter("@STD2", SqlDbType.Int);
                    parSTD2.Value = User_std2;
                    cmd.Parameters.Add(parSTD2);

                    SqlParameter parmSTD3 = new SqlParameter("@STD3", SqlDbType.Int);
                    parmSTD3.Value = User_std3;
                    cmd.Parameters.Add(parmSTD3);

                    SqlParameter parmuserID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                    parmuserID.Value = Commons.LOGINUSERID;
                    cmd.Parameters.Add(parmuserID);

                    cmd.ExecuteNonQuery();//excute는 넣을 때 쓰는건 NonQuery 그 외에건 가져올 때
                }
           
        }

        private void grdPhonetbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void Calculate_Favor_Specific()
        {
            int temp1=0,temp2=0,temp3=0;
            
            if(User_std1!=Product_std1)
            { //두 숫자 사이 차 절대값 구하기
                temp1 = Math.Abs(User_std1 - Product_std1);
                temp1 = temp1 / 10;
            }
            if (User_std2 != Product_std2)
            { //두 숫자 사이 차 절대값 구하기
                temp2 = Math.Abs(User_std2 - Product_std2);
                temp2 = temp2 / 10;
            }
            if (User_std3 != Product_std3)
            { //두 숫자 사이 차 절대값 구하기
                temp3 = Math.Abs(User_std3 - Product_std3);
                temp3 = temp3 / 10;
            }

            if (User_std1 != Product_std1)
            {
                if (User_std1 > Product_std1)
                {
                    User_std1 = User_std1 - temp1;
                }
                else if (Product_std1 > User_std1)
                {
                    User_std1 = User_std1 + temp1;
                }
            }
            if (User_std2 != Product_std2)
            {
                if (User_std2 > Product_std2)
                {
                    User_std2 = User_std2 - temp2;
                }
                else if (Product_std2 > User_std2)
                {
                    User_std2 = User_std2 + temp2;
                }
            }
            if (User_std3 != Product_std3)
            {
                if (User_std3 > Product_std3)
                {
                    User_std3 = User_std3 - temp3;
                }
                else if (Product_std3 > User_std3)
                {
                    User_std3 = User_std3 + temp3;
                }
            }
            

        }

        private void NewRecommend_Click(object sender, EventArgs e)
        {
            // HJ 추가 [20200703 12:40] : 추천창 켜기
            RmdForm form = new RmdForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void All_Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this,"정말 종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in this.MdiChildren)
                {
                    item.Close();
                }
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}


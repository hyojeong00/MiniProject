using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class DiffShowForm : Form
    {
        public DiffShowForm()
        {
            InitializeComponent();
        }

        private void DiffShow_Load(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = "SELECT  ROW_NUMBER() OVER(ORDER BY SQRT(POWER((u.STD1 - p.STD1),2) + POWER((u.STD2 - p.STD2),2) + POWER((u.STD3 - P.STD3),2)) DESC) AS 순위 "
                                        + " , u.userName AS 이름 ,u.userID AS 아이디 ,u.userUSCallPlan AS 사용요금제 ,SQRT(POWER((u.STD1 - p.STD1), 2) + POWER((u.STD2 - p.STD2), 2) + POWER((u.STD3 - P.STD3), 2))" +
                                        " , ABS(u.STD1 - p.STD1) AS '가격성향차이', ABS(u.STD2 - p.STD2) AS '데이터량성향차이', ABS(u.STD3 - p.STD3) AS '혜택성향차이' "
                                  + " FROM userTbl AS u "
                                 + " INNER JOIN productTbl AS p ON u.userUSCallPlan = p.CallingPlan "
                                 + " WHERE SQRT(POWER((u.STD1 - p.STD1),2) + POWER((u.STD2 - p.STD2),2) + POWER((u.STD3 - P.STD3),2)) != 0 ";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "userTbl");

                GrdDiffShow.DataSource = ds;
                GrdDiffShow.DataMember = "userTbl";
            }
            DataGridViewColumn column = GrdDiffShow.Columns[4];
            column.Visible = false;
            column = GrdDiffShow.Columns[3];
            column.Width = column.Width + 20;
            column = GrdDiffShow.Columns[5];
            column.Width = column.Width + 20;
            column = GrdDiffShow.Columns[6];
            column.Width = column.Width + 30;
            column = GrdDiffShow.Columns[7];
            column.Width = column.Width + 20;
        }
    }
}

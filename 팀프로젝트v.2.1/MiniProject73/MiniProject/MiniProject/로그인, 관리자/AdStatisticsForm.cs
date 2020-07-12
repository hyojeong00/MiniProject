using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class AdStatisticsForm : Form
    {
        string[] CallingName = new string[10];
        int[] count = new int[10];
        int usercount = 0;

        public AdStatisticsForm()
        {
            InitializeComponent();
        }

        private void AdStatisticsForm_Load(object sender, EventArgs e)
        {

            Color[] color_decision = new Color[10];
            color_decision[0] = Color.Red;
            color_decision[1] = Color.Blue;
            color_decision[2] = Color.LightGray;
            color_decision[3] = Color.Beige;
            color_decision[4] = Color.BlueViolet;
            color_decision[5] = Color.FloralWhite;
            color_decision[6] = Color.Firebrick;
            color_decision[7] = Color.Brown;
            color_decision[8] = Color.Coral;
            color_decision[9] = Color.Chocolate;

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = " SELECT num " +
                                  "  FROM userTbl ORDER BY num DESC ";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "sold");

                SqlDataReader reader = cmd.ExecuteReader();


                reader.Read();

                usercount = int.Parse(reader[0].ToString());
            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = " SELECT CallingPlan, SoldCallPlan " +
                                  "  FROM productTbl " +
                                  "  ORDER BY SoldCallPlan DESC ";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "sold");

                SqlDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < 5; i++)
                {
                    reader.Read();

                    CallingName[i] = reader[0].ToString();
                    count[i] = int.Parse(reader[1].ToString());
                }

                for (int i = 0; i < 5; i++)
                {
                    chart1.Series["Series1"].Points.Add(count[i]);
                    chart1.Series["Series1"].Points[i].Color = color_decision[i];
                    chart1.Series["Series1"].Points[i].AxisLabel = CallingName[i];
                }

            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                string strQuery = " SELECT STD1,STD2,STD3 " +
                                  "  FROM userTbl ";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "sold");

                SqlDataReader reader = cmd.ExecuteReader();

                int std1 = 0, std2 = 0, std3 = 0;
                int standard1 = 0, standard2 = 0, standard3 = 0;

                for (int i = 0; i < usercount; i++)
                {
                    reader.Read();

                    std1 = int.Parse(reader[0].ToString());
                    std2 = int.Parse(reader[1].ToString());
                    std3 = int.Parse(reader[2].ToString());

                    if (std1 != std2 && std1 != std3 && std2 != std3)
                    {
                        if (std1 > std2 && std1 > std3)
                            standard1 += 1;
                        if (std2 > std1 && std2 > std3)
                            standard2 += 1;
                        if (std3 > std1 && std3 > std2)
                            standard3 += 1;
                    }
                    else if (std1 == std2 || std1 == std3 || std2 == std3)
                    {
                        if (std1 == std2)
                        {
                            if (std1 > std3)
                            {
                                standard1 += 1;
                                standard2 += 1;
                            }
                            else
                                standard3 += 1;
                        }
                        if (std1 == std3)
                        {
                            if (std1 > std2)
                            {
                                standard1 += 1;
                                standard3 += 1;
                            }
                            else
                                standard2 += 1;
                        }
                        if (std2 == std3)
                        {
                            if (std2 > std1)
                            {
                                standard2 += 1;
                                standard3 += 1;
                            }
                            else
                                standard1 += 1;
                        }
                    }
                }

                double sum = standard1 + standard2 + standard3;
                double dstd1 = (standard1 / sum) * 100;
                double dstd2 = (standard2 / sum) * 100;
                double dstd3 = (standard3 / sum) * 100;

                dstd1 = Math.Round(dstd1, 2);
                dstd2 = Math.Round(dstd2, 2);
                dstd3 = Math.Round(dstd3, 2);

                chart2.Series["Series1"].Points.Add(dstd1);
                chart2.Series["Series1"].Points[0].Color = color_decision[0];
                chart2.Series["Series1"].Points[0].AxisLabel = "가격";
                chart2.Series["Series1"].Points[0].LegendText = "가격";

                chart2.Series["Series1"].Points.Add(dstd2);
                chart2.Series["Series1"].Points[1].Color = color_decision[1];
                chart2.Series["Series1"].Points[1].AxisLabel = "데이터";
                chart2.Series["Series1"].Points[1].LegendText = "데이터";

                chart2.Series["Series1"].Points.Add(dstd3);
                chart2.Series["Series1"].Points[2].Color = color_decision[2];
                chart2.Series["Series1"].Points[2].AxisLabel = "혜택";
                chart2.Series["Series1"].Points[2].LegendText = "혜택";
            }

            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                string[] Company = new string[usercount];
                double skt = 0;
                double kt = 0;
                double lg = 0;


                conn.Open();
                string strQuery = "  SELECT p.Company " +
                                  "  FROM userTbl AS u " +
                                  "  INNER JOIN productTbl AS p " +
                                  "  ON u.userUSCallPlan = p.CallingPlan  ";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "sold");



                SqlDataReader reader = cmd.ExecuteReader();


                for (int i = 0; i < usercount; i++)
                {
                    reader.Read();

                    Company[i] = reader[0].ToString();

                    if (Company[i] == "SKT")
                        skt = skt + 1;
                    if (Company[i] == "KT")
                        kt = kt + 1;
                    if (Company[i] == "LGT")
                        lg = lg + 1;
                }

                double sum = 0;

                sum = skt + kt + lg;
                skt = skt / sum * 100;

                kt = kt / sum * 100;
                lg = lg / sum * 100;

                double skt1 = Math.Round(skt, 2);
                double kt1 = Math.Round(kt, 2);
                double lg1 = Math.Round(lg, 2);

                chart3.Series["Series1"].Points.Add(skt1);
                chart3.Series["Series1"].Points[0].Color = color_decision[0];
                chart3.Series["Series1"].Points[0].AxisLabel = "SKT";
                chart3.Series["Series1"].Points[0].LegendText = "SKT";

                chart3.Series["Series1"].Points.Add(kt1);
                chart3.Series["Series1"].Points[1].Color = color_decision[1];
                chart3.Series["Series1"].Points[1].AxisLabel = "KT";
                chart3.Series["Series1"].Points[1].LegendText = "KT";

                chart3.Series["Series1"].Points.Add(lg1);
                chart3.Series["Series1"].Points[2].Color = color_decision[2];
                chart3.Series["Series1"].Points[2].AxisLabel = "LGT";
                chart3.Series["Series1"].Points[2].LegendText = "LGT";


            }

        }
    }
}

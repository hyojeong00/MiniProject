using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartChart
{
    public partial class Form1 : MetroForm
    {
        string[] CallingName = new string[10];
        int[] count = new int[10];
        int usercount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Commons.strConnString))
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
            using (SqlConnection conn = new SqlConnection(Commons.strConnString))
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

                for (int i = 0; i < 10; i++)
                {
                    reader.Read();

                    CallingName[i] = reader[0].ToString();
                    count[i] = int.Parse(reader[1].ToString());



                }
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


                for (int i = 0; i < 5; i++)
                {
                    chart1.Series["Series1"].Points.Add(count[i]);
                    chart1.Series["Series1"].Points[i].Color = color_decision[i];
                    chart1.Series["Series1"].Points[i].AxisLabel = CallingName[i];
                    chart1.Series["Series1"].Points[i].LegendText = CallingName[i];

                }



            }
            using (SqlConnection conn = new SqlConnection(Commons.strConnString))
            {
                

                conn.Open();
                string strQuery = " SELECT STD1,STD2,STD3 " +
                                  "  FROM userTbl ";

                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "sold");



                SqlDataReader reader = cmd.ExecuteReader();

                int std1=0,std2=0,std3=0;
                int standard1=0, standard2=0, standard3=0;

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

                dstd1 = Math.Round(dstd1,2);
                dstd2= Math.Round(dstd2, 2);
                dstd3=Math.Round(dstd3, 2);


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
        }
        
    }
}

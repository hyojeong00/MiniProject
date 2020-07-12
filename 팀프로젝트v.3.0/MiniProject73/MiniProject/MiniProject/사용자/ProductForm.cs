using MetroFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroMessageBox.Show(this,"정말 종료하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in this.MdiChildren)
                {
                    item.Close();
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT userSearch FROM userTbl WHERE userID = @userID ";

                SqlParameter paramID = new SqlParameter("@userID", SqlDbType.VarChar, 50);
                paramID.Value = Commons.LOGINUSERID;
                cmd.Parameters.Add(paramID);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader[0].ToString() == "False")
                {
                    QueForm form = new QueForm();
                    form.ShowDialog();
                }
            }

            All_Products all_Products = new All_Products();
            all_Products.Dock = DockStyle.Fill;
            all_Products.MdiParent = this;
            all_Products.Show();
            all_Products.WindowState = FormWindowState.Maximized;
        }
    }
}

using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class AdministrationForm : MetroForm

    {
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MetroMessageBox.Show(this,"정말 종료하시겠습니까?","종료",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in this.MdiChildren)
                {
                    item.Close();
                }
                e.Cancel = false;
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            AdMemberForm form = new AdMemberForm();
            InitChildForm(form, "회원관리");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            AdListForm form = new AdListForm();
            InitChildForm(form, "목록관리");
        }
        private void InitChildForm(Form form, string strFormTitle)
        {
            form.Text = strFormTitle;
            form.Dock = DockStyle.Fill;
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            DiffShowForm form = new DiffShowForm();
            InitChildForm(form, "성향차이분석");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.Close();
            }
            AdStatisticsForm form = new AdStatisticsForm();
            InitChildForm(form, "통계");
        }
    }
}


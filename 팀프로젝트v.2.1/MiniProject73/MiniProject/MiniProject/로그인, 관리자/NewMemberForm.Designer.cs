namespace MiniProject
{
    partial class NewMemberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnID = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlID = new System.Windows.Forms.Panel();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pnlAge = new System.Windows.Forms.Panel();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pnlMobile = new System.Windows.Forms.Panel();
            this.pnlPlan = new System.Windows.Forms.Panel();
            this.cboUSCallPlan = new MetroFramework.Controls.MetroComboBox();
            this.panel1.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlID.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlAge.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.pnlMobile.SuspendLayout();
            this.pnlPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(6, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 26);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "이름";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblID.Location = new System.Drawing.Point(3, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(84, 25);
            this.lblID.TabIndex = 13;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPassword.Location = new System.Drawing.Point(6, 14);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(95, 25);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAge
            // 
            this.lblAge.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAge.Location = new System.Drawing.Point(3, 13);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(84, 25);
            this.lblAge.TabIndex = 15;
            this.lblAge.Text = "나이";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGender.Location = new System.Drawing.Point(4, 14);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(84, 25);
            this.lblGender.TabIndex = 16;
            this.lblGender.Text = "성별";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMobile
            // 
            this.lblMobile.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMobile.Location = new System.Drawing.Point(16, 13);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(84, 25);
            this.lblMobile.TabIndex = 17;
            this.lblMobile.Text = "전화번호";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlan
            // 
            this.lblPlan.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlan.Location = new System.Drawing.Point(3, 15);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(159, 25);
            this.lblPlan.TabIndex = 18;
            this.lblPlan.Text = "현재 사용 요금제";
            this.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtID.Location = new System.Drawing.Point(110, 19);
            this.txtID.MaxLength = 50;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(325, 20);
            this.txtID.TabIndex = 1;
            this.txtID.AcceptsTabChanged += new System.EventHandler(this.txtID_AcceptsTabChanged);
            this.txtID.Click += new System.EventHandler(this.txtID_Click);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // btnID
            // 
            this.btnID.BackColor = System.Drawing.Color.MediumPurple;
            this.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnID.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnID.ForeColor = System.Drawing.Color.White;
            this.btnID.Location = new System.Drawing.Point(441, 0);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(106, 36);
            this.btnID.TabIndex = 2;
            this.btnID.Text = "중복확인";
            this.btnID.UseVisualStyleBackColor = false;
            this.btnID.Click += new System.EventHandler(this.btnID_Click);
            this.btnID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnID_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPassword.Location = new System.Drawing.Point(110, 19);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(325, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.Control;
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAge.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtAge.Location = new System.Drawing.Point(110, 18);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(325, 20);
            this.txtAge.TabIndex = 4;
            this.txtAge.Click += new System.EventHandler(this.txtAge_Click);
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdbtnMale.Location = new System.Drawing.Point(172, 14);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(66, 24);
            this.rdbtnMale.TabIndex = 5;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "남자";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            this.rdbtnMale.Click += new System.EventHandler(this.rdbtnMale_Click);
            this.rdbtnMale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdbtnMale_KeyPress);
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdbtnFemale.Location = new System.Drawing.Point(292, 14);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(66, 24);
            this.rdbtnFemale.TabIndex = 6;
            this.rdbtnFemale.TabStop = true;
            this.rdbtnFemale.Text = "여자";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            this.rdbtnFemale.Click += new System.EventHandler(this.rdbtnFemale_Click);
            this.rdbtnFemale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rdbtnFemale_KeyPress);
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.SystemColors.Control;
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMobile.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMobile.Location = new System.Drawing.Point(109, 18);
            this.txtMobile.MaxLength = 13;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(325, 20);
            this.txtMobile.TabIndex = 7;
            this.txtMobile.Click += new System.EventHandler(this.txtMobile_Click);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.MediumPurple;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(407, 534);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 55);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(599, 534);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 55);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 615);
            this.panel1.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(250, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(546, 35);
            this.panel3.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("비비트리고딕_L", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(78, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 43);
            this.label8.TabIndex = 0;
            this.label8.Text = "회원가입";
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.White;
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Location = new System.Drawing.Point(250, 39);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(546, 50);
            this.pnlName.TabIndex = 32;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("비비트리고딕_L", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(110, 19);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(339, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // pnlID
            // 
            this.pnlID.BackColor = System.Drawing.SystemColors.Control;
            this.pnlID.Controls.Add(this.lblID);
            this.pnlID.Controls.Add(this.btnID);
            this.pnlID.Controls.Add(this.txtID);
            this.pnlID.Location = new System.Drawing.Point(250, 110);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(546, 50);
            this.pnlID.TabIndex = 33;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPassword.Controls.Add(this.lblPassword);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(250, 181);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(546, 50);
            this.pnlPassword.TabIndex = 34;
            // 
            // pnlAge
            // 
            this.pnlAge.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAge.Controls.Add(this.lblAge);
            this.pnlAge.Controls.Add(this.txtAge);
            this.pnlAge.Location = new System.Drawing.Point(250, 252);
            this.pnlAge.Name = "pnlAge";
            this.pnlAge.Size = new System.Drawing.Size(546, 50);
            this.pnlAge.TabIndex = 35;
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGender.Controls.Add(this.lblGender);
            this.pnlGender.Controls.Add(this.rdbtnMale);
            this.pnlGender.Controls.Add(this.rdbtnFemale);
            this.pnlGender.Location = new System.Drawing.Point(250, 323);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(546, 50);
            this.pnlGender.TabIndex = 36;
            // 
            // pnlMobile
            // 
            this.pnlMobile.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMobile.Controls.Add(this.lblMobile);
            this.pnlMobile.Controls.Add(this.txtMobile);
            this.pnlMobile.Location = new System.Drawing.Point(251, 394);
            this.pnlMobile.Name = "pnlMobile";
            this.pnlMobile.Size = new System.Drawing.Size(546, 50);
            this.pnlMobile.TabIndex = 37;
            // 
            // pnlPlan
            // 
            this.pnlPlan.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPlan.Controls.Add(this.cboUSCallPlan);
            this.pnlPlan.Controls.Add(this.lblPlan);
            this.pnlPlan.Location = new System.Drawing.Point(251, 465);
            this.pnlPlan.Name = "pnlPlan";
            this.pnlPlan.Size = new System.Drawing.Size(546, 50);
            this.pnlPlan.TabIndex = 38;
            // 
            // cboUSCallPlan
            // 
            this.cboUSCallPlan.BackColor = System.Drawing.SystemColors.Control;
            this.cboUSCallPlan.FormattingEnabled = true;
            this.cboUSCallPlan.ItemHeight = 24;
            this.cboUSCallPlan.Location = new System.Drawing.Point(178, 12);
            this.cboUSCallPlan.Name = "cboUSCallPlan";
            this.cboUSCallPlan.Size = new System.Drawing.Size(216, 30);
            this.cboUSCallPlan.TabIndex = 8;
            this.cboUSCallPlan.UseSelectable = true;
            this.cboUSCallPlan.DropDown += new System.EventHandler(this.cboUSCallPlan_DropDown);
            this.cboUSCallPlan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUSCallPlan_KeyPress);
            // 
            // NewMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 615);
            this.Controls.Add(this.pnlPlan);
            this.Controls.Add(this.pnlMobile);
            this.Controls.Add(this.pnlGender);
            this.Controls.Add(this.pnlAge);
            this.Controls.Add(this.pnlPassword);
            this.Controls.Add(this.pnlID);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("배달의민족 한나체 Air", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "NewMemberForm";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.NewMemberForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlAge.ResumeLayout(false);
            this.pnlAge.PerformLayout();
            this.pnlGender.ResumeLayout(false);
            this.pnlGender.PerformLayout();
            this.pnlMobile.ResumeLayout(false);
            this.pnlMobile.PerformLayout();
            this.pnlPlan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlID;
        private System.Windows.Forms.Panel pnlAge;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.Panel pnlMobile;
        private System.Windows.Forms.Panel pnlPlan;
        private MetroFramework.Controls.MetroComboBox cboUSCallPlan;
    }
}
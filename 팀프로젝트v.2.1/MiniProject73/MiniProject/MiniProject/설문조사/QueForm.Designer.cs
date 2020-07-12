using System;

namespace MiniProject
{
    partial class QueForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroPanel1 = new System.Windows.Forms.Panel();
            this.metroRadioButton4 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton3 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton2 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.metroPanel2 = new System.Windows.Forms.Panel();
            this.metroRadioButton7 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton10 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton9 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.metroPanel3 = new System.Windows.Forms.Panel();
            this.metroRadioButton12 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton15 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton14 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton11 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.metroPanel4 = new System.Windows.Forms.Panel();
            this.metroRadioButton8 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton16 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton13 = new System.Windows.Forms.RadioButton();
            this.metroRadioButton5 = new System.Windows.Forms.RadioButton();
            this.MetroButton1 = new System.Windows.Forms.Button();
            this.MetroButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MediumPurple;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(727, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "1. 영화를 좋아하나요?";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroRadioButton4);
            this.metroPanel1.Controls.Add(this.metroRadioButton3);
            this.metroPanel1.Controls.Add(this.metroRadioButton2);
            this.metroPanel1.Controls.Add(this.metroRadioButton1);
            this.metroPanel1.Location = new System.Drawing.Point(247, 180);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(727, 86);
            this.metroPanel1.TabIndex = 2;
            // 
            // metroRadioButton4
            // 
            this.metroRadioButton4.AutoSize = true;
            this.metroRadioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton4.Location = new System.Drawing.Point(543, 33);
            this.metroRadioButton4.Name = "metroRadioButton4";
            this.metroRadioButton4.Size = new System.Drawing.Size(111, 22);
            this.metroRadioButton4.TabIndex = 3;
            this.metroRadioButton4.TabStop = true;
            this.metroRadioButton4.Text = "매우 좋아한다";
            this.metroRadioButton4.UseVisualStyleBackColor = true;
            this.metroRadioButton4.CheckedChanged += new System.EventHandler(this.metroRadioButton4_CheckedChanged);
            // 
            // metroRadioButton3
            // 
            this.metroRadioButton3.AutoSize = true;
            this.metroRadioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton3.Location = new System.Drawing.Point(385, 33);
            this.metroRadioButton3.Name = "metroRadioButton3";
            this.metroRadioButton3.Size = new System.Drawing.Size(81, 22);
            this.metroRadioButton3.TabIndex = 2;
            this.metroRadioButton3.TabStop = true;
            this.metroRadioButton3.Text = "좋아한다";
            this.metroRadioButton3.UseVisualStyleBackColor = true;
            this.metroRadioButton3.CheckedChanged += new System.EventHandler(this.metroRadioButton3_CheckedChanged);
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton2.Location = new System.Drawing.Point(227, 33);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(81, 22);
            this.metroRadioButton2.TabIndex = 1;
            this.metroRadioButton2.TabStop = true;
            this.metroRadioButton2.Text = "싫어한다";
            this.metroRadioButton2.UseVisualStyleBackColor = true;
            this.metroRadioButton2.CheckedChanged += new System.EventHandler(this.metroRadioButton2_CheckedChanged);
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton1.Location = new System.Drawing.Point(39, 33);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(111, 22);
            this.metroRadioButton1.TabIndex = 0;
            this.metroRadioButton1.TabStop = true;
            this.metroRadioButton1.Text = "매우 싫어한다";
            this.metroRadioButton1.UseVisualStyleBackColor = true;
            this.metroRadioButton1.CheckedChanged += new System.EventHandler(this.metroRadioButton1_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.MediumPurple;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(13, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(727, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "2. 당신은 어느 직업군에 속하나요?";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroRadioButton7);
            this.metroPanel2.Controls.Add(this.metroRadioButton10);
            this.metroPanel2.Controls.Add(this.metroRadioButton9);
            this.metroPanel2.Controls.Add(this.metroRadioButton6);
            this.metroPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroPanel2.Location = new System.Drawing.Point(247, 323);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(727, 86);
            this.metroPanel2.TabIndex = 4;
            // 
            // metroRadioButton7
            // 
            this.metroRadioButton7.AutoSize = true;
            this.metroRadioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton7.Location = new System.Drawing.Point(544, 33);
            this.metroRadioButton7.Name = "metroRadioButton7";
            this.metroRadioButton7.Size = new System.Drawing.Size(68, 22);
            this.metroRadioButton7.TabIndex = 3;
            this.metroRadioButton7.TabStop = true;
            this.metroRadioButton7.Text = "직장인";
            this.metroRadioButton7.UseVisualStyleBackColor = true;
            this.metroRadioButton7.CheckedChanged += new System.EventHandler(this.metroRadioButton7_CheckedChanged);
            // 
            // metroRadioButton10
            // 
            this.metroRadioButton10.AutoSize = true;
            this.metroRadioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton10.Location = new System.Drawing.Point(380, 33);
            this.metroRadioButton10.Name = "metroRadioButton10";
            this.metroRadioButton10.Size = new System.Drawing.Size(55, 22);
            this.metroRadioButton10.TabIndex = 2;
            this.metroRadioButton10.TabStop = true;
            this.metroRadioButton10.Text = "주부";
            this.metroRadioButton10.UseVisualStyleBackColor = true;
            this.metroRadioButton10.CheckedChanged += new System.EventHandler(this.metroRadioButton10_CheckedChanged);
            // 
            // metroRadioButton9
            // 
            this.metroRadioButton9.AutoSize = true;
            this.metroRadioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton9.Location = new System.Drawing.Point(203, 33);
            this.metroRadioButton9.Name = "metroRadioButton9";
            this.metroRadioButton9.Size = new System.Drawing.Size(68, 22);
            this.metroRadioButton9.TabIndex = 1;
            this.metroRadioButton9.TabStop = true;
            this.metroRadioButton9.Text = "자영업";
            this.metroRadioButton9.UseVisualStyleBackColor = true;
            this.metroRadioButton9.CheckedChanged += new System.EventHandler(this.metroRadioButton9_CheckedChanged);
            // 
            // metroRadioButton6
            // 
            this.metroRadioButton6.AutoSize = true;
            this.metroRadioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton6.Location = new System.Drawing.Point(39, 33);
            this.metroRadioButton6.Name = "metroRadioButton6";
            this.metroRadioButton6.Size = new System.Drawing.Size(55, 22);
            this.metroRadioButton6.TabIndex = 0;
            this.metroRadioButton6.TabStop = true;
            this.metroRadioButton6.Text = "학생";
            this.metroRadioButton6.UseVisualStyleBackColor = true;
            this.metroRadioButton6.CheckedChanged += new System.EventHandler(this.metroRadioButton6_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.MediumPurple;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(13, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(465, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "3. 어느 정도의 연령이신가요?";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.metroRadioButton12);
            this.metroPanel3.Controls.Add(this.metroRadioButton15);
            this.metroPanel3.Controls.Add(this.metroRadioButton14);
            this.metroPanel3.Controls.Add(this.metroRadioButton11);
            this.metroPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroPanel3.Location = new System.Drawing.Point(244, 466);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(727, 86);
            this.metroPanel3.TabIndex = 5;
            // 
            // metroRadioButton12
            // 
            this.metroRadioButton12.AutoSize = true;
            this.metroRadioButton12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton12.Location = new System.Drawing.Point(547, 33);
            this.metroRadioButton12.Name = "metroRadioButton12";
            this.metroRadioButton12.Size = new System.Drawing.Size(94, 22);
            this.metroRadioButton12.TabIndex = 3;
            this.metroRadioButton12.TabStop = true;
            this.metroRadioButton12.Text = "장년(50대)";
            this.metroRadioButton12.UseVisualStyleBackColor = true;
            this.metroRadioButton12.CheckedChanged += new System.EventHandler(this.metroRadioButton12_CheckedChanged);
            // 
            // metroRadioButton15
            // 
            this.metroRadioButton15.AutoSize = true;
            this.metroRadioButton15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton15.Location = new System.Drawing.Point(421, 33);
            this.metroRadioButton15.Name = "metroRadioButton15";
            this.metroRadioButton15.Size = new System.Drawing.Size(94, 22);
            this.metroRadioButton15.TabIndex = 2;
            this.metroRadioButton15.TabStop = true;
            this.metroRadioButton15.Text = "중년(40대)";
            this.metroRadioButton15.UseVisualStyleBackColor = true;
            this.metroRadioButton15.CheckedChanged += new System.EventHandler(this.metroRadioButton15_CheckedChanged);
            // 
            // metroRadioButton14
            // 
            this.metroRadioButton14.AutoSize = true;
            this.metroRadioButton14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton14.Location = new System.Drawing.Point(220, 33);
            this.metroRadioButton14.Name = "metroRadioButton14";
            this.metroRadioButton14.Size = new System.Drawing.Size(174, 22);
            this.metroRadioButton14.TabIndex = 1;
            this.metroRadioButton14.TabStop = true;
            this.metroRadioButton14.Text = "청년(만 19세 ~ 만 39세)";
            this.metroRadioButton14.UseVisualStyleBackColor = true;
            this.metroRadioButton14.CheckedChanged += new System.EventHandler(this.metroRadioButton14_CheckedChanged);
            // 
            // metroRadioButton11
            // 
            this.metroRadioButton11.AutoSize = true;
            this.metroRadioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton11.Location = new System.Drawing.Point(39, 33);
            this.metroRadioButton11.Name = "metroRadioButton11";
            this.metroRadioButton11.Size = new System.Drawing.Size(154, 22);
            this.metroRadioButton11.TabIndex = 0;
            this.metroRadioButton11.TabStop = true;
            this.metroRadioButton11.Text = "청소년(만 18세 이하)";
            this.metroRadioButton11.UseVisualStyleBackColor = true;
            this.metroRadioButton11.CheckedChanged += new System.EventHandler(this.metroRadioButton11_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.MediumPurple;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(16, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(727, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "4. 원하는 혜택을 선택하세요";
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.metroRadioButton8);
            this.metroPanel4.Controls.Add(this.metroRadioButton16);
            this.metroPanel4.Controls.Add(this.metroRadioButton13);
            this.metroPanel4.Controls.Add(this.metroRadioButton5);
            this.metroPanel4.Location = new System.Drawing.Point(244, 610);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(727, 86);
            this.metroPanel4.TabIndex = 6;
            // 
            // metroRadioButton8
            // 
            this.metroRadioButton8.AutoSize = true;
            this.metroRadioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton8.Location = new System.Drawing.Point(548, 33);
            this.metroRadioButton8.Name = "metroRadioButton8";
            this.metroRadioButton8.Size = new System.Drawing.Size(124, 22);
            this.metroRadioButton8.TabIndex = 3;
            this.metroRadioButton8.TabStop = true;
            this.metroRadioButton8.Text = "멤버쉽 VIP 받기";
            this.metroRadioButton8.UseVisualStyleBackColor = true;
            this.metroRadioButton8.CheckedChanged += new System.EventHandler(this.metroRadioButton8_CheckedChanged);
            // 
            // metroRadioButton16
            // 
            this.metroRadioButton16.AutoSize = true;
            this.metroRadioButton16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton16.Location = new System.Drawing.Point(352, 33);
            this.metroRadioButton16.Name = "metroRadioButton16";
            this.metroRadioButton16.Size = new System.Drawing.Size(162, 22);
            this.metroRadioButton16.TabIndex = 2;
            this.metroRadioButton16.TabStop = true;
            this.metroRadioButton16.Text = "스마트기기 1회선 무료";
            this.metroRadioButton16.UseVisualStyleBackColor = true;
            this.metroRadioButton16.CheckedChanged += new System.EventHandler(this.metroRadioButton16_CheckedChanged);
            // 
            // metroRadioButton13
            // 
            this.metroRadioButton13.AutoSize = true;
            this.metroRadioButton13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton13.Location = new System.Drawing.Point(187, 33);
            this.metroRadioButton13.Name = "metroRadioButton13";
            this.metroRadioButton13.Size = new System.Drawing.Size(128, 22);
            this.metroRadioButton13.TabIndex = 1;
            this.metroRadioButton13.TabStop = true;
            this.metroRadioButton13.Text = "해외에서 톡 무료";
            this.metroRadioButton13.UseVisualStyleBackColor = true;
            this.metroRadioButton13.CheckedChanged += new System.EventHandler(this.metroRadioButton13_CheckedChanged);
            // 
            // metroRadioButton5
            // 
            this.metroRadioButton5.AutoSize = true;
            this.metroRadioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.metroRadioButton5.Location = new System.Drawing.Point(39, 33);
            this.metroRadioButton5.Name = "metroRadioButton5";
            this.metroRadioButton5.Size = new System.Drawing.Size(111, 22);
            this.metroRadioButton5.TabIndex = 0;
            this.metroRadioButton5.TabStop = true;
            this.metroRadioButton5.Text = "미디어팩 무료";
            this.metroRadioButton5.UseVisualStyleBackColor = true;
            this.metroRadioButton5.CheckedChanged += new System.EventHandler(this.metroRadioButton5_CheckedChanged);
            // 
            // MetroButton1
            // 
            this.MetroButton1.BackColor = System.Drawing.Color.MediumPurple;
            this.MetroButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MetroButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MetroButton1.ForeColor = System.Drawing.Color.White;
            this.MetroButton1.Location = new System.Drawing.Point(459, 706);
            this.MetroButton1.Name = "MetroButton1";
            this.MetroButton1.Size = new System.Drawing.Size(93, 35);
            this.MetroButton1.TabIndex = 13;
            this.MetroButton1.Text = "다음";
            this.MetroButton1.UseVisualStyleBackColor = false;
            this.MetroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // MetroButton
            // 
            this.MetroButton.BackColor = System.Drawing.Color.MediumPurple;
            this.MetroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MetroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MetroButton.ForeColor = System.Drawing.Color.White;
            this.MetroButton.Location = new System.Drawing.Point(633, 706);
            this.MetroButton.Name = "MetroButton";
            this.MetroButton.Size = new System.Drawing.Size(101, 35);
            this.MetroButton.TabIndex = 14;
            this.MetroButton.Text = "건너뛰기";
            this.MetroButton.UseVisualStyleBackColor = false;
            this.MetroButton.Click += new System.EventHandler(this.MetroButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 80);
            this.panel1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1097, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "UserName";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1034, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "사용자:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "설문지";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.MediumPurple;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(247, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 45);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumPurple;
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(247, 272);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(727, 45);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumPurple;
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Location = new System.Drawing.Point(247, 415);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(727, 45);
            this.panel4.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MediumPurple;
            this.panel7.Controls.Add(this.textBox4);
            this.panel7.Location = new System.Drawing.Point(244, 559);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(727, 45);
            this.panel7.TabIndex = 19;
            // 
            // QueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.ControlBox = false;
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MetroButton);
            this.Controls.Add(this.MetroButton1);
            this.Controls.Add(this.metroPanel4);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설문지";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

   



        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel metroPanel1;
        private System.Windows.Forms.RadioButton metroRadioButton2;
        private System.Windows.Forms.RadioButton metroRadioButton1;
        private System.Windows.Forms.RadioButton metroRadioButton4;
        private System.Windows.Forms.RadioButton metroRadioButton3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel metroPanel2;
        private System.Windows.Forms.RadioButton metroRadioButton7;
        private System.Windows.Forms.RadioButton metroRadioButton10;
        private System.Windows.Forms.RadioButton metroRadioButton9;
        private System.Windows.Forms.RadioButton metroRadioButton6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel metroPanel3;
        private System.Windows.Forms.RadioButton metroRadioButton12;
        private System.Windows.Forms.RadioButton metroRadioButton15;
        private System.Windows.Forms.RadioButton metroRadioButton14;
        private System.Windows.Forms.RadioButton metroRadioButton11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel metroPanel4;
        private System.Windows.Forms.RadioButton metroRadioButton8;
        private System.Windows.Forms.RadioButton metroRadioButton16;
        private System.Windows.Forms.RadioButton metroRadioButton13;
        private System.Windows.Forms.RadioButton metroRadioButton5;
        private System.Windows.Forms.Button MetroButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Button MetroButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
    }
}


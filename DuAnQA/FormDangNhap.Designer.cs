namespace DuAnQA
{
    partial class FormDangNhap
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
            txtTenDN = new TextBox();
            txtMatKhau = new TextBox();
            panel2 = new Panel();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            chkHienMatKhau = new CheckBox();
            panel4 = new Panel();
            panel1 = new Panel();
            btnDangNhap = new RButton();
            lblThoat = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtTenDN
            // 
            txtTenDN.BorderStyle = BorderStyle.None;
            txtTenDN.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenDN.Location = new Point(211, 178);
            txtTenDN.Margin = new Padding(3, 4, 3, 4);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(285, 27);
            txtTenDN.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.None;
            txtMatKhau.Location = new Point(211, 259);
            txtMatKhau.Margin = new Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(285, 27);
            txtMatKhau.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleVioletRed;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 500);
            panel2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(38, 387);
            label5.Name = "label5";
            label5.Size = new Size(211, 30);
            label5.TabIndex = 1;
            label5.Text = "Huongie Clothes";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logomoi;
            pictureBox1.Location = new Point(21, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(253, 261);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(chkHienMatKhau);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(btnDangNhap);
            panel3.Controls.Add(lblThoat);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(txtMatKhau);
            panel3.Controls.Add(txtTenDN);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(300, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 500);
            panel3.TabIndex = 7;
            panel3.Paint += panel3_Paint;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkHienMatKhau.ForeColor = Color.DarkSlateGray;
            chkHienMatKhau.Location = new Point(314, 334);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(182, 29);
            chkHienMatKhau.TabIndex = 11;
            chkHienMatKhau.Text = "Ẩn/Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkSlateGray;
            panel4.ForeColor = Color.SlateGray;
            panel4.Location = new Point(211, 289);
            panel4.Name = "panel4";
            panel4.Size = new Size(280, 2);
            panel4.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Location = new Point(211, 211);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 2);
            panel1.TabIndex = 9;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.PaleVioletRed;
            btnDangNhap.BorderColor = null;
            btnDangNhap.BorderRadius = 30;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(175, 405);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(208, 41);
            btnDangNhap.TabIndex = 8;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click_1;
            // 
            // lblThoat
            // 
            lblThoat.AutoSize = true;
            lblThoat.ForeColor = Color.DarkSlateGray;
            lblThoat.Location = new Point(499, 9);
            lblThoat.Name = "lblThoat";
            lblThoat.Size = new Size(39, 28);
            lblThoat.TabIndex = 7;
            lblThoat.Text = "❌";
            lblThoat.Click += lblThoat_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.DarkSlateGray;
            label8.Location = new Point(56, 263);
            label8.Name = "label8";
            label8.Size = new Size(108, 28);
            label8.TabIndex = 6;
            label8.Text = "Mật khẩu : ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.DarkSlateGray;
            label7.Location = new Point(56, 185);
            label7.Name = "label7";
            label7.Size = new Size(149, 28);
            label7.TabIndex = 1;
            label7.Text = "Tên đăng nhập :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Century Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.PaleVioletRed;
            label6.Location = new Point(195, 89);
            label6.Name = "label6";
            label6.Size = new Size(147, 47);
            label6.TabIndex = 0;
            label6.Text = "LOGIN";
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(850, 500);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống đăng nhập";
            Load += FormDangNhap_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtTenDN;
        private TextBox txtMatKhau;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label5;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblThoat;
        private Panel panel1;
        private RButton btnDangNhap;
        private Panel panel4;
        private CheckBox chkHienMatKhau;
    }
}
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
            label2 = new Label();
            label3 = new Label();
            txtTenDN = new TextBox();
            txtMatKhau = new TextBox();
            label1 = new Label();
            btnDangNhap = new Button();
            linkQuenMK = new LinkLabel();
            linkDangKy = new LinkLabel();
            panel1 = new Panel();
            btnMat = new Button();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LavenderBlush;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkSlateGray;
            label2.Location = new Point(46, 130);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 1;
            label2.Text = "Tài khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LavenderBlush;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkSlateGray;
            label3.Location = new Point(46, 262);
            label3.Name = "label3";
            label3.Size = new Size(111, 30);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(46, 176);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(549, 31);
            txtTenDN.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(46, 307);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(549, 31);
            txtMatKhau.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(128, 49);
            label1.Name = "label1";
            label1.Size = new Size(450, 45);
            label1.TabIndex = 0;
            label1.Text = "Huongie clothes xin chào!";
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.LavenderBlush;
            btnDangNhap.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDangNhap.ForeColor = Color.Black;
            btnDangNhap.Location = new Point(296, 394);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(112, 34);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // linkQuenMK
            // 
            linkQuenMK.AutoSize = true;
            linkQuenMK.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            linkQuenMK.ForeColor = Color.DarkSlateGray;
            linkQuenMK.LinkColor = Color.DarkSlateGray;
            linkQuenMK.Location = new Point(55, 359);
            linkQuenMK.Name = "linkQuenMK";
            linkQuenMK.Size = new Size(147, 25);
            linkQuenMK.TabIndex = 2;
            linkQuenMK.TabStop = true;
            linkQuenMK.Text = "Quên mật khẩu?";
            linkQuenMK.LinkClicked += linkQuenMK_LinkClicked;
            // 
            // linkDangKy
            // 
            linkDangKy.AutoSize = true;
            linkDangKy.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            linkDangKy.LinkColor = Color.Black;
            linkDangKy.Location = new Point(414, 442);
            linkDangKy.Name = "linkDangKy";
            linkDangKy.Size = new Size(79, 25);
            linkDangKy.TabIndex = 3;
            linkDangKy.TabStop = true;
            linkDangKy.Text = "Đăng ký";
            linkDangKy.LinkClicked += linkDangKy_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtTenDN);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnMat);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(linkDangKy);
            panel1.Controls.Add(linkQuenMK);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDangNhap);
            panel1.Location = new Point(264, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(693, 501);
            panel1.TabIndex = 5;
            // 
            // btnMat
            // 
            btnMat.Location = new Point(601, 307);
            btnMat.Name = "btnMat";
            btnMat.Size = new Size(48, 34);
            btnMat.TabIndex = 5;
            btnMat.Text = "👁️";
            btnMat.UseVisualStyleBackColor = true;
            btnMat.Click += btnMat_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DarkSlateGray;
            label4.Location = new Point(209, 442);
            label4.Name = "label4";
            label4.Size = new Size(199, 25);
            label4.TabIndex = 4;
            label4.Text = "Bạn chưa có tài khoản ?";
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(panel1);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDangNhap";
            Load += FormDangNhap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtTenDN;
        private TextBox txtMatKhau;
        private Label label1;
        private Button btnDangNhap;
        private LinkLabel linkQuenMK;
        private LinkLabel linkDangKy;
        private Panel panel1;
        private Label label4;
        private Button btnMat;
    }
}
namespace DuAnQA
{
    partial class FormDangKy
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
            label1 = new Label();
            lblTenDN = new Label();
            lblMatKhau = new Label();
            lblEmail = new Label();
            txtTenDN = new TextBox();
            txtMatKhau = new TextBox();
            txtEmail = new TextBox();
            btnDangKy = new Button();
            btnQuayLai = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.SteelBlue;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(379, 44);
            label1.Name = "label1";
            label1.Size = new Size(360, 45);
            label1.TabIndex = 0;
            label1.Text = "Đăng Ký Tài Khoản";
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Location = new Point(67, 130);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(134, 25);
            lblTenDN.TabIndex = 1;
            lblTenDN.Text = "Tên đăng nhập ";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(67, 256);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(95, 25);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu :";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(67, 375);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 25);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email :";
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(67, 174);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(407, 31);
            txtTenDN.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(67, 294);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(407, 31);
            txtMatKhau.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(67, 414);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(407, 31);
            txtEmail.TabIndex = 8;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(89, 474);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(112, 34);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(362, 474);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(112, 34);
            btnQuayLai.TabIndex = 10;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(605, 174);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(387, 271);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1168, 541);
            Controls.Add(pictureBox1);
            Controls.Add(btnQuayLai);
            Controls.Add(label1);
            Controls.Add(lblTenDN);
            Controls.Add(btnDangKy);
            Controls.Add(txtEmail);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDN);
            Controls.Add(txtMatKhau);
            Controls.Add(lblEmail);
            Name = "FormDangKy";
            Text = "FormDangKy";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTenDN;
        private Label lblMatKhau;
        private Label lblEmail;
        private TextBox txtTenDN;
        private TextBox txtMatKhau;
        private TextBox txtEmail;
        private Button btnDangKy;
        private Button btnQuayLai;
        private PictureBox pictureBox1;
    }
}
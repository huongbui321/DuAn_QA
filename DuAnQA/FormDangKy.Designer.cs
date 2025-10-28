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
            lblHoTen = new Label();
            lblEmail = new Label();
            txtTenDN = new TextBox();
            txtMatKhau = new TextBox();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            btnDangKy = new Button();
            btnQuayLai = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(352, 28);
            label1.Name = "label1";
            label1.Size = new Size(169, 45);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ";
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Location = new Point(141, 94);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(138, 25);
            lblTenDN.TabIndex = 1;
            lblTenDN.Text = "Tên đăng nhập :";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(141, 166);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(95, 25);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu :";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(141, 237);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(75, 25);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ tên :";
            lblHoTen.Click += lblHoTen_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(141, 301);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 25);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email :";
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(364, 94);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(223, 31);
            txtTenDN.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(364, 166);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(223, 31);
            txtMatKhau.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(364, 237);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(223, 31);
            txtHoTen.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(364, 301);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(223, 31);
            txtEmail.TabIndex = 8;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(211, 385);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(112, 34);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(475, 383);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(112, 34);
            btnQuayLai.TabIndex = 10;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuayLai);
            Controls.Add(btnDangKy);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDN);
            Controls.Add(lblEmail);
            Controls.Add(lblHoTen);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTenDN);
            Controls.Add(label1);
            Name = "FormDangKy";
            Text = "FormDangKy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTenDN;
        private Label lblMatKhau;
        private Label lblHoTen;
        private Label lblEmail;
        private TextBox txtTenDN;
        private TextBox txtMatKhau;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private Button btnDangKy;
        private Button btnQuayLai;
    }
}
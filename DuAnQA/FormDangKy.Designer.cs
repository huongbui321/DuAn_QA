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
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(214, 11);
            label1.Name = "label1";
            label1.Size = new Size(169, 45);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ";
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Location = new Point(58, 75);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(138, 25);
            lblTenDN.TabIndex = 1;
            lblTenDN.Text = "Tên đăng nhập :";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(58, 141);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(95, 25);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu :";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(58, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 25);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email :";
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(281, 83);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(223, 31);
            txtTenDN.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(281, 149);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(223, 31);
            txtMatKhau.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(281, 220);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(223, 31);
            txtEmail.TabIndex = 8;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(128, 366);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(112, 34);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(392, 364);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(112, 34);
            btnQuayLai.TabIndex = 10;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnQuayLai);
            panel1.Controls.Add(lblTenDN);
            panel1.Controls.Add(btnDangKy);
            panel1.Controls.Add(lblMatKhau);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(txtTenDN);
            panel1.Location = new Point(285, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 430);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1168, 541);
            Controls.Add(panel1);
            Name = "FormDangKy";
            Text = "FormDangKy";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel1;
    }
}
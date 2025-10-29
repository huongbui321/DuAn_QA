namespace DuAnQA
{
    partial class FormQuenMK
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
            label2 = new Label();
            panel1 = new Panel();
            btnThoat = new Button();
            btnXacNhan = new Button();
            txtNLMK = new TextBox();
            txtMKmoi = new TextBox();
            txtEmail = new TextBox();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LavenderBlush;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(213, 45);
            label1.Name = "label1";
            label1.Size = new Size(227, 45);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 143);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 1;
            label2.Text = "Email :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(btnThoat);
            panel1.Controls.Add(btnXacNhan);
            panel1.Controls.Add(txtNLMK);
            panel1.Controls.Add(txtMKmoi);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(270, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 447);
            panel1.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(385, 348);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 34);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += button2_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(173, 348);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(112, 34);
            btnXacNhan.TabIndex = 9;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += button1_Click;
            // 
            // txtNLMK
            // 
            txtNLMK.Location = new Point(236, 281);
            txtNLMK.Name = "txtNLMK";
            txtNLMK.Size = new Size(367, 31);
            txtNLMK.TabIndex = 8;
            // 
            // txtMKmoi
            // 
            txtMKmoi.Location = new Point(236, 209);
            txtMKmoi.Name = "txtMKmoi";
            txtMKmoi.Size = new Size(367, 31);
            txtMKmoi.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(236, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(368, 31);
            txtEmail.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 287);
            label5.Name = "label5";
            label5.Size = new Size(165, 25);
            label5.TabIndex = 4;
            label5.Text = "Nhập lại mật khẩu: ";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 212);
            label4.Name = "label4";
            label4.Size = new Size(131, 25);
            label4.TabIndex = 3;
            label4.Text = "Mật khẩu mới :";
            // 
            // FormQuenMK
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1159, 572);
            Controls.Add(panel1);
            Name = "FormQuenMK";
            Text = "FormQuenMK";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtNLMK;
        private TextBox txtMKmoi;
        private Button btnThoat;
        private Button btnXacNhan;
    }
}
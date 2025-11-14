namespace DuAnQA
{
    partial class FormThanhToan
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
            picQR = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            txtOTP = new TextBox();
            btnXacNhan = new Button();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            label3 = new Label();
            lblTongTien = new Label();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // picQR
            // 
            picQR.Location = new Point(214, 92);
            picQR.Name = "picQR";
            picQR.Size = new Size(270, 270);
            picQR.SizeMode = PictureBoxSizeMode.CenterImage;
            picQR.TabIndex = 0;
            picQR.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.HotPink;
            label1.Location = new Point(238, 29);
            label1.Name = "label1";
            label1.Size = new Size(222, 45);
            label1.TabIndex = 1;
            label1.Text = "Thanh Toán";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 456);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 2;
            label2.Text = "Mã OTP : ";
            // 
            // txtOTP
            // 
            txtOTP.Location = new Point(337, 456);
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(167, 31);
            txtOTP.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(299, 519);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(114, 36);
            btnXacNhan.TabIndex = 4;
            btnXacNhan.Text = "  Xác nhận ";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // sqlCommandBuilder1
            // 
            sqlCommandBuilder1.DataAdapter = null;
            sqlCommandBuilder1.QuotePrefix = "[";
            sqlCommandBuilder1.QuoteSuffix = "]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(202, 384);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 5;
            label3.Text = "Tổng tiền :  ";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(337, 384);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(59, 25);
            lblTongTien.TabIndex = 6;
            lblTongTien.Text = "label4";
            // 
            // FormThanhToan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(712, 589);
            Controls.Add(lblTongTien);
            Controls.Add(label3);
            Controls.Add(btnXacNhan);
            Controls.Add(txtOTP);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picQR);
            Name = "FormThanhToan";
            Text = "FormThanhToan";
            Load += FormThanhToan_Load;
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picQR;
        private Label label1;
        private Label label2;
        private TextBox txtOTP;
        private Button btnXacNhan;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label label3;
        private Label lblTongTien;
    }
}
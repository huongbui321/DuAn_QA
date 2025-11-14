namespace DuAnQA
{
    partial class FormTTKH
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            btnXacNhan = new Button();
            dtpNgaySinh = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.HotPink;
            label1.Location = new Point(397, 54);
            label1.Name = "label1";
            label1.Size = new Size(419, 45);
            label1.TabIndex = 0;
            label1.Text = "Thông Tin Khách Hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(612, 188);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 1;
            label2.Text = "Họ và Tên : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(612, 269);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 2;
            label3.Text = "Ngày sinh :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(612, 350);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(612, 431);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 4;
            label5.Text = "Địa chỉ : ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.anh_thieplogo;
            pictureBox1.Location = new Point(124, 173);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(362, 309);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(749, 185);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(259, 31);
            txtHoTen.TabIndex = 6;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(749, 350);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(259, 31);
            txtSoDienThoai.TabIndex = 8;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(749, 431);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(259, 31);
            txtDiaChi.TabIndex = 9;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(545, 549);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(112, 34);
            btnXacNhan.TabIndex = 11;
            btnXacNhan.Text = "Xác Nhận ";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click_1;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(749, 269);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(259, 31);
            dtpNgaySinh.TabIndex = 12;
            // 
            // FormTTKH
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(dtpNgaySinh);
            Controls.Add(btnXacNhan);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtHoTen);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormTTKH";
            Text = "FormTTKH";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private TextBox txtDiaChi;
        private Button btnXacNhan;
        private DateTimePicker dtpNgaySinh;
    }
}
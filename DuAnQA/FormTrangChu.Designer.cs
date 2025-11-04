namespace DuAnQA
{
    partial class FormTrangChu
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
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            picGioHang = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            flowSanPham = new FlowLayoutPanel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGioHang).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(215, 132);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.goidienthoai;
            pictureBox4.Location = new Point(671, 19);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(47, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.email1;
            pictureBox3.Location = new Point(358, 21);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(724, 21);
            label3.Name = "label3";
            label3.Size = new Size(229, 25);
            label3.TabIndex = 7;
            label3.Text = "0856340155 - 0853350333";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 21);
            label2.Name = "label2";
            label2.Size = new Size(233, 25);
            label2.TabIndex = 6;
            label2.Text = "huongieclothes@gmail.com";
            // 
            // button1
            // 
            button1.Location = new Point(1016, 71);
            button1.Name = "button1";
            button1.Size = new Size(107, 34);
            button1.TabIndex = 5;
            button1.Text = "Đăng xuất";
            button1.UseVisualStyleBackColor = true;
            // 
            // picGioHang
            // 
            picGioHang.BorderStyle = BorderStyle.FixedSingle;
            picGioHang.Image = Properties.Resources.giohang;
            picGioHang.Location = new Point(906, 75);
            picGioHang.Name = "picGioHang";
            picGioHang.Size = new Size(47, 32);
            picGioHang.SizeMode = PictureBoxSizeMode.StretchImage;
            picGioHang.TabIndex = 4;
            picGioHang.TabStop = false;
            picGioHang.Click += picGioHang_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(377, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(508, 31);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 76);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 2;
            label1.Text = "Tìm Kiếm";
            // 
            // flowSanPham
            // 
            flowSanPham.AutoScroll = true;
            flowSanPham.Location = new Point(3, 144);
            flowSanPham.Name = "flowSanPham";
            flowSanPham.Size = new Size(1190, 424);
            flowSanPham.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(picGioHang);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1193, 135);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // FormTrangChu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(panel1);
            Controls.Add(flowSanPham);
            Name = "FormTrangChu";
            Text = "FormTrangChu";
            Load += FormTrangChu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGioHang).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox picGioHang;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private FlowLayoutPanel flowSanPham;
        private Panel panel1;
    }
}
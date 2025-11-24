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
            btnDangXuat = new Button();
            picGioHang = new PictureBox();
            txtTK = new TextBox();
            label1 = new Label();
            flowSanPham = new FlowLayoutPanel();
            panel1 = new Panel();
            btnMuaNhieu = new RButton();
            picLichSu = new PictureBox();
            btnTK = new Button();
            flpDanhMuc = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGioHang).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLichSu).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 163);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.goidienthoai;
            pictureBox4.Location = new Point(954, 29);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(47, 36);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.email1;
            pictureBox3.Location = new Point(596, 31);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1007, 31);
            label3.Name = "label3";
            label3.Size = new Size(229, 25);
            label3.TabIndex = 7;
            label3.Text = "0856340155 - 0853350333";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 31);
            label2.Name = "label2";
            label2.Size = new Size(233, 25);
            label2.TabIndex = 6;
            label2.Text = "huongieclothes@gmail.com";
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(55, 898);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(107, 34);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // picGioHang
            // 
            picGioHang.BorderStyle = BorderStyle.FixedSingle;
            picGioHang.Image = Properties.Resources.giohang;
            picGioHang.Location = new Point(1239, 85);
            picGioHang.Name = "picGioHang";
            picGioHang.Size = new Size(60, 35);
            picGioHang.SizeMode = PictureBoxSizeMode.StretchImage;
            picGioHang.TabIndex = 4;
            picGioHang.TabStop = false;
            picGioHang.Click += picGioHang_Click;
            // 
            // txtTK
            // 
            txtTK.Location = new Point(549, 87);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(576, 31);
            txtTK.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(401, 91);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 2;
            label1.Text = "Tìm Kiếm";
            label1.Click += label1_Click;
            // 
            // flowSanPham
            // 
            flowSanPham.AutoScroll = true;
            flowSanPham.Location = new Point(235, 172);
            flowSanPham.Name = "flowSanPham";
            flowSanPham.Size = new Size(1443, 772);
            flowSanPham.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnMuaNhieu);
            panel1.Controls.Add(picLichSu);
            panel1.Controls.Add(btnTK);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(picGioHang);
            panel1.Controls.Add(txtTK);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1678, 166);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // btnMuaNhieu
            // 
            btnMuaNhieu.BackColor = Color.PaleVioletRed;
            btnMuaNhieu.BorderColor = null;
            btnMuaNhieu.BorderRadius = 20;
            btnMuaNhieu.FlatAppearance.BorderSize = 0;
            btnMuaNhieu.FlatStyle = FlatStyle.Flat;
            btnMuaNhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnMuaNhieu.ForeColor = Color.White;
            btnMuaNhieu.Location = new Point(1520, 78);
            btnMuaNhieu.Name = "btnMuaNhieu";
            btnMuaNhieu.Size = new Size(146, 40);
            btnMuaNhieu.TabIndex = 12;
            btnMuaNhieu.Text = "Mua Ngay";
            btnMuaNhieu.UseVisualStyleBackColor = false;
            btnMuaNhieu.Click += btnMuaNhieu_Click;
            // 
            // picLichSu
            // 
            picLichSu.Image = Properties.Resources.iconLSDN;
            picLichSu.Location = new Point(1341, 85);
            picLichSu.Name = "picLichSu";
            picLichSu.Size = new Size(50, 34);
            picLichSu.SizeMode = PictureBoxSizeMode.StretchImage;
            picLichSu.TabIndex = 11;
            picLichSu.TabStop = false;
            picLichSu.Click += picLichSu_Click;
            // 
            // btnTK
            // 
            btnTK.Location = new Point(1149, 86);
            btnTK.Name = "btnTK";
            btnTK.Size = new Size(53, 34);
            btnTK.TabIndex = 10;
            btnTK.Text = "🔍";
            btnTK.UseVisualStyleBackColor = true;
            btnTK.Click += btnTK_Click;
            // 
            // flpDanhMuc
            // 
            flpDanhMuc.AutoScroll = true;
            flpDanhMuc.FlowDirection = FlowDirection.TopDown;
            flpDanhMuc.Location = new Point(0, 172);
            flpDanhMuc.Name = "flpDanhMuc";
            flpDanhMuc.Size = new Size(238, 720);
            flpDanhMuc.TabIndex = 4;
            flpDanhMuc.Paint += flpDanhMuc_Paint;
            // 
            // FormTrangChu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1678, 944);
            Controls.Add(btnDangXuat);
            Controls.Add(flpDanhMuc);
            Controls.Add(panel1);
            Controls.Add(flowSanPham);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTrangChu";
            Load += FormTrangChu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGioHang).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLichSu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox picGioHang;
        private TextBox txtTK;
        private Label label1;
        private Button btnDangXuat;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private FlowLayoutPanel flowSanPham;
        private Panel panel1;
        private Button btnTK;
        private FlowLayoutPanel flpDanhMuc;
        private PictureBox picLichSu;
        private RButton btnMuaNhieu;
    }
}
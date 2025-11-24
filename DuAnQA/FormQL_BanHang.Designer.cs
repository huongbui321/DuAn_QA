namespace DuAnQA
{
    partial class FormQL_BanHang
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
            pnMenu = new Panel();
            pictureBox1 = new PictureBox();
            btnDangXuat = new Button();
            btnThongKe = new Button();
            btnQLKho = new Button();
            btnQLTaiKhoan = new Button();
            btnQLDonHang = new Button();
            btnQLSanPham = new Button();
            pnHeader = new Panel();
            pnContent = new Panel();
            pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(353, 47);
            label1.Name = "label1";
            label1.Size = new Size(740, 55);
            label1.TabIndex = 0;
            label1.Text = "Trang quản trị Huongie Clothes 👗";
            label1.Click += label1_Click;
            // 
            // pnMenu
            // 
            pnMenu.BackColor = Color.Pink;
            pnMenu.Controls.Add(pictureBox1);
            pnMenu.Controls.Add(btnDangXuat);
            pnMenu.Controls.Add(btnThongKe);
            pnMenu.Controls.Add(btnQLKho);
            pnMenu.Controls.Add(btnQLTaiKhoan);
            pnMenu.Controls.Add(btnQLDonHang);
            pnMenu.Controls.Add(btnQLSanPham);
            pnMenu.Dock = DockStyle.Left;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(260, 944);
            pnMenu.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoFashionshop;
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 158);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(65, 883);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(110, 39);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(0, 510);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(260, 83);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "📊 Thống kê & Báo cáo";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnQLKho
            // 
            btnQLKho.Location = new Point(0, 424);
            btnQLKho.Name = "btnQLKho";
            btnQLKho.Size = new Size(260, 83);
            btnQLKho.TabIndex = 3;
            btnQLKho.Text = "📦 Quản lý Kho";
            btnQLKho.UseVisualStyleBackColor = true;
            btnQLKho.Click += btnQLKho_Click;
            // 
            // btnQLTaiKhoan
            // 
            btnQLTaiKhoan.Location = new Point(0, 338);
            btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            btnQLTaiKhoan.Size = new Size(260, 83);
            btnQLTaiKhoan.TabIndex = 2;
            btnQLTaiKhoan.Text = "👥 Quản lý Tài khoản";
            btnQLTaiKhoan.UseVisualStyleBackColor = true;
            btnQLTaiKhoan.Click += btnQLTaiKhoan_Click;
            // 
            // btnQLDonHang
            // 
            btnQLDonHang.Location = new Point(0, 252);
            btnQLDonHang.Name = "btnQLDonHang";
            btnQLDonHang.Size = new Size(260, 83);
            btnQLDonHang.TabIndex = 1;
            btnQLDonHang.Text = "\U0001f6d2 Quản lý Đơn hàng";
            btnQLDonHang.UseVisualStyleBackColor = true;
            btnQLDonHang.Click += btnQLDonHang_Click;
            // 
            // btnQLSanPham
            // 
            btnQLSanPham.Location = new Point(0, 166);
            btnQLSanPham.Name = "btnQLSanPham";
            btnQLSanPham.Size = new Size(260, 83);
            btnQLSanPham.TabIndex = 0;
            btnQLSanPham.Text = "👗 Quản lý Sản phẩm";
            btnQLSanPham.UseVisualStyleBackColor = true;
            btnQLSanPham.Click += btnQLSanPham_Click;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.LavenderBlush;
            pnHeader.Controls.Add(label1);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(260, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(1418, 166);
            pnHeader.TabIndex = 2;
            // 
            // pnContent
            // 
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(260, 166);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(1418, 778);
            pnContent.TabIndex = 3;
            // 
            // FormQL_BanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1678, 944);
            Controls.Add(pnContent);
            Controls.Add(pnHeader);
            Controls.Add(pnMenu);
            Name = "FormQL_BanHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormQL_BanHang";
            pnMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel pnMenu;
        private Panel pnHeader;
        private Panel pnContent;
        private Button btnQLSanPham;
        private PictureBox pictureBox1;
        private Button btnQLTaiKhoan;
        private Button btnQLDonHang;
        private Button btnThongKe;
        private Button btnQLKho;
        private Button btnDangXuat;
    }
}
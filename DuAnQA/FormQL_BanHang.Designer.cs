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
            btnDangXuat = new Button();
            btnThongKe = new Button();
            btnQLKho = new Button();
            btnQLTaiKhoan = new Button();
            btnQLDonHang = new Button();
            btnQLSanPham = new Button();
            pnHeader = new Panel();
            pnContent = new Panel();
            pictureBox1 = new PictureBox();
            pnMenu.SuspendLayout();
            pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(113, 48);
            label1.Name = "label1";
            label1.Size = new Size(740, 55);
            label1.TabIndex = 0;
            label1.Text = "Trang quản trị Huongie Clothes 👗";
            label1.Click += label1_Click;
            // 
            // pnMenu
            // 
            pnMenu.BackColor = Color.Pink;
            pnMenu.Controls.Add(btnDangXuat);
            pnMenu.Controls.Add(btnThongKe);
            pnMenu.Controls.Add(btnQLKho);
            pnMenu.Controls.Add(btnQLTaiKhoan);
            pnMenu.Controls.Add(btnQLDonHang);
            pnMenu.Controls.Add(btnQLSanPham);
            pnMenu.Location = new Point(0, 166);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(260, 506);
            pnMenu.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(73, 448);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(110, 39);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(0, 348);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(260, 83);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "📊 Thống kê & Báo cáo";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnQLKho
            // 
            btnQLKho.Location = new Point(0, 262);
            btnQLKho.Name = "btnQLKho";
            btnQLKho.Size = new Size(260, 83);
            btnQLKho.TabIndex = 3;
            btnQLKho.Text = "📦 Quản lý Kho";
            btnQLKho.UseVisualStyleBackColor = true;
            btnQLKho.Click += btnQLKho_Click;
            // 
            // btnQLTaiKhoan
            // 
            btnQLTaiKhoan.Location = new Point(0, 176);
            btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            btnQLTaiKhoan.Size = new Size(260, 83);
            btnQLTaiKhoan.TabIndex = 2;
            btnQLTaiKhoan.Text = "👥 Quản lý Tài khoản";
            btnQLTaiKhoan.UseVisualStyleBackColor = true;
            btnQLTaiKhoan.Click += btnQLTaiKhoan_Click;
            // 
            // btnQLDonHang
            // 
            btnQLDonHang.Location = new Point(0, 90);
            btnQLDonHang.Name = "btnQLDonHang";
            btnQLDonHang.Size = new Size(260, 83);
            btnQLDonHang.TabIndex = 1;
            btnQLDonHang.Text = "\U0001f6d2 Quản lý Đơn hàng";
            btnQLDonHang.UseVisualStyleBackColor = true;
            btnQLDonHang.Click += btnQLDonHang_Click;
            // 
            // btnQLSanPham
            // 
            btnQLSanPham.Location = new Point(0, 4);
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
            pnHeader.Location = new Point(266, 2);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(937, 166);
            pnHeader.TabIndex = 2;
            // 
            // pnContent
            // 
            pnContent.Location = new Point(266, 161);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(937, 503);
            pnContent.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoFashionshop;
            pictureBox1.Location = new Point(0, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 158);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // FormQL_BanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(pictureBox1);
            Controls.Add(pnContent);
            Controls.Add(pnHeader);
            Controls.Add(pnMenu);
            Name = "FormQL_BanHang";
            Text = "FormQL_BanHang";
            pnMenu.ResumeLayout(false);
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
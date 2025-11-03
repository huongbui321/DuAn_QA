namespace DuAnQA
{
    partial class FormChiTietSanPham
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
            picHinhAnh = new PictureBox();
            label1 = new Label();
            lblTenSP = new Label();
            lblGia = new Label();
            lblMoTa = new Label();
            lblSL = new Label();
            lblChonSize = new Label();
            cboSize = new ComboBox();
            numSoLuongMua = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnThemGioHang = new Button();
            btnMuaNgay = new Button();
            lblSoLuong = new Label();
            btnQuayLai = new Button();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongMua).BeginInit();
            SuspendLayout();
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(34, 131);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(359, 393);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(451, 33);
            label1.Name = "label1";
            label1.Size = new Size(402, 54);
            label1.TabIndex = 1;
            label1.Text = "Chi Tiết Sản Phẩm";
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(708, 131);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(58, 25);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "TenSP";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(708, 261);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(75, 25);
            lblGia.TabIndex = 3;
            lblGia.Text = "Đơn giá";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(708, 196);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(62, 25);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô Tả";
            // 
            // lblSL
            // 
            lblSL.AutoSize = true;
            lblSL.Location = new Point(923, 287);
            lblSL.Name = "lblSL";
            lblSL.Size = new Size(89, 25);
            lblSL.TabIndex = 5;
            lblSL.Text = "Số Lượng";
            // 
            // lblChonSize
            // 
            lblChonSize.AutoSize = true;
            lblChonSize.Location = new Point(509, 391);
            lblChonSize.Name = "lblChonSize";
            lblChonSize.Size = new Size(43, 25);
            lblChonSize.TabIndex = 6;
            lblChonSize.Text = "Size";
            // 
            // cboSize
            // 
            cboSize.FormattingEnabled = true;
            cboSize.Items.AddRange(new object[] { "S", "M", "L" });
            cboSize.Location = new Point(708, 391);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(304, 33);
            cboSize.TabIndex = 7;
            // 
            // numSoLuongMua
            // 
            numSoLuongMua.Location = new Point(708, 326);
            numSoLuongMua.Name = "numSoLuongMua";
            numSoLuongMua.Size = new Size(304, 31);
            numSoLuongMua.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(509, 131);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 9;
            label2.Text = "Tên Sản Phẩm :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(509, 196);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 10;
            label3.Text = "Mô Tả :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(509, 261);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 11;
            label4.Text = "Đơn giá :";
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.Location = new Point(509, 481);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(184, 34);
            btnThemGioHang.TabIndex = 12;
            btnThemGioHang.Text = "Thêm vào giỏ hàng";
            btnThemGioHang.UseVisualStyleBackColor = true;
            btnThemGioHang.Click += btnThemGioHang_Click;
            // 
            // btnMuaNgay
            // 
            btnMuaNgay.Location = new Point(771, 481);
            btnMuaNgay.Name = "btnMuaNgay";
            btnMuaNgay.Size = new Size(121, 34);
            btnMuaNgay.TabIndex = 13;
            btnMuaNgay.Text = "Mua ngay";
            btnMuaNgay.UseVisualStyleBackColor = true;
            btnMuaNgay.Click += btnMuaNgay_Click;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(509, 326);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(98, 25);
            lblSoLuong.TabIndex = 14;
            lblSoLuong.Text = "Số Lượng :";
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(971, 481);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(112, 34);
            btnQuayLai.TabIndex = 15;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += button1_Click;
            // 
            // FormChiTietSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1211, 591);
            Controls.Add(btnQuayLai);
            Controls.Add(lblSoLuong);
            Controls.Add(btnMuaNgay);
            Controls.Add(btnThemGioHang);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numSoLuongMua);
            Controls.Add(cboSize);
            Controls.Add(lblChonSize);
            Controls.Add(lblSL);
            Controls.Add(lblMoTa);
            Controls.Add(lblGia);
            Controls.Add(lblTenSP);
            Controls.Add(label1);
            Controls.Add(picHinhAnh);
            Name = "FormChiTietSanPham";
            Text = "FormChiTietSanPham";
            Load += FormChiTietSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongMua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picHinhAnh;
        private Label label1;
        private Label lblTenSP;
        private Label lblGia;
        private Label lblMoTa;
        private Label lblSL;
        private Label lblChonSize;
        private ComboBox cboSize;
        private NumericUpDown numSoLuongMua;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnThemGioHang;
        private Button btnMuaNgay;
        private Label lblSoLuong;
        private Button btnQuayLai;
    }
}
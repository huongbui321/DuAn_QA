namespace DuAnQA
{
    partial class UC_QuanLySanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            label8 = new Label();
            groupBox1 = new GroupBox();
            cbMaDanhMuc = new ComboBox();
            picHinhAnh = new PictureBox();
            label7 = new Label();
            txtSoLuong = new TextBox();
            txtMaSanPham = new TextBox();
            label4 = new Label();
            btnLuu = new Button();
            txtMoTa = new TextBox();
            label6 = new Label();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtDonGia = new TextBox();
            txtTenSanPham = new TextBox();
            txtHinhAnh = new TextBox();
            btnChonAnh = new Button();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvSanPham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvSanPham);
            splitContainer1.Size = new Size(1418, 778);
            splitContainer1.SplitterDistance = 423;
            splitContainer1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(550, 22);
            label8.Name = "label8";
            label8.Size = new Size(328, 45);
            label8.TabIndex = 1;
            label8.Text = "Quản lý sản phẩm";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbMaDanhMuc);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(txtMaSanPham);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtDonGia);
            groupBox1.Controls.Add(txtTenSanPham);
            groupBox1.Controls.Add(txtHinhAnh);
            groupBox1.Controls.Add(btnChonAnh);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1354, 294);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cbMaDanhMuc
            // 
            cbMaDanhMuc.FormattingEnabled = true;
            cbMaDanhMuc.Location = new Point(164, 226);
            cbMaDanhMuc.Name = "cbMaDanhMuc";
            cbMaDanhMuc.Size = new Size(220, 33);
            cbMaDanhMuc.TabIndex = 25;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(1081, 47);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(202, 189);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 6;
            picHinhAnh.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 226);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 24;
            label7.Text = "Danh mục :";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(164, 185);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(220, 31);
            txtSoLuong.TabIndex = 23;
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Location = new Point(164, 64);
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.Size = new Size(220, 31);
            txtMaSanPham.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 64);
            label4.Name = "label4";
            label4.Size = new Size(129, 25);
            label4.TabIndex = 21;
            label4.Text = "Mã sản phẩm :";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(949, 226);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 34);
            btnLuu.TabIndex = 20;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click_1;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(717, 53);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(259, 65);
            txtMoTa.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(638, 64);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 16;
            label6.Text = "Mô tả : ";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(839, 226);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 34);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click_1;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(729, 226);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 34);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click_1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(619, 226);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 34);
            btnSua.TabIndex = 13;
            btnSua.Text = "  Sửa ";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click_1;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(509, 226);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 34);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(164, 144);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(220, 31);
            txtDonGia.TabIndex = 9;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(164, 103);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(220, 31);
            txtTenSanPham.TabIndex = 8;
            // 
            // txtHinhAnh
            // 
            txtHinhAnh.Location = new Point(717, 165);
            txtHinhAnh.Name = "txtHinhAnh";
            txtHinhAnh.Size = new Size(153, 31);
            txtHinhAnh.TabIndex = 7;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(876, 162);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(100, 34);
            btnChonAnh.TabIndex = 5;
            btnChonAnh.Text = "Chọn ảnh ";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(638, 168);
            label5.Name = "label5";
            label5.Size = new Size(53, 25);
            label5.TabIndex = 4;
            label5.Text = "Ảnh :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 187);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 2;
            label3.Text = "Số lượng :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 146);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 1;
            label2.Text = "Đơn giá :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 105);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên sản phẩm :";
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(0, 0);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.RowTemplate.Height = 33;
            dgvSanPham.Size = new Size(1418, 351);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellClick += dgvSanPham_CellContentClick;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            // 
            // UC_QuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "UC_QuanLySanPham";
            Size = new Size(1418, 778);
            Load += UC_QuanLySanPham_Load_1;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label3;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private TextBox txtDonGia;
        private TextBox txtTenSanPham;
        private TextBox txtHinhAnh;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtMoTa;
        private Label label6;
        private GroupBox groupBox1;
        private TextBox txtMaSanPham;
        private Label label4;
        private Button btnLuu;
        private TextBox txtSoLuong;
        private ComboBox cbMaDanhMuc;
        private Label label7;
        private DataGridView dgvSanPham;
        private Label label8;
    }
}

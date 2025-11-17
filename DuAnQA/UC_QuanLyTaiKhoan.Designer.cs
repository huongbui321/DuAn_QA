namespace DuAnQA
{
    partial class UC_QuanLyTaiKhoan
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
            dgvTaiKhoan = new DataGridView();
            txtTimKiem = new TextBox();
            groupBox1 = new GroupBox();
            cboTrangThai = new ComboBox();
            cboVaiTro = new ComboBox();
            txtDiaChi = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtTenDangNhap = new TextBox();
            txtHoTen = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnLuu = new Button();
            btnThem = new Button();
            label8 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label9 = new Label();
            groupBox2 = new GroupBox();
            btnSua = new Button();
            btnX = new Button();
            btnLM = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new Point(22, 108);
            dgvTaiKhoan.Margin = new Padding(3, 4, 3, 4);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.RowTemplate.Height = 24;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new Size(482, 245);
            dgvTaiKhoan.TabIndex = 12;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellContentClick;
            dgvTaiKhoan.CellContentClick += dgvTaiKhoan_CellContentClick;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.Location = new Point(118, 52);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(346, 31);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AliceBlue;
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(cboVaiTro);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(3, 77);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(393, 363);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(130, 325);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(200, 33);
            cboTrangThai.TabIndex = 6;
            // 
            // cboVaiTro
            // 
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(130, 280);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(200, 33);
            cboVaiTro.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(130, 235);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(200, 31);
            txtDiaChi.TabIndex = 4;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(130, 190);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(200, 31);
            txtSoDienThoai.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(130, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 31);
            txtEmail.TabIndex = 2;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(130, 100);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 31);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(130, 55);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 31);
            txtHoTen.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 328);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 6;
            label7.Text = "Trạng Thái:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 283);
            label6.Name = "label6";
            label6.Size = new Size(68, 25);
            label6.TabIndex = 5;
            label6.Text = "Vai Trò:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 238);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 4;
            label5.Text = "Địa Chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 193);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 3;
            label4.Text = "Sdt :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 148);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 103);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên ĐN :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 58);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ và Tên:";
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLuu.Location = new Point(639, 446);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(72, 37);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnThem.Location = new Point(200, 443);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(72, 37);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(24, 55);
            label8.Name = "label8";
            label8.Size = new Size(88, 25);
            label8.TabIndex = 13;
            label8.Text = "Tìm kiếm:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.DimGray;
            label9.Location = new Point(334, 21);
            label9.Name = "label9";
            label9.Size = new Size(299, 41);
            label9.TabIndex = 14;
            label9.Text = "Quản lý Tài khoản";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(dgvTaiKhoan);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(402, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(532, 363);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(304, 444);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(72, 37);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnX
            // 
            btnX.Location = new Point(408, 444);
            btnX.Name = "btnX";
            btnX.Size = new Size(72, 37);
            btnX.TabIndex = 16;
            btnX.Text = "Xóa";
            btnX.UseVisualStyleBackColor = true;
            btnX.Click += btnX_Click;
            // 
            // btnLM
            // 
            btnLM.Location = new Point(507, 445);
            btnLM.Name = "btnLM";
            btnLM.Size = new Size(96, 36);
            btnLM.TabIndex = 17;
            btnLM.Text = "Làm mới";
            btnLM.UseVisualStyleBackColor = true;
            btnLM.Click += btnLM_Click;
            // 
            // UC_QuanLyTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnLM);
            Controls.Add(btnX);
            Controls.Add(btnSua);
            Controls.Add(groupBox2);
            Controls.Add(label9);
            Controls.Add(btnThem);
            Controls.Add(btnLuu);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_QuanLyTaiKhoan";
            Size = new Size(952, 506);
            Load += UC_QuanLyTaiKhoan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Khai báo các control
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label8;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label9;
        private GroupBox groupBox2;
        private Button btnSua;
        private Button btnX;
        private Button btnLM;
    }
}
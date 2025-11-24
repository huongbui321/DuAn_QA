namespace DuAnQA
{
    partial class UC_QuanLyKho
    {
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
            dgvKhoHang = new DataGridView();
            txtTimKiemSP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnNhapKho = new RButton();
            btnXuatKho = new RButton();
            ((System.ComponentModel.ISupportInitialize)dgvKhoHang).BeginInit();
            SuspendLayout();
            // 
            // dgvKhoHang
            // 
            dgvKhoHang.AllowUserToAddRows = false;
            dgvKhoHang.AllowUserToDeleteRows = false;
            dgvKhoHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoHang.Location = new Point(34, 175);
            dgvKhoHang.Margin = new Padding(3, 4, 3, 4);
            dgvKhoHang.Name = "dgvKhoHang";
            dgvKhoHang.ReadOnly = true;
            dgvKhoHang.RowHeadersWidth = 51;
            dgvKhoHang.RowTemplate.Height = 24;
            dgvKhoHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoHang.Size = new Size(1327, 528);
            dgvKhoHang.TabIndex = 4;
            dgvKhoHang.CellClick += dgvKhoHang_CellClick;
            dgvKhoHang.CellContentClick += dgvKhoHang_CellClick;
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.Location = new Point(510, 113);
            txtTimKiemSP.Margin = new Padding(3, 4, 3, 4);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.Size = new Size(475, 31);
            txtTimKiemSP.TabIndex = 1;
            txtTimKiemSP.TextChanged += txtTimKiemSP_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(394, 116);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(621, 31);
            label2.Name = "label2";
            label2.Size = new Size(251, 45);
            label2.TabIndex = 5;
            label2.Text = "Quản Lý Kho";
            // 
            // btnNhapKho
            // 
            btnNhapKho.BackColor = Color.LightPink;
            btnNhapKho.BorderColor = null;
            btnNhapKho.BorderRadius = 40;
            btnNhapKho.FlatAppearance.BorderSize = 0;
            btnNhapKho.FlatStyle = FlatStyle.Flat;
            btnNhapKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhapKho.ForeColor = Color.Black;
            btnNhapKho.Location = new Point(526, 717);
            btnNhapKho.Name = "btnNhapKho";
            btnNhapKho.Size = new Size(177, 47);
            btnNhapKho.TabIndex = 6;
            btnNhapKho.Text = "Nhập kho";
            btnNhapKho.UseVisualStyleBackColor = false;
            // 
            // btnXuatKho
            // 
            btnXuatKho.BackColor = Color.Pink;
            btnXuatKho.BorderColor = null;
            btnXuatKho.BorderRadius = 40;
            btnXuatKho.FlatAppearance.BorderSize = 0;
            btnXuatKho.FlatStyle = FlatStyle.Flat;
            btnXuatKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatKho.ForeColor = Color.Black;
            btnXuatKho.Location = new Point(784, 717);
            btnXuatKho.Name = "btnXuatKho";
            btnXuatKho.Size = new Size(177, 47);
            btnXuatKho.TabIndex = 7;
            btnXuatKho.Text = "Xuất kho";
            btnXuatKho.UseVisualStyleBackColor = false;
            // 
            // UC_QuanLyKho
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnXuatKho);
            Controls.Add(btnNhapKho);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTimKiemSP);
            Controls.Add(dgvKhoHang);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_QuanLyKho";
            Size = new Size(1418, 778);
            Load += UC_QuanLyKho_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhoHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoHang;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private RButton btnNhapKho;
        private RButton btnXuatKho;
    }
}
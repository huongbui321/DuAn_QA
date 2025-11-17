namespace DuAnQA
{
    partial class UC_QuanLyDonHang
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
            dgvDonHang = new DataGridView();
            dgvChiTiet = new DataGridView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDonHang
            // 
            dgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonHang.Location = new Point(15, 30);
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.RowHeadersWidth = 62;
            dgvDonHang.RowTemplate.Height = 33;
            dgvDonHang.Size = new Size(845, 173);
            dgvDonHang.TabIndex = 0;
            dgvDonHang.CellClick += dgvDonHang_CellContentClick;
            dgvDonHang.CellContentClick += dgvDonHang_CellContentClick;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(15, 30);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.RowTemplate.Height = 33;
            dgvChiTiet.Size = new Size(845, 161);
            dgvChiTiet.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(316, 20);
            label1.Name = "label1";
            label1.Size = new Size(295, 41);
            label1.TabIndex = 2;
            label1.Text = "Quản lý Đơn hàng";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDonHang);
            groupBox1.Location = new Point(28, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(875, 209);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách Đơn hàng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvChiTiet);
            groupBox2.Location = new Point(28, 293);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(875, 197);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết Đơn hàng";
            // 
            // UC_QuanLyDonHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "UC_QuanLyDonHang";
            Size = new Size(937, 490);
            Load += UC_QuanLyDonHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDonHang;
        private DataGridView dgvChiTiet;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}

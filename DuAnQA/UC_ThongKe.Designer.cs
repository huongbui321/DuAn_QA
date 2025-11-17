namespace DuAnQA
{
    partial class UC_ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            lblTongDoanhThu = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblTongDonHang = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTongKhachHang = new Label();
            label5 = new Label();
            panel4 = new Panel();
            lblTongTonKho = new Label();
            label7 = new Label();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartTrangThai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvTopSanPham = new DataGridView();
            dgvTopKhachHang = new DataGridView();
            btnXuatExcel = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTrangThai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopKhachHang).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 192);
            panel1.Controls.Add(lblTongDoanhThu);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(54, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 69);
            panel1.TabIndex = 0;
           // panel1.Paint += this.panel1_Paint;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongDoanhThu.Location = new Point(10, 40);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(169, 31);
            lblTongDoanhThu.TabIndex = 1;
            lblTongDoanhThu.Text = "0 VNĐ";
            lblTongDoanhThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 30);
            label1.TabIndex = 0;
            label1.Text = "Tổng Doanh Thu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 192);
            panel2.Controls.Add(lblTongDonHang);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(271, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(193, 69);
            panel2.TabIndex = 1;
           // panel2.Paint += this.panel2_Paint;
            // 
            // lblTongDonHang
            // 
            lblTongDonHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongDonHang.Location = new Point(13, 37);
            lblTongDonHang.Name = "lblTongDonHang";
            lblTongDonHang.Size = new Size(159, 31);
            lblTongDonHang.TabIndex = 1;
            lblTongDonHang.Text = "0";
            lblTongDonHang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 10);
            label3.Name = "label3";
            label3.Size = new Size(162, 30);
            label3.TabIndex = 0;
            label3.Text = "Tổng Đơn Hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(192, 255, 255);
            panel3.Controls.Add(lblTongKhachHang);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(488, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(193, 69);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // lblTongKhachHang
            // 
            lblTongKhachHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongKhachHang.Location = new Point(10, 40);
            lblTongKhachHang.Name = "lblTongKhachHang";
            lblTongKhachHang.Size = new Size(179, 28);
            lblTongKhachHang.TabIndex = 1;
            lblTongKhachHang.Text = "0";
            lblTongKhachHang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(10, 9);
            label5.Name = "label5";
            label5.Size = new Size(179, 30);
            label5.TabIndex = 0;
            label5.Text = "Tổng Khách Hàng";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 224, 192);
            panel4.Controls.Add(lblTongTonKho);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(705, 77);
            panel4.Name = "panel4";
            panel4.Size = new Size(193, 69);
            panel4.TabIndex = 3;
            panel4.Paint += panel4_Paint;
            // 
            // lblTongTonKho
            // 
            lblTongTonKho.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTonKho.Location = new Point(13, 37);
            lblTongTonKho.Name = "lblTongTonKho";
            lblTongTonKho.Size = new Size(180, 31);
            lblTongTonKho.TabIndex = 1;
            lblTongTonKho.Text = "0";
            lblTongTonKho.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(28, 7);
            label7.Name = "label7";
            label7.Size = new Size(143, 30);
            label7.TabIndex = 0;
            label7.Text = "Tổng Tồn Kho";
            // 
            // chartDoanhThu
            // 
            chartArea9.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend9);
            chartDoanhThu.Location = new Point(71, 24);
            chartDoanhThu.Name = "chartDoanhThu";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            chartDoanhThu.Series.Add(series9);
            chartDoanhThu.Size = new Size(297, 162);
            chartDoanhThu.TabIndex = 4;
            chartDoanhThu.Text = "Biểu đồ Doanh thu";
            // 
            // chartTrangThai
            // 
            chartArea10.Name = "ChartArea1";
            chartTrangThai.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            chartTrangThai.Legends.Add(legend10);
            chartTrangThai.Location = new Point(515, 24);
            chartTrangThai.Name = "chartTrangThai";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            chartTrangThai.Series.Add(series10);
            chartTrangThai.Size = new Size(297, 162);
            chartTrangThai.TabIndex = 5;
            chartTrangThai.Text = "Biểu đồ Trạng thái";
            // 
            // dgvTopSanPham
            // 
            dgvTopSanPham.AllowUserToAddRows = false;
            dgvTopSanPham.AllowUserToDeleteRows = false;
            dgvTopSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopSanPham.Dock = DockStyle.Fill;
            dgvTopSanPham.Location = new Point(3, 27);
            dgvTopSanPham.Name = "dgvTopSanPham";
            dgvTopSanPham.ReadOnly = true;
            dgvTopSanPham.RowHeadersWidth = 51;
            dgvTopSanPham.RowTemplate.Height = 29;
            dgvTopSanPham.Size = new Size(423, 91);
            dgvTopSanPham.TabIndex = 6;
            // 
            // dgvTopKhachHang
            // 
            dgvTopKhachHang.AllowUserToAddRows = false;
            dgvTopKhachHang.AllowUserToDeleteRows = false;
            dgvTopKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopKhachHang.Dock = DockStyle.Fill;
            dgvTopKhachHang.Location = new Point(3, 27);
            dgvTopKhachHang.Name = "dgvTopKhachHang";
            dgvTopKhachHang.ReadOnly = true;
            dgvTopKhachHang.RowHeadersWidth = 51;
            dgvTopKhachHang.RowTemplate.Height = 29;
            dgvTopKhachHang.Size = new Size(423, 91);
            dgvTopKhachHang.TabIndex = 7;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatExcel.Location = new Point(374, 110);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(135, 60);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "Xuất Báo Cáo Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chartDoanhThu);
            groupBox1.Controls.Add(chartTrangThai);
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Location = new Point(44, 183);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(866, 192);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Doanh thu 7 ngày qua";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvTopSanPham);
            groupBox2.Location = new Point(44, 382);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(429, 121);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Top 5 sản phẩm bán chạy ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvTopKhachHang);
            groupBox3.Location = new Point(485, 382);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(429, 121);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top 5 KH chi nhiều";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(321, 21);
            label2.Name = "label2";
            label2.Size = new Size(312, 41);
            label2.TabIndex = 15;
            label2.Text = "Thống kê - Báo cáo";
            // 
            // UC_ThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(label2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_ThongKe";
            Size = new Size(937, 503);
            Load += UC_ThongKe_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTrangThai).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopKhachHang).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Khai báo các control
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTongDonHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTongKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTongTonKho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrangThai;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
        private System.Windows.Forms.DataGridView dgvTopKhachHang;
        private System.Windows.Forms.Button btnXuatExcel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label2;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // <-- Thư viện Biểu đồ
using OfficeOpenXml; // <-- Thư viện EPPlus (Excel)
using OfficeOpenXml.Style;

namespace DuAnQA
{
    public partial class UC_ThongKe : UserControl
    {
        KetNoi kn = new KetNoi();

        // Tạo các biến để lưu dữ liệu, dùng cho việc Xuất Excel
        private DataTable dtTopSanPham;
        private DataTable dtTopKhachHang;
        private DataTable dtDoanhThu;
        public UC_ThongKe()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                // Tải 4 chức năng
                LoadKPIs();
                LoadChartDoanhThu();
                LoadChartTrangThai();
                LoadTopLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tổng thể khi tải Dashboard: " + ex.Message);
            }
        }
        private void LoadKPIs()
        {
            try
            {
                // 1. Tổng Doanh Thu (Chỉ đơn "Đã thanh toán")
                string queryDT = "SELECT SUM(TongTien) FROM DonHang WHERE TrangThai = N'Đã thanh toán'";
                DataTable dtDT = kn.LayDuLieu(queryDT);
                if (dtDT.Rows.Count > 0 && dtDT.Rows[0][0] != DBNull.Value)
                {
                    lblTongDoanhThu.Text = Convert.ToDecimal(dtDT.Rows[0][0]).ToString("N0") + " VNĐ";
                }
                else
                {
                    lblTongDoanhThu.Text = "0 VNĐ";
                }

                // 2. Tổng Đơn Hàng (Tất cả)
                string queryDH = "SELECT COUNT(*) FROM DonHang";
                DataTable dtDH = kn.LayDuLieu(queryDH);
                lblTongDonHang.Text = dtDH.Rows[0][0].ToString();

                // 3. Tổng Khách Hàng (Chỉ vai trò Khách hàng)
                string queryKH = "SELECT COUNT(*) FROM NguoiDung WHERE VaiTro = N'Khách hàng'";
                DataTable dtKH = kn.LayDuLieu(queryKH);
                lblTongKhachHang.Text = dtKH.Rows[0][0].ToString();

                // 4. Tổng Tồn Kho
                string queryKho = "SELECT SUM(SoLuong) FROM SanPham";
                DataTable dtKho = kn.LayDuLieu(queryKho);
                if (dtKho.Rows.Count > 0 && dtKho.Rows[0][0] != DBNull.Value)
                {
                    lblTongTonKho.Text = Convert.ToInt32(dtKho.Rows[0][0]).ToString("N0");
                }
                else
                {
                    lblTongTonKho.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải KPIs: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadChartDoanhThu()
        {
            try
            {
                // <<< SỬA QUERY: Dùng CTE để tạo 7 ngày gần nhất >>>
                // Query này sẽ luôn trả về 7 dòng, kể cả ngày đó doanh thu = 0
                string query = @"
            ;WITH Last7Days(Ngay) AS 
            (
                -- 1. Lấy ngày hôm nay
                SELECT CONVERT(date, GETDATE())
                UNION ALL
                -- 2. Đệ quy để lấy 6 ngày trước đó
                SELECT DATEADD(day, -1, Ngay)
                FROM Last7Days
                WHERE Ngay > DATEADD(day, -6, CONVERT(date, GETDATE()))
            ),
            DoanhThuTheoNgay AS
            (
                -- 3. Tính doanh thu (chỉ đơn 'Đã thanh toán')
                SELECT 
                    CONVERT(date, NgayDat) AS Ngay, 
                    SUM(TongTien) AS DoanhThu
                FROM DonHang
                WHERE TrangThai = N'Đã thanh toán'
                GROUP BY CONVERT(date, NgayDat)
            )
            -- 4. LEFT JOIN 7 ngày với doanh thu
            SELECT 
                L7D.Ngay,
                ISNULL(DT.DoanhThu, 0) AS DoanhThu  -- Nếu ngày đó không có doanh thu, trả về 0
            FROM Last7Days AS L7D
            LEFT JOIN DoanhThuTheoNgay AS DT ON L7D.Ngay = DT.Ngay
            ORDER BY L7D.Ngay;
        ";

                // Lưu lại để xuất Excel (nếu bạn cần)
                dtDoanhThu = kn.LayDuLieu(query);

                chartDoanhThu.Series.Clear();
                Series series = chartDoanhThu.Series.Add("Doanh thu");

                // <<< Đổi thành Column (Biểu đồ Cột) >>>
                series.ChartType = SeriesChartType.Column;
                series.XValueType = ChartValueType.Date;

                // Tắt gạch chéo khi giá trị = 0
                series.EmptyPointStyle.Color = Color.Transparent;

                foreach (DataRow row in dtDoanhThu.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                    series.Points.AddXY(ngay, doanhThu);
                }

                // Tùy chỉnh hiển thị
                chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                chartDoanhThu.Legends[0].Enabled = false; // Ẩn chú thích
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- CHỨC NĂNG 4: BIỂU ĐỒ TRÒN TRẠNG THÁI ---
        private void LoadChartTrangThai()
        {
            try
            {
                string query = "SELECT TrangThai, COUNT(*) AS SoLuong FROM DonHang GROUP BY TrangThai";
                DataTable dt = kn.LayDuLieu(query);

                chartTrangThai.Series.Clear();
                Series series = chartTrangThai.Series.Add("Trạng thái");
                series.ChartType = SeriesChartType.Pie; // Biểu đồ Dạng Tròn

                foreach (DataRow row in dt.Rows)
                {
                    string trangThai = row["TrangThai"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuong"]);

                    // Thêm một "miếng bánh"
                    DataPoint dp = new DataPoint(0, soLuong);
                    dp.LegendText = $"{trangThai} ({soLuong})"; // Chú thích
                    dp.Label = $"{soLuong}"; // Hiển thị số trên miếng bánh
                    series.Points.Add(dp);
                }
                chartTrangThai.Legends[0].Docking = Docking.Bottom; // Đưa chú thích xuống dưới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải biểu đồ trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CHỨC NĂNG 3: TẢI DANH SÁCH TOP 5 ---
        private void LoadTopLists()
        {
            try
            {
                // Top 5 Sản phẩm bán chạy
                string queryTopSP = @"
                    SELECT TOP 5 
                        T2.TenSanPham, 
                        SUM(T1.SoLuong) AS TongSoLuongBan
                    FROM ChiTietDonHang AS T1
                    JOIN SanPham AS T2 ON T1.MaSanPham = T2.MaSanPham
                    GROUP BY T2.TenSanPham
                    ORDER BY TongSoLuongBan DESC";

                dtTopSanPham = kn.LayDuLieu(queryTopSP); // Lưu lại
                dgvTopSanPham.DataSource = dtTopSanPham;
                dgvTopSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgvTopSanPham.Columns["TongSoLuongBan"].HeaderText = "Đã Bán";
                dgvTopSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Top 5 Khách hàng chi nhiều
                string queryTopKH = @"
                    SELECT TOP 5 
                        T2.HoTen, 
                        SUM(T1.TongTien) AS TongChiTieu
                    FROM DonHang AS T1
                    JOIN NguoiDung AS T2 ON T1.MaNguoiDung = T2.MaNguoiDung
                    WHERE T1.TrangThai = N'Đã thanh toán'
                    GROUP BY T2.HoTen
                    ORDER BY TongChiTieu DESC";

                dtTopKhachHang = kn.LayDuLieu(queryTopKH); // Lưu lại
                dgvTopKhachHang.DataSource = dtTopKhachHang;
                dgvTopKhachHang.Columns["HoTen"].HeaderText = "Tên Khách Hàng";
                dgvTopKhachHang.Columns["TongChiTieu"].HeaderText = "Tổng Chi Tiêu";
                dgvTopKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
                dgvTopKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Top Lists: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở hộp thoại Lưu file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = $"BaoCao_HuongieClothes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        // --- Sheet 1: KPIs ---
                        var wsKPI = package.Workbook.Worksheets.Add("KPIs Tổng Quan");
                        wsKPI.Cells["A1"].Value = "BÁO CÁO TỔNG QUAN HUONGIE CLOTHES";
                        wsKPI.Cells["A1:C1"].Merge = true;
                        wsKPI.Cells["A1"].Style.Font.Bold = true;
                        wsKPI.Cells["A1"].Style.Font.Size = 16;

                        wsKPI.Cells["A3"].Value = "Tổng Doanh Thu";
                        wsKPI.Cells["B3"].Value = lblTongDoanhThu.Text;
                        wsKPI.Cells["A4"].Value = "Tổng Đơn Hàng";
                        wsKPI.Cells["B4"].Value = lblTongDonHang.Text;
                        wsKPI.Cells["A5"].Value = "Tổng Khách Hàng";
                        wsKPI.Cells["B5"].Value = lblTongKhachHang.Text;
                        wsKPI.Cells["A6"].Value = "Tổng Tồn Kho";
                        wsKPI.Cells["B6"].Value = lblTongTonKho.Text;
                        wsKPI.Cells["A3:A6"].Style.Font.Bold = true;
                        wsKPI.Cells["A3:B6"].AutoFitColumns();

                        // --- Sheet 2: Doanh thu 7 ngày ---
                        if (dtDoanhThu != null && dtDoanhThu.Rows.Count > 0)
                        {
                            var wsDoanhThu = package.Workbook.Worksheets.Add("Doanh thu 7 ngày");
                            wsDoanhThu.Cells["A1"].LoadFromDataTable(dtDoanhThu, true);
                            wsDoanhThu.Cells[2, 1, dtDoanhThu.Rows.Count + 1, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                            wsDoanhThu.Cells[2, 2, dtDoanhThu.Rows.Count + 1, 2].Style.Numberformat.Format = "#,##0";
                            wsDoanhThu.Cells["A1:B1"].Style.Font.Bold = true;
                            wsDoanhThu.Cells["A1:B" + (dtDoanhThu.Rows.Count + 1)].AutoFitColumns();
                        }

                        // --- Sheet 3: Top Sản phẩm ---
                        if (dtTopSanPham != null && dtTopSanPham.Rows.Count > 0)
                        {
                            var wsTopSP = package.Workbook.Worksheets.Add("Top Sản Phẩm");
                            wsTopSP.Cells["A1"].LoadFromDataTable(dtTopSanPham, true);
                            wsTopSP.Cells["A1:B1"].Style.Font.Bold = true;
                            wsTopSP.Cells["A1:B" + (dtTopSanPham.Rows.Count + 1)].AutoFitColumns();
                        }

                        // --- Sheet 4: Top Khách hàng ---
                        if (dtTopKhachHang != null && dtTopKhachHang.Rows.Count > 0)
                        {
                            var wsTopKH = package.Workbook.Worksheets.Add("Top Khách Hàng");
                            wsTopKH.Cells["A1"].LoadFromDataTable(dtTopKhachHang, true);
                            wsTopKH.Cells[2, 2, dtTopKhachHang.Rows.Count + 1, 2].Style.Numberformat.Format = "#,##0";
                            wsTopKH.Cells["A1:B1"].Style.Font.Bold = true;
                            wsTopKH.Cells["A1:B" + (dtTopKhachHang.Rows.Count + 1)].AutoFitColumns();
                        }

                        // --- Lưu file ---
                        FileInfo file = new FileInfo(saveDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

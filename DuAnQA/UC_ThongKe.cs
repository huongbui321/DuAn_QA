using OfficeOpenXml; // <-- Thư viện EPPlus (Excel)
using OfficeOpenXml.Style;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
        private void TaoHeaderCongTy(ExcelWorksheet ws, string tieuDeBaoCao)
        {
            // Tên công ty
            ws.Cells["A1:E1"].Merge = true;
            ws.Cells["A1"].Value = "CỬA HÀNG THỜI TRANG HUONGIE CLOTHES";
            ws.Cells["A1"].Style.Font.Size = 14;
            ws.Cells["A1"].Style.Font.Bold = true;
            ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Địa chỉ
            ws.Cells["A2:E2"].Merge = true;
            ws.Cells["A2"].Value = "Địa chỉ: Hà Nội - Hotline: 0856.340.155";
            ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Tiêu đề báo cáo
            ws.Cells["A4:E4"].Merge = true;
            ws.Cells["A4"].Value = tieuDeBaoCao.ToUpper();
            ws.Cells["A4"].Style.Font.Size = 16;
            ws.Cells["A4"].Style.Font.Bold = true;
            ws.Cells["A4"].Style.Font.Color.SetColor(Color.Blue);
            ws.Cells["A4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Ngày tháng
            ws.Cells["A5:E5"].Merge = true;
            ws.Cells["A5"].Value = $"(Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm})";
            ws.Cells["A5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A5"].Style.Font.Italic = true;
        }

        // Hàm 2: Tạo Chữ Ký (Dùng chung)
        private void TaoChuKy(ExcelWorksheet ws, int startRow)
        {
            // Người lập
            ws.Cells[startRow, 1, startRow, 2].Merge = true;
            ws.Cells[startRow, 1].Value = "Người lập biểu";
            ws.Cells[startRow, 1].Style.Font.Bold = true;
            ws.Cells[startRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Giám đốc
            ws.Cells[startRow, 4, startRow, 5].Merge = true;
            ws.Cells[startRow, 4].Value = "Quản lý";
            ws.Cells[startRow, 4].Style.Font.Bold = true;
            ws.Cells[startRow, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Ký tên (cách ra 4 dòng)
            int signPlace = startRow + 4;
            ws.Cells[signPlace, 1, signPlace, 2].Merge = true;
            ws.Cells[signPlace, 1].Value = "(Ký, họ tên)";
            ws.Cells[signPlace, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[signPlace, 4, signPlace, 5].Merge = true;
            ws.Cells[signPlace, 4].Value = "(Ký, đóng dấu)";
            ws.Cells[signPlace, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        // Hàm 3: Tự động tạo Sheet từ DataTable (Header + Table + Footer)
        private void TaoSheetBaoCao(ExcelWorksheet ws, DataTable dt, string title)
        {
            // 1. Tạo Header
            TaoHeaderCongTy(ws, title);

            // 2. Đổ dữ liệu
            int startRow = 7;
            if (dt.Rows.Count > 0)
            {
                // Load dữ liệu
                ws.Cells["A" + startRow].LoadFromDataTable(dt, true);

                // Format tiêu đề bảng (dòng đầu tiên của bảng)
                int colCount = dt.Columns.Count;
                using (var range = ws.Cells[startRow, 1, startRow, colCount])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Kẻ khung viền cho toàn bộ bảng
                int endRow = startRow + dt.Rows.Count;
                using (var range = ws.Cells[startRow, 1, endRow, colCount])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // 3. Tạo Chữ ký ở dưới cùng
                TaoChuKy(ws, endRow + 3);
            }
            else
            {
                ws.Cells["A7"].Value = "Không có dữ liệu.";
            }
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FileName = $"BaoCao_TongHop_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var package = new ExcelPackage())
                    {
                        // ==========================================================
                        // SHEET 1: BÁO CÁO TỔNG HỢP (DASHBOARD) - MỚI THÊM
                        // ==========================================================
                        var wsTongHop = package.Workbook.Worksheets.Add("Báo Cáo Tổng Hợp");

                        // 1. Header Công Ty
                        TaoHeaderCongTy(wsTongHop, "BÁO CÁO TỔNG HỢP TÌNH HÌNH KINH DOANH");

                        // 2. Khu vực KPIs (Trình bày ngang)
                        int rowKPI = 7;
                        // Tiêu đề cột
                        wsTongHop.Cells[rowKPI, 1].Value = "DOANH THU";
                        wsTongHop.Cells[rowKPI, 2].Value = "ĐƠN HÀNG";
                        wsTongHop.Cells[rowKPI, 3].Value = "KHÁCH HÀNG";
                        wsTongHop.Cells[rowKPI, 4].Value = "TỒN KHO";

                        // Style tiêu đề
                        using (var range = wsTongHop.Cells[rowKPI, 1, rowKPI, 4])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                            range.Style.Font.Color.SetColor(Color.White);
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        // Giá trị
                        rowKPI++;
                        wsTongHop.Cells[rowKPI, 1].Value = lblTongDoanhThu.Text;
                        wsTongHop.Cells[rowKPI, 2].Value = lblTongDonHang.Text;
                        wsTongHop.Cells[rowKPI, 3].Value = lblTongKhachHang.Text;
                        wsTongHop.Cells[rowKPI, 4].Value = lblTongTonKho.Text;

                        // Style giá trị
                        using (var range = wsTongHop.Cells[rowKPI, 1, rowKPI, 4])
                        {
                            range.Style.Font.Size = 14;
                            range.Style.Font.Bold = true;
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                        }
                        wsTongHop.Cells[1, 1, rowKPI, 4].AutoFitColumns(); // Giãn cột cho đẹp

                        // 3. Hai bảng Top nằm cạnh nhau
                        int rowTable = rowKPI + 3;

                        // --- Bảng bên Trái: Top Sản Phẩm ---
                        wsTongHop.Cells[rowTable, 1].Value = "TOP SẢN PHẨM BÁN CHẠY";
                        wsTongHop.Cells[rowTable, 1, rowTable, 2].Merge = true;
                        wsTongHop.Cells[rowTable, 1].Style.Font.Bold = true;
                        wsTongHop.Cells[rowTable, 1].Style.Font.Color.SetColor(Color.Red);

                        if (dtTopSanPham != null && dtTopSanPham.Rows.Count > 0)
                        {
                            // Đổ dữ liệu vào ô A(rowTable+1)
                            wsTongHop.Cells[rowTable + 1, 1].LoadFromDataTable(dtTopSanPham, true);
                            // Kẻ khung
                            int endRowSP = rowTable + 1 + dtTopSanPham.Rows.Count;
                            using (var range = wsTongHop.Cells[rowTable + 1, 1, endRowSP, 2])
                            {
                                range.AutoFitColumns();
                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }
                        }

                        // --- Bảng bên Phải: Top Khách Hàng ---
                        // Đặt tại cột D (Cột 4)
                        wsTongHop.Cells[rowTable, 4].Value = "TOP KHÁCH HÀNG VIP";
                        wsTongHop.Cells[rowTable, 4, rowTable, 5].Merge = true;
                        wsTongHop.Cells[rowTable, 4].Style.Font.Bold = true;
                        wsTongHop.Cells[rowTable, 4].Style.Font.Color.SetColor(Color.Red);

                        if (dtTopKhachHang != null && dtTopKhachHang.Rows.Count > 0)
                        {
                            // Đổ dữ liệu vào ô D(rowTable+1)
                            wsTongHop.Cells[rowTable + 1, 4].LoadFromDataTable(dtTopKhachHang, true);

                            // Format tiền
                            int endRowKH = rowTable + 1 + dtTopKhachHang.Rows.Count;
                            wsTongHop.Cells[rowTable + 2, 5, endRowKH, 5].Style.Numberformat.Format = "#,##0 \"VNĐ\"";

                            // Kẻ khung
                            using (var range = wsTongHop.Cells[rowTable + 1, 4, endRowKH, 5])
                            {
                                range.AutoFitColumns();
                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }
                        }

                        // Chữ ký cho sheet tổng hợp
                        TaoChuKy(wsTongHop, rowTable + 10);


                        // ==========================================================
                        // CÁC SHEET CHI TIẾT (GIỮ NGUYÊN NHƯ CŨ)
                        // ==========================================================

                        // Sheet 2: Doanh thu 7 ngày
                        if (dtDoanhThu != null && dtDoanhThu.Rows.Count > 0)
                        {
                            var ws = package.Workbook.Worksheets.Add("Chi Tiết Doanh Thu");
                            TaoSheetBaoCao(ws, dtDoanhThu, "CHI TIẾT DOANH THU 7 NGÀY");
                            int lastRow = dtDoanhThu.Rows.Count + 7;
                            ws.Cells[8, 1, lastRow, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                            ws.Cells[8, 2, lastRow, 2].Style.Numberformat.Format = "#,##0 \"VNĐ\"";
                            ws.Cells.AutoFitColumns();
                        }

                        // Sheet 3: Top Sản Phẩm (Chi tiết)
                        if (dtTopSanPham != null)
                        {
                            var ws = package.Workbook.Worksheets.Add("Chi Tiết Sản Phẩm");
                            TaoSheetBaoCao(ws, dtTopSanPham, "THỐNG KÊ SẢN PHẨM BÁN CHẠY");
                            ws.Cells.AutoFitColumns();
                        }

                        // Sheet 4: Top Khách Hàng (Chi tiết)
                        if (dtTopKhachHang != null)
                        {
                            var ws = package.Workbook.Worksheets.Add("Chi Tiết Khách Hàng");
                            TaoSheetBaoCao(ws, dtTopKhachHang, "THỐNG KÊ KHÁCH HÀNG");
                            int lastRow = dtTopKhachHang.Rows.Count + 7;
                            ws.Cells[8, 2, lastRow, 2].Style.Numberformat.Format = "#,##0 \"VNĐ\"";
                            ws.Cells.AutoFitColumns();
                        }

                        // --- LƯU FILE ---
                        FileInfo file = new FileInfo(saveDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Xuất báo cáo tổng hợp thành công!\n" + file.FullName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

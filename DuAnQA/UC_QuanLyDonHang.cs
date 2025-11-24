using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class UC_QuanLyDonHang : UserControl
    {
        private KetNoi kn = new KetNoi();
        public UC_QuanLyDonHang()
        {
            InitializeComponent();
        }

        private void UC_QuanLyDonHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachDonHang();
        }
        private void LoadDanhSachDonHang()
        {
            try
            {
                // Giả sử tên bảng của bạn là DonHang
                string query = "SELECT MaDonHang, NgayDat, MaNguoiDung, TongTien, TrangThai FROM DonHang ORDER BY NgayDat DESC";
                DataTable dt = kn.LayDuLieu(query);
                dgvDonHang.DataSource = dt;

                // Tùy chỉnh tên cột (nếu bạn muốn)
                dgvDonHang.Columns["MaDonHang"].HeaderText = "Mã ĐH";
                dgvDonHang.Columns["NgayDat"].HeaderText = "Ngày Đặt";
                dgvDonHang.Columns["MaNguoiDung"].HeaderText = "Mã NV";
                dgvDonHang.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvDonHang.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy MaDonHang từ dòng được chọn
                    DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                    // Giả sử MaDonHang là kiểu int, nếu là string thì .ToString()
                    int maDH = Convert.ToInt32(row.Cells["MaDonHang"].Value);

                    // Tải chi tiết của đơn hàng đó vào lưới dgvChiTiet
                    LoadChiTietDonHang(maDH);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LoadChiTietDonHang(int maDonHang)
        {
            try
            {
                // (Query JOIN 4 bảng của bạn giữ nguyên)
                string query = @"
            SELECT 
                T4.HoTen,
                T2.TenSanPham, 
                T1.SoLuong, 
                T1.DonGia,
                T2.MoTa
            FROM ChiTietDonHang AS T1
            JOIN SanPham AS T2 ON T1.MaSanPham = T2.MaSanPham
            JOIN DonHang AS T3 ON T1.MaDonHang = T3.MaDonHang
            JOIN NguoiDung AS T4 ON T3.MaNguoiDung = T4.MaNguoiDung
            WHERE T1.MaDonHang = @MaDH";

                SqlParameter[] parameters = {
            new SqlParameter("@MaDH", maDonHang)
        };

                DataTable dt = kn.LayDuLieu(query, parameters);
                dgvChiTiet.DataSource = dt;

                // <<< PHẦN LÀM ĐẸP (Thêm code này vào) >>>

                // 1. Đặt tên tiêu đề (Header)
                dgvChiTiet.Columns["HoTen"].HeaderText = "Tên NV";
                dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên SP";
                dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvChiTiet.Columns["MoTa"].HeaderText = "Mô Tả";

                // 2. Căn lề
                // Căn giữa cho cột "Số Lượng"
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Căn phải cho cột "Đơn Giá"
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 3. Định dạng số
                // Hiển thị 550,000 thay vì 550000,00
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                // 4. Tự động co giãn cột
                // Chế độ "Fill" sẽ tự lấp đầy toàn bộ chiều rộng của lưới
                dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 5. Điều chỉnh tỉ lệ (Tùy chọn, nhưng nên có)
                // Cho cột "Số Lượng" và "Đơn Giá" nhỏ lại
                dgvChiTiet.Columns["SoLuong"].FillWeight = 50; // (Mặc định là 100)
                dgvChiTiet.Columns["DonGia"].FillWeight = 80;
                // Cho cột "Mô Tả" và "Tên Khách Hàng" rộng ra
                dgvChiTiet.Columns["HoTen"].FillWeight = 100;
                dgvChiTiet.Columns["TenSanPham"].FillWeight = 120;
                dgvChiTiet.Columns["MoTa"].FillWeight = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
   

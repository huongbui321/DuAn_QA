using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace DuAnQA
{
    public partial class UC_QuanLyKho : UserControl
    {
        KetNoi kn = new KetNoi();
        private DataTable originalDataTable; // Biến lưu dữ liệu gốc để lọc

        // Biến lưu sản phẩm đang chọn
        private string selectedMaSP = ""; // Lưu Mã SP đang chọn
        private int currentSoLuong = 0;   // Lưu Số lượng đang chọn
        public UC_QuanLyKho()
        {
            InitializeComponent();
        }

        private void UC_QuanLyKho_Load(object sender, EventArgs e)
        {
            LoadDataKho();

            // Vô hiệu hóa nút khi chưa chọn sản phẩm
            btnNhapKho.Enabled = false;
            btnXuatKho.Enabled = false;
        }
        private void LoadDataKho()
        {
            try
            {
                // 1. Sửa câu query để lấy thêm cột NgayCapNhat
                string query = "SELECT MaSanPham, TenSanPham, SoLuong, NgayCapNhat FROM SanPham";
                originalDataTable = kn.LayDuLieu(query);
                dgvKhoHang.DataSource = originalDataTable;

                // --- TÙY CHỈNH LƯỚI ---
                dgvKhoHang.Columns["MaSanPham"].HeaderText = "Mã SP";
                dgvKhoHang.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgvKhoHang.Columns["SoLuong"].HeaderText = "Số Lượng Tồn";

                // 2. Thêm cột mới
                dgvKhoHang.Columns["NgayCapNhat"].HeaderText = "Lần Cập Nhật Cuối";

                // Tự động co giãn
                dgvKhoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 3. Căn lề và định dạng
                dgvKhoHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKhoHang.Columns["SoLuong"].DefaultCellStyle.Format = "N0"; // Hiển thị số (ví dụ: 1,000)

                // 4. Thêm định dạng ngày giờ
                dgvKhoHang.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // 5. Điều chỉnh tỉ lệ
                dgvKhoHang.Columns["MaSanPham"].FillWeight = 50;
                dgvKhoHang.Columns["TenSanPham"].FillWeight = 130;
                dgvKhoHang.Columns["SoLuong"].FillWeight = 100;
                dgvKhoHang.Columns["NgayCapNhat"].FillWeight = 100; // Thêm size cho cột mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = txtTimKiemSP.Text.Trim();

                if (string.IsNullOrEmpty(filter))
                {
                    originalDataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Lọc theo Tên Sản Phẩm
                    originalDataTable.DefaultView.RowFilter = $"TenSanPham LIKE '%{filter}%'";
                }
            }
            catch (Exception) { /* Bỏ qua lỗi gõ ký tự đặc biệt */ }
        }

        // --- SỰ KIỆN BẤM VÀO LƯỚI ---
        private void dgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo bấm vào dòng hợp lệ
            {
                try
                {
                    DataGridViewRow row = dgvKhoHang.Rows[e.RowIndex];

                    // Lấy thông tin của dòng được chọn
                    selectedMaSP = row.Cells["MaSanPham"].Value.ToString();
                    currentSoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    // Bật 2 nút lên
                    btnNhapKho.Enabled = true;
                    btnXuatKho.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn sản phẩm: " + ex.Message);
                    // Nếu lỗi thì tắt nút đi
                    btnNhapKho.Enabled = false;
                    btnXuatKho.Enabled = false;
                    selectedMaSP = "";
                }
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaSP)) return;

            // 1. Hỏi số lượng
            string input = Interaction.InputBox("Nhập số lượng cần thêm vào kho:", "Nhập kho", "10");

            // 2. Kiểm tra
            if (int.TryParse(input, out int soLuongNhap) && soLuongNhap > 0)
            {
                try
                {
                    // 3. Cập nhật CSDL (ĐÃ THÊM NgayCapNhat = GETDATE())
                    string query = "UPDATE SanPham SET SoLuong = SoLuong + @SoLuongNhap, NgayCapNhat = GETDATE() WHERE MaSanPham = @MaSP";
                    SqlParameter[] parameters = {
                new SqlParameter("@SoLuongNhap", soLuongNhap),
                new SqlParameter("@MaSP", selectedMaSP)
            };
                    kn.ThucThi(query, parameters);

                    MessageBox.Show("Nhập kho thành công!", "Thông báo");
                    LoadDataKho(); // Tải lại lưới

                    // Tắt nút đi sau khi xong
                    btnNhapKho.Enabled = false;
                    btnXuatKho.Enabled = false;
                    selectedMaSP = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nhập kho: " + ex.Message, "Lỗi");
                }
            }
            else if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập một số dương hợp lệ.", "Lỗi");
            }

        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaSP)) return;

            // 1. Hỏi số lượng
            string input = Interaction.InputBox($"Nhập số lượng cần xuất (tồn kho hiện tại: {currentSoLuong})", "Xuất kho", "1");

            // 2. Kiểm tra
            if (int.TryParse(input, out int soLuongXuat) && soLuongXuat > 0)
            {
                // 2a. Kiểm tra tồn kho
                if (soLuongXuat > currentSoLuong)
                {
                    MessageBox.Show($"Không thể xuất {soLuongXuat} sản phẩm. Tồn kho chỉ còn {currentSoLuong}.", "Lỗi");
                    return;
                }

                try
                {
                    // 3. Cập nhật CSDL (ĐÃ THÊM NgayCapNhat = GETDATE())
                    string query = "UPDATE SanPham SET SoLuong = SoLuong - @SoLuongXuat, NgayCapNhat = GETDATE() WHERE MaSanPham = @MaSP";
                    SqlParameter[] parameters = {
                new SqlParameter("@SoLuongXuat", soLuongXuat),
                new SqlParameter("@MaSP", selectedMaSP)
            };
                    kn.ThucThi(query, parameters);

                    MessageBox.Show("Xuất kho thành công!", "Thông báo");
                    LoadDataKho(); // Tải lại lưới

                    // Tắt nút đi sau khi xong
                    btnNhapKho.Enabled = false;
                    btnXuatKho.Enabled = false;
                    selectedMaSP = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất kho: " + ex.Message, "Lỗi");
                }
            }
            else if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập một số dương hợp lệ.", "Lỗi");
            }
        }
    }
}

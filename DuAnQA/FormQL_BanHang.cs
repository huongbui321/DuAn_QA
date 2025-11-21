using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class FormQL_BanHang : Form
    {
        public FormQL_BanHang()
        {
            InitializeComponent();
        }

        // === SỰ KIỆN LOAD FORM ===
        private void FormQL_BanHang_Load(object sender, EventArgs e)
        {
            string vaiTro = StaticData.VaiTroHienTai;

            // 2. Kiểm tra và Ẩn/Hiện các nút dựa trên vai trò
            if (vaiTro == "NhanVien")
            {
                // --- NHÂN VIÊN ---
                // Được phép: Bán hàng (Sản phẩm), Xem đơn hàng
                btnQLSanPham.Visible = true;
                btnQLDonHang.Visible = true;

                // Bị cấm: Quản lý nhân sự, Kho, Thống kê tiền nong
                btnQLTaiKhoan.Visible = false;
                btnQLKho.Visible = false;      // (Tùy bạn: có thể cho xem nhưng không cho nhập xuất)
                btnThongKe.Visible = false;
            }
            else
            {
                // --- ADMIN ---
                // Được phép tất cả
                btnQLSanPham.Visible = true;
                btnQLDonHang.Visible = true;
                btnQLTaiKhoan.Visible = true;
                btnQLKho.Visible = true;
                btnThongKe.Visible = true;
            }
           
        }

        // === HÀM DÙNG CHUNG ĐỂ TẢI USER CONTROL ===
        private void LoadUserControl(UserControl uc)
        {
            // (Giả sử panel nội dung màu xanh của bạn tên là pnContent)
            // Nếu nó có tên khác, hãy đổi chữ 'pnContent'
            pnContent.BackgroundImage = null;

            // 2. Xóa control cũ và thêm mới
            pnContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnContent.Controls.Add(uc);
        }

        // ===================================================
        // === CÁC HÀM SỰ KIỆN CLICK (MÀ BẠN BỊ THIẾU) ===
        // ===================================================

        // === NÚT 1 ===
        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            // (Thêm code đổi màu nút tại đây nếu muốn)
            UC_QuanLySanPham uc = new UC_QuanLySanPham();
            LoadUserControl(uc);
        }

        // === NÚT 2 ===
        private void btnQLDonHang_Click(object sender, EventArgs e)
        {
            UC_QuanLyDonHang uc = new UC_QuanLyDonHang();
            LoadUserControl(uc);
        }

        // === NÚT 3 ===
        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            UC_QuanLyTaiKhoan uc = new UC_QuanLyTaiKhoan();
            LoadUserControl(uc);

        }

        // === NÚT 4 ===
        private void btnQLKho_Click(object sender, EventArgs e)
        {
            UC_QuanLyKho uc = new UC_QuanLyKho();
            LoadUserControl(uc);
        }

        // === NÚT 5 ===
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UC_ThongKe uc = new UC_ThongKe();
            LoadUserControl(uc);
        }

        // === NÚT ĐĂNG XUẤT ===
        // (Giả sử nút của bạn tên là btnDangXuat)
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StaticData.MaNguoiDungHienTai = 0; // Reset admin
                this.Close(); // Đóng form này, FormDangNhap sẽ tự hiện lại
            }
        }

        // (Hàm label1_Click cũ của bạn không cần thiết nữa,
        // nhưng nếu nó vẫn còn trong file Designer, bạn có thể để trống ở đây)
        private void label1_Click(object sender, EventArgs e)
        {
            // Có thể xóa hàm này
        }
    }
}
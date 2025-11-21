using Microsoft.Data.SqlClient;
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
    public partial class FormDangNhap : Form
    {
        // Khai báo kết nối ở đây để có thể dùng trong 'finally'
        KetNoi kn = new KetNoi();
        bool hienMatKhau = false; // Biến lưu trạng thái

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        // ==================== LOGIC ĐĂNG NHẬP (ĐÃ SỬA) ====================


        // ==================== CÁC NÚT KHÁC ====================

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy fDangKy = new FormDangKy();
            fDangKy.Show();
            this.Hide();
            fDangKy.FormClosed += (s, args) => this.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDN == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 1. KIỂM TRA ADMIN CỨNG (Hardcode - Theo yêu cầu của bạn) ---
            // Nếu đăng nhập bằng "admin" và mật khẩu "1" -> Vào thẳng trang quản trị
            if (tenDN.Equals("admin", StringComparison.OrdinalIgnoreCase) && matKhau == "1")
            {
                MessageBox.Show("Đăng nhập thành công (Quản trị viên)!");

                // Lưu thông tin giả lập cho admin
                StaticData.MaNguoiDungHienTai = 1; // Giả sử ID admin là 1
                StaticData.TenNguoiDungHienTai = "Admin Hệ Thống";
                StaticData.VaiTroHienTai = "Admin";

                this.Hide();
                FormQL_BanHang f_admin = new FormQL_BanHang();
                f_admin.ShowDialog(); // Mở trang Quản lý

                // Khi form Admin đóng lại thì chạy tiếp dòng dưới
                txtMatKhau.Clear();
                this.Show();
                return; // Dừng hàm, không chạy xuống dưới nữa
            }

            // --- 2. KIỂM TRA TÀI KHOẢN NHÂN VIÊN TRONG CSDL ---
            SqlDataReader dr = null;
            try
            {
                kn.MoKetNoi();
                // Lấy thêm cột VaiTro để biết đường chuyển hướng
                string sql = "SELECT MaNguoiDung, TenDangNhap, VaiTro FROM NguoiDung WHERE TenDangNhap=@user AND MatKhau=@pass AND TrangThai=N'Hoạt động'";

                SqlCommand cmd = new SqlCommand(sql, kn.conn);
                cmd.Parameters.AddWithValue("@user", tenDN);
                cmd.Parameters.AddWithValue("@pass", matKhau);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Lưu thông tin vào biến toàn cục
                    StaticData.MaNguoiDungHienTai = Convert.ToInt32(dr["MaNguoiDung"]);
                    StaticData.TenNguoiDungHienTai = dr["TenDangNhap"].ToString();
                    string vaiTro = dr["VaiTro"].ToString();
                    StaticData.VaiTroHienTai = vaiTro;

                    MessageBox.Show($"Xin chào {vaiTro}: {StaticData.TenNguoiDungHienTai}!");
                    this.Hide();

                    // --- PHÂN LUỒNG CHUYỂN HƯỚNG ---
                    if (vaiTro == "Admin")
                    {
                        // Nếu trong DB vai trò là Admin -> Mở trang Quản lý
                        FormQL_BanHang f = new FormQL_BanHang();
                        f.ShowDialog();
                    }
                    else
                    {
                        // Nếu là Nhân viên (hoặc bất kỳ vai trò nào khác) -> Mở trang Bán hàng (TrangChu)
                        FormTrangChu f = new FormTrangChu();
                        f.ShowDialog();
                    }

                    // Khi form kia đóng lại thì hiện lại form đăng nhập
                    txtMatKhau.Clear();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập, mật khẩu hoặc tài khoản đã bị khóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                kn.DongKetNoi();
            }
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                // Nếu ô được tích -> Hiện mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu bỏ tích -> Ẩn mật khẩu (hiện dấu chấm tròn)
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
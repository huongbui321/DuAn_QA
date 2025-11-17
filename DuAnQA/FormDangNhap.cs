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
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDN == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!" , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tenDN.Equals("admin", StringComparison.OrdinalIgnoreCase) && matKhau == "1")
            {
                // Thông báo đăng nhập thành công (tùy chọn)
                MessageBox.Show("Đăng nhập thành công với tư cách Quản trị viên!");

                // Ẩn form đăng nhập hiện tại
                this.Hide();

                // Khởi tạo và hiển thị FormQL_BanHang
                FormQL_BanHang f_admin = new FormQL_BanHang();
                f_admin.ShowDialog(); // Hiển thị form admin và chờ cho đến khi nó được đóng

                // Sau khi form admin đóng, xóa mật khẩu và hiển thị lại form đăng nhập
                txtMatKhau.Clear();
                this.Show();

                // Dừng thực thi hàm để không chạy code đăng nhập của người dùng thường
                return;
            }

            SqlDataReader dr = null;
            try
            {
                kn.MoKetNoi();
                SqlCommand cmd = new SqlCommand("SELECT MaNguoiDung, TenDangNhap FROM NguoiDung WHERE TenDangNhap=@user AND MatKhau=@pass", kn.conn);
                cmd.Parameters.AddWithValue("@user", tenDN);
                cmd.Parameters.AddWithValue("@pass", matKhau);

                dr = cmd.ExecuteReader();

                if (dr.Read()) // Nếu tìm thấy (Đúng)
                {
                    // Lưu thông tin người dùng
                    StaticData.MaNguoiDungHienTai = Convert.ToInt32(dr["MaNguoiDung"]);
                    StaticData.TenNguoiDungHienTai = dr["TenDangNhap"].ToString();

                    MessageBox.Show("Đăng nhập thành công!");

                    dr.Close();
                    kn.DongKetNoi();
                    this.Hide();
                    FormTrangChu kh = new FormTrangChu();
                    kh.ShowDialog();

                    txtMatKhau.Clear(); // Xóa mật khẩu cũ
                    this.Show(); 
                }
                else // Nếu không tìm thấy (Sai)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo Reader và Kết nối LUÔN ĐƯỢC ĐÓNG
                dr?.Close();
                kn.DongKetNoi();
            }
        }

        // ==================== CÁC NÚT KHÁC ====================

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMat_Click(object sender, EventArgs e)
        {
            // (Đã gộp 2 hàm btnMat_Click_1 và btnMat_Click)
            if (hienMatKhau)
            {
                txtMatKhau.UseSystemPasswordChar = true;
                btnMat.Text = "👁"; // đổi icon về mắt thường
                hienMatKhau = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = false;
                btnMat.Text = "🙈"; // đổi icon sang mắt nhắm
                hienMatKhau = true;
            }
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // (Đã gộp 2 hàm linkQuenMK_LinkClicked_1 và linkQuenMK_LinkClicked)
            FormQuenMK fQuenMK = new FormQuenMK();
            fQuenMK.Show();
            this.Hide();
            fQuenMK.FormClosed += (s, args) => this.Show();
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy fDangKy = new FormDangKy();
            fDangKy.Show();
            this.Hide();
            fDangKy.FormClosed += (s, args) => this.Show();
        }
    }
}
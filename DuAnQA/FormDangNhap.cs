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
        public FormDangNhap()
        {
            InitializeComponent();

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDN == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Trường hợp đặc biệt: nếu là admin / mật khẩu '1' → mở FormQL_BanHang
            if (tenDN.Equals("admin", StringComparison.OrdinalIgnoreCase) && matKhau == "1")
            {
                // kiểm tra trong DB nếu cần (ví dụ admin phải tồn tại trong DB)
                FormQL_BanHang fAdmin = new FormQL_BanHang();
                fAdmin.Show();
                this.Hide();
                return;
            }

            // Ngược lại: kiểm tra tài khoản trong DB
            try
            {
                KetNoi kn = new KetNoi();
                kn.MoKetNoi();

                SqlCommand cmd = new SqlCommand("SELECT * FROM NguoiDung WHERE TenDangNhap=@user AND MatKhau=@pass", kn.conn);
                cmd.Parameters.AddWithValue("@user", txtTenDN.Text);
                cmd.Parameters.AddWithValue("@pass", txtMatKhau.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    FormTrangChu kh = new FormTrangChu();
                    kh.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }

                kn.DongKetNoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool hienMatKhau = false; // Biến lưu trạng thái

        private void btnMat_Click(object sender, EventArgs e)
        {
            // Nếu đang hiển thị mật khẩu → ẩn đi
            if (hienMatKhau)
            {
                txtMatKhau.UseSystemPasswordChar = true;
                btnMat.Text = "👁"; // đổi icon về mắt thường
                hienMatKhau = false;
            }
            else // Nếu đang ẩn → hiện mật khẩu
            {
                txtMatKhau.UseSystemPasswordChar = false;
                btnMat.Text = "🙈"; // đổi icon sang mắt nhắm (hoặc chữ khác nếu bạn thích)
                hienMatKhau = true;
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }
        private void linkQuenMK_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMK fQuenMK = new FormQuenMK(); // Tạo form quên mật khẩu
            fQuenMK.Show();                        // Hiển thị form quên mật khẩu
            this.Hide();
            fQuenMK.FormClosed += (s, args) => this.Show();
        }

        private void btnMat_Click_1(object sender, EventArgs e)
        {
            // Nếu đang hiển thị mật khẩu → ẩn đi
            if (hienMatKhau)
            {
                txtMatKhau.UseSystemPasswordChar = true;
                btnMat.Text = "👁"; // đổi icon về mắt thường
                hienMatKhau = false;
            }
            else // Nếu đang ẩn → hiện mật khẩu
            {
                txtMatKhau.UseSystemPasswordChar = false;
                btnMat.Text = "🙈"; // đổi icon sang mắt nhắm (hoặc chữ khác nếu bạn thích)
                hienMatKhau = true;
            }
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy fDangKy = new FormDangKy();
            fDangKy.Show();
            this.Hide();
            fDangKy.FormClosed += (s, args) =>this.Show();
        }

       
    }
}
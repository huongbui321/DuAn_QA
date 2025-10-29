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
    public partial class FormQuenMK : Form
    {
        public FormQuenMK()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhauMoi = txtMKmoi.Text.Trim();
            string nhapLaiMK = txtNLMK.Text.Trim();

            // 1️⃣ Kiểm tra thông tin có bị trống không
            if (email == "" || matKhauMoi == "" || nhapLaiMK == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Kiểm tra mật khẩu nhập lại có khớp không
            if (matKhauMoi != nhapLaiMK)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3️⃣ Kiểm tra email có tồn tại trong hệ thống không
            try
            {
                string sqlCheck = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @em";
                int tonTai = kn.DemDong(sqlCheck, new SqlParameter("@em", email));

                if (tonTai == 0)
                {
                    MessageBox.Show("Email này chưa được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4️⃣ Cập nhật mật khẩu mới
                string sqlUpdate = "UPDATE NguoiDung SET MatKhau = @mk WHERE Email = @em";
                int kq = kn.ThucThi(sqlUpdate,
                    new SqlParameter("@mk", matKhauMoi),
                    new SqlParameter("@em", email)
                );

                if (kq > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay lại form đăng nhập
                    FormDangNhap f = new FormDangNhap();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
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
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void lblHoTen_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string mk = txtMatKhau.Text.Trim();
            string email = txtEmail.Text.Trim();
            // Kiểm tra nhập thiếu
            if (tenDN == "" || mk == "" || email == "")
            {
                MessageBox.Show("Vui long dien day du thong tin!", "Lỗi", MessageBoxButtons.OK);
                    return;
            }
            // Kiểm tra định dạng email cơ bản
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (kn.conn)
                {
                    kn.conn.Open();

                    // 1️⃣ Kiểm tra xem email đã tồn tại chưa
                    string sqlCheck = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @em";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, kn.conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@em", email);
                        int dem = (int)cmdCheck.ExecuteScalar();

                        if (dem > 0)
                        {
                            MessageBox.Show("Email đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2️⃣ Thêm người dùng mới
                    string sqlThem = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, Email) VALUES (@ten, @mk, @em)";
                    using (SqlCommand cmdThem = new SqlCommand(sqlThem, kn.conn))
                    {
                        cmdThem.Parameters.AddWithValue("@ten", tenDN);
                        cmdThem.Parameters.AddWithValue("@mk", mk);
                        cmdThem.Parameters.AddWithValue("@em", email);

                        int kq = cmdThem.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Quay lại form đăng nhập
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
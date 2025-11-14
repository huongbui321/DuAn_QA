using Microsoft.Data.SqlClient;
using System;
// Xóa: using System.Security.Cryptography;
// Xóa: using System.Text;
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class FormDangKy : Form
    {
        KetNoi kn = new KetNoi();

        public FormDangKy()
        {
            InitializeComponent();
        }

        // ==================== SỰ KIỆN NÚT ĐĂNG KÝ ====================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // (Giả sử tên: txtTenDN, txtMatKhau, txtEmail)
            string tenDN = txtTenDN.Text.Trim();
            string mk = txtMatKhau.Text.Trim(); // <-- Mật khẩu gốc
            string email = txtEmail.Text.Trim();

            // 1. Kiểm tra nhập thiếu
            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên đăng nhập, Mật khẩu và Email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng email
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. (ĐÃ XÓA BƯỚC BĂM MẬT KHẨU)

            try
            {
                // 4. Kiểm tra email đã tồn tại chưa
                // (Dùng hàm DemDong có sẵn của bạn)
                string sqlCheck = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @em";
                int dem = kn.DemDong(sqlCheck, new SqlParameter("@em", email));

                if (dem > 0)
                {
                    MessageBox.Show("Email này đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. Thêm người dùng mới (lưu mật khẩu gốc 'mk')
                string sqlThem = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, Email) VALUES (@ten, @mk, @em); SELECT SCOPE_IDENTITY();";

                kn.MoKetNoi();

                SqlCommand cmdThem = new SqlCommand(sqlThem, kn.conn);
                cmdThem.Parameters.AddWithValue("@ten", tenDN);
                cmdThem.Parameters.AddWithValue("@mk", mk); // <-- LƯU MẬT KHẨU GỐC
                cmdThem.Parameters.AddWithValue("@em", email);

                object result = cmdThem.ExecuteScalar();

                if (result != null) // Nếu INSERT thành công
                {
                    int maNguoiDungMoi = Convert.ToInt32(result);

                    MessageBox.Show("Đăng ký thành công! \nVui lòng cập nhật thông tin cá nhân của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn form đăng ký
                    this.Hide();

                    // Mở FormTTKH và truyền ID vào
                    FormTTKH frmTTKH = new FormTTKH(maNguoiDungMoi);
                    frmTTKH.ShowDialog(); // Hiển thị và chờ form này đóng

                    // Sau khi FormTTKH đóng, form đăng ký cũng đóng
                    // (Người dùng sẽ tự động quay về FormDangNhap)
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                kn.DongKetNoi(); // Luôn đóng kết nối
            }
        }

        // ==================== CÁC SỰ KIỆN KHÁC ====================

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // (Các hàm rỗng để code khớp với file .Designer của bạn)
        private void FormDangKy_Load(object sender, EventArgs e) { }
        private void lblHoTen_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
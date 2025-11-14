using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class FormTTKH : Form
    {
        // 1. Biến để lưu ID người dùng được gửi từ FormDangKy
        private int maNguoiDungHienTai;

        // 2. Lớp kết nối
        KetNoi kn = new KetNoi();

        // ==================== HÀM KHỞI TẠO ====================

        /// <summary>
        /// Hàm khởi tạo RỖNG - Bắt buộc cho Trình thiết kế (Designer).
        /// </summary>
        public FormTTKH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm khởi tạo dùng để NHẬN ID TỪ FormDangKy.
        /// </summary>
        public FormTTKH(int maNguoiDung)
        {
            InitializeComponent();

            // Lưu ID vào biến của form
            this.maNguoiDungHienTai = maNguoiDung;
        }

        // ==================== SỰ KIỆN NÚT XÁC NHẬN ====================

        // (Bạn cần đặt tên nút là btnXacNhan trong [Design])
      

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            // (Giả sử tên controls: txtHoTen, dtpNgaySinh, txtSoDienThoai, txtDiaChi)
            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value; // Dùng DateTimePicker cho ngày sinh
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Họ tên, Số điện thoại và Địa chỉ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Câu lệnh UPDATE
            // (Hãy chắc chắn bảng NguoiDung có các cột HoTen, NgaySinh, SoDienThoai, DiaChi)
            try
            {
                string sql = "UPDATE NguoiDung SET HoTen = @hoTen, NgaySinh = @ngaySinh, SoDienThoai = @sdt, DiaChi = @diaChi WHERE MaNguoiDung = @maND";

                // Dùng hàm ThucThi (INSERT/UPDATE/DELETE) của lớp KetNoi (vì hàm này tự mở/đóng kết nối)
                int kq = kn.ThucThi(sql,
                    new SqlParameter("@hoTen", hoTen),
                    new SqlParameter("@ngaySinh", ngaySinh),
                    new SqlParameter("@sdt", soDienThoai),
                    new SqlParameter("@diaChi", diaChi),
                    new SqlParameter("@maND", this.maNguoiDungHienTai) // <-- Dùng ID đã lưu
                );

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công! \nChào mừng đến với Huongie Clothes!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tự động đóng form này
                    // (Sẽ quay trở lại FormDangKy, và FormDangKy cũng sẽ tự đóng)
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
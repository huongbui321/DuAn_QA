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
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        KetNoi kn = new KetNoi();
        private DataTable originalDataTable; // Biến lưu dữ liệu gốc để lọc
        private string currentMaNguoiDung = ""; // Lưu mã ND đang chọn
        private bool isAdding = false;
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT MaNguoiDung, HoTen, TenDangNhap, Email, SoDienThoai, DiaChi, VaiTro, TrangThai FROM NguoiDung";
                originalDataTable = kn.LayDuLieu(query);
                dgvTaiKhoan.DataSource = originalDataTable;

                // Tùy chỉnh tiêu đề cột
                dgvTaiKhoan.Columns["MaNguoiDung"].HeaderText = "Mã Người Dùng";
                dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên ĐN";
                dgvTaiKhoan.Columns["SoDienThoai"].HeaderText = "Điện Thoại";
                dgvTaiKhoan.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai Trò";
                dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng Thái";

                dgvTaiKhoan.Columns["HoTen"].FillWeight = 120;
                dgvTaiKhoan.Columns["TenDangNhap"].FillWeight = 120;
                dgvTaiKhoan.Columns["SoDienThoai"].FillWeight = 100;
                dgvTaiKhoan.Columns["DiaChi"].FillWeight = 120;
                dgvTaiKhoan.Columns["VaiTro"].FillWeight = 120;
                dgvTaiKhoan.Columns["TrangThai"].FillWeight = 120;

                //dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxes()
        {
            // Tải ComboBox Vai Trò (Chức năng 4)
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("Khách hàng");
            cboVaiTro.SelectedIndex = -1;

            // Tải ComboBox Trạng Thái (Chức năng 5)
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Đã khóa");
            cboTrangThai.SelectedIndex = -1;
        }

        // --- HÀM QUẢN LÝ TRẠNG THÁI NÚT/TEXTBOX ---
        private void SetControlsState(bool isEditing)
        {
            // Bật/tắt các ô nhập liệu
            txtHoTen.Enabled = isEditing;
            txtTenDangNhap.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtSoDienThoai.Enabled = isEditing;
            txtDiaChi.Enabled = isEditing;
            cboVaiTro.Enabled = isEditing;
            cboTrangThai.Enabled = isEditing;

            if (isAdding) // Khi Thêm
                txtTenDangNhap.Enabled = true;
            else if (isEditing) // Khi Sửa
                txtTenDangNhap.Enabled = false; // Khóa Tên ĐN

            // Bật/tắt các nút
            btnLuu.Enabled = isEditing;
            btnLM.Enabled = isEditing;

            // Các nút Thêm/Sửa/Xóa chỉ bật khi KHÔNG ở chế độ editing
            btnThem.Enabled = !isEditing;

            // <<< SỬA LOGIC KHI NÀO NÚT SỬA/XÓA ĐƯỢC BẬT >>>
            bool daChonDong = !string.IsNullOrEmpty(currentMaNguoiDung);
            btnSua.Enabled = !isEditing && daChonDong;
            btnX.Enabled = !isEditing && daChonDong; // Chỉ cho Xóa khi đã chọn 1 dòng
        }

        // --- HÀM XÓA TRẮNG CÁC Ô ---
        private void ClearTextBoxes()
        {
            txtHoTen.Text = "";
            txtTenDangNhap.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            cboVaiTro.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
            currentMaNguoiDung = "";
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                try
                {
                    isAdding = false;

                    // 1. KHÓA các ô lại (chỉ để xem)
                    SetControlsState(false);

                    // 2. Lấy dữ liệu từ dòng vừa bấm
                    DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                    currentMaNguoiDung = row.Cells["MaNguoiDung"].Value.ToString();

                    // 3. Đổ dữ liệu lên các ô
                    txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                    txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                    txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

                    cboVaiTro.SelectedItem = row.Cells["VaiTro"].Value.ToString();
                    cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();

                    // 4. Bật nút Sửa và Xóa (vì SetControlsState(false) đã chạy)
                    btnSua.Enabled = true;
                    btnX.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = txtTimKiem.Text.Trim();

                if (string.IsNullOrEmpty(filter))
                {
                    originalDataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Tìm kiếm trên 3 cột
                    originalDataTable.DefaultView.RowFilter =
                        $"HoTen LIKE '%{filter}%' OR " +
                        $"TenDangNhap LIKE '%{filter}%' OR " +
                        $"Email LIKE '%{filter}%'";
                }
            }
            catch (Exception) { }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearTextBoxes();
            SetControlsState(true);
            txtHoTen.Focus(); // Chuyển trỏ chuột vào ô Họ Tên

            // Gợi ý giá trị mặc định khi Thêm
            cboVaiTro.SelectedItem = "Khách hàng";
            cboTrangThai.SelectedItem = "Hoạt động";
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn dòng nào chưa
            if (string.IsNullOrEmpty(currentMaNguoiDung))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Tạo biến 'result' để lưu lựa chọn Yes/No của người dùng
            // (Đây là dòng bạn bị thiếu)
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn XÓA tài khoản '{txtTenDangNhap.Text}'?\n\n" +
                "LƯU Ý: Nếu tài khoản này đã từng bán hàng, bạn sẽ không thể xóa.\n" +
                "Thay vào đó, hãy chuyển trạng thái sang 'Đã khóa'.",
                "CẢNH BÁO XÓA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 3. Kiểm tra biến 'result'
            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @MaND";
                    SqlParameter[] param = { new SqlParameter("@MaND", currentMaNguoiDung) };
                    kn.ThucThi(query, param);

                    MessageBox.Show("Đã xóa tài khoản thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLM_Click(sender, e);
                }
                catch (SqlException sqlEx)
                {
                    // Bắt lỗi 547 (Lỗi khóa ngoại - Đã có đơn hàng)
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show(
                            "KHÔNG THỂ XÓA tài khoản này vì họ đã có lịch sử bán hàng!\n\n" +
                            "Giải pháp: Hãy chọn dòng này, bấm Sửa, và đổi Trạng thái thành 'Đã khóa'.",
                            "Bảo vệ dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL khi xóa: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                cboVaiTro.SelectedItem == null ||
                cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ Họ tên, Tên đăng nhập, Vai trò và Trạng thái.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "";
                SqlParameter[] parameters;

                if (isAdding) // THÊM MỚI
                {
                    // Khi thêm mới, phải có Mật khẩu. Ta đặt mặc định là '123'
                    query = @"INSERT INTO NguoiDung (HoTen, TenDangNhap, Email, SoDienThoai, DiaChi, VaiTro, TrangThai, MatKhau) 
                              VALUES (@HoTen, @TenDN, @Email, @SDT, @DiaChi, @VaiTro, @TrangThai, @MatKhau)";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                        new SqlParameter("@TenDN", txtTenDangNhap.Text.Trim()),
                        new SqlParameter("@Email", txtEmail.Text.Trim()),
                        new SqlParameter("@SDT", txtSoDienThoai.Text.Trim()),
                        new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                        new SqlParameter("@VaiTro", cboVaiTro.SelectedItem.ToString()),
                        new SqlParameter("@TrangThai", cboTrangThai.SelectedItem.ToString()),
                        new SqlParameter("@MatKhau", "123") // !!! Mật khẩu mặc định khi tạo
                    };
                }
                else // SỬA (Bao gồm Phân quyền và Khóa/Mở khóa)
                {
                    query = @"UPDATE NguoiDung 
                              SET HoTen = @HoTen, Email = @Email, SoDienThoai = @SDT, DiaChi = @DiaChi, 
                                  VaiTro = @VaiTro, TrangThai = @TrangThai 
                              WHERE MaNguoiDung = @MaND";
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("@HoTen", txtHoTen.Text.Trim()),
                        new SqlParameter("@Email", txtEmail.Text.Trim()),
                        new SqlParameter("@SDT", txtSoDienThoai.Text.Trim()),
                        new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                        new SqlParameter("@VaiTro", cboVaiTro.SelectedItem.ToString()),
                        new SqlParameter("@TrangThai", cboTrangThai.SelectedItem.ToString()),
                        new SqlParameter("@MaND", currentMaNguoiDung) // Lấy từ biến đã lưu
                    };
                }

                // Thực thi
                kn.ThucThi(query, parameters);

                string message = isAdding ? "Thêm tài khoản thành công!" : "Cập nhật tài khoản thành công!";
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(); // Tải lại lưới
                btnLM_Click(sender, e); // Dọn dẹp và reset
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi trùng khóa
                {
                    MessageBox.Show($"Lỗi: Tên đăng nhập '{txtTenDangNhap.Text.Trim()}' đã tồn tại.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu (SQL): " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearTextBoxes();
            SetControlsState(false); // Hàm này sẽ tự động khóa btnSua/btnXoa
            originalDataTable.DefaultView.RowFilter = string.Empty;
        }

        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxes();
            SetControlsState(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaNguoiDung))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo");
                return;
            }

            isAdding = false; // Báo hiệu đây là chế độ Sửa
            SetControlsState(true); // Mở khóa các control

            txtHoTen.Focus();
        }
    }

}

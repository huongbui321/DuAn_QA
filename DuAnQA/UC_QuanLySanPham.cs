using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // QUAN TRỌNG: Cần cho SqlParameter

namespace DuAnQA // Đảm bảo đây là namespace của bạn
{
    public partial class UC_QuanLySanPham : UserControl
    {
        // 1. Khởi tạo đối tượng KetNoi
        private KetNoi kn = new KetNoi();

        private string currentMaSP = "";
        private bool isAdding = false;

        public UC_QuanLySanPham()
        {
            InitializeComponent();
        }

        // --- HÀM TẢI DỮ LIỆU ---
        private void LoadData()
        {
            try
            {
                string query = "SELECT MaSanPham, TenSanPham, MoTa, Gia, SoLuong, HinhAnh, MaDanhMuc FROM SanPham";
                DataTable dt = kn.LayDuLieu(query);


                dgvSanPham.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM TẢI DỮ LIỆU CHO COMBOBOX DANH MỤC ---
        private void LoadDanhMucComboBox()
        {
            try
            {
                // !!! QUAN TRỌNG: Sửa lại tên bảng (DanhMuc) và cột (MaDanhMuc, TenDanhMuc)
                // !!! cho đúng với Database của bạn
                string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                DataTable dt = kn.LayDuLieu(query);

                cbMaDanhMuc.DataSource = dt;
                cbMaDanhMuc.ValueMember = "MaDanhMuc";   // Giá trị lưu (ví dụ: DM01)
                cbMaDanhMuc.DisplayMember = "TenDanhMuc"; // Giá trị hiển thị (ví dụ: Áo Sơ Mi)
                cbMaDanhMuc.SelectedIndex = -1; // Bỏ chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM QUẢN LÝ TRẠNG THÁI CÁC NÚT ---
        private void SetControlsState(bool isEditing)
        {
            txtMaSanPham.Enabled = isEditing;
            txtTenSanPham.Enabled = isEditing;
            txtMoTa.Enabled = isEditing;
            // !!! LƯU Ý: Đảm bảo tên control này là chính xác (txtDonGia hay txtGia?)
            txtDonGia.Enabled = isEditing;
            txtSoLuong.Enabled = isEditing;
            txtHinhAnh.Enabled = isEditing;
            cbMaDanhMuc.Enabled = isEditing;
            btnChonAnh.Enabled = isEditing;
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;

            btnLuu.Enabled = isEditing;
            btnLamMoi.Enabled = isEditing;
        }

        // --- HÀM XÓA TRẮNG CÁC TEXTBOX ---
        private void ClearTextBoxes()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtMoTa.Text = "";
            // !!! LƯU Ý: Đảm bảo tên control này là chính xác (txtDonGia hay txtGia?)
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtHinhAnh.Text = "";
            cbMaDanhMuc.SelectedIndex = -1; // "Xóa trắng" combobox
            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Có thể xóa hàm này nếu không dùng
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một dòng hợp lệ và không phải đang "Thêm mới"
            if (e.RowIndex >= 0 && !isAdding)
            {
                try
                {
                    // Lấy dòng hiện tại được click
                    DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                    // 1. Gán dữ liệu từ Grid vào các TextBox
                    currentMaSP = row.Cells["MaSanPham"].Value.ToString();
                    txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
                    txtTenSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
                    txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                    txtDonGia.Text = row.Cells["Gia"].Value.ToString(); // Giả sử tên là txtDonGia
                    txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                    txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();

                    // 2. Hiển thị ảnh lên PictureBox (Giả sử tên là picHinhAnh)
                    try
                    {
                        string relativePath = txtHinhAnh.Text;
                        if (!string.IsNullOrEmpty(relativePath))
                        {
                            // Lấy đường dẫn tuyệt đối của file ảnh (từ thư mục chạy .exe)
                            string fullPath = Path.Combine(Application.StartupPath, relativePath);

                            if (File.Exists(fullPath))
                            {
                                // Tải ảnh bằng MemoryStream để tránh bị lỗi "file is being used"
                                byte[] imageData = File.ReadAllBytes(fullPath);
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    // Giải phóng ảnh cũ trước khi gán ảnh mới
                                    if (picHinhAnh.Image != null)
                                    {
                                        picHinhAnh.Image.Dispose();
                                    }
                                    picHinhAnh.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                // Nếu không tìm thấy file, xóa ảnh cũ
                                if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                                picHinhAnh.Image = null;
                            }
                        }
                        else
                        {
                            // Nếu đường dẫn ảnh bị rỗng, xóa ảnh cũ
                            if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                            picHinhAnh.Image = null;
                        }
                    }
                    catch (Exception)
                    {
                        // Nếu có bất kỳ lỗi nào khi tải ảnh, chỉ cần xóa ảnh cũ
                        if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = null;
                    }

                    // 3. Chọn giá trị tương ứng trong ComboBox
                    object maDanhMucValue = row.Cells["MaDanhMuc"].Value;
                    if (maDanhMucValue != DBNull.Value && maDanhMucValue != null)
                    {
                        cbMaDanhMuc.SelectedValue = maDanhMucValue;
                    }
                    else
                    {
                        // Nếu không có danh mục, bỏ chọn
                        cbMaDanhMuc.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void UC_QuanLySanPham_Load_1(object sender, EventArgs e)
        {
            LoadData();
            LoadDanhMucComboBox();
            SetControlsState(false);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            isAdding = true;
            SetControlsState(true);
            ClearTextBoxes();
            txtMaSanPham.Focus();
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Focus();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(currentMaSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isAdding = false;
            SetControlsState(true);
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Focus();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(currentMaSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{txtTenSanPham.Text}' (Mã: {currentMaSP})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM SanPham WHERE MaSanPham = @MaSP";
                    SqlParameter[] parameters = {
                        new SqlParameter("@MaSP", currentMaSP)
                    };
                    kn.ThucThi(query, parameters);

                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearTextBoxes();
                    currentMaSP = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            SetControlsState(false);
            ClearTextBoxes();
            currentMaSP = "";
            isAdding = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }

            // Kiểm tra ComboBox Danh Mục
            if (cbMaDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cho sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaDanhMuc.Focus();
                return;
            }

            // Kiểm tra và Ép kiểu (Parse) Giá và Số lượng
            // (Biến 'gia' và 'soLuong' sẽ được dùng trong khối 'try' bên dưới)
            if (!decimal.TryParse(txtDonGia.Text, out decimal gia) || !int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Giá và Số lượng phải là số hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // === 2. PHẦN LƯU VÀO DATABASE (TRY...CATCH) ===
            try
            {
                string query = "";
                SqlParameter[] parameters;

                if (isAdding) // Trường hợp THÊM MỚI
                {
                    // SỬA LỖI IDENTITY: 
                    // 1. Bỏ "MaSanPham" và "@MaSP" khỏi câu query
                    query = "INSERT INTO SanPham (TenSanPham, MoTa, Gia, SoLuong, HinhAnh, MaDanhMuc) " +
                            "VALUES (@TenSP, @MoTa, @Gia, @SoLuong, @HinhAnh, @MaDM)";

                    parameters = new SqlParameter[]
                    {
                // 2. Bỏ tham số "@MaSP" đi
                new SqlParameter("@TenSP", txtTenSanPham.Text.Trim()),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                new SqlParameter("@Gia", gia),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@HinhAnh", txtHinhAnh.Text.Trim()),
                new SqlParameter("@MaDM", cbMaDanhMuc.SelectedValue)
                    };
                }
                else // Trường hợp SỬA
                {
                    // Phần code Sửa này đã đúng, giữ nguyên
                    query = "UPDATE SanPham SET TenSanPham = @TenSP, MoTa = @MoTa, Gia = @Gia, " +
                            "SoLuong = @SoLuong, HinhAnh = @HinhAnh, MaDanhMuc = @MaDM " +
                            "WHERE MaSanPham = @MaSP_Old";

                    parameters = new SqlParameter[]
                    {
                new SqlParameter("@TenSP", txtTenSanPham.Text.Trim()),
                new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                new SqlParameter("@Gia", gia),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@HinhAnh", txtHinhAnh.Text.Trim()),
                new SqlParameter("@MaDM", cbMaDanhMuc.SelectedValue),
                new SqlParameter("@MaSP_Old", currentMaSP) // Dùng MaSP cũ để tìm đúng dòng
                    };
                }

                // Thực thi câu lệnh (Thêm hoặc Sửa)
                kn.ThucThi(query, parameters);

                // Thông báo thành công và dọn dẹp
                string message = isAdding ? "Thêm sản phẩm thành công!" : "Cập nhật sản phẩm thành công!";
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(); // Tải lại lưới
                SetControlsState(false); // Khóa các control
                ClearTextBoxes(); // Xóa trắng các ô
                currentMaSP = ""; // Đặt lại Mã SP đang chọn
            }
            catch (SqlException sqlEx) // Bắt các lỗi từ SQL Server
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // Lỗi trùng khóa (ví dụ: Tên sản phẩm Unique)
                {
                    MessageBox.Show($"Lỗi: Tên sản phẩm '{txtTenSanPham.Text.Trim()}' có thể đã tồn tại.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu (SQL): " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // Bắt các lỗi chung khác
            {
                MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {

            string targetFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            // 2. Mở cửa sổ chọn file
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Chọn hình ảnh sản phẩm";
                openFile.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 3. Lấy tên file và đường dẫn đích
                        string selectedFileName = Path.GetFileName(openFile.FileName);
                        string targetPath = Path.Combine(targetFolder, selectedFileName);

                        // 4. Copy file vào thư mục "Images" (ghi đè nếu đã tồn tại)
                        File.Copy(openFile.FileName, targetPath, true);

                        // 5. Lưu đường dẫn TƯƠNG ĐỐI vào TextBox
                        string relativePath = Path.Combine("Images", selectedFileName);
                        txtHinhAnh.Text = relativePath;

                        // 6. Tải ảnh vào mảng byte[]
                        byte[] imageData = File.ReadAllBytes(targetPath);

                        // <<< THÊM MỚI: KIỂM TRA FILE CÓ BỊ RỖNG (0-BYTE) KHÔNG >>>
                        if (imageData.Length == 0)
                        {
                            // Nếu file rỗng, thông báo và dừng lại
                            MessageBox.Show("File ảnh bạn chọn bị rỗng hoặc không hợp lệ.", "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Xóa ảnh cũ (nếu có)
                            if (picHinhAnh.Image != null)
                            {
                                picHinhAnh.Image.Dispose();
                                picHinhAnh.Image = null;
                            }
                            return; // Dừng, không chạy code bên dưới
                        }
                        // <<< KẾT THÚC THÊM MỚI >>>

                        // 7. Hiển thị ảnh (Cách cũ đã đúng)
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            if (picHinhAnh.Image != null)
                            {
                                picHinhAnh.Image.Dispose();
                            }
                            picHinhAnh.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu file bị hỏng (corrupted), nó sẽ bị bắt lỗi ở đây
                        MessageBox.Show("Lỗi khi sao chép hoặc tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (picHinhAnh.Image != null)
                        {
                            picHinhAnh.Image.Dispose();
                            picHinhAnh.Image = null;
                        }
                    }
                }
            }
        }
    }
}
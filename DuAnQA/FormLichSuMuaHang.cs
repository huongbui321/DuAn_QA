using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing; // <-- Cần cho Font và Color
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class FormLichSuMuaHang : Form
    {
        KetNoi kn = new KetNoi();
        private int maNguoiDung;

        // 1. Hàm khởi tạo rỗng
        public FormLichSuMuaHang()
        {
            InitializeComponent();
        }

        // 2. Hàm khởi tạo để nhận ID người dùng
        public FormLichSuMuaHang(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
        }

        // 3. Khi Form được tải
        private void FormLichSuMuaHang_Load(object sender, EventArgs e)
        {
            this.Text = "Lịch sử mua hàng";
            this.BackColor = Color.AliceBlue;
            this.StartPosition = FormStartPosition.CenterParent;

            if (this.maNguoiDung == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy người dùng.");
                this.Close();
                return;
            }

            TaiLichSuMuaHang();
        }

        private void TaiLichSuMuaHang()
        {
            try
            {
                DataTable dtLichSu = kn.LayLichSuMuaHang(this.maNguoiDung);
                dgvLichSu.DataSource = dtLichSu;

                if (dtLichSu.Rows.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có lịch sử mua hàng nào.", "Thông báo");
                }

                StyleDataGridView(); // Gọi hàm style (đã sửa)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử mua hàng: " + ex.Message, "Lỗi CSDL");
            }
        }

        // ==================================================
        // === HÀM MỚI: ĐỊNH DẠNG LẠI DATAGRIDVIEW ===
        // ==================================================
        private void StyleDataGridView()
        {
            // Tắt các thuộc tính mặc định
            dgvLichSu.ReadOnly = true;
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.AllowUserToDeleteRows = false;
            dgvLichSu.RowHeadersVisible = false;

            // Màu sắc và Font chữ
            dgvLichSu.BackgroundColor = Color.AliceBlue;
            dgvLichSu.BorderStyle = BorderStyle.None;
            dgvLichSu.EnableHeadersVisualStyles = false;

            // Style Header
            dgvLichSu.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            dgvLichSu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvLichSu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLichSu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichSu.ColumnHeadersHeight = 40;

            // Style Rows
            dgvLichSu.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvLichSu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 200, 220);
            dgvLichSu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLichSu.RowTemplate.Height = 30;
            dgvLichSu.AlternatingRowsDefaultCellStyle.BackColor = Color.LavenderBlush;

            // Thêm cột NÚT HỦY (Nếu chưa có)
            if (dgvLichSu.Columns["btnHuy"] == null)
            {
                DataGridViewButtonColumn btnHuyCol = new DataGridViewButtonColumn();
                btnHuyCol.Name = "btnHuy";
                btnHuyCol.HeaderText = "Hủy Đơn";
                btnHuyCol.Text = "Hủy";
                btnHuyCol.UseColumnTextForButtonValue = true;
                btnHuyCol.Width = 80;
                btnHuyCol.DefaultCellStyle.BackColor = Color.Tomato;
                btnHuyCol.DefaultCellStyle.ForeColor = Color.White;
                dgvLichSu.Columns.Add(btnHuyCol);
            }

            // Căn chỉnh và kích thước cột
            if (dgvLichSu.Columns.Count > 0)
            {
                // Ẩn cột MaDonHang (vẫn cần để Hủy)
                dgvLichSu.Columns["MaDonHang"].Visible = false;

                // <<< SỬA Ở ĐÂY: CHO HIỆN CỘT TRẠNG THÁI >>>

                dgvLichSu.Columns["Ngày đặt"].Width = 180;
                dgvLichSu.Columns["Ngày đặt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvLichSu.Columns["Tên sản phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvLichSu.Columns["Số lượng"].Width = 120;
                dgvLichSu.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvLichSu.Columns["Đơn giá"].Width = 130;
                dgvLichSu.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLichSu.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvLichSu.Columns["TrangThai"].Width = 150;
                dgvLichSu.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // === SỰ KIỆN MỚI: THÊM " VNĐ" VÀO CỘT ĐƠN GIÁ ===
        private void dgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvLichSu.Columns["Đơn giá"].Index && e.Value != null)
            {
                if (e.Value is decimal || e.Value is int)
                {
                    decimal gia = Convert.ToDecimal(e.Value);
                    e.Value = gia.ToString("N0") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        // <<< HÀM MỚI: XỬ LÝ BẤM NÚT "HỦY" >>>
        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có bấm vào cột nút "Hủy" không
            if (e.ColumnIndex == dgvLichSu.Columns["btnHuy"].Index && e.RowIndex >= 0)
            {
                // Lấy MaDonHang và TrangThai từ dòng được bấm
                int maDonHangCanHuy = Convert.ToInt32(dgvLichSu.Rows[e.RowIndex].Cells["MaDonHang"].Value);
                string trangThai = dgvLichSu.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

                // Kiểm tra logic trước khi gọi hàm Hủy
                if (trangThai != "Chờ xử lý")
                {
                    MessageBox.Show($"Không thể hủy đơn hàng đã '{trangThai}'.", "Lỗi");
                    return;
                }

                var result = MessageBox.Show($"Bạn có chắc muốn hủy đơn hàng mã {maDonHangCanHuy}?\n" +
                                            "Hàng sẽ được hoàn trả về kho.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    HuyDonHang(maDonHangCanHuy);
                }
            }
        }
        private void HuyDonHang(int maDonHangCanHuy)
        {
            SqlTransaction transaction = null;
            try
            {
                // (Không cần kiểm tra trạng thái nữa vì đã kiểm tra ở CellContentClick)
                kn.MoKetNoi();
                transaction = kn.conn.BeginTransaction();

                // BƯỚC 1: TRẢ LẠI HÀNG VÀO KHO
                // 1a. Lấy danh sách sản phẩm trong đơn hàng
                string queryChiTiet = "SELECT MaSanPham, SoLuong FROM ChiTietDonHang WHERE MaDonHang = @MaDH";

                // Cần truyền transaction vào hàm LayDuLieu (Bạn cần sửa KetNoi.cs nếu chưa có)
                // Giả sử hàm LayDuLieu của bạn có thể nhận transaction
                DataTable dtChiTiet = kn.LayDuLieu(queryChiTiet, transaction, new SqlParameter("@MaDH", maDonHangCanHuy));

                // 1b. Cộng trả lại số lượng vào bảng SanPham
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    int maSP = Convert.ToInt32(row["MaSanPham"]);
                    int soLuongTraLai = Convert.ToInt32(row["SoLuong"]);

                    string queryTraKho = "UPDATE SanPham SET SoLuong = SoLuong + @SoLuongTraLai WHERE MaSanPham = @MaSP";
                    kn.ThucThi(queryTraKho, transaction,
                        new SqlParameter("@SoLuongTraLai", soLuongTraLai),
                        new SqlParameter("@MaSP", maSP)
                    );
                }

                // BƯỚC 2: CẬP NHẬT TRẠNG THÁI ĐƠN HÀNG
                string queryHuyDon = "UPDATE DonHang SET TrangThai = N'Đã hủy' WHERE MaDonHang = @MaDH";
                kn.ThucThi(queryHuyDon, transaction, new SqlParameter("@MaDH", maDonHangCanHuy));

                // BƯỚC 3: LƯU THAY ĐỔI
                transaction.Commit();
                MessageBox.Show("Đã hủy đơn hàng thành công và hoàn trả sản phẩm vào kho.");

                TaiLichSuMuaHang(); // Tải lại lưới
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Hủy bỏ mọi thay đổi nếu có lỗi
                MessageBox.Show("Lỗi khi hủy đơn hàng: " + ex.Message, "Lỗi nghiêm trọng");
            }
            finally
            {
                kn.DongKetNoi();
            }
        }
        private void btnQL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
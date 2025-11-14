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
            // Chỉnh sửa Form
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

                // === GỌI HÀM STYLE SAU KHI TẢI DỮ LIỆU ===
                StyleDataGridView();
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
            dgvLichSu.RowHeadersVisible = false; // Ẩn cột đầu hàng (mũi tên)

            // Màu sắc và Font chữ
            dgvLichSu.BackgroundColor = Color.AliceBlue;
            dgvLichSu.BorderStyle = BorderStyle.None;
            dgvLichSu.EnableHeadersVisualStyles = false; // Bắt buộc để style header

            // Style Header
            dgvLichSu.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            dgvLichSu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvLichSu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLichSu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichSu.ColumnHeadersHeight = 40; // Tăng chiều cao Header

            // Style Rows
            dgvLichSu.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvLichSu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 200, 220); // Màu hồng nhạt khi chọn
            dgvLichSu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLichSu.RowTemplate.Height = 30; // Tăng chiều cao hàng

            // Màu xen kẽ (Zebra)
            dgvLichSu.AlternatingRowsDefaultCellStyle.BackColor = Color.LavenderBlush;

            // Căn chỉnh và kích thước cột (Dùng tên cột ALIAS từ câu SQL)
            if (dgvLichSu.Columns.Count > 0)
            {
                // Cột Ngày đặt: Căn giữa, Rộng 160
                dgvLichSu.Columns["Ngày đặt"].Width = 160;
                dgvLichSu.Columns["Ngày đặt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cột Tên sản phẩm: Tự động lấp đầy
                dgvLichSu.Columns["Tên sản phẩm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Cột Số lượng: Căn giữa, Rộng 80
                dgvLichSu.Columns["Số lượng"].Width = 80;
                dgvLichSu.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Cột Đơn giá: Căn phải, Rộng 120
                dgvLichSu.Columns["Đơn giá"].Width = 130;
                dgvLichSu.Columns["Đơn giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // (Chúng ta sẽ format thêm " VNĐ" ở sự kiện CellFormatting)
            }
        }

        // === SỰ KIỆN MỚI: THÊM " VNĐ" VÀO CỘT ĐƠN GIÁ ===
        private void dgvLichSu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem đây có phải cột "Đơn giá" không
            if (e.ColumnIndex == dgvLichSu.Columns["Đơn giá"].Index && e.Value != null)
            {
                // Lấy giá trị decimal
                if (e.Value is decimal || e.Value is int)
                {
                    decimal gia = Convert.ToDecimal(e.Value);

                    // Định dạng lại (N0 = 350,000) và thêm " VNĐ"
                    e.Value = gia.ToString("N0") + " VNĐ";
                    e.FormattingApplied = true; // Báo cho DataGridView biết là đã xử lý
                }
            }
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
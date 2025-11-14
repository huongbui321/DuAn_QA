using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // <-- THÊM THƯ VIỆN NÀY
using System.IO;                 // <-- THÊM THƯ VIỆN NÀY

namespace DuAnQA
{
    public partial class FormGioHang : Form
    {
        KetNoi kn = new KetNoi(); // <-- Thêm đối tượng Kết Nối
        Label LabelTrong; // Khai báo labelTrống
        private bool daThanhToanThanhCong = false;
        public FormGioHang()
        {
            InitializeComponent();

            // Khởi tạo labelTrống
            LabelTrong = new Label();
            LabelTrong.Text = "🛒 Giỏ hàng của bạn đang trống!";
            LabelTrong.Font = new Font("Segoe UI", 14, FontStyle.Italic);
            LabelTrong.ForeColor = Color.Gray;
            LabelTrong.TextAlign = ContentAlignment.MiddleCenter;
            LabelTrong.AutoSize = false;
            // Đặt kích thước cho label (thay 800 bằng chiều rộng của flowGioHang)
            LabelTrong.Size = new Size(800, 100);
        }

        private void FormGioHang_Load(object sender, EventArgs e)
        {
            HienThiGioHang();
            // Xóa: flowGioHang.Controls.Add(labelTrong); (Đã chuyển vào HienThiGioHang)
        }

        private void HienThiGioHang()
        {
            flowGioHang.Controls.Clear();
            decimal tongTien = 0;

            // Kiểm tra giỏ hàng trống TRƯỚC
            if (StaticData.DanhSachGioHang.Count == 0)
            {
                flowGioHang.Controls.Add(LabelTrong);
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                return;
            }

            // Nếu không trống, hiển thị sản phẩm
            foreach (var sp in StaticData.DanhSachGioHang)
            {
                Panel pnl = new Panel();
                pnl.Width = 600;
                pnl.Height = 120;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Margin = new Padding(200, 5, 5, 5);

                // Ảnh
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                // (Thêm kiểm tra HinhAnh null)
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    string path = Path.Combine(Application.StartupPath, sp.HinhAnh);
                    if (File.Exists(path))
                        pic.Image = Image.FromFile(path);
                }
                pic.Width = 100;
                pic.Height = 100;
                pic.Left = 10;
                pic.Top = 10;

                // Tên sản phẩm
                Label lblTen = new Label();
                lblTen.Text = sp.TenSP;
                lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTen.Left = 120;
                lblTen.Top = 10;
                lblTen.AutoSize = true;

                // Size
                Label lblSize = new Label();
                lblSize.Text = "Size: " + sp.Size;
                lblSize.Left = 120;
                lblSize.Top = 40;
                lblSize.AutoSize = true;

                // Số lượng
                Label lblSL = new Label();
                lblSL.Text = "SL: " + sp.SoLuong;
                lblSL.Left = 200;
                lblSL.Top = 40;
                lblSL.AutoSize = true;

                // Đơn giá
                Label lblGia = new Label();
                lblGia.Text = "Giá: " + sp.Gia.ToString("N0") + " VNĐ";
                lblGia.Left = 120;
                lblGia.Top = 70;
                lblGia.AutoSize = true;

                // Thành tiền (Lấy từ thuộc tính tự tính của GioHang.cs)
                Label lblThanhTien = new Label();
                lblThanhTien.Text = "Thành tiền: " + sp.ThanhTien.ToString("N0") + " VNĐ";
                lblThanhTien.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblThanhTien.ForeColor = Color.DarkRed;
                lblThanhTien.Left = 300;
                lblThanhTien.Top = 70;
                lblThanhTien.AutoSize = true;

                tongTien += sp.ThanhTien; // Dùng thuộc tính tự tính

                pnl.Controls.Add(pic);
                pnl.Controls.Add(lblTen);
                pnl.Controls.Add(lblSize);
                pnl.Controls.Add(lblSL);
                pnl.Controls.Add(lblGia);
                pnl.Controls.Add(lblThanhTien);

                flowGioHang.Controls.Add(pnl);
            }

            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            // Kiểm tra cờ
            if (this.daThanhToanThanhCong)
            {
                // Nếu đã mua, gửi tín hiệu OK
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Nếu không, gửi tín hiệu Cancel
                this.DialogResult = DialogResult.Cancel;
            }

            this.Close(); // Đóng form
        }

        // ==========================================================
        // === SỰ KIỆN NÚT THANH TOÁN (ĐÃ CẬP NHẬT LOGIC) ===
        // ==========================================================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (StaticData.DanhSachGioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, vui lòng thêm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // (Giả sử bạn đã lưu ID người dùng khi họ đăng nhập)
            if (StaticData.MaNguoiDungHienTai == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn thanh toán giỏ hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Dùng thuộc tính tự tính của GioHang.cs
            decimal tongTien = StaticData.DanhSachGioHang.Sum(x => x.ThanhTien);

            FormThanhToan f = new FormThanhToan(tongTien);
            f.StartPosition = FormStartPosition.CenterParent;

            // Chờ người dùng nhập OTP
            if (f.ShowDialog() == DialogResult.OK)
            {
                // === BẮT ĐẦU XỬ LÝ CSDL (TRANSACTION) ===

                bool thanhCong = GhiDonHangVaoCSDL(tongTien);

                if (thanhCong)
                {
                    MessageBox.Show("Đặt hàng thành công! Cảm ơn bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StaticData.DanhSachGioHang.Clear(); // Xóa giỏ hàng tĩnh
                    HienThiGioHang(); // Cập nhật lại giao diện (sẽ hiển thị giỏ trống)
                    // this.Close(); // (Tùy bạn, có thể đóng hoặc ở lại xem giỏ trống)
                    this.daThanhToanThanhCong = true;
                }
                // (Nếu thất bại, hàm GhiDonHangVaoCSDL sẽ tự hiển thị lỗi)
            }
            else
            {
                MessageBox.Show("Thanh toán đã bị hủy.", "Thông báo");
            }
        }

        // ==========================================================
        // === HÀM MỚI: GHI ĐƠN HÀNG VÀ TRỪ KHO (TRANSACTION) ===
        // ==========================================================
        private bool GhiDonHangVaoCSDL(decimal tongTien)
        {
            SqlTransaction transaction = null;
            try
            {
                kn.MoKetNoi(); // Mở kết nối 1 LẦN
                transaction = kn.conn.BeginTransaction(); // Bắt đầu giao dịch

                // BƯỚC A: TẠO ĐƠN HÀNG (DonHang)
                int maNguoiDung = StaticData.MaNguoiDungHienTai; // Giả định
                string sqlDonHang = "INSERT INTO DonHang (MaNguoiDung, NgayDat, TongTien, TrangThai) VALUES (@maND, GETDATE(), @tongTien, N'Chờ xử lý'); SELECT SCOPE_IDENTITY();";

                object result = kn.ThucThiLayScalar(sqlDonHang, transaction,
                    new SqlParameter("@maND", maNguoiDung),
                    new SqlParameter("@tongTien", tongTien)
                );

                int maDonHangMoi = Convert.ToInt32(result);

                // BƯỚC B & C: THÊM CHI TIẾT & TRỪ KHO (Loop)
                foreach (var item in StaticData.DanhSachGioHang)
                {
                    // (Lấy MaSanPham, SoLuong, Gia từ item)

                    // BƯỚC B: Thêm vào ChiTietDonHang
                    string sqlChiTiet = "INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, SoLuong, DonGia) VALUES (@maDH, @maSP, @soLuong, @donGia)";
                    kn.ThucThi(sqlChiTiet, transaction,
                        new SqlParameter("@maDH", maDonHangMoi),
                        new SqlParameter("@maSP", item.MaSanPham),
                        new SqlParameter("@soLuong", item.SoLuong),
                        new SqlParameter("@donGia", item.Gia)
                    );

                    // BƯỚC C: TRỪ SỐ LƯỢNG KHO
                    string sqlTruKho = "UPDATE SanPham SET SoLuong = SoLuong - @soLuongMua WHERE MaSanPham = @maSP";
                    kn.ThucThi(sqlTruKho, transaction,
                        new SqlParameter("@soLuongMua", item.SoLuong),
                        new SqlParameter("@maSP", item.MaSanPham)
                    );
                }

                // BƯỚC D: HOÀN TẤT GIAO DỊCH
                transaction.Commit(); // LƯU TẤT CẢ THAY ĐỔI
                return true; // Trả về thành công
            }
            catch (Exception ex)
            {
                // BƯỚC E: HỦY GIAO DỊCH NẾU CÓ LỖI
                try
                {
                    transaction?.Rollback(); // HỦY BỎ mọi thay đổi
                }
                catch { }

                MessageBox.Show("Lỗi nghiêm trọng khi đặt hàng: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Trả về thất bại
            }
            finally
            {
                kn.DongKetNoi(); // Đóng kết nối dù thành công hay thất bại
            }
        }


        // (Code cũ của bạn, đã sửa lỗi)
        private void label2_Click(object sender, EventArgs e)
        {
            // Hàm này có thể bị lỗi nếu bạn chưa khai báo 'labelTrong'
            // Code mới đã chuyển 'labelTrong' ra ngoài
            flowGioHang.Controls.Clear();
            flowGioHang.Controls.Add(LabelTrong);
        }
    }
}
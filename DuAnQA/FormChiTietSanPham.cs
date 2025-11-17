using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.SqlClient; // <<< 1. THÊM THƯ VIỆN NÀY

namespace DuAnQA
{
    public partial class FormChiTietSanPham : Form
    {
        private SanPham sp;
        private KetNoi kn = new KetNoi(); // <<< 2. THÊM ĐỐI TƯỢNG KẾT NỐI

        public FormChiTietSanPham(SanPham sanPham)
        {
            InitializeComponent();
            sp = sanPham;

        }

        private void FormChiTietSanPham_Load(object sender, EventArgs e)
        {
            lblTenSP.Text = sp.TenSanPham;
            lblGia.Text = sp.Gia.ToString("N0") + " VNĐ";
            lblMoTa.Text = sp.MoTa;
            lblSL.Text = $"Còn lại: {sp.SoLuong}";
            string path = Path.Combine(Application.StartupPath, sp.HinhAnh);
            if (File.Exists(path))
                picHinhAnh.Image = Image.FromFile(path);
            cboSize.Items.AddRange(new[] { "S", "M", "L" });
            cboSize.SelectedIndex = 0;
            numSoLuongMua.Minimum = 1;
            numSoLuongMua.Maximum = Math.Max(1, sp.SoLuong);
        }

        // <<< 3. SỬA TOÀN BỘ HÀM "MUA NGAY" >>>
        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin
            int soLuongMua = (int)numSoLuongMua.Value;
            string sizeChon = cboSize.Text;
            decimal tongTien = sp.Gia * soLuongMua;

            // 2. Kiểm tra
            if (string.IsNullOrEmpty(sizeChon))
            {
                MessageBox.Show("Vui lòng chọn size sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (StaticData.MaNguoiDungHienTai == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Mở Form Thanh Toán
            FormThanhToan f = new FormThanhToan(tongTien);
            f.StartPosition = FormStartPosition.CenterParent;
            DialogResult thanhToanResult = f.ShowDialog();

            // 4. Quyết định trạng thái
            string trangThaiDonHang;
            if (thanhToanResult == DialogResult.OK)
            {
                trangThaiDonHang = "Đã thanh toán";
            }
            else
            {
                trangThaiDonHang = "Chờ xử lý";
            }

            // 5. Lưu đơn hàng "Mua ngay" vào CSDL
            bool thanhCong = GhiDonHangMuaNgayVaoCSDL(soLuongMua, sizeChon, tongTien, trangThaiDonHang);

            if (thanhCong)
            {
                MessageBox.Show($"Đặt hàng (mua ngay) thành công! Trạng thái: {trangThaiDonHang}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form chi tiết sau khi mua thành công
            }
            // (Nếu thất bại, hàm GhiDonHang... sẽ tự báo lỗi)
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            int soLuongMua = (int)numSoLuongMua.Value;
            string sizeChon = cboSize.Text;

            if (string.IsNullOrEmpty(sizeChon))
            {
                MessageBox.Show("Vui lòng chọn size sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var spTonTai = StaticData.DanhSachGioHang
                .FirstOrDefault(x => x.MaSanPham == sp.MaSanPham && x.Size == sizeChon);

            if (spTonTai != null)
            {
                spTonTai.SoLuong += soLuongMua;
            }
            else
            {
                GioHang item = new GioHang
                {
                    MaSanPham = sp.MaSanPham,
                    TenSP = sp.TenSanPham,
                    Gia = sp.Gia,
                    SoLuong = soLuongMua,
                    Size = sizeChon,
                    HinhAnh = sp.HinhAnh
                };
                StaticData.DanhSachGioHang.Add(item);
            }

            MessageBox.Show($"{sp.TenSanPham} (Size: {sizeChon}) đã được thêm vào giỏ hàng!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // <<< 4. THÊM HÀM MỚI ĐỂ XỬ LÝ "MUA NGAY" >>>
        private bool GhiDonHangMuaNgayVaoCSDL(int soLuongMua, string sizeChon, decimal tongTien, string trangThaiDonHang)
        {
            // Đây là phiên bản rút gọn của hàm GhiDonHangVaoCSDL bên FormGioHang
            // Nó chỉ xử lý 1 sản phẩm duy nhất
            SqlTransaction transaction = null;
            try
            {
                kn.MoKetNoi();
                transaction = kn.conn.BeginTransaction();

                // BƯỚC A: TẠO ĐƠN HÀNG (DonHang)
                int maNguoiDung = StaticData.MaNguoiDungHienTai;
                string sqlDonHang = "INSERT INTO DonHang (MaNguoiDung, NgayDat, TongTien, TrangThai) VALUES (@maND, GETDATE(), @tongTien, @trangThai); SELECT SCOPE_IDENTITY();";

                object result = kn.ThucThiLayScalar(sqlDonHang, transaction,
                    new SqlParameter("@maND", maNguoiDung),
                    new SqlParameter("@tongTien", tongTien),
                    new SqlParameter("@trangThai", trangThaiDonHang)
                );
                int maDonHangMoi = Convert.ToInt32(result);

                // BƯỚC B: THÊM CHI TIẾT (ChiTietDonHang)
                // Lưu ý: Logic này giả định bảng ChiTietDonHang của bạn không lưu 'Size'
                string sqlChiTiet = "INSERT INTO ChiTietDonHang (MaDonHang, MaSanPham, SoLuong, DonGia) VALUES (@maDH, @maSP, @soLuong, @donGia)";
                kn.ThucThi(sqlChiTiet, transaction,
                    new SqlParameter("@maDH", maDonHangMoi),
                    new SqlParameter("@maSP", sp.MaSanPham),
                    new SqlParameter("@soLuong", soLuongMua),
                    new SqlParameter("@donGia", sp.Gia)
                );

                // BƯỚC C: TRỪ SỐ LƯỢNG KHO (SanPham)
                string sqlTruKho = "UPDATE SanPham SET SoLuong = SoLuong - @soLuongMua WHERE MaSanPham = @maSP";
                kn.ThucThi(sqlTruKho, transaction,
                    new SqlParameter("@soLuongMua", soLuongMua),
                    new SqlParameter("@maSP", sp.MaSanPham)
                );

                // BƯỚC D: HOÀN TẤT
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback(); // Hủy bỏ nếu có lỗi
                MessageBox.Show("Lỗi nghiêm trọng khi đặt hàng: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                kn.DongKetNoi();
            }
        }
    }
}
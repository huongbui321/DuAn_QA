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
                pnl.Width = 600; // Tăng chiều rộng để chứa nút Xóa
                pnl.Height = 120;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Margin = new Padding(100, 5, 5, 5); // Giảm margin trái 1 chút

                // Ảnh (Sửa lỗi khóa file)
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    string path = Path.Combine(Application.StartupPath, sp.HinhAnh);
                    if (File.Exists(path))
                    {
                        // Dùng MemoryStream để tránh lỗi khóa file
                        byte[] imageData = File.ReadAllBytes(path);
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pic.Image = Image.FromStream(ms);
                        }
                    }
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

                // <<< SỬA 1: Dùng ComboBox cho Size >>>
                ComboBox cboSize = new ComboBox();
                cboSize.Items.AddRange(new[] { "S", "M", "L" });
                cboSize.SelectedItem = sp.Size;
                cboSize.Left = 120;
                cboSize.Top = 40;
                cboSize.Width = 70;
                cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
                cboSize.Tag = sp; // Gán đối tượng sp vào Tag để biết đang sửa item nào
                cboSize.SelectedIndexChanged += new EventHandler(cboSize_SelectedIndexChanged);

                // <<< SỬA 2: Dùng NumericUpDown cho Số lượng >>>
                NumericUpDown numSL = new NumericUpDown();
                numSL.Value = sp.SoLuong;
                numSL.Minimum = 1;
                numSL.Maximum = 99; // Giới hạn max, hoặc bạn có thể truy vấn số lượng tồn kho
                numSL.Left = 200;
                numSL.Top = 40;
                numSL.Width = 50;
                numSL.Tag = sp; // Gán đối tượng sp vào Tag
                numSL.ValueChanged += new EventHandler(numSL_ValueChanged);

                // Đơn giá
                Label lblGia = new Label();
                lblGia.Text = "Giá: " + sp.Gia.ToString("N0") + " VNĐ";
                lblGia.Left = 120;
                lblGia.Top = 70;
                lblGia.AutoSize = true;

                // Thành tiền
                Label lblThanhTien = new Label();
                lblThanhTien.Text = "Thành tiền: " + sp.ThanhTien.ToString("N0") + " VNĐ";
                lblThanhTien.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblThanhTien.ForeColor = Color.DarkRed;
                lblThanhTien.Left = 300;
                lblThanhTien.Top = 70;
                lblThanhTien.AutoSize = true;

                tongTien += sp.ThanhTien;

                // <<< SỬA 3: Thêm Nút Xóa >>>
                Button btnXoa = new Button();
                btnXoa.Text = "Xóa";
                btnXoa.BackColor = Color.Pink;
                btnXoa.Left = 520; // Đặt ở góc phải panel
                btnXoa.Top = 35;
                btnXoa.Width = 70;
                btnXoa.Height = 40;
                btnXoa.Tag = sp; // Gán đối tượng sp vào Tag
                btnXoa.Click += new EventHandler(btnXoa_Click);

                pnl.Controls.Add(pic);
                pnl.Controls.Add(lblTen);
                pnl.Controls.Add(cboSize); // Thêm cboSize (thay cho lblSize)
                pnl.Controls.Add(numSL);   // Thêm numSL (thay cho lblSL)
                pnl.Controls.Add(lblGia);
                pnl.Controls.Add(lblThanhTien);
                pnl.Controls.Add(btnXoa);  // Thêm btnXoa

                flowGioHang.Controls.Add(pnl);
            }

            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }
        private void numSL_ValueChanged(object sender, EventArgs e)
        {
            // 1. Lấy control và đối tượng sp từ Tag
            NumericUpDown num = (NumericUpDown)sender;
            GioHang item = (GioHang)num.Tag;

            // 2. Cập nhật số lượng trong giỏ hàng tĩnh
            item.SoLuong = (int)num.Value;

            // 3. Tải lại toàn bộ giỏ hàng để cập nhật thành tiền và tổng tiền
            HienThiGioHang();
        }

        // --- SỰ KIỆN KHI THAY ĐỔI SIZE ---
        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Lấy control và đối tượng sp từ Tag
            ComboBox cbo = (ComboBox)sender;
            GioHang item = (GioHang)cbo.Tag;

            // 2. Cập nhật size
            item.Size = cbo.Text;

            // 3. Tải lại giỏ hàng
            HienThiGioHang();
        }

        // --- SỰ KIỆN KHI BẤM NÚT XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Lấy control và đối tượng sp từ Tag
            Button btn = (Button)sender;
            GioHang item = (GioHang)btn.Tag;

            var result = MessageBox.Show($"Bạn có chắc muốn xóa {item.TenSP} khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // 2. Xóa khỏi giỏ hàng tĩnh
                StaticData.DanhSachGioHang.Remove(item);

                // 3. Tải lại giỏ hàng
                HienThiGioHang();
            }
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

            if (StaticData.MaNguoiDungHienTai == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc muốn đặt hàng và thanh toán giỏ hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
                return;

            decimal tongTien = StaticData.DanhSachGioHang.Sum(x => x.ThanhTien);

            FormThanhToan f = new FormThanhToan(tongTien);
            f.StartPosition = FormStartPosition.CenterParent;

            // Chờ người dùng nhập OTP hoặc bấm Thoát
            DialogResult thanhToanResult = f.ShowDialog();

            // <<< SỬA LOGIC Ở ĐÂY >>>
            // 1. Quyết định trạng thái dựa trên kết quả của FormThanhToan
            string trangThaiDonHang;
            if (thanhToanResult == DialogResult.OK)
            {
                // Người dùng nhập OTP thành công
                trangThaiDonHang = "Đã thanh toán";
            }
            else // (DialogResult.Cancel hoặc đóng bằng dấu X)
            {
                // Người dùng bấm "Thoát"
                trangThaiDonHang = "Chờ xử lý";
            }

            // 2. LƯU ĐƠN HÀNG VÀO CSDL (LUÔN LUÔN LƯU, chỉ khác trạng thái)
            bool thanhCong = GhiDonHangVaoCSDL(tongTien, trangThaiDonHang);

            if (thanhCong)
            {
                MessageBox.Show($"Đặt hàng thành công! Trạng thái: {trangThaiDonHang}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticData.DanhSachGioHang.Clear(); // Xóa giỏ hàng tĩnh
                HienThiGioHang(); // Cập nhật lại giao diện (sẽ hiển thị giỏ trống)
                this.daThanhToanThanhCong = true; // Đặt cờ để khi quay lại sẽ tải lại form MuaHang
            }
        }

        // ==========================================================
        // === HÀM MỚI: GHI ĐƠN HÀNG VÀ TRỪ KHO (TRANSACTION) ===
        // ==========================================================
        private bool GhiDonHangVaoCSDL(decimal tongTien, string trangThaiDonHang)
        {
            SqlTransaction transaction = null;
            try
            {
                kn.MoKetNoi(); // Mở kết nối 1 LẦN
                transaction = kn.conn.BeginTransaction(); // Bắt đầu giao dịch

                // BƯỚC A: TẠO ĐƠN HÀNG (DonHang)
                int maNguoiDung = StaticData.MaNguoiDungHienTai;

                // <<< SỬA 2: Dùng @trangThai thay vì N'Chờ xử lý' >>>
                string sqlDonHang = "INSERT INTO DonHang (MaNguoiDung, NgayDat, TongTien, TrangThai) VALUES (@maND, GETDATE(), @tongTien, @trangThai); SELECT SCOPE_IDENTITY();";

                object result = kn.ThucThiLayScalar(sqlDonHang, transaction,
                    new SqlParameter("@maND", maNguoiDung),
                    new SqlParameter("@tongTien", tongTien),
                    new SqlParameter("@trangThai", trangThaiDonHang) // <<< SỬA 3: Thêm parameter
                );

                int maDonHangMoi = Convert.ToInt32(result);

                // BƯỚC B & C: THÊM CHI TIẾT & TRỪ KHO (Loop)
                foreach (var item in StaticData.DanhSachGioHang)
                {
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
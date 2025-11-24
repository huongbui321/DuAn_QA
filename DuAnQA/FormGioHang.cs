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

            // Giữ nguyên kích thước form như bạn thiết kế (hoặc set cứng nếu cần)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false; // Không cho phóng to để giữ giao diện gọn

            // --- CẤU HÌNH THANH TRƯỢT ---
            flowGioHang.AutoScroll = true; // BẬT THANH TRƯỢT
            flowGioHang.FlowDirection = FlowDirection.TopDown; // Xếp theo chiều dọc
            flowGioHang.WrapContents = false; // Không cho xuống dòng ngang

            // Neo panel để nó luôn bám theo kích thước form
            flowGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Label trống (giữ nguyên)
            LabelTrong = new Label();
            LabelTrong.Text = "🛒 Giỏ hàng của bạn đang trống!";
            LabelTrong.Font = new Font("Segoe UI", 14, FontStyle.Italic);
            LabelTrong.ForeColor = Color.Gray;
            LabelTrong.TextAlign = ContentAlignment.MiddleCenter;
            LabelTrong.AutoSize = false;
            LabelTrong.Dock = DockStyle.Top;
            LabelTrong.Height = 100;
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

            // --- TRƯỜNG HỢP 1: GIỎ HÀNG TRỐNG ---
            if (StaticData.DanhSachGioHang.Count == 0)
            {
                // 1. Tắt thanh trượt
                flowGioHang.AutoScroll = false;

                Label lblTrong = new Label();
                lblTrong.Text = "Giỏ hàng của bạn đang trống !";
                lblTrong.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTrong.ForeColor = Color.Silver;

                // 2. Cấu hình để căn giữa tuyệt đối
                lblTrong.AutoSize = false;
                lblTrong.TextAlign = ContentAlignment.MiddleCenter; // Căn chữ vào giữa Label

                // 3. Set kích thước Label BẰNG ĐÚNG kích thước khung chứa
                // (Trừ đi 2px để tránh bị viền chèn ép)
                lblTrong.Width = flowGioHang.ClientSize.Width - 2;
                lblTrong.Height = flowGioHang.ClientSize.Height - 2;

                // 4. Xóa Margin để không bị lệch
                lblTrong.Margin = new Padding(0);

                flowGioHang.Controls.Add(lblTrong);
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                return;
            }

            // --- TRƯỜNG HỢP 2: CÓ SẢN PHẨM (Code bên dưới giữ nguyên) ---
            flowGioHang.AutoScroll = true;
            int w = flowGioHang.ClientSize.Width - 40;

            foreach (var sp in StaticData.DanhSachGioHang)
            {
                Panel pnl = new Panel();
                pnl.Width = w;  // Chiều rộng tự động co giãn theo khung
                pnl.Height = 120;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.BackColor = Color.White;
                pnl.Margin = new Padding(5); // Khoảng cách giữa các ô

                // 1. Ảnh
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    string path = Path.Combine(Application.StartupPath, sp.HinhAnh);
                    if (File.Exists(path))
                    {
                        byte[] imgBytes = File.ReadAllBytes(path);
                        using (MemoryStream ms = new MemoryStream(imgBytes)) pic.Image = Image.FromStream(ms);
                    }
                }
                pic.Width = 100; pic.Height = 100;
                pic.Left = 10; pic.Top = 10;

                // 2. Thông tin (Tên, Size, SL, Giá)
                // Cố định vị trí bên trái
                int leftInfo = 120;

                // Tên SP
                Label lblTen = new Label();
                lblTen.Text = sp.TenSP;
                lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTen.AutoSize = true;
                lblTen.Left = leftInfo; lblTen.Top = 10;

                // ComboBox Size
                ComboBox cboSize = new ComboBox();
                cboSize.Items.AddRange(new[] { "S", "M", "L", "XL" });
                cboSize.SelectedItem = sp.Size;
                cboSize.Width = 50;
                cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
                cboSize.Left = leftInfo; cboSize.Top = 40;
                cboSize.Tag = sp;
                cboSize.SelectedIndexChanged += new EventHandler(cboSize_SelectedIndexChanged);

                // Numeric Số lượng
                NumericUpDown numSL = new NumericUpDown();
                numSL.Value = sp.SoLuong; numSL.Minimum = 1; numSL.Maximum = 99;
                numSL.Width = 50;
                numSL.Left = leftInfo + 60; numSL.Top = 40;
                numSL.Tag = sp;
                numSL.ValueChanged += new EventHandler(numSL_ValueChanged);

                // Đơn giá
                Label lblGia = new Label();
                lblGia.Text = "Giá: " + sp.Gia.ToString("N0");
                lblGia.ForeColor = Color.Gray;
                lblGia.AutoSize = true;
                lblGia.Left = leftInfo; lblGia.Top = 75;

                // --- 3. CỤM BÊN PHẢI (NÚT XÓA & THÀNH TIỀN) ---
                // Neo vị trí dựa trên pnl.Width để luôn nằm sát lề phải dù form to hay nhỏ

                // Nút Xóa
                Button btnXoa = new Button();
                btnXoa.Text = "Xóa";
                btnXoa.BackColor = Color.Pink;
                btnXoa.FlatStyle = FlatStyle.Flat;
                btnXoa.FlatAppearance.BorderSize = 0;
                btnXoa.Width = 60; btnXoa.Height = 30;
                // Công thức: Chiều rộng Panel - Chiều rộng nút - 10px lề
                btnXoa.Left = pnl.Width - 90;
                btnXoa.Top = 40;
                btnXoa.Tag = sp;
                btnXoa.Click += new EventHandler(btnXoa_Click);

                // Thành tiền
                Label lblThanhTien = new Label();
                lblThanhTien.Text = "Thành tiền:\n" + sp.ThanhTien.ToString("N0") + " VNĐ";
                lblThanhTien.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblThanhTien.ForeColor = Color.DarkRed;
                lblThanhTien.TextAlign = ContentAlignment.MiddleRight; // Căn chữ sang phải
                lblThanhTien.AutoSize = false;
                lblThanhTien.Width = 200;
                lblThanhTien.Height = 60;
                // Công thức: Chiều rộng Panel - Chiều rộng Label - 10px lề
                lblThanhTien.Left = 350;
                lblThanhTien.Top = 45;

                tongTien += sp.ThanhTien;

                pnl.Controls.Add(pic);
                pnl.Controls.Add(lblTen);
                pnl.Controls.Add(cboSize);
                pnl.Controls.Add(numSL);
                pnl.Controls.Add(lblGia);
                pnl.Controls.Add(btnXoa);
                pnl.Controls.Add(lblThanhTien);

                flowGioHang.Controls.Add(pnl);
            }

            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }
        private void numSL_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            GioHang item = (GioHang)num.Tag;
            item.SoLuong = (int)num.Value;
            HienThiGioHang();
        }

        // --- SỰ KIỆN KHI THAY ĐỔI SIZE ---
        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            GioHang item = (GioHang)cbo.Tag;
            item.Size = cbo.Text;
            HienThiGioHang();
        }

        // --- SỰ KIỆN KHI BẤM NÚT XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GioHang item = (GioHang)btn.Tag;
            var result = MessageBox.Show($"Xóa {item.TenSP}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                StaticData.DanhSachGioHang.Remove(item);
                HienThiGioHang();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (this.daThanhToanThanhCong) this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.Cancel;
            this.Close();
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
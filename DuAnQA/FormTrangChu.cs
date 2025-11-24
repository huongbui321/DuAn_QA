using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DuAnQA
{
    public partial class FormTrangChu : Form
    {
        KetNoi kn = new KetNoi();

        // Đây là danh sách "chính", tải 1 lần khi mở form
        List<SanPham> danhSachSanPham;

        public FormTrangChu()
        {
            InitializeComponent();
        }


        private void TaiLaiDuLieuSanPham()
        {
            // 1. Tải lại danh sách chính từ CSDL (với số lượng mới)
            danhSachSanPham = kn.LayDanhSachSanPham();

            // 2. Tải lại danh mục (để reset màu)
            TaiDanhMucLenPanel();

            // 3. Hiển thị lại toàn bộ sản phẩm (với số lượng mới)
            HienThiDanhSach(danhSachSanPham);
        }
        // ==================== SỰ KIỆN LOAD FORM ====================

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            // 1. Tải danh sách sản phẩm GỐC (master list) một lần duy nhất
            danhSachSanPham = kn.LayDanhSachSanPham();

            // 2. Tải danh mục lên panel menu bên trái
            TaiDanhMucLenPanel();

            // 3. Hiển thị toàn bộ sản phẩm ban đầu
            HienThiDanhSach(danhSachSanPham);
        }

        // ==================== TẢI DANH MỤC LÊN MENU ====================
        private void TaiDanhMucLenPanel()
        {
            flpDanhMuc.Controls.Clear();

            // 2. TẠO NÚT "TẤT CẢ SẢN PHẨM"
            Button btnTatCa = new Button();
            // THÊM EMOJI VÀO ĐÂY
            btnTatCa.Text = "🛍️ Tất cả                sản phẩm"; // Ví dụ: icon ngôi nhà
            btnTatCa.Width = flpDanhMuc.Width - 25;
            btnTatCa.Height = 70;
            btnTatCa.TextAlign = ContentAlignment.MiddleLeft;
            btnTatCa.FlatStyle = FlatStyle.Flat;
            btnTatCa.FlatAppearance.BorderSize = 0;
            btnTatCa.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Để font này hỗ trợ Emoji
            btnTatCa.ForeColor = Color.DeepPink;
            btnTatCa.Tag = "ALL";
            btnTatCa.Cursor = Cursors.Hand;
            btnTatCa.Click += DanhMuc_Click;
            flpDanhMuc.Controls.Add(btnTatCa);

            // 3. LẤY DANH MỤC TỪ CSDL
            DataTable dtDanhMuc = kn.LayTatCaDanhMuc();

            // 4. TẠO CÁC NÚT CHO DANH MỤC KHÁC
            foreach (DataRow row in dtDanhMuc.Rows)
            {
                Button btn = new Button();
                string tenDanhMuc = row["TenDanhMuc"].ToString();
                string icon = "";

                // CHỌN ICON TÙY THEO TÊN DANH MỤC
                switch (tenDanhMuc.ToLower()) // Dùng ToLower để so sánh không phân biệt chữ hoa/thường
                {
                    case "áo":
                        icon = "👕"; // Icon áo thun
                        break;
                    case "quần":
                        icon = "👖"; // Icon quần jean
                        break;
                    case "váy":
                        icon = "👗"; // Icon váy
                        break;
                    case "set":
                        icon = "👚"; // Icon áo blouse
                        break;
                    case "giày":
                        icon = "👟"; // Icon giày thể thao
                        break;
                    case "phụ kiện":
                        icon = "💎"; // Icon kim cương (hoặc 👜 cho túi xách, 🧢 cho mũ...)
                        break;
                    default:
                        icon = "✨"; // Icon mặc định nếu không khớp
                        break;
                }

                // THÊM EMOJI VÀO TRƯỚC TÊN DANH MỤC
                btn.Text = icon + " " + tenDanhMuc; // Ví dụ: "👕 Áo"
                                                    // Nếu bạn muốn có dấu chấm đầu dòng như trước, hãy thêm vào:
                                                    // btn.Text = "    • " + icon + " " + tenDanhMuc; 

                btn.Width = flpDanhMuc.Width - 25;
                btn.Height = 50;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9); // Font Segoe UI thường hỗ trợ Emoji rất tốt
                btn.Cursor = Cursors.Hand;
                btn.Tag = row["MaDanhMuc"].ToString();
                btn.Click += DanhMuc_Click;
                flpDanhMuc.Controls.Add(btn);
            }
        }


        // ==================== HÀM HIỂN THỊ CHUNG ====================
        // (Đây là hàm HienThiSanPham cũ, đã đổi tên)
        private void HienThiDanhSach(List<SanPham> ds)
        {
            flowSanPham.Controls.Clear();

            if (ds == null || ds.Count == 0)
            {
                Label lbl = new Label();
                lbl.Text = "Không có sản phẩm nào phù hợp!";
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lbl.ForeColor = Color.Gray;
                flowSanPham.Controls.Add(lbl);
                return;
            }

            foreach (SanPham sp in ds)
            {
                Panel pnl = TaoPanelSanPham(sp);
                flowSanPham.Controls.Add(pnl);
            }
        }

        // ==================== HÀM TẠO 1 PANEL SẢN PHẨM ====================
        private Panel TaoPanelSanPham(SanPham sp)
        {
            Panel pnlSP = new Panel();
            pnlSP.Width = 310;   // Tăng mạnh chiều rộng (Cũ: 255)
            pnlSP.Height = 480;  // Tăng chiều cao (Cũ: 380)
            pnlSP.BackColor = Color.MistyRose; // Giữ nguyên màu
            pnlSP.Margin = new Padding(20);    // Tăng khoảng cách viền (Margin) lên 20 cho thoáng
            pnlSP.Tag = sp;

            // 2. ẢNH SẢN PHẨM
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            string duongDan = Path.Combine(Application.StartupPath, sp.HinhAnh ?? "");
            if (File.Exists(duongDan))
                pic.Image = Image.FromFile(duongDan);

            // Ảnh vuông to: (310 - 20 padding) = 290
            pic.Width = 290;
            pic.Height = 290;
            pic.Top = 10;
            pic.Left = 10;
            pic.Cursor = Cursors.Hand;
            pic.Click += (s, e) => MoChiTietSanPham(pnlSP, e);

            // 3. TÊN SẢN PHẨM
            Label lblTen = new Label();
            lblTen.Text = sp.TenSanPham;
            lblTen.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Tăng font lên 12
            lblTen.ForeColor = Color.DeepPink;
            lblTen.AutoSize = false;
            lblTen.TextAlign = ContentAlignment.MiddleCenter;
            lblTen.Width = 290;
            lblTen.Height = 50; // Cho 2 dòng thoải mái
            lblTen.Top = pic.Bottom + 5;
            lblTen.Left = 10;
            lblTen.Click += (s, e) => MoChiTietSanPham(pnlSP, e);

            // 4. GIÁ SẢN PHẨM
            Label lblGia = new Label();
            lblGia.Text = sp.Gia.ToString("N0") + " VNĐ";
            lblGia.ForeColor = Color.HotPink;
            lblGia.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Tăng font lên 12
            lblGia.AutoSize = false;
            lblGia.TextAlign = ContentAlignment.MiddleCenter;
            lblGia.Width = 290;
            lblGia.Height = 30;
            lblGia.Top = lblTen.Bottom;
            lblGia.Left = 10;

            // --- 5. KHU VỰC CHỌN SIZE & SỐ LƯỢNG ---
            int controlY = lblGia.Bottom + 10;

            // Label "Size"
            Label lblS = new Label();
            lblS.Text = "Size:"; lblS.AutoSize = true;
            lblS.Font = new Font("Segoe UI", 9); // Tăng font
            lblS.Top = controlY + 3;
            lblS.Left = 30; // Căn lề trái rộng hơn

            // ComboBox chọn Size
            ComboBox cboSize = new ComboBox();
            cboSize.Items.AddRange(new object[] { "S", "M", "L", "XL" });
            cboSize.SelectedIndex = 0;
            cboSize.Width = 55;
            cboSize.Font = new Font("Segoe UI", 9);
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.Top = controlY;
            cboSize.Left = 75;
            cboSize.Name = "cboSize";

            // Label "SL"
            Label lblQ = new Label();
            lblQ.Text = "SL:"; lblQ.AutoSize = true;
            lblQ.Font = new Font("Segoe UI", 9);
            lblQ.Top = controlY + 3;
            lblQ.Left = 160;

            // Numeric chọn Số lượng
            NumericUpDown numSL = new NumericUpDown();
            numSL.Minimum = 1; numSL.Maximum = 100; numSL.Value = 1;
            numSL.Width = 55;
            numSL.Font = new Font("Segoe UI", 9);
            numSL.Top = controlY;
            numSL.Left = 195;
            numSL.Name = "numSL";

            // --- 6. CHECKBOX "CHỌN MUA" ---
            CheckBox chkChon = new CheckBox();
            chkChon.Text = "Chọn mua";
            chkChon.Name = "chkChonMua";
            chkChon.Font = new Font("Segoe UI", 11); // Tăng font
            chkChon.ForeColor = Color.Black;
            chkChon.AutoSize = true;
            chkChon.Tag = sp;

            // Căn giữa: (310 - 100) / 2 = 105
            chkChon.Left = 100;
            chkChon.Top = cboSize.Bottom + 10;

            // Thêm control con vào Panel
            pnlSP.Controls.Add(pic);
            pnlSP.Controls.Add(lblTen);
            pnlSP.Controls.Add(lblGia);
            pnlSP.Controls.Add(lblS);
            pnlSP.Controls.Add(cboSize);
            pnlSP.Controls.Add(lblQ);
            pnlSP.Controls.Add(numSL);
            pnlSP.Controls.Add(chkChon);

            return pnlSP;
        }

        // ==================== SỰ KIỆN CLICK LỌC DANH MỤC ====================
        private void DanhMuc_Click(object sender, EventArgs e)
        {
            Button btnDuocNhan = sender as Button;
            string maDM = btnDuocNhan.Tag.ToString();

            // Đổi màu nút (để người dùng biết đang chọn)
            foreach (Control ctrl in flpDanhMuc.Controls)
            {
                if (ctrl is Button)
                {
                    (ctrl as Button).ForeColor = Color.Black;
                }
            }
            btnDuocNhan.ForeColor = Color.DeepPink;

            // Lọc sản phẩm từ MASTER LIST
            List<SanPham> dsKetQua;

            if (maDM == "ALL")
            {
                dsKetQua = danhSachSanPham; // Lấy lại toàn bộ
            }
            else
            {
                // Dùng LINQ để lọc danh sách có sẵn
                dsKetQua = danhSachSanPham
                    .Where(sp => sp.MaDanhMuc == maDM)
                    .ToList();
            }

            // Hiển thị kết quả lọc
            HienThiDanhSach(dsKetQua);
        }

        // ==================== SỰ KIỆN CLICK NÚT TÌM KIẾM ====================
        private void btnTK_Click(object sender, EventArgs e)
        {
            // (Giả sử TextBox tên là txtTK)
            string tuKhoa = txtTK.Text.Trim().ToLower();

            // Nếu ô tìm kiếm trống, hiển thị lại toàn bộ
            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiDanhSach(danhSachSanPham);
                return;
            }

            // Dùng LINQ để lọc danh sách có sẵn
            var ketQua = danhSachSanPham
                .Where(sp => sp.TenSanPham.ToLower().Contains(tuKhoa))
                .ToList();

            // Hiển thị kết quả tìm kiếm
            HienThiDanhSach(ketQua);
        }

        // ==================== MỞ FORM CHI TIẾT SẢN PHẨM ====================
        private void MoChiTietSanPham(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel pnl = null;

            // Tìm Panel cha
            if (ctrl is Panel)
                pnl = ctrl as Panel;
            else if (ctrl.Parent is Panel)
                pnl = ctrl.Parent as Panel;
            else
            {
                Control p = ctrl.Parent;
                while (p != null && !(p is Panel))
                    p = p.Parent;
                pnl = p as Panel;
            }

            if (pnl == null || pnl.Tag == null) return;

            if (pnl.Tag is SanPham sp)
            {
                FormChiTietSanPham f = new FormChiTietSanPham(sp);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        // ==================== MỞ GIỎ HÀNG ====================
        private void picGioHang_Click(object sender, EventArgs e)
        {
            FormGioHang f = new FormGioHang();
            f.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = f.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                TaiLaiDuLieuSanPham();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void flpDanhMuc_Paint(object sender, PaintEventArgs e) { }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // 1. Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?", // Nội dung thông báo
                "Xác nhận đăng xuất",                  // Tiêu đề
                MessageBoxButtons.YesNo,                 // Các nút Yes/No
                MessageBoxIcon.Question                  // Icon câu hỏi
            );

            // 2. Kiểm tra người dùng bấm nút nào
            if (result == DialogResult.Yes)
            {
                // Nếu bấm "Yes":

                // 2a. Xóa thông tin đăng nhập (Rất quan trọng)
                StaticData.MaNguoiDungHienTai = 0;
                StaticData.TenNguoiDungHienTai = "";

                // 2b. Đóng FormTrangChu
                // (Code ở FormDangNhap sẽ tự động hiển thị lại FormDangNhap)
                this.Close();
            }
            // 3. Nếu bấm "No", không làm gì cả, hộp thoại tự đóng.
        }

        private void picLichSu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (StaticData.MaNguoiDungHienTai == 0)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem lịch sử mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // (Tùy chọn: Mở form đăng nhập nếu muốn)
                // FormDangNhap fLogin = new FormDangNhap();
                // fLogin.ShowDialog();
                return;
            }

            // Mở Form Lịch sử và truyền ID người dùng hiện tại vào
            FormLichSuMuaHang fLichSu = new FormLichSuMuaHang(StaticData.MaNguoiDungHienTai);
            fLichSu.StartPosition = FormStartPosition.CenterParent;
            fLichSu.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMuaNhieu_Click(object sender, EventArgs e)
        {
            int demSanPham = 0;

            // 1. DUYỆT VÀ THÊM VÀO GIỎ
            foreach (Control ctrlPnl in flowSanPham.Controls)
            {
                if (ctrlPnl is Panel pnl)
                {
                    // Tìm các control con
                    CheckBox chk = pnl.Controls["chkChonMua"] as CheckBox;
                    ComboBox cbo = pnl.Controls["cboSize"] as ComboBox;
                    NumericUpDown num = pnl.Controls["numSL"] as NumericUpDown;

                    // Nếu tìm thấy và được tích
                    if (chk != null && cbo != null && num != null && chk.Checked)
                    {
                        if (chk.Tag is SanPham sp)
                        {
                            string selectedSize = cbo.SelectedItem.ToString();
                            int selectedQty = (int)num.Value;

                            // Thêm vào giỏ hàng
                            ThemVaoGioHang(sp, selectedQty, selectedSize);
                            demSanPham++;
                        }
                    }
                }
            }

            // 2. XỬ LÝ SAU KHI THÊM
            if (demSanPham > 0)
            {
                // --- THAY ĐỔI Ở ĐÂY: KHÔNG HIỆN MESSAGEBOX NỮA ---

                // Mở luôn Form Giỏ hàng
                FormGioHang f = new FormGioHang();
                f.StartPosition = FormStartPosition.CenterParent;

                // ShowDialog sẽ dừng code ở đây cho đến khi bạn đóng Form Giỏ hàng
                DialogResult result = f.ShowDialog(this);

                // 3. SAU KHI ĐÓNG GIỎ HÀNG -> RESET GIAO DIỆN
                // Hàm này sẽ xóa hết các panel cũ và vẽ lại mới -> Mất hết các dấu tích đã chọn
                TaiLaiDuLieuSanPham();
            }
            else
            {
                MessageBox.Show("Bạn chưa tích chọn sản phẩm nào cả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hàm hỗ trợ thêm vào giỏ (Tách riêng cho gọn)
        private void ThemVaoGioHang(SanPham sp, int soLuong, string size)
        {
            // Kiểm tra xem đã có trong giỏ chưa (cùng ID và cùng Size)
            var spTonTai = StaticData.DanhSachGioHang
                .FirstOrDefault(x => x.MaSanPham == sp.MaSanPham && x.Size == size);

            if (spTonTai != null)
            {
                spTonTai.SoLuong += soLuong;
            }
            else
            {
                StaticData.DanhSachGioHang.Add(new GioHang
                {
                    MaSanPham = sp.MaSanPham,
                    TenSP = sp.TenSanPham,
                    Gia = sp.Gia,
                    HinhAnh = sp.HinhAnh,
                    Size = size, // Size mặc định
                    SoLuong = soLuong
                });
            }
        }
    }
}
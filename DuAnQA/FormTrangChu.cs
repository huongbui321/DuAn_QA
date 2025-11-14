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
            pnlSP.Width = 200;
            pnlSP.Height = 280;
            pnlSP.BackColor = Color.MistyRose;
            pnlSP.Margin = new Padding(10);
            pnlSP.Cursor = Cursors.Hand;

            // Ảnh sản phẩm
            PictureBox pic = new PictureBox();
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            string duongDan = Path.Combine(Application.StartupPath, sp.HinhAnh ?? "");
            if (File.Exists(duongDan))
                pic.Image = Image.FromFile(duongDan);
            pic.Width = 180;
            pic.Height = 180;
            pic.Top = 10;
            pic.Left = 10;
            pic.Cursor = Cursors.Hand;

            // Tên sản phẩm
            Label lblTen = new Label();
            lblTen.Text = sp.TenSanPham;
            lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTen.ForeColor = Color.DeepPink;
            lblTen.AutoSize = false;
            lblTen.TextAlign = ContentAlignment.MiddleCenter;
            lblTen.Width = pnlSP.Width - 10;
            lblTen.Height = 36;
            lblTen.Top = pic.Bottom + 5;
            lblTen.Left = (pnlSP.Width - lblTen.Width) / 2;
            lblTen.Cursor = Cursors.Hand;

            // Giá sản phẩm
            Label lblGia = new Label();
            lblGia.Text = sp.Gia.ToString("N0") + " VNĐ";
            lblGia.ForeColor = Color.HotPink;
            lblGia.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblGia.AutoSize = false;
            lblGia.TextAlign = ContentAlignment.MiddleCenter;
            lblGia.Width = pnlSP.Width - 10;
            lblGia.Height = 24;
            lblGia.Top = lblTen.Bottom + 2;
            lblGia.Left = (pnlSP.Width - lblGia.Width) / 2;
            lblGia.Cursor = Cursors.Hand;

            // Gắn sản phẩm vào panel
            pnlSP.Tag = sp;

            // Gắn sự kiện mở chi tiết
            pnlSP.Click += MoChiTietSanPham;
            pic.Click += MoChiTietSanPham;
            lblTen.Click += MoChiTietSanPham;
            lblGia.Click += MoChiTietSanPham;

            // Thêm control con
            pnlSP.Controls.Add(pic);
            pnlSP.Controls.Add(lblTen);
            pnlSP.Controls.Add(lblGia);

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
            f.ShowDialog();
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void flpDanhMuc_Paint(object sender, PaintEventArgs e) { }

    }
}
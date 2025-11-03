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
    public partial class FormTrangChu : Form
    {
        KetNoi kn = new KetNoi();
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            HienThiSanPham();
        }
        private void HienThiSanPham()
        {
            flowSanPham.Controls.Clear();
            List<SanPham> ds = kn.LayDanhSachSanPham();

            foreach (SanPham sp in ds)
            {
                // tạo bản sao cục bộ để tránh lỗi closure khi gán sự kiện trong vòng lặp
                SanPham spLocal = sp;

                Panel pnlSP = new Panel();
                pnlSP.Width = 200;
                pnlSP.Height = 280;
                pnlSP.BackColor = Color.MistyRose;
                pnlSP.Margin = new Padding(10);
                pnlSP.Cursor = Cursors.Hand; // con trỏ khi rê vào

                // Ảnh sản phẩm
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                string duongDan = Path.Combine(Application.StartupPath, spLocal.HinhAnh);
                if (File.Exists(duongDan))
                    pic.Image = Image.FromFile(duongDan);
                // nếu không có file, có thể gán ảnh mặc định hoặc để trống
                pic.Width = 180;
                pic.Height = 180;
                pic.Top = 10;
                pic.Left = 10;
                pic.Cursor = Cursors.Hand;

                // Tên sản phẩm
                Label lblTen = new Label();
                lblTen.Text = spLocal.TenSanPham;
                lblTen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTen.ForeColor = Color.DeepPink;
                lblTen.AutoSize = false;
                lblTen.TextAlign = ContentAlignment.MiddleCenter;
                lblTen.Width = pnlSP.Width - 10;
                lblTen.Height = 36; // cho phép xuống 2 dòng
                lblTen.Top = pic.Bottom + 5;
                lblTen.Left = (pnlSP.Width - lblTen.Width) / 2;
                lblTen.Cursor = Cursors.Hand;

                // Giá sản phẩm
                Label lblGia = new Label();
                lblGia.Text = spLocal.Gia.ToString("N0") + " VNĐ";
                lblGia.ForeColor = Color.HotPink;
                lblGia.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblGia.AutoSize = false;
                lblGia.TextAlign = ContentAlignment.MiddleCenter;
                lblGia.Width = pnlSP.Width - 10;
                lblGia.Height = 24;
                lblGia.Top = lblTen.Bottom + 2;
                lblGia.Left = (pnlSP.Width - lblGia.Width) / 2;
                lblGia.Cursor = Cursors.Hand;

                // Gán sản phẩm vào Tag của panel để lấy lại sau
                pnlSP.Tag = spLocal;

                // Gắn sự kiện Click cho panel và các control con
                // dùng cùng 1 handler để mở chi tiết
                pnlSP.Click += MoChiTietSanPham;
                pic.Click += MoChiTietSanPham;
                lblTen.Click += MoChiTietSanPham;
                lblGia.Click += MoChiTietSanPham;

                // Thêm control vào panel (thêm theo thứ tự: ảnh rồi tên rồi giá)
                pnlSP.Controls.Add(pic);
                pnlSP.Controls.Add(lblTen);
                pnlSP.Controls.Add(lblGia);

                // Thêm panel vào flowLayoutPanel
                flowSanPham.Controls.Add(pnlSP);
            }
        }
        private void MoChiTietSanPham(object sender, EventArgs e)
        {
            // Tìm panel chứa sản phẩm:
            Control ctrl = sender as Control;

            // Nếu người click là control con (PictureBox/Label), lấy parent panel
            Panel pnl = null;
            if (ctrl is Panel)
                pnl = ctrl as Panel;
            else if (ctrl.Parent is Panel)
                pnl = ctrl.Parent as Panel;
            else
            {
                // tìm lên parent thêm một cấp nữa (phòng trường hợp sâu hơn)
                Control p = ctrl.Parent;
                while (p != null && !(p is Panel))
                    p = p.Parent;
                pnl = p as Panel;
            }

            if (pnl == null) return;

            // Lấy sản phẩm từ Tag
            if (pnl.Tag is SanPham sp)
            {
                // Mở form chi tiết modal
                FormChiTietSanPham f = new FormChiTietSanPham(sp);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }
    }
}





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
    public partial class FormGioHang : Form
    {
        public FormGioHang()
        {
            InitializeComponent();
        }

        private void FormGioHang_Load(object sender, EventArgs e)
        {
            HienThiGioHang();
            flowGioHang.Controls.Add(labelTrong);
        }
        private void HienThiGioHang()
        {
            flowGioHang.Controls.Clear();
            decimal tongTien = 0;

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
                string path = Path.Combine(Application.StartupPath, sp.HinhAnh);
                if (File.Exists(path))
                    pic.Image = Image.FromFile(path);
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

                // Thành tiền
                Label lblThanhTien = new Label();
                lblThanhTien.Text = "Thành tiền: " + sp.ThanhTien.ToString("N0") + " VNĐ";
                lblThanhTien.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblThanhTien.ForeColor = Color.DarkRed;
                lblThanhTien.Left = 300;
                lblThanhTien.Top = 70;
                lblThanhTien.AutoSize = true;

                tongTien += sp.ThanhTien;

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
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (StaticData.DanhSachGioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, vui lòng thêm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn thanh toán giỏ hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            decimal tongTien = StaticData.DanhSachGioHang.Sum(x => x.ThanhTien);

            FormThanhToan f = new FormThanhToan(tongTien);
            f.StartPosition = FormStartPosition.CenterParent;

            if (f.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Thanh toán thành công! Cảm ơn bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticData.DanhSachGioHang.Clear();
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Label labelTrong = new Label();
            labelTrong.Text = "🛒 Giỏ hàng của bạn đang trống!";
            labelTrong.Font = new Font("Segoe UI", 14, FontStyle.Italic);
            labelTrong.ForeColor = Color.Gray;
            labelTrong.TextAlign = ContentAlignment.MiddleCenter;
            labelTrong.Dock = DockStyle.Fill;
        }
    }
}

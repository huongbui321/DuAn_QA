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


namespace DuAnQA
{
    public partial class FormChiTietSanPham : Form
    {
        private SanPham sp;
        public FormChiTietSanPham(SanPham sanPham)
        {
            InitializeComponent();
            sp = sanPham;
            btnMuaNgay.Click += btnMuaNgay_Click;
            btnThemGioHang.Click += btnThemGioHang_Click;
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

        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Mua ngay {numSoLuongMua.Value} sản phẩm {sp.TenSanPham} (Size {cboSize.Text})");
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{sp.TenSanPham} đã được thêm vào giỏ hàng!");
            var spTonTai = StaticData.DanhSachGioHang
       .FirstOrDefault(x => x.TenSP == sp.TenSanPham && x.Size == cboSize.Text);

            if (spTonTai != null)
            {
                spTonTai.SoLuong += (int)numSoLuongMua.Value;
            }
            else
            {
                // Nếu chưa có thì thêm mới
                GioHang item = new GioHang
                {
                    TenSP = sp.TenSanPham,
                    Gia = sp.Gia,
                    SoLuong = (int)numSoLuongMua.Value,
                    Size = cboSize.Text,
                    HinhAnh = sp.HinhAnh
                };
                StaticData.DanhSachGioHang.Add(item);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
            int soLuongMua = (int)numSoLuongMua.Value;
            string sizeChon = cboSize.Text;

            if (string.IsNullOrEmpty(sizeChon))
            {
                MessageBox.Show("Vui lòng chọn size sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem sản phẩm (với size cụ thể) đã có trong giỏ chưa
            // (Kiểm tra bằng MaSanPham và Size là chính xác nhất)
            var spTonTai = StaticData.DanhSachGioHang
                .FirstOrDefault(x => x.MaSanPham == sp.MaSanPham && x.Size == sizeChon);

            if (spTonTai != null)
            {
                // Nếu đã có: Chỉ cộng thêm số lượng
                spTonTai.SoLuong += soLuongMua;
                // Không cần gán ThanhTien, vì nó tự tính
            }
            else
            {
                // Nếu chưa có: Thêm mới
                GioHang item = new GioHang
                {
                    MaSanPham = sp.MaSanPham, // <-- Gán MaSanPham (quan trọng)
                    TenSP = sp.TenSanPham,
                    Gia = sp.Gia,
                    SoLuong = soLuongMua,
                    Size = sizeChon,
                    HinhAnh = sp.HinhAnh
                    // Không gán ThanhTien, vì nó tự tính
                };
                StaticData.DanhSachGioHang.Add(item);
            }

            // Thông báo sau khi đã thêm/cập nhật xong
            MessageBox.Show($"{sp.TenSanPham} (Size: {sizeChon}) đã được thêm vào giỏ hàng!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

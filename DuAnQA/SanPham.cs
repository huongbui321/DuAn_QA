using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    public class SanPham
    {
        public SanPham()
        {
        }

        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }


        public SanPham(int maSanPham, string tenSanPham, string moTa, decimal gia, int soLuong, string hinhAnh)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            MoTa = moTa;
            Gia = gia;
            SoLuong = soLuong;
            HinhAnh = hinhAnh;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    public class GioHang
    {
        public string HinhAnh { get; set; }
        public string TenSP { get; set; }
        public string Size { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public decimal ThanhTien => Gia * SoLuong;
        public int MaSanPham { get; set; }
    }
    }

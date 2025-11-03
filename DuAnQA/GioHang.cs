using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    internal class GioHang
    {
            public string TenSP { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
            public string Size { get; set; }

            public decimal ThanhTien => Gia * SoLuong;
        }
    }

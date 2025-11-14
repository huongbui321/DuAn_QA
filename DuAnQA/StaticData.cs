using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    public static class StaticData
    {
        public static List<GioHang> DanhSachGioHang = new List<GioHang>();

        public static int MaNguoiDungHienTai { get; set; } = 0;

        public static string TenNguoiDungHienTai { get; set; } = "";

    }
}
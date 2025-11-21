using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    public static class StaticData
    {
        // Biến lưu thông tin người dùng sau khi đăng nhập
        public static int MaNguoiDungHienTai = 0;
        public static string TenNguoiDungHienTai = "";

        // <<< THÊM BIẾN NÀY >>>
        public static string VaiTroHienTai = "";

        // Danh sách giỏ hàng (giữ nguyên)
        public static List<GioHang> DanhSachGioHang = new List<GioHang>();

    }
}
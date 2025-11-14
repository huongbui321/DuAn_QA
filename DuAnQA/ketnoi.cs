using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic; // Cần cho List<>

namespace DuAnQA
{
    internal class KetNoi
    {
        // 🔹 Chuỗi kết nối
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HuongieClothes;Integrated Security=True";

        // 🔹 Đối tượng kết nối
        public SqlConnection conn;

        // 🔹 Hàm khởi tạo
        public KetNoi()
        {
            conn = new SqlConnection(connectionString);
        }

        // 🔹 Hàm mở kết nối
        public void MoKetNoi()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        // 🔹 Hàm đóng kết nối
        public void DongKetNoi()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        // ✅ 1️⃣ Hàm đếm số dòng (SELECT COUNT(*))
        public int DemDong(string sql, params SqlParameter[] ts)
        {
            int kq = 0;
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ts != null)
                        cmd.Parameters.AddRange(ts);

                    kq = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi DemDong: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
            return kq;
        }

        // ✅ 2️⃣ Hàm thực thi INSERT, UPDATE, DELETE (Tự động Mở/Đóng)
        public int ThucThi(string sql, params SqlParameter[] ts)
        {
            int kq = 0;
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ts != null)
                        cmd.Parameters.AddRange(ts);

                    kq = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ThucThi: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
            return kq;
        }

        // ✅ 3️⃣ Hàm lấy dữ liệu SELECT trả về DataTable
        public DataTable LayDuLieu(string sql, params SqlParameter[] ts)
        {
            DataTable dt = new DataTable();
            try
            {
                MoKetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ts != null)
                        cmd.Parameters.AddRange(ts);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi LayDuLieu: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
            return dt;
        }

        // (Các hàm cũ của bạn)
        public List<SanPham> LayDanhSachSanPham()
        {
            List<SanPham> ds = new List<SanPham>();
            MoKetNoi();
            string sql = "SELECT * FROM SanPham";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = Convert.ToInt32(reader["MaSanPham"]);
                sp.TenSanPham = reader["TenSanPham"].ToString();
                sp.MoTa = reader["MoTa"].ToString();
                sp.Gia = Convert.ToDecimal(reader["Gia"]);
                sp.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                sp.HinhAnh = reader["HinhAnh"].ToString();
                if (reader["MaDanhMuc"] != DBNull.Value)
                    sp.MaDanhMuc = reader["MaDanhMuc"].ToString();
                else
                    sp.MaDanhMuc = null;
                ds.Add(sp);
            }
            reader.Close();
            DongKetNoi();
            return ds;
        }

        public DataTable LayTatCaDanhMuc()
        {
            string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
            return LayDuLieu(sql);
        }

        public List<SanPham> LaySanPhamTheoDanhMuc(string maDanhMuc)
        {
            List<SanPham> ds = new List<SanPham>();
            MoKetNoi();
            string sql = "SELECT * FROM SanPham WHERE MaDanhMuc = @maDM";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maDM", maDanhMuc);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = Convert.ToInt32(reader["MaSanPham"]);
                sp.TenSanPham = reader["TenSanPham"].ToString();
                sp.MoTa = reader["MoTa"].ToString();
                sp.Gia = Convert.ToDecimal(reader["Gia"]);
                sp.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                sp.HinhAnh = reader["HinhAnh"].ToString();
                if (reader["MaDanhMuc"] != DBNull.Value)
                    sp.MaDanhMuc = reader["MaDanhMuc"].ToString();
                ds.Add(sp);
            }
            reader.Close();
            DongKetNoi();
            return ds;
        }

        // ==========================================================
        // === 🚀 2 HÀM MỚI ĐƯỢC THÊM ĐỂ HỖ TRỢ TRANSACTION ===
        // ==========================================================

        /// <summary>
        /// ✅ 2b. Hàm thực thi (dành cho Transaction)
        /// Hàm này KHÔNG tự động Mở/Đóng kết nối, mà dùng Transaction có sẵn.
        /// </summary>
        public int ThucThi(string sql, SqlTransaction tran, params SqlParameter[] ts)
        {
            // Phải dùng connection và transaction từ bên ngoài truyền vào
            using (SqlCommand cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                if (ts != null)
                    cmd.Parameters.AddRange(ts);

                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable LayLichSuMuaHang(int maNguoiDung)
        {
            // Câu SQL này JOIN 3 bảng: DonHang, ChiTietDonHang, và SanPham
            string sql = @"
        SELECT 
            T1.NgayDat AS [Ngày đặt],
            T3.TenSanPham AS [Tên sản phẩm],
            T2.SoLuong AS [Số lượng],
            T2.DonGia AS [Đơn giá]
        FROM DonHang AS T1
        JOIN ChiTietDonHang AS T2 ON T1.MaDonHang = T2.MaDonHang
        JOIN SanPham AS T3 ON T2.MaSanPham = T3.MaSanPham
        WHERE
            T1.MaNguoiDung = @maND
        ORDER BY
            T1.NgayDat DESC"; // Sắp xếp theo ngày mới nhất

            // Dùng hàm LayDuLieu có sẵn của bạn
            return LayDuLieu(sql, new SqlParameter("@maND", maNguoiDung));
        }
        public object ThucThiLayScalar(string sql, SqlTransaction tran, params SqlParameter[] ts)
        {
            using (SqlCommand cmd = new SqlCommand(sql, tran.Connection, tran))
            {
                if (ts != null)
                    cmd.Parameters.AddRange(ts);

                return cmd.ExecuteScalar();
            }
        }
    }
}
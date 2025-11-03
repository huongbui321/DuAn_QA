using System;
using System.Data;
using Microsoft.Data.SqlClient;

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

        // ✅ 2️⃣ Hàm thực thi INSERT, UPDATE, DELETE
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

                ds.Add(sp);
            }

            reader.Close();
            DongKetNoi();
            return ds;
        }
    
}
}

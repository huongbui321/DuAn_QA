using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnQA
{
    internal class KetNoi
    {
        // 🔹 Khai báo chuỗi kết nối (connection string)
        private string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HuongieClothes;Integrated Security=True";

        // 🔹 Tạo đối tượng kết nối
        public SqlConnection conn;

        // 🔹 Hàm khởi tạo
        public KetNoi()
        {
            conn = new SqlConnection(connectionString);
        }

        // 🔹 Hàm mở kết nối
        public void MoKetNoi()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // 🔹 Hàm đóng kết nối
        public void DongKetNoi()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
   
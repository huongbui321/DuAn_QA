using Microsoft.Data.SqlClient;

using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;



namespace DuAnQA

{

    public partial class FormThanhToan : Form

    {

        private decimal tongTien;

        private string otpCode;



        public FormThanhToan()

        {

            InitializeComponent();

            this.tongTien = tongTien;

        }



        public FormThanhToan(decimal tongTien)

        {

            InitializeComponent();

            this.tongTien = tongTien;



            // Ví dụ: hiển thị tổng tiền lên label

            lblTongTien.Text = tongTien.ToString("C");

        }



        private void FormThanhToan_Load(object sender, EventArgs e)

        {

            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";



            // Tạo mã QR ngẫu nhiên (mã giả lập)

            otpCode = new Random().Next(100000, 999999).ToString();



            // Hiển thị hình QR (dùng link giả lập)

            picQR.ImageLocation = "https://api.qrserver.com/v1/create-qr-code/?data=ThanhToan" + otpCode + "&size=270x215";

        }



        private void btnXacNhan_Click(object sender, EventArgs e)

        {

            if (txtOTP.Text == otpCode)

            {

                MessageBox.Show("Xác thực thành công!");

                this.DialogResult = DialogResult.OK;

                this.Close();

            }

            else

            {

                MessageBox.Show("Mã OTP không đúng, vui lòng thử lại!");

            }

        }

    }



}
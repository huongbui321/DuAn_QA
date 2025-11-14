namespace DuAnQA
{
    partial class FormGioHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnQuayLai = new Button();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            flowGioHang = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(426, 62);
            label1.Name = "label1";
            label1.Size = new Size(359, 45);
            label1.TabIndex = 1;
            label1.Text = "Giỏ hàng của bạn\U0001f6d2";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(543, 458);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(0, 25);
            lblTongTien.TabIndex = 2;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(692, 520);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(112, 34);
            btnThanhToan.TabIndex = 3;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(382, 520);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(112, 34);
            btnQuayLai.TabIndex = 4;
            btnQuayLai.Text = "Quay lại ";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.Connection = null;
            sqlCommand2.Notification = null;
            sqlCommand2.Transaction = null;
            // 
            // flowGioHang
            // 
            flowGioHang.Location = new Point(74, 167);
            flowGioHang.Name = "flowGioHang";
            flowGioHang.Size = new Size(1032, 288);
            flowGioHang.TabIndex = 5;
            // 
            // FormGioHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(flowGioHang);
            Controls.Add(btnQuayLai);
            Controls.Add(btnThanhToan);
            Controls.Add(lblTongTien);
            Controls.Add(label1);
            Name = "FormGioHang";
            Text = "FormGioHang";
            Load += FormGioHang_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnQuayLai;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private FlowLayoutPanel flowGioHang;
        private Label labelTrong;
      
    }
}
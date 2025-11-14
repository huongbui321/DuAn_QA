namespace DuAnQA
{
    partial class FormLichSuMuaHang
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
            dgvLichSu = new DataGridView();
            label1 = new Label();
            btnQL = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).BeginInit();
            SuspendLayout();
            // 
            // dgvLichSu
            // 
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSu.BackgroundColor = Color.Azure;
            dgvLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSu.Location = new Point(95, 93);
            dgvLichSu.Name = "dgvLichSu";
            dgvLichSu.RowHeadersWidth = 62;
            dgvLichSu.RowTemplate.Height = 33;
            dgvLichSu.Size = new Size(1030, 497);
            dgvLichSu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.HotPink;
            label1.Location = new Point(447, 25);
            label1.Name = "label1";
            label1.Size = new Size(344, 45);
            label1.TabIndex = 1;
            label1.Text = "Lịch Sử Mua Hàng";
            // 
            // btnQL
            // 
            btnQL.Location = new Point(552, 606);
            btnQL.Name = "btnQL";
            btnQL.Size = new Size(112, 34);
            btnQL.TabIndex = 2;
            btnQL.Text = "Quay Lại";
            btnQL.UseVisualStyleBackColor = true;
            btnQL.Click += btnQL_Click;
            // 
            // FormLichSuMuaHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1203, 664);
            Controls.Add(btnQL);
            Controls.Add(label1);
            Controls.Add(dgvLichSu);
            Name = "FormLichSuMuaHang";
            Text = "FormLichSuMuaHang";
            Load += FormLichSuMuaHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLichSu;
        private Label label1;
        private Button btnQL;
    }
}
namespace DOANHEQTCSDL
{
    partial class KhachHang
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
            this.components = new System.ComponentModel.Container();
            this.dgv_KhachHang = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_XoaSua = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_Ho = new System.Windows.Forms.TextBox();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.txt_MaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TimSDT = new System.Windows.Forms.TextBox();
            this.txt_TimTen = new System.Windows.Forms.TextBox();
            this.txt_TimMaKH = new System.Windows.Forms.TextBox();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.cbb_MaNguoiDung = new System.Windows.Forms.ComboBox();
            this.txt_TongDH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).BeginInit();
            this.contextMenuStrip_XoaSua.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_KhachHang
            // 
            this.dgv_KhachHang.AllowUserToAddRows = false;
            this.dgv_KhachHang.AllowUserToResizeColumns = false;
            this.dgv_KhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_KhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KhachHang.ContextMenuStrip = this.contextMenuStrip_XoaSua;
            this.dgv_KhachHang.Location = new System.Drawing.Point(211, 41);
            this.dgv_KhachHang.Name = "dgv_KhachHang";
            this.dgv_KhachHang.RowHeadersWidth = 51;
            this.dgv_KhachHang.RowTemplate.Height = 24;
            this.dgv_KhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KhachHang.Size = new System.Drawing.Size(492, 239);
            this.dgv_KhachHang.TabIndex = 0;
            this.dgv_KhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KhachHang_CellClick);
            // 
            // contextMenuStrip_XoaSua
            // 
            this.contextMenuStrip_XoaSua.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_XoaSua.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Xoa});
            this.contextMenuStrip_XoaSua.Name = "contextMenuStrip_XoaSua";
            this.contextMenuStrip_XoaSua.Size = new System.Drawing.Size(105, 28);
            // 
            // toolStripMenuItem_Xoa
            // 
            this.toolStripMenuItem_Xoa.Name = "toolStripMenuItem_Xoa";
            this.toolStripMenuItem_Xoa.Size = new System.Drawing.Size(104, 24);
            this.toolStripMenuItem_Xoa.Text = "Xóa";
            this.toolStripMenuItem_Xoa.Click += new System.EventHandler(this.toolStripMenuItem_Xoa_Click);
            // 
            // txt_Ho
            // 
            this.txt_Ho.Location = new System.Drawing.Point(10, 80);
            this.txt_Ho.Name = "txt_Ho";
            this.txt_Ho.Size = new System.Drawing.Size(66, 22);
            this.txt_Ho.TabIndex = 1;
            // 
            // txt_Ten
            // 
            this.txt_Ten.Location = new System.Drawing.Point(128, 80);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(66, 22);
            this.txt_Ten.TabIndex = 2;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(10, 131);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(184, 22);
            this.txt_SDT.TabIndex = 3;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(10, 182);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(184, 22);
            this.txt_DiaChi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Họ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã Người dùng";
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(10, 325);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(73, 32);
            this.btn_Them.TabIndex = 11;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(401, 35);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(73, 32);
            this.btn_TimKiem.TabIndex = 14;
            this.btn_TimKiem.Text = "Tìm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Location = new System.Drawing.Point(10, 29);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.ReadOnly = true;
            this.txt_MaKH.Size = new System.Drawing.Size(100, 22);
            this.txt_MaKH.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mã KH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(325, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 29);
            this.label7.TabIndex = 17;
            this.label7.Text = "Danh Sách Khách Hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_TimSDT);
            this.groupBox1.Controls.Add(this.txt_TimTen);
            this.groupBox1.Controls.Add(this.txt_TimMaKH);
            this.groupBox1.Controls.Add(this.btn_TimKiem);
            this.groupBox1.Location = new System.Drawing.Point(211, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 80);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Số điện thoại";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mã KH";
            // 
            // txt_TimSDT
            // 
            this.txt_TimSDT.Location = new System.Drawing.Point(259, 45);
            this.txt_TimSDT.Name = "txt_TimSDT";
            this.txt_TimSDT.Size = new System.Drawing.Size(102, 22);
            this.txt_TimSDT.TabIndex = 17;
            // 
            // txt_TimTen
            // 
            this.txt_TimTen.Location = new System.Drawing.Point(141, 45);
            this.txt_TimTen.Name = "txt_TimTen";
            this.txt_TimTen.Size = new System.Drawing.Size(102, 22);
            this.txt_TimTen.TabIndex = 16;
            // 
            // txt_TimMaKH
            // 
            this.txt_TimMaKH.Location = new System.Drawing.Point(23, 45);
            this.txt_TimMaKH.Name = "txt_TimMaKH";
            this.txt_TimMaKH.Size = new System.Drawing.Size(102, 22);
            this.txt_TimMaKH.TabIndex = 15;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(121, 325);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(73, 32);
            this.btn_Sua.TabIndex = 20;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // cbb_MaNguoiDung
            // 
            this.cbb_MaNguoiDung.FormattingEnabled = true;
            this.cbb_MaNguoiDung.Location = new System.Drawing.Point(10, 233);
            this.cbb_MaNguoiDung.Name = "cbb_MaNguoiDung";
            this.cbb_MaNguoiDung.Size = new System.Drawing.Size(184, 24);
            this.cbb_MaNguoiDung.TabIndex = 21;
            // 
            // txt_TongDH
            // 
            this.txt_TongDH.Location = new System.Drawing.Point(10, 286);
            this.txt_TongDH.Name = "txt_TongDH";
            this.txt_TongDH.ReadOnly = true;
            this.txt_TongDH.Size = new System.Drawing.Size(184, 22);
            this.txt_TongDH.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Số lượng đơn hàng";
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 427);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_TongDH);
            this.Controls.Add(this.cbb_MaNguoiDung);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_MaKH);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.txt_Ten);
            this.Controls.Add(this.txt_Ho);
            this.Controls.Add(this.dgv_KhachHang);
            this.Name = "KhachHang";
            this.Text = "KhachHang";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).EndInit();
            this.contextMenuStrip_XoaSua.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_KhachHang;
        private System.Windows.Forms.TextBox txt_Ho;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.TextBox txt_MaKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_XoaSua;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Xoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.ComboBox cbb_MaNguoiDung;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_TimSDT;
        private System.Windows.Forms.TextBox txt_TimTen;
        private System.Windows.Forms.TextBox txt_TimMaKH;
        private System.Windows.Forms.TextBox txt_TongDH;
        private System.Windows.Forms.Label label11;
    }
}
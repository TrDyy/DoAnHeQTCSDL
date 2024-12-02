namespace DOANHEQTCSDL
{
    partial class SanPham
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
            this.dgv_sp = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic_sp = new System.Windows.Forms.PictureBox();
            this.cbo_loaisp = new System.Windows.Forms.ComboBox();
            this.lb_phanloai = new System.Windows.Forms.Label();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn__luu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tensp = new System.Windows.Forms.TextBox();
            this.txt_giagoc = new System.Windows.Forms.TextBox();
            this.txt_mota = new System.Windows.Forms.TextBox();
            this.cbo_gioitinh = new System.Windows.Forms.ComboBox();
            this.lb_thuonghieu = new System.Windows.Forms.Label();
            this.cbo_thuonghieu = new System.Windows.Forms.ComboBox();
            this.btn_gtb = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_sp
            // 
            this.dgv_sp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.GiaBan,
            this.GioiTinh,
            this.Mota});
            this.dgv_sp.Location = new System.Drawing.Point(12, 100);
            this.dgv_sp.Name = "dgv_sp";
            this.dgv_sp.RowHeadersWidth = 51;
            this.dgv_sp.RowTemplate.Height = 24;
            this.dgv_sp.Size = new System.Drawing.Size(446, 350);
            this.dgv_sp.TabIndex = 0;
            this.dgv_sp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sp_CellClick);
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã SP";
            this.MaSanPham.MinimumWidth = 6;
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.Width = 70;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.Width = 125;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá bán";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 110;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 125;
            // 
            // Mota
            // 
            this.Mota.DataPropertyName = "Mota";
            this.Mota.HeaderText = "Mô tả";
            this.Mota.MinimumWidth = 6;
            this.Mota.Name = "Mota";
            this.Mota.Width = 125;
            // 
            // pic_sp
            // 
            this.pic_sp.Location = new System.Drawing.Point(561, 21);
            this.pic_sp.Name = "pic_sp";
            this.pic_sp.Size = new System.Drawing.Size(199, 151);
            this.pic_sp.TabIndex = 1;
            this.pic_sp.TabStop = false;
            // 
            // cbo_loaisp
            // 
            this.cbo_loaisp.FormattingEnabled = true;
            this.cbo_loaisp.Location = new System.Drawing.Point(12, 50);
            this.cbo_loaisp.Name = "cbo_loaisp";
            this.cbo_loaisp.Size = new System.Drawing.Size(143, 32);
            this.cbo_loaisp.TabIndex = 2;
            this.cbo_loaisp.SelectedValueChanged += new System.EventHandler(this.cbo_loaisp_SelectedValueChanged);
            // 
            // lb_phanloai
            // 
            this.lb_phanloai.AutoSize = true;
            this.lb_phanloai.Location = new System.Drawing.Point(12, 21);
            this.lb_phanloai.Name = "lb_phanloai";
            this.lb_phanloai.Size = new System.Drawing.Size(105, 25);
            this.lb_phanloai.TabIndex = 3;
            this.lb_phanloai.Text = "Phân loại:";
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(323, 49);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(151, 29);
            this.btn_all.TabIndex = 4;
            this.btn_all.Text = "Tất cả sản phẩm";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(488, 403);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(78, 27);
            this.btn_them.TabIndex = 5;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn__luu
            // 
            this.btn__luu.Location = new System.Drawing.Point(601, 403);
            this.btn__luu.Name = "btn__luu";
            this.btn__luu.Size = new System.Drawing.Size(78, 27);
            this.btn__luu.TabIndex = 6;
            this.btn__luu.Text = "Lưu";
            this.btn__luu.UseVisualStyleBackColor = true;
            this.btn__luu.Click += new System.EventHandler(this.btn__luu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Giá gốc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mô tả:";
            // 
            // txt_tensp
            // 
            this.txt_tensp.Location = new System.Drawing.Point(628, 197);
            this.txt_tensp.Name = "txt_tensp";
            this.txt_tensp.Size = new System.Drawing.Size(192, 32);
            this.txt_tensp.TabIndex = 12;
            // 
            // txt_giagoc
            // 
            this.txt_giagoc.Location = new System.Drawing.Point(628, 244);
            this.txt_giagoc.Name = "txt_giagoc";
            this.txt_giagoc.Size = new System.Drawing.Size(192, 32);
            this.txt_giagoc.TabIndex = 13;
            // 
            // txt_mota
            // 
            this.txt_mota.Location = new System.Drawing.Point(628, 344);
            this.txt_mota.Name = "txt_mota";
            this.txt_mota.Size = new System.Drawing.Size(192, 32);
            this.txt_mota.TabIndex = 14;
            // 
            // cbo_gioitinh
            // 
            this.cbo_gioitinh.FormattingEnabled = true;
            this.cbo_gioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Unisex"});
            this.cbo_gioitinh.Location = new System.Drawing.Point(628, 294);
            this.cbo_gioitinh.Name = "cbo_gioitinh";
            this.cbo_gioitinh.Size = new System.Drawing.Size(192, 32);
            this.cbo_gioitinh.TabIndex = 15;
            // 
            // lb_thuonghieu
            // 
            this.lb_thuonghieu.AutoSize = true;
            this.lb_thuonghieu.Location = new System.Drawing.Point(166, 21);
            this.lb_thuonghieu.Name = "lb_thuonghieu";
            this.lb_thuonghieu.Size = new System.Drawing.Size(139, 25);
            this.lb_thuonghieu.TabIndex = 17;
            this.lb_thuonghieu.Text = "Thương hiệu:";
            // 
            // cbo_thuonghieu
            // 
            this.cbo_thuonghieu.FormattingEnabled = true;
            this.cbo_thuonghieu.Location = new System.Drawing.Point(161, 50);
            this.cbo_thuonghieu.Name = "cbo_thuonghieu";
            this.cbo_thuonghieu.Size = new System.Drawing.Size(156, 32);
            this.cbo_thuonghieu.TabIndex = 16;
            this.cbo_thuonghieu.SelectedValueChanged += new System.EventHandler(this.cbo_thuonghieu_SelectedValueChanged);
            // 
            // btn_gtb
            // 
            this.btn_gtb.Location = new System.Drawing.Point(323, 15);
            this.btn_gtb.Name = "btn_gtb";
            this.btn_gtb.Size = new System.Drawing.Size(151, 27);
            this.btn_gtb.TabIndex = 18;
            this.btn_gtb.Text = "TB Sản phẩm";
            this.btn_gtb.UseVisualStyleBackColor = true;
            this.btn_gtb.Click += new System.EventHandler(this.btn_gtb_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(714, 403);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(78, 27);
            this.btn_xoa.TabIndex = 19;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 459);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_gtb);
            this.Controls.Add(this.lb_thuonghieu);
            this.Controls.Add(this.cbo_thuonghieu);
            this.Controls.Add(this.cbo_gioitinh);
            this.Controls.Add(this.txt_mota);
            this.Controls.Add(this.txt_giagoc);
            this.Controls.Add(this.txt_tensp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn__luu);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.lb_phanloai);
            this.Controls.Add(this.cbo_loaisp);
            this.Controls.Add(this.pic_sp);
            this.Controls.Add(this.dgv_sp);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SanPham";
            this.Load += new System.EventHandler(this.SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_sp;
        private System.Windows.Forms.PictureBox pic_sp;
        private System.Windows.Forms.ComboBox cbo_loaisp;
        private System.Windows.Forms.Label lb_phanloai;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn__luu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tensp;
        private System.Windows.Forms.TextBox txt_giagoc;
        private System.Windows.Forms.TextBox txt_mota;
        private System.Windows.Forms.ComboBox cbo_gioitinh;
        private System.Windows.Forms.Label lb_thuonghieu;
        private System.Windows.Forms.ComboBox cbo_thuonghieu;
        private System.Windows.Forms.Button btn_gtb;
        private System.Windows.Forms.Button btn_xoa;
    }
}
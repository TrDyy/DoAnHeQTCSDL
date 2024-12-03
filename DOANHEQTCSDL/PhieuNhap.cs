using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KETNOI;
namespace DOANHEQTCSDL
{
    public partial class PhieuNhap : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_phieuNhap = new DataTable();
        DataTable dt_chiTietPhieuNhap = new DataTable();

        public PhieuNhap()
        {
            InitializeComponent();
        }

        private void PhieuNhap_Load_1(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            dgv_phieuNhap.CellClick += dgv_phieuNhap_CellClick;
            LoadTongTien();
        }


        /// <summary>
        /// Hiển thị danh sách phiếu nhập từ cơ sở dữ liệu
        /// </summary>
        public void LoadPhieuNhap()
        {
            string sql = @"
            SELECT pn.MaPhieuNhap, nc.TenNhaCungCap, pn.NgayNhap, pn.TongTien
            FROM 
            PhieuNhap pn
            JOIN 
            NhaCungCap nc ON pn.MaNhaCungCap = nc.MaNhaCungCap";

            dt_phieuNhap = db.getDataTable(sql);
            dgv_phieuNhap.DataSource = dt_phieuNhap;

            // Tùy chỉnh DataGridView
            dgv_phieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
            dgv_phieuNhap.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp"; // Tên nhà cung cấp
            dgv_phieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgv_phieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";

            dgv_phieuNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_phieuNhap.Columns["TongTien"].DefaultCellStyle.Format = "C0";
            dgv_phieuNhap.Columns["TongTien"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");// Định dạng tiền tệ
        }


        /// <summary>
        /// Hiển thị chi tiết phiếu nhập khi chọn phiếu nhập
        /// </summary>
        /// <param name="maPhieuNhap">Mã phiếu nhập được chọn</param>
        //        public void LoadChiTietPhieuNhap(int maPhieuNhap)
        //        {
        //            string sql = @"
        //                SELECT 
        //                    MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap 
        //                FROM ChiTietPhieuNhap 
        //                WHERE MaPhieuNhap = " + maPhieuNhap;

        //            dt_chiTietPhieuNhap = db.getDataTable(sql);
        //            dgv_chiTietPhieuNhap.DataSource = dt_chiTietPhieuNhap;

        //            // Tùy chỉnh DataGridView
        //            dgv_chiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
        //            dgv_chiTietPhieuNhap.Columns["MaMauSac"].HeaderText = "Mã Màu Sắc";
        //            dgv_chiTietPhieuNhap.Columns["MaKichThuoc"].HeaderText = "Mã Kích Thước";
        //            dgv_chiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
        //            dgv_chiTietPhieuNhap.Columns["GiaNhap"].HeaderText = "Giá Nhập";

        //            dgv_chiTietPhieuNhap.Columns["GiaNhap"].DefaultCellStyle.Format = "C2"; // Định dạng tiền tệ
        //        }
        public void LoadChiTietPhieuNhap(int maPhieuNhap)
        {
            string sql = @"
        SELECT 
            ctpn.MaSanPham, 
            sp.TenSanPham, 
            ms.TenMauSac AS TenMau, 
            kt.TenKichThuoc AS TenKichThuoc, 
            ctpn.SoLuong, 
            ctpn.GiaNhap
        FROM 
            ChiTietPhieuNhap ctpn
        JOIN 
            SanPham sp ON ctpn.MaSanPham = sp.MaSanPham
        JOIN 
            MauSac ms ON ctpn.MaMauSac = ms.MaMauSac
        JOIN 
            KichThuoc kt ON ctpn.MaKichThuoc = kt.MaKichThuoc
        WHERE 
            ctpn.MaPhieuNhap = " + maPhieuNhap;

            dt_chiTietPhieuNhap = db.getDataTable(sql);

            if (dt_chiTietPhieuNhap.Rows.Count > 0)
            {
                dgv_chiTietPhieuNhap.DataSource = dt_chiTietPhieuNhap;

                // Cấu hình tiêu đề cột
                dgv_chiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                dgv_chiTietPhieuNhap.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dgv_chiTietPhieuNhap.Columns["TenMau"].HeaderText = "Màu Sắc";
                dgv_chiTietPhieuNhap.Columns["TenKichThuoc"].HeaderText = "Kích Thước";
                dgv_chiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgv_chiTietPhieuNhap.Columns["GiaNhap"].HeaderText = "Giá Nhập";

                // Định dạng cột tiền tệ
                dgv_chiTietPhieuNhap.Columns["GiaNhap"].DefaultCellStyle.Format = "C0";
                dgv_chiTietPhieuNhap.Columns["GiaNhap"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
            }
            else
            {
                MessageBox.Show("Không có chi tiết phiếu nhập nào.");
            }
        }

        /// <summary>
        /// Sự kiện khi người dùng chọn một hàng trong danh sách phiếu nhập
        /// </summary>
        private void dgv_phieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Lấy mã phiếu nhập từ hàng được chọn
                    int maPhieuNhap = Convert.ToInt32(dgv_phieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value);
                    LoadChiTietPhieuNhap(maPhieuNhap); // Hiển thị chi tiết phiếu nhập

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết phiếu nhập: " + ex.Message);
            }
        }

        //public void LoadTongTien()
        //{
        //    string sql = "SELECT dbo.TinhTongTienTatCaPhieuNhap()"; // Gọi hàm tính tổng tiền
        //    object result = db.getValue(sql); // Lấy kết quả trả về từ hàm

        //    if (result != DBNull.Value)
        //    {
        //        decimal tongTien = Convert.ToDecimal(result);
        //        txtTongTien.Text = tongTien.ToString("C2"); // Hiển thị vào TextBox
        //    }
        //    else
        //    {
        //        txtTongTien.Text = "0.00"; // Nếu không có dữ liệu, hiển thị 0
        //    }
        //}

        public void LoadTongTien()
        {
            string sql = "SELECT dbo.TinhTongTienTatCaPhieuNhap()"; // Gọi hàm tính tổng tiền trong cơ sở dữ liệu

            try
            {
                // Sử dụng phương thức getExecuteScalar để lấy giá trị tổng tiền
                object result = db.getExecuteScalar(sql);

                // Kiểm tra nếu giá trị trả về là NULL
                if (result != DBNull.Value && result != null)
                {
                    decimal tongTien = Convert.ToDecimal(result);  // Chuyển giá trị trả về thành kiểu decimal
                    txtTongTien.Text = tongTien.ToString("#,0") + " VND";  // Hiển thị giá trị vào TextBox với định dạng tiền tệ và thêm "VND"
                }
                else
                {
                    txtTongTien.Text = "0 VND";  // Nếu không có kết quả, hiển thị 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng tiền: " + ex.Message); // Xử lý lỗi
            }
        }


        private void btnThemPN_Click(object sender, EventArgs e)
        {
            ThemPhieuNhap gd = new ThemPhieuNhap();
            gd.Show();
           
        }

       
    }
}

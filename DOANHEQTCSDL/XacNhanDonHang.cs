using KETNOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANHEQTCSDL
{
    public partial class XacNhanDonHang : Form
    {
        DBConnect db = new DBConnect();
        public XacNhanDonHang(string tenKhachHang, string thanhToan, DataTable tempDataTable, string kiemTra)
        {
            InitializeComponent();

            // Hiển thị dữ liệu trên Form mới
            txtTenKH.Text = tenKhachHang;
            txtThanhTien.Text = thanhToan;
            dgvSanPham.DataSource = tempDataTable;
            if (kiemTra == "Mua tại cửa hàng")
            {
                // Gán giá trị địa chỉ và khóa chỉnh sửa

                txtDiaChiGiaoNhan.Text = "Mua tại cửa hàng";
                txtDiaChiGiaoNhan.ReadOnly = true;
            }
            else
            {
                // Mở khóa chỉnh sửa địa chỉ
                txtDiaChiGiaoNhan.Text = string.Empty;
                txtDiaChiGiaoNhan.ReadOnly = false;
            }

            // Thiết lập ngày đặt là ngày hiện tại
            txtThoiGianDat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void XacNhanDonHang_Load(object sender, EventArgs e)
        {

        }


        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Truy vấn lấy thông tin màu sắc, kích thước và hình ảnh
                string layMaKH = "SELECT MaKhachHang From KhachHang " +
                    "Where dbo.HoVaTen(Ho, Ten) = @TenKhachHang ";

                var maKHValue = new Dictionary<string, object>
                {
                    { "@TenKhachHang", txtTenKH.Text }
                };

                

                // Lấy thông tin từ form
                int maKhachHang = Convert.ToInt32(db.getExecuteScalarWithParams(layMaKH, maKHValue));  // Giả sử đã chọn khách hàng trong ComboBox
                string trangThaiDonHang;
                if (txtDiaChiGiaoNhan.Text != "Mua tại cửa hàng")
                {
                    trangThaiDonHang = "Đang chờ xử lý";
                }
                else
                {
                    trangThaiDonHang = "Hoàn thành";
                }

                // Tạo DataTable để lưu chi tiết đơn hàng
                DataTable chiTietDonHangTable = new DataTable();
                chiTietDonHangTable.Columns.Add("MaSanPham", typeof(int));
                chiTietDonHangTable.Columns.Add("SoLuong", typeof(int));
                chiTietDonHangTable.Columns.Add("ThanhTien", typeof(decimal));
                chiTietDonHangTable.Columns.Add("MaMauSac", typeof(int));
                chiTietDonHangTable.Columns.Add("MaKichThuoc", typeof(int));
                // Lấy dữ liệu từ GridView
                // Duyệt qua tempDataTable để thêm vào chiTietDonHangTable
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    // Kiểm tra nếu dòng không phải là dòng mới (dòng ảo)
                    if (!row.IsNewRow)
                    {
                        // Kiểm tra nếu tất cả các ô quan trọng đều có giá trị hợp lệ
                        if (row.Cells["MaSanPham"].Value != null && row.Cells["Số Lượng"].Value != null && row.Cells["Giá Bán"].Value != null)
                        {
                            try
                            {
                                int maSanPham = Convert.ToInt32(row.Cells["MaSanPham"].Value);
                                int soLuong = Convert.ToInt32(row.Cells["Số Lượng"].Value);
                                decimal giaBan = Convert.ToDecimal(row.Cells["Giá Bán"].Value);
                                decimal thanhTien = soLuong * giaBan;

                                // Kiểm tra các ô khác, đảm bảo không có lỗi khi lấy giá trị
                                int maMauSac = GetMaMauSac(row.Cells["Màu Sắc"].Value.ToString());
                                int maKichThuoc = GetMaKichThuoc(row.Cells["Kích Thước"].Value.ToString());

                                // Thêm dữ liệu vào DataTable chi tiết đơn hàng
                                chiTietDonHangTable.Rows.Add(maSanPham, soLuong, thanhTien, maMauSac, maKichThuoc);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi xử lý dữ liệu dòng: " + ex.Message);
                            }
                        }
                    }
                }
                
               

                // Gọi stored procedure qua EXEC
                string query = "EXEC sp_ThemDonHangMoi @MaKhachHang, @DiaChiGiaoHang, @TrangThaiDonHang, @ChiTietDonHang";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@MaKhachHang", maKhachHang },
                    { "@DiaChiGiaoHang", txtDiaChiGiaoNhan.Text },
                    { "@TrangThaiDonHang", trangThaiDonHang },
                    { "@ChiTietDonHang",chiTietDonHangTable } // Dữ liệu chi tiết đơn hàng
                };
                string typeName = "dbo.ChiTietDonHangType";

                // Thực thi câu lệnh SQL
                int result = (int)db.getExecuteNonQueryWithParams(query, parameters, typeName);

                if (result > 0)
                {
                    MessageBox.Show("Thêm đơn hàng thành công!");
                    this.Close() ;
                }
                else
                {
                    MessageBox.Show("Thêm đơn hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message);
            }
        }


        private int GetMaMauSac(string tenMauSac)
        {
            string query = "SELECT MaMauSac FROM MauSac WHERE TenMauSac = @TenMauSac";
            var parameters = new Dictionary<string, object>
            {
                { "@TenMauSac", tenMauSac }
            };
            DataTable dt = db.getDataTableWithParams(query, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["MaMauSac"]) : 0;
        }

        // Hàm lấy mã kích thước từ tên kích thước
        private int GetMaKichThuoc(string tenKichThuoc)
        {
            string query = "SELECT MaKichThuoc FROM KichThuoc WHERE TenKichThuoc = @TenKichThuoc";
            var parameters = new Dictionary<string, object>
            {
                { "@TenKichThuoc", tenKichThuoc }
            };
            DataTable dt = db.getDataTableWithParams(query, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["MaKichThuoc"]) : 0;
        }

      
    }
}

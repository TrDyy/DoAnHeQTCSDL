using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using KETNOI;

namespace DOANHEQTCSDL
{
    public partial class ThemPhieuNhap : Form
    {
        DBConnect db = new DBConnect();

        public ThemPhieuNhap()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void ThemPhieuNhap_Load_1(object sender, EventArgs e)
        {
            LoadComboBox("SELECT MaSanPham, TenSanPham FROM SanPham", cbTenSanPham, "MaSanPham", "TenSanPham");
            LoadComboBox("SELECT MaMauSac, TenMauSac FROM MauSac", cbMauSac, "MaMauSac", "TenMauSac");
            LoadComboBox("SELECT MaKichThuoc, TenKichThuoc FROM KichThuoc", cbKichThuoc, "MaKichThuoc", "TenKichThuoc");
            LoadComboBox("SELECT MaNhaCungCap,TenNhaCungCap FROM NhaCungCap", cbPhieuNhap, "MaNhaCungCap", "TenNhaCungCap");

        }

        private void LoadComboBox(string query, ComboBox comboBox, string valueMember, string displayMember)
        {
            try
            {
                // Lấy dữ liệu
                DataTable dt = db.getDataTable(query);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show(string.Format("Không có dữ liệu để tải vào {0}.", comboBox.Name));
                    return;
                }

                // Reset ComboBox trước khi gán
                comboBox.DataSource = null;
                comboBox.DataSource = dt;
                comboBox.ValueMember = valueMember;
                comboBox.DisplayMember = displayMember;


            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi tải dữ liệu vào {0}: {1}", comboBox.Name, ex.Message));
            }
        }



        private void InitializeDataGridView()
        {
            dgvChiTietPhieuNhap.ColumnCount = 10;  // Tổng số cột
            dgvChiTietPhieuNhap.Columns[0].Name = "Mã nhà cung cấp";  // Cột mã nhà cung cấp
            dgvChiTietPhieuNhap.Columns[1].Name = "Tên nhà cung cấp"; // Cột tên nhà cung cấp
            dgvChiTietPhieuNhap.Columns[2].Name = "Mã sản phẩm";
            dgvChiTietPhieuNhap.Columns[3].Name = "Tên sản phẩm";
            dgvChiTietPhieuNhap.Columns[4].Name = "Mã màu sắc";
            dgvChiTietPhieuNhap.Columns[5].Name = "Tên màu sắc";
            dgvChiTietPhieuNhap.Columns[6].Name = "Mã kích thước";
            dgvChiTietPhieuNhap.Columns[7].Name = "Tên kích thước";
            dgvChiTietPhieuNhap.Columns[8].Name = "Số lượng";
            dgvChiTietPhieuNhap.Columns[9].Name = "Giá nhập";
        }


        private void btn_ThemCTPN_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các ComboBox và TextBox
                string maSanPham = cbTenSanPham.SelectedValue.ToString();
                string tenSanPham = cbTenSanPham.Text;
                string maMauSac = cbMauSac.SelectedValue.ToString();
                string tenMauSac = cbMauSac.Text;
                string maKichThuoc = cbKichThuoc.SelectedValue.ToString();
                string tenKichThuoc = cbKichThuoc.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                decimal giaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                // Lấy mã và tên nhà cung cấp từ ComboBox
                string maNhaCungCap = cbPhieuNhap.SelectedValue.ToString();
                string tenNhaCungCap = cbPhieuNhap.Text;

                // Thêm dòng vào DataGridView, mã và tên nhà cung cấp ở đầu
                dgvChiTietPhieuNhap.Rows.Add(maNhaCungCap, tenNhaCungCap, maSanPham, tenSanPham, maMauSac, tenMauSac, maKichThuoc, tenKichThuoc, soLuong, giaNhap);
                CalculateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }



        //Phương thức lấy mã phiếu nhập tự động
        private int LayMaPhieuNhapTuDong()
        {
            try
            {
                string query = @"SELECT MAX(MaPhieuNhap) + 1 FROM PhieuNhap"; // Lấy mã phiếu nhập mới nhất và cộng thêm 1
                SqlCommand cmd = new SqlCommand(query, db.conn);

                if (db.conn.State == ConnectionState.Closed)
                {
                    db.conn.Open();
                }

                // Trả về mã phiếu nhập mới
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã phiếu nhập: " + ex.Message);
                return 0; // Trả về 0 nếu lỗi
            }
            finally
            {
                if (db.conn.State == ConnectionState.Open)
                {
                    db.conn.Close();
                }
            }
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong DataGridView không
            if (dgvChiTietPhieuNhap.SelectedRows.Count > 0)
            {
                try
                {
                    // Lấy chỉ số dòng đã chọn
                    int rowIndex = dgvChiTietPhieuNhap.SelectedRows[0].Index;

                    // Lấy mã phiếu nhập từ dòng đã chọn (nếu cần để xóa trong cơ sở dữ liệu)
                    int maSanPham = Convert.ToInt32(dgvChiTietPhieuNhap.Rows[rowIndex].Cells[2].Value);
                    int maMauSac = Convert.ToInt32(dgvChiTietPhieuNhap.Rows[rowIndex].Cells[4].Value);
                    int maKichThuoc = Convert.ToInt32(dgvChiTietPhieuNhap.Rows[rowIndex].Cells[6].Value);

                    // Câu lệnh SQL để xóa dữ liệu từ cơ sở dữ liệu
                    string query = "DELETE FROM ChiTietPhieuNhap WHERE MaSanPham = @MaSanPham AND MaMauSac = @MaMauSac AND MaKichThuoc = @MaKichThuoc";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmd.Parameters.AddWithValue("@MaMauSac", maMauSac);
                    cmd.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);

                    // Mở kết nối và thực hiện câu lệnh xóa
                    if (db.conn.State == ConnectionState.Closed)
                    {
                        db.conn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    db.conn.Close();

                    // Sau khi xóa, xóa dòng trong DataGridView
                    dgvChiTietPhieuNhap.Rows.RemoveAt(rowIndex);
                    CalculateTotalAmount();

                    MessageBox.Show("Xóa hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hàng: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
            }
        }




        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            // Duyệt qua tất cả các dòng trong DataGridView để tính tổng tiền
            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                // Kiểm tra nếu cột "Số lượng" và "Giá nhập" không rỗng
                if (row.Cells[8].Value != null && row.Cells[9].Value != null)
                {
                    try
                    {
                        int quantity = Convert.ToInt32(row.Cells[8].Value);  // Số lượng
                        decimal price = Convert.ToDecimal(row.Cells[9].Value);  // Giá nhập

                        // Tính tổng tiền của dòng hiện tại
                        decimal lineTotal = quantity * price;

                        // Cộng dồn tổng tiền của phiếu nhập
                        totalAmount += lineTotal;
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi khi chuyển đổi giá trị, bỏ qua dòng này
                    }
                }
            }

            // Cập nhật tổng tiền vào TextBox
            // Cập nhật tổng tiền vào TextBox
            txtTongTien.Text = totalAmount.ToString("#,0", new System.Globalization.CultureInfo("vi-VN")) + " VND";


            return totalAmount; // Trả về tổng tiền
        }

        private void btn_LuuCTPN_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã phiếu nhập (sinh tự động)
                int maPhieuNhap = LayMaPhieuNhapTuDong();  // Phiếu nhập sẽ được tạo tự động

                // Tính tổng tiền từ DataGridView
                decimal tongTien = CalculateTotalAmount();

                // Khởi tạo đối tượng DBConnect
                DBConnect db = new DBConnect();

                // Tạo một DataTable để chứa chi tiết phiếu nhập
                DataTable dtChiTietPhieuNhap = GetChiTietPhieuNhapDataTable();

                // Chuẩn bị tham số cho Stored Procedure
                SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@MaNhaCungCap", SqlDbType.Int) { Value = Convert.ToInt32(cbPhieuNhap.SelectedValue) },
            new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien },
            new SqlParameter("@ChiTietPhieuNhap", SqlDbType.Structured)
            {
                TypeName = "dbo.ChiTietPhieuNhapType",  // Tên kiểu dữ liệu bảng trong SQL Server
                Value = dtChiTietPhieuNhap  // Chuyển DataTable thành kiểu dữ liệu bảng
            }
        };

                // Gọi Stored Procedure để lưu phiếu nhập cùng chi tiết
                db.executeStoredProcedure("ThemPhieuNhap", parameters);

                // Hiển thị thông báo thành công
                MessageBox.Show("Lưu dữ liệu chi tiết phiếu nhập và tổng tiền thành công!");

                // Xóa dữ liệu trong DataGridView sau khi lưu
                dgvChiTietPhieuNhap.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }





        private DataTable GetChiTietPhieuNhapDataTable()
        {
            // Tạo một DataTable có cấu trúc giống kiểu dữ liệu ChiTietPhieuNhapType
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSanPham", typeof(int));
            dt.Columns.Add("MaMauSac", typeof(int));
            dt.Columns.Add("MaKichThuoc", typeof(int));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GiaNhap", typeof(decimal));

            // Lấy dữ liệu từ DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    dt.Rows.Add(
                        Convert.ToInt32(row.Cells[2].Value), // MaSanPham
                        Convert.ToInt32(row.Cells[4].Value), // MaMauSac
                        Convert.ToInt32(row.Cells[6].Value), // MaKichThuoc
                        Convert.ToInt32(row.Cells[8].Value), // SoLuong
                        Convert.ToDecimal(row.Cells[9].Value) // GiaNhap
                    );
                }
            }

            return dt;
        }

        private void btnXemPhieuNhap_Click(object sender, EventArgs e)
        {
            PhieuNhap gd = new PhieuNhap();
            gd.FormClosed += (s, args) => this.Close();
            gd.Show();
            this.Hide();
        }


    }
}

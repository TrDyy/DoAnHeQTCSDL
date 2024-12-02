using KETNOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANHEQTCSDL
{
    public partial class KiemTraDon : Form
    {
        DBConnect db = new DBConnect();
        DataTable tempDataTable;
        public KiemTraDon()
        {
            InitializeComponent();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

     


        private void KiemTraDon_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadSP();
            LoadTT();
            LoaddvgSanPham();
        }

        private void LoadKH()
        {
            try
            {
                string query = "SELECT dbo.HoVaTen(Ho, Ten) AS TenKhachHang FROM KhachHang";
                DataTable dt = db.getDataTable(query);
                DataRow newRow = dt.NewRow();
                newRow["TenKhachHang"] = "All";  // Mã Phiếu Thu mặc định
                dt.Rows.InsertAt(newRow, 0);
                LoadComboBoxData(cbTenKH, dt.DefaultView.ToTable(true, "TenKhachHang"), "TenKhachHang", "TenKhachHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void LoadSP()
        {
            try
            {
                string query = "EXEC LayMaDonHang";
                DataTable dt = db.getDataTable(query);
                DataRow newRow = dt.NewRow();
                newRow["MaDonHang"] = 0;  // Mã Phiếu Thu mặc định
                dt.Rows.InsertAt(newRow, 0);
                LoadComboBoxData(cbMaDH, dt.DefaultView.ToTable(true, "MaDonHang"), "MaDonHang", "MaDonHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void LoadTT()
        {

            cbTrangThaiDonHang.Items.Add("Hoàn Thành");
            cbTrangThaiDonHang.Items.Add("Đang chờ xử lý");

        }

        private void LoaddvgSanPham()
        {
            tempDataTable = new DataTable();

            string query = "EXEC LayThongTinDonHang";
            tempDataTable = db.getDataTable(query);
            dvgDonHang.DataSource = tempDataTable;
           
        }
    

        

        private void LoadComboBoxData(ComboBox comboBox, DataTable dt, string displayMember, string valueMember)
        {
            comboBox.DataSource = null; // Reset data source
           
            comboBox.DataSource = dt;
           
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
           
        }

        private void dvgDonHang_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dvgDonHang.ClearSelection();
                dvgDonHang.Rows[e.RowIndex].Selected = true;

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Xem chi tiết đơn hàng").Click += (s, ev) => {
                    string maDon = dvgDonHang.SelectedRows[0].Cells["MaDonHang"].Value.ToString();
                    ChiTietDonHang formChiTiet = new ChiTietDonHang(maDon);
                    formChiTiet.ShowDialog();
                };

                menu.Show(dvgDonHang, dvgDonHang.PointToClient(Cursor.Position));
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dvgDonHang.Rows)
            {
                if (row.Cells["TrangThaiDonHang"].Value != null && row.Cells["MaDonHang"].Value != null)
                {

                    string maDon = row.Cells["MaDonHang"].Value.ToString();
                    string trangThai = row.Cells["TrangThaiDonHang"].Value.ToString();

                    if (trangThai == "Đã hủy")
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string query = "EXEC HuyDonHang @MaDonHang";
                            var paremeter = new Dictionary<string, object>
                            {
                            { "@MaDonHang", maDon}
                            };
                            db.getExecuteNonQueryWithParams(query, paremeter, null);
                            MessageBox.Show("Đơn hàng đã hủy thành công!");
                        }
                    }
                    else
                    {
                        string query = "EXEC CapNhatDonHang @MaDonHang, @TrangThai";
                        var parameters = new Dictionary<string, object>
                        {
                            {"@MaDonHang", maDon},
                            {"@TrangThai", trangThai}
                        };
                        db.getExecuteNonQueryWithParams(query, parameters, null);
                    }

                }
            }
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ ComboBox
                string maDH = cbMaDH.SelectedIndex != 0 && cbMaDH.SelectedValue.ToString() != "0"
                              ? cbMaDH.SelectedValue.ToString()
                              : null;
                string tenKH = cbTenKH.SelectedIndex != 0 && cbTenKH.SelectedValue.ToString() != "All"
                               ? cbTenKH.SelectedValue.ToString()
                               : null;
                string tinhTrang = cbTrangThaiDonHang.SelectedIndex != -1
                                   ? cbTrangThaiDonHang.SelectedItem.ToString()
                                   : "";


                // Tạo DataTable tạm thời
                tempDataTable = new DataTable();

                // Chuẩn bị truy vấn với tham số
                string query = "EXEC LocDonHang @MaDonHang, @TenKhachHang, @TinhTrang";

                var parameters = new Dictionary<string, object>
        {
            { "@MaDonHang", string.IsNullOrEmpty(maDH) ? DBNull.Value : (object)int.Parse(maDH) },
            { "@TenKhachHang", string.IsNullOrEmpty(tenKH) ? DBNull.Value : (object)tenKH },
            { "@TinhTrang", string.IsNullOrEmpty(tinhTrang) ? DBNull.Value : (object)tinhTrang }
        };

                // Lấy dữ liệu
                tempDataTable = db.getDataTableWithParams(query, parameters);

                // Gán dữ liệu vào DataGridView
                dvgDonHang.DataSource = tempDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.ToString(), "Thông báo");
            }
        }

    }
}

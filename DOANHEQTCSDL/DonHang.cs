using KETNOI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DOANHEQTCSDL
{
    public partial class DonHang : Form
    {
        DBConnect db = new DBConnect();
        private DataTable tempDataTable;
       

        public DonHang()
        {
            InitializeComponent();
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            LoadMaSP();
            LoadKH();
            LoadTempTable();
            LoadCbKiemTra();


        }

        private void LoadTempTable()
        {
            tempDataTable = new DataTable();
            tempDataTable.Columns.Add("MaSanPham", typeof(string)); // Mã sản phẩm, cột ẩn
            tempDataTable.Columns.Add("Tên Sản Phẩm", typeof(string));
            tempDataTable.Columns.Add("Màu Sắc", typeof(string));
            tempDataTable.Columns.Add("Kích Thước", typeof(string));
            tempDataTable.Columns.Add("Số Lượng", typeof(int));
            tempDataTable.Columns.Add("Giá Bán", typeof(decimal));

            // Gắn DataTable vào DataGridView
            dtGridTempDH.DataSource = tempDataTable;
            dtGridTempDH.Columns["MaSanPham"].Visible = false;
        }

        private void LoadCbKiemTra()
        {
            cbKiemTra.Items.Add("Mua tại cửa hàng");
            cbKiemTra.Items.Add("Giao nhận");
        }

        private void LoadMaSP()
        {
            try
            {
                string query = "EXEC LayMaSanPham";
                DataTable dt = db.getDataTable(query);
                cbMaSP.DataSource = dt;
                cbMaSP.DisplayMember = "MaSanPham";
                cbMaSP.ValueMember = "MaSanPham";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSP.SelectedValue == null || string.IsNullOrEmpty(cbMaSP.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ.");
                return;
            }

            DataRowView drv = (DataRowView)cbMaSP.SelectedItem;
            string valueMaSP = drv["MaSanPham"].ToString();

            LoadSanPhamDetails(valueMaSP);
        }

        private void LoadSanPhamDetails(string maSanPham)
        {
            try
            {
                // Truy vấn lấy thông tin màu sắc, kích thước và hình ảnh
                string query = "EXEC LayThongTinDonHangChoKhach @MaSanPham";

                var parameters = new Dictionary<string, object>
        {
            { "@MaSanPham", maSanPham }
        };

                DataTable dt = db.getDataTableWithParams(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtTenSanPham.Text = dt.Rows[0]["TenSanPham"].ToString();
                    txtGiaBan.Text = dt.Rows[0]["GiaBan"].ToString();
                    // Gán dữ liệu cho ComboBox
                    LoadComboBoxData(cbMauSac, dt.DefaultView.ToTable(true, "TenMauSac"), "TenMauSac", "TenMauSac");
                    LoadComboBoxData(cbKichThuoc, dt.DefaultView.ToTable(true, "TenKichThuoc"), "TenKichThuoc", "TenKichThuoc");

                    // Hiển thị hình ảnh
                    string hinhAnh = dt.Rows[0]["HinhAnh"].ToString();
                    string imagePath = Path.Combine(Application.StartupPath, "PICTURE", hinhAnh);

                    if (File.Exists(imagePath))
                    {
                        picSanPham.Image = Image.FromFile(imagePath);
                        picSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hình ảnh tại: " + imagePath);
                        picSanPham.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu cho sản phẩm này!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sản phẩm: " + ex.Message);
            }
        }


        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (cbMauSac.SelectedValue == null || cbKichThuoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn màu sắc và kích thước.");
                return;
            }

            if (string.IsNullOrEmpty(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                return;
            }

            int maSanPham = int.Parse(cbMaSP.SelectedValue.ToString());
            string mauSac = cbMauSac.Text;
            string kichThuoc = cbKichThuoc.Text;


            // Kiểm tra số lượng tồn kho
            string query = "EXEC LaySoLuongTonKho @MaSanPham, @MauSac, @KichThuoc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaSanPham", maSanPham },
                { "@MauSac", mauSac },
                { "@KichThuoc", kichThuoc }
            };

            
            DataTable dt = db.getDataTableWithParams(query, parameters);
            if(dt.Rows.Count >0)
            {
                int soLuongTon = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                if (soLuong > soLuongTon)
                {
                    MessageBox.Show("Không đủ sản phẩm, tồn kho: " + soLuongTon.ToString(), "Thông báo");
                    return;
                }
                // Thêm vào DataGridView
       

                tempDataTable.Rows.Add(maSanPham, txtTenSanPham.Text, mauSac, kichThuoc, soLuong, txtGiaBan.Text);

                UpdateThanhTien();
            }
                

           
        }

        private void UpdateThanhTien()
        {
            try
            {
                decimal thanhTien = 0;

                // Duyệt qua từng hàng trong DataGridView
                foreach (DataGridViewRow row in dtGridTempDH.Rows)
                {
                    if (row.Cells["Số Lượng"].Value != null && row.Cells["Giá Bán"].Value != null)
                    {
                        // Lấy số lượng và giá bán
                        int soLuong = Convert.ToInt32(row.Cells["Số Lượng"].Value);
                        decimal giaBan = Convert.ToDecimal(row.Cells["Giá Bán"].Value);

                        // Tính tiền cho sản phẩm
                        thanhTien += soLuong * giaBan;
                    }
                }

                // Cập nhật giá trị thành tiền vào TextBox
                txtThanhTien.Text = thanhTien.ToString("N0"); // Hiển thị theo định dạng số
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính thành tiền: " + ex.Message);
            }
        }



        private void LoadKH()
        {
            try
            {
                string query = "SELECT dbo.HoVaTen(Ho, Ten) AS TenKhachHang FROM KhachHang";
                DataTable dt = db.getDataTable(query);
                cbTenKH.DataSource = dt;
                cbTenKH.DisplayMember = "TenKhachHang";
                cbTenKH.ValueMember = "TenKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void LoadComboBoxData(ComboBox comboBox, DataTable dt, string displayMember, string valueMember)
        {
            comboBox.DataSource = null; // Reset data source
            comboBox.DataSource = dt;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        private void btnXoaGrid_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (dtGridTempDH.SelectedRows.Count > 0)
                    {
                        // Xóa dòng được chọn
                        foreach (DataGridViewRow row in dtGridTempDH.SelectedRows)
                        {
                            dtGridTempDH.Rows.Remove(row);
                            UpdateThanhTien();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa dòng: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(cbTenKH.SelectedValue.ToString() != "User")
            {
                
            }
            if (tempDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống, vui lòng thêm sản phẩm.");
                return;
            }
            if(cbKiemTra.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn hình thức.");
                return;
            }
            // Lấy dữ liệu cần truyền từ Form cũ
            string tenKhachHang = cbTenKH.SelectedValue.ToString();
            string thanhTien = txtThanhTien.Text;
            string kiemTra = cbKiemTra.SelectedItem.ToString();
           
            // Mở Form mới và truyền dữ liệu
            using (var formXacNhan = new XacNhanDonHang(tenKhachHang, thanhTien, tempDataTable, kiemTra))
            {
                formXacNhan.ShowDialog();
            }

        }





      

    }
}

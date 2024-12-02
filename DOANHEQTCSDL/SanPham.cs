using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KETNOI;

namespace DOANHEQTCSDL
{
    public partial class SanPham : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_sp = new DataTable();
        DataTable dt_loaisp = new DataTable();
        DataTable dt_thuonghieu = new DataTable();
        private int selected_id = 0;
        private string selectedProductName;
        private decimal selectedProductPrice;
        private string selectedPicture;
        public SanPham()
        {
            InitializeComponent();
          
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            
            LoadloaiSP();
            Loadthuonghieu();
            LoadSP();
        }

        private void Loadthuonghieu()//load thuong hieu
        {
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu
                string sql = "select * from ThuongHieu";
                dt_thuonghieu = db.getDataTable(sql);

                // Gán nguồn dữ liệu cho DataGridView
                cbo_thuonghieu.DataSource = dt_thuonghieu;
                cbo_thuonghieu.ValueMember = "MaThuongHieu";
                cbo_thuonghieu.DisplayMember = "TenThuongHieu";

            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadloaiSP()//load loai san pham
        {
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu
                string sql = "select * from PhanLoai";
                dt_loaisp = db.getDataTable(sql);

                // Gán nguồn dữ liệu cho DataGridView
                cbo_loaisp.DataSource = dt_loaisp;
                cbo_loaisp.ValueMember = "MaPhanLoai";
                cbo_loaisp.DisplayMember = "TenPhanLoai";
         
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        public void LoadSP()//Load danh sách sản phẩm
        {
           
           
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu
                string sql = "select * from SanPham";
                dt_sp = db.getDataTable(sql);

                // Gán nguồn dữ liệu cho DataGridView
                dgv_sp.DataSource = dt_sp;

                // Nếu cần, bạn có thể ẩn các cột không cần thiết
                dgv_sp.Columns["MaPhanLoai"].Visible = false;
                dgv_sp.Columns["MaThuongHieu"].Visible = false;
                dgv_sp.Columns["GiaGoc"].Visible = false;
                dgv_sp.Columns["HinhAnh"].Visible = false;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }
        
        private void dgv_sp_CellClick(object sender, DataGridViewCellEventArgs e)//su kien click vao hang san pham
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var cellValue = dgv_sp.Rows[e.RowIndex].Cells["HinhAnh"].Value;
                    string imagePath = cellValue != null ? cellValue.ToString() : string.Empty;
                    selected_id = Convert.ToInt32(dgv_sp.Rows[e.RowIndex].Cells["MaSanPham"].Value);
                    selectedProductName = dgv_sp.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                    selectedProductPrice = Convert.ToDecimal(dgv_sp.Rows[e.RowIndex].Cells["GiaBan"].Value);
                    selectedPicture = dgv_sp.Rows[e.RowIndex].Cells["HinhAnh"].Value.ToString();
                    // load textbox thong tin
                    txt_tensp.Text = selectedProductName;
                    txt_giagoc.Text = (dgv_sp.Rows[e.RowIndex].Cells["GiaGoc"].Value.ToString());
                    txt_mota.Text = (dgv_sp.Rows[e.RowIndex].Cells["MoTa"].Value.ToString());
                    cbo_gioitinh.Text = (dgv_sp.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString());


                    if (string.IsNullOrEmpty(imagePath))
                    {
                        MessageBox.Show("Dữ liệu hình ảnh bị thiếu ở dòng này.");
                        pic_sp.Image = null;
                        return;
                    }
                    // Lấy đường dẫn đến thư mục chứa ứng dụng
                    string startupPath = Application.StartupPath;
                    // Lấy thư mục gốc của project
                    string projectPath = Directory.GetParent(startupPath).Parent.FullName; // Điều hướng lên 3 cấp
                    // Giả sử hình ảnh được lưu trong thư mục "PICTURE" trong thư mục ứng dụng
                    string folderPath = Path.Combine(projectPath, "PICTURE");
                    string fullPath = Path.Combine(folderPath, imagePath);

                    if (File.Exists(fullPath))
                    {
                        if (pic_sp.Image != null)
                        {
                            pic_sp.Image.Dispose();
                            pic_sp.Image = null;
                        }

                        pic_sp.Image = Image.FromFile(fullPath);
                        pic_sp.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        MessageBox.Show($"Hình ảnh không tồn tại: {fullPath}");
                        pic_sp.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
            }
        }
        //loc theo loai sanpham
        private void cbo_loaisp_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbo_loaisp.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                
                try
                {
                    // Tạo câu truy vấn SQL để lấy dữ liệu
                    string sql = "select * from SanPham where MaPhanLoai = " + cbo_loaisp.SelectedValue.ToString() + "";
                    dt_sp = db.getDataTable(sql);

                    // Gán nguồn dữ liệu cho DataGridView
                    dgv_sp.DataSource = dt_sp;

                    // Nếu cần, bạn có thể ẩn các cột không cần thiết
                    dgv_sp.Columns["MaPhanLoai"].Visible = false;
                    dgv_sp.Columns["MaThuongHieu"].Visible = false;
                    dgv_sp.Columns["GiaGoc"].Visible = false;
                    dgv_sp.Columns["HinhAnh"].Visible = false;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
            
        }
        //hien thi tat ca san pham
        private void btn_all_Click(object sender, EventArgs e)
        {
            LoadSP();
        }

        private void btn__luu_Click(object sender, EventArgs e)
        {
            if(txt_tensp.Text.Length == 0 || txt_giagoc.Text.Length == 0 || txt_mota.Text.Length== 0 || cbo_gioitinh.Text.Length == 0)
            {
                MessageBox.Show("Nhập đầy đủ thông tin trước khi cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //cap nhat thong tin san pham
                string sql = "EXEC CAPNHAT_SANPHAM\r\n\t@MaSanPham = "+selected_id+",\r\n    @TenSanPham = N'"+txt_tensp.Text+"',\r\n    @GioiTinh = N'"+cbo_gioitinh.SelectedItem.ToString()+"',\r\n    @GiaGoc = "+txt_giagoc.Text+",\r\n    @MoTa = N'"+txt_mota.Text+"'";
                //đoạn này có kích hoạt trigger cập nhật giá bán khi thay đổi giá gốc dưới csdl
                int kq = db.getExecuteNonQuery(sql);
                if (kq != 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công !", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại !", "Thông báo");
                }
            }
        }
        //Loc san pham theo thuong hieu
        private void cbo_thuonghieu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_thuonghieu.SelectedValue.ToString() != "System.Data.DataRowView")
            {

                try
                {
                    // Tạo câu truy vấn SQL để lấy dữ liệu
                    string sql = "select * from SanPham where MaThuongHieu = " + cbo_thuonghieu.SelectedValue.ToString() + "";
                    dt_sp = db.getDataTable(sql);

                    // Gán nguồn dữ liệu cho DataGridView
                    dgv_sp.DataSource = dt_sp;

                    // Nếu cần, bạn có thể ẩn các cột không cần thiết
                    dgv_sp.Columns["MaPhanLoai"].Visible = false;
                    dgv_sp.Columns["MaThuongHieu"].Visible = false;
                    dgv_sp.Columns["GiaGoc"].Visible = false;
                    dgv_sp.Columns["HinhAnh"].Visible = false;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            
            ThemSanPham _them = new ThemSanPham();          
            _them.Show();
        }

        private void btn_gtb_Click(object sender, EventArgs e)
        {
            TrungBinhMatHang _tb = new TrungBinhMatHang();
            _tb.Show();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql = "select dbo.kiemtra_khoangoai_sp("+selected_id+")\r\n";
            int kq = int.Parse(db.getExecuteScalar(sql).ToString());
            if(kq == 0)
            {
                MessageBox.Show("Sản phẩm tồn tại ở nơi khác, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Tien hanh xoas
                string sql_2 = "delete from SanPham where MaSanPham = "+selected_id+"";
                int kq2 = db.getExecuteNonQuery(sql_2);
                if (kq2 != 0)
                {
                    //// Lấy đường dẫn đến thư mục chứa ứng dụng
                    //string startupPath = Application.StartupPath;
                    //// Lấy thư mục gốc của project
                    //string projectPath = Directory.GetParent(startupPath).Parent.FullName; // Điều hướng lên 3 cấp
                    //// Giả sử hình ảnh được lưu trong thư mục "PICTURE" trong thư mục ứng dụng
                    //string folderPath = Path.Combine(projectPath, "PICTURE");
                    //string fullPath = Path.Combine(folderPath, selectedPicture);
                    //try
                    //{
                    //    if (File.Exists(fullPath)) // Kiểm tra xem tệp có tồn tại không
                    //    {
                    //        File.Delete(fullPath); // Xóa tệp
                    //        LoadSP();//load lai sp
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Có lỗi xảy ra khi xóa tệp: " + ex.Message);
                    //}
                    MessageBox.Show("Xóa sản phẩm thành công !", "Thông báo");

                }
                else
                {                 
                    MessageBox.Show("Xóa sản phẩm thất bại !", "Thông báo");
                }
            }
        }

      
    }
}

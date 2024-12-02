using KETNOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANHEQTCSDL
{
    public partial class ThemSanPham : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_sp = new DataTable();
        DataTable dt_loaisp = new DataTable();
        DataTable dt_thuonghieu = new DataTable();
        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            Loadthuonghieu();
            LoadloaiSP();
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
                cbo_phanloai.DataSource = dt_loaisp;
                cbo_phanloai.ValueMember = "MaPhanLoai";
                cbo_phanloai.DisplayMember = "TenPhanLoai";

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

          
                
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void txt_giagoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // Thư mục khởi đầu
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"; // Bộ lọc tệp chỉ cho phép jpg, jpeg, png
                openFileDialog.Title = "Chọn một hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy tên tệp đã chọn
                    string fileName = openFileDialog.FileName;
                    // Hiển thị tên tệp trong một MessageBox (hoặc xử lý theo cách khác)
                    txt_hinhanh.Text = fileName;    
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_hinhanh.Text) || !chk_form())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy đường dẫn đến thư mục chứa ứng dụng
                string startupPath = Application.StartupPath;
                // Lấy thư mục gốc của project
                string projectPath = Directory.GetParent(startupPath).Parent.FullName; // Điều hướng lên 3 cấp
                                                                                       // Giả sử hình ảnh được lưu trong thư mục "PICTURE" trong thư mục ứng dụng
                string folderPath = Path.Combine(projectPath, "PICTURE");


                string targetFile = Path.Combine(folderPath, Path.GetFileName(txt_hinhanh.Text)); // Đường dẫn tệp đích

                // Kiểm tra xem thư mục PICTURE có tồn tại không, nếu không thì tạo
                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show("Cos loi");
                }

                // Sao chép tệp vào thư mục PICTURE
                File.Copy(txt_hinhanh.Text, targetFile, true); // true để ghi đè nếu tệp đã tồn tại
                //lưu sản phẩm xuống csdl
                string HinhAnh = Path.GetFileName(txt_hinhanh.Text);//lay ten anh
                string sql = "EXEC THEM_SANPHAM\r\n    @TenSanPham = N'"+txt_tensp.Text+"',\r\n    @MaPhanLoai = "+cbo_phanloai.SelectedValue.ToString()+",\r\n    @MaThuongHieu = "+cbo_thuonghieu.SelectedValue.ToString()+",\r\n    @GioiTinh = N'"+cbo_gioitinh.SelectedItem.ToString()+"',\r\n    @GiaGoc = "+txt_giagoc.Text+",\r\n    @GiaBan = "+txt_giaban.Text+",\r\n    @MoTa = N'"+txt_mota.Text+"',\r\n    @HinhAnh = N'"+HinhAnh+"';";
                
                int kq = db.getExecuteNonQuery(sql);
                if (kq != 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công !", "Thông báo");
                    refresh_form();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại !", "Thông báo");
                }


                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        //kiem tra form day du thong tin truoc khi luu
        private bool chk_form()
        {
            if(txt_tensp.Text.Length == 0 || txt_mota.Text.Length == 0 || txt_giagoc.Text.Length == 0 || txt_giaban.Text.Length == 0 || cbo_gioitinh.Text.Length == 0 || cbo_phanloai.Text.Length == 0 || cbo_thuonghieu.Text.Length == 0)
            {  return false; }
            return true;
        }
        //refresh form sau khi nhan luu
        private void refresh_form()
        {
            txt_tensp.Text = null;
            txt_mota.Text = null;
            txt_giagoc.Text = null;
            txt_giaban.Text = null;
            txt_hinhanh.Text = null;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Đóng cửa sổ thêm ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(r == DialogResult.OK)
            {
                this.Close();
            }
            
        }
    }
    
}

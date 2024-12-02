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
    public partial class ManHinhChinh : Form
    {
        private int roleId;
        public ManHinhChinh(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            lb_ngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
            if (roleId != 1) // Không phải admin
            {
                labelTenDangNhap.Text = "Nhân viên";
                button6.Enabled = false; // Ẩn nút 1
                button1.Enabled = false; // Ẩn nút 2
            }
            else
            {
                labelTenDangNhap.Text = "Admin";
            }
        }
        private Form currentFormChild;

        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false; // Đặt form con không phải là top-level
            childForm.FormBorderStyle = FormBorderStyle.None; // Không hiển thị viền form
            childForm.Dock = DockStyle.Fill; // Đổ đầy panel_Body
            panel_body.Controls.Add(childForm); // Thêm form vào panel_Body
            panel_body.Tag = childForm; // Lưu tag để tham chiếu
            childForm.BringToFront(); // Đưa form con lên trên
            childForm.Show(); // Hiển thị form con
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyDonHang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuNhap());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoan());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCC());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LuuTruDuLieu());
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn màn hình chính
            DangNhap loginForm = new DangNhap();
            loginForm.FormClosed += (s, args) => this.Close(); // Đảm bảo ứng dụng đóng khi form đăng nhập đóng
            loginForm.Show(); // Hiển thị form đăng nhập
        }

        private void lb_chao_Click(object sender, EventArgs e)
        {

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

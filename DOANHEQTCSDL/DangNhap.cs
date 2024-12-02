using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using KETNOI;

namespace DOANHEQTCSDL
{
    public partial class DangNhap : Form
    {
        DBConnect db = new DBConnect();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin đăng nhập
            string username = textTenDangNhap.Text.Trim();
            string password = textMatKhau.Text.Trim();

            try
            {
                // Truy vấn để lấy mã vai trò của người dùng
                string sql = "SELECT MaVaiTro FROM NguoiDung WHERE TenDangNhap = @username AND MatKhau = @password";
                var parameters = new Dictionary<string, object>() {
                    { "@username", username },
                    { "@password", password}
                };

                object result = db.getExecuteScalarWithParams(sql, parameters);

                if (result != null)
                {
                    int roleId = int.Parse(result.ToString());

                    // Điều hướng theo vai trò
                    OpenMainForm(roleId);
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(textTenDangNhap.Text))
            {
                SetPanelBorderError(panelTenDangNhap, true);
                isValid = false;
            }
            else
            {
                SetPanelBorderError(panelTenDangNhap, false);
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(textMatKhau.Text))
            {
                SetPanelBorderError(panelMatKhau, true);
                isValid = false;
            }
            else
            {
                SetPanelBorderError(panelMatKhau, false);
            }

            return isValid;
        }

        private void SetPanelBorderError(Panel panel, bool hasError)
        {
            if (hasError)
            {
                panel.BackColor = Color.Red; // Viền đỏ khi có lỗi
            }
            else
            {
                panel.BackColor = Color.Gray; // Viền xám khi không có lỗi
            }
        }

        private void OpenMainForm(int roleId)
        {
            Form mainForm;

            switch (roleId)
            {
                case 1: // Admin
                    mainForm = new ManHinhChinh(roleId); // Truyền roleId sang màn hình chính
                    break;

                case 2: // Nhân viên
                    mainForm = new ManHinhChinh(roleId); // Truyền roleId sang màn hình chính
                    break;

                default:
                    MessageBox.Show("Vai trò không xác định.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Mở màn hình chính
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
            this.Hide();
        }
    }
}

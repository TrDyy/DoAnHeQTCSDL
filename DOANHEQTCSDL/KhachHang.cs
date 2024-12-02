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
    public partial class KhachHang : Form
    {

        DBConnect db = new DBConnect();
        public KhachHang()
        {
            InitializeComponent();
        }

        private void LoadKhachHang()
        {
            try
            {
                db.openConnect();

                // Tạo SqlCommand để gọi Stored Procedure
                SqlCommand cmd = new SqlCommand("LayDanhSachKhachHang", db.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dgv_KhachHang.DataSource = dt;

                db.closeConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void AddKhachHang(string ho, string ten, string dienThoai, string diaChiDayDu, int? maNguoiDung)
        {
            try
            {
                db.openConnect();

                // Tạo SqlCommand để gọi Stored Procedure
                SqlCommand cmd = new SqlCommand("ThemKhachHang", db.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số cho Stored Procedure
                cmd.Parameters.Add(new SqlParameter("@Ho", SqlDbType.NVarChar, 50) { Value = ho });
                cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 50) { Value = ten });
                cmd.Parameters.Add(new SqlParameter("@DienThoai", SqlDbType.NVarChar, 20) { Value = dienThoai });
                cmd.Parameters.Add(new SqlParameter("@DiaChiDayDu", SqlDbType.NVarChar, 255) { Value = diaChiDayDu });
                cmd.Parameters.Add(new SqlParameter("@MaNguoiDung", SqlDbType.Int)
                {
                    Value = maNguoiDung.HasValue ? (object)maNguoiDung.Value : DBNull.Value
                });

                // Thực thi Stored Procedure
                int result = cmd.ExecuteNonQuery();

                // Kiểm tra kết quả
                if (result > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                db.closeConnect();
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadNguoiDungToComboBox();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Ho.Text.Trim()) ||
                string.IsNullOrEmpty(txt_Ten.Text.Trim()) ||
                string.IsNullOrEmpty(txt_SDT.Text.Trim()) ||
                string.IsNullOrEmpty(txt_DiaChi.Text.Trim()) ||
                cbb_MaNguoiDung.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ho = txt_Ho.Text.Trim();
            string ten = txt_Ten.Text.Trim();
            string dienThoai = txt_SDT.Text.Trim();
            string diaChiDayDu = txt_DiaChi.Text.Trim();
            int? maNguoiDung = cbb_MaNguoiDung.SelectedValue != null ? (int?)Convert.ToInt32(cbb_MaNguoiDung.SelectedValue) : null;

            AddKhachHang(ho, ten, dienThoai, diaChiDayDu, maNguoiDung);
        }

        private void toolStripMenuItem_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_KhachHang.SelectedRows.Count > 0)
                {
                    int maKhachHang = Convert.ToInt32(dgv_KhachHang.SelectedRows[0].Cells["MaKhachHang"].Value);

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Gọi Stored Procedure để xóa khách hàng
                        string query = $"EXEC XoaKhachHang @MaKhachHang = {maKhachHang}";
                        int deleteResult = db.getExecuteNonQuery(query);

                        if (deleteResult > 0)
                        {
                            MessageBox.Show("Xóa khách hàng thành công!");
                            LoadKhachHang();
                        }
                        else
                        {
                            MessageBox.Show("Xóa khách hàng thất bại!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_KhachHang.Rows[e.RowIndex];

                txt_MaKH.Text = row.Cells["MaKhachHang"].Value?.ToString();
                txt_Ho.Text = row.Cells["Ho"].Value?.ToString();
                txt_Ten.Text = row.Cells["Ten"].Value?.ToString();
                txt_SDT.Text = row.Cells["DienThoai"].Value?.ToString();
                txt_DiaChi.Text = row.Cells["DiaChiDayDu"].Value?.ToString();
                // Gán giá trị vào ComboBox
                if (row.Cells["MaNguoiDung"].Value != null)
                {
                    cbb_MaNguoiDung.SelectedValue = row.Cells["MaNguoiDung"].Value;
                }
                else
                {
                    cbb_MaNguoiDung.SelectedIndex = -1; // Không chọn mục nào nếu giá trị null
                }

                // Lấy mã khách hàng để tính tổng số đơn hàng
                if (int.TryParse(row.Cells["MaKhachHang"].Value?.ToString(), out int maKhachHang))
                {
                    int tongSoDonHang = LayTongSoDonHang(maKhachHang);
                    txt_TongDH.Text = tongSoDonHang.ToString();
                }
                else
                {
                    txt_TongDH.Text = "0";
                }


            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int maKhachHang = int.Parse(txt_MaKH.Text);
                string ho = txt_Ho.Text;
                string ten = txt_Ten.Text;
                string dienThoai = txt_SDT.Text;
                string diaChiDayDu = txt_DiaChi.Text;

                // Gọi Stored Procedure để sửa khách hàng
                string query = $"EXEC SuaKhachHang @MaKhachHang = {maKhachHang}, " +
                               $"@Ho = N'{ho}', @Ten = N'{ten}', " +
                               $"@DienThoai = N'{dienThoai}', @DiaChiDayDu = N'{diaChiDayDu}'";
                int result = db.getExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
        }

        private void LoadNguoiDungToComboBox()
        {
            try
            {
                string query = "SELECT MaNguoiDung, TenDangNhap FROM NguoiDung";
                DataTable dtNguoiDung = db.getDataTable(query);

                cbb_MaNguoiDung.DataSource = dtNguoiDung;
                cbb_MaNguoiDung.DisplayMember = "MaNguoiDung";
                cbb_MaNguoiDung.ValueMember = "MaNguoiDung";
                cbb_MaNguoiDung.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        private void TimKiemKhachHang(int? maKH, string ten, string dienThoai)
        {
            try
            {
                db.openConnect();

                SqlCommand cmd = new SqlCommand("TimKiemKhachHang", db.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào Stored Procedure
                cmd.Parameters.Add(new SqlParameter("@MaKH", SqlDbType.Int) { Value = maKH ?? (object)DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(ten) ? (object)DBNull.Value : ten });
                cmd.Parameters.Add(new SqlParameter("@DienThoai", SqlDbType.NVarChar, 20) { Value = string.IsNullOrEmpty(dienThoai) ? (object)DBNull.Value : dienThoai });

                // Lấy dữ liệu từ Stored Procedure
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_KhachHang.DataSource = dt;

                db.closeConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            int? maKH = string.IsNullOrEmpty(txt_TimMaKH.Text) ? (int?)null : int.Parse(txt_TimMaKH.Text.Trim());
            string ten = string.IsNullOrEmpty(txt_TimTen.Text) ? null : txt_TimTen.Text.Trim();
            string dienThoai = string.IsNullOrEmpty(txt_TimSDT.Text) ? null : txt_TimSDT.Text.Trim();

            TimKiemKhachHang(maKH, ten, dienThoai);
        }




        private int LayTongSoDonHang(int maKhachHang)
        {
            try
            {
                db.openConnect();

                // Tạo SqlCommand để gọi Function
                SqlCommand cmd = new SqlCommand("SELECT dbo.TongSoDonHang(@MaKhachHang)", db.GetConnection());
                cmd.CommandType = CommandType.Text;

                // Thêm tham số
                cmd.Parameters.Add(new SqlParameter("@MaKhachHang", SqlDbType.Int) { Value = maKhachHang });

                // Thực thi và lấy kết quả
                object result = cmd.ExecuteScalar();

                db.closeConnect();

                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tổng số đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

    }
}

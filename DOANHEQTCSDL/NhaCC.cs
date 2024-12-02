using DOANHEQTCSDL.DAO;
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
    public partial class NhaCC : Form
    {
        BindingSource NCCList = new BindingSource();
        public NhaCC()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            dgv_NCC.DataSource = NCCList;

            loadListNCC();
            addNCCBinding();
        }

        void loadListNCC()
        {
            NCCList.DataSource = NhaCungCap_DAO.Instance.GetListNhaCungCap();
        }

        //databinding với từng thuộc tính từ bảng dgv_NCC
        void addNCCBinding()
        {
            txt_MaNCC.DataBindings.Add(new Binding("Text", dgv_NCC.DataSource, "MaNhaCungCap", true, DataSourceUpdateMode.Never));
            txt_TenNCC.DataBindings.Add(new Binding("Text", dgv_NCC.DataSource, "TenNhaCungCap", true, DataSourceUpdateMode.Never));
            txt_DiaChi.DataBindings.Add(new Binding("Text", dgv_NCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txt_Email.DataBindings.Add(new Binding("Text", dgv_NCC.DataSource, "DienThoai", true, DataSourceUpdateMode.Never));
            txt_SDT.DataBindings.Add(new Binding("Text", dgv_NCC.DataSource, "Email", true, DataSourceUpdateMode.Never));
        }

        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNCC = txt_TenNCC.Text;
                string diaChi = txt_DiaChi.Text;
                string email = txt_Email.Text;
                string sdt = txt_SDT.Text;

                if (NhaCungCap_DAO.Instance.InsertNhaCungCap(tenNCC, diaChi, sdt, email))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadListNCC();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaNCC_Click(object sender, EventArgs e)
        {
            int MaNhaCungCap = int.Parse(txt_MaNCC.Text);

            if (NhaCungCap_DAO.Instance.DeleteNhaCungCap(MaNhaCungCap))
            {
                MessageBox.Show("Xóa thành công!");
                loadListNCC();
            }
            else
            {
                MessageBox.Show("Lỗi xóa nhà cung cấp!");
            }
        }

        private void btn_SuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                int maNCC = int.Parse(txt_MaNCC.Text);
                string tenNCC = txt_TenNCC.Text;
                string diaChi = txt_DiaChi.Text;
                string sdt = txt_SDT.Text;
                string email = txt_Email.Text;

                if (NhaCungCap_DAO.Instance.UpdateNhaCungCap(maNCC, tenNCC, diaChi, sdt, email))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadListNCC(); // Refresh danh sách nhà cung cấp
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
    }
}

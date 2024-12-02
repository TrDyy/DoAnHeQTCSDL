using DOANHEQTCSDL.DAO;
using DOANHEQTCSDL.DTO;
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
    public partial class TaiKhoan : Form
    {
        //Tạo databinding 
        BindingSource NVList = new BindingSource();

        public TaiKhoan()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            dgv_NV.DataSource = NVList;

            loadListNV();
            addNguoiDungBinding();
            loadVaiTroIntoCombobox(cbo_VaiTro);
        }

        void loadListNV()
        {
            NVList.DataSource = NguoiDung_DAO.Instance.GetListNguoiDung();
        }

        //databinding với từng thuộc tính từ bảng dgv_NV
        void addNguoiDungBinding()
        {
            txt_MaNguoiDung.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "MaNguoiDung", true, DataSourceUpdateMode.Never));
            txt_MatKhau.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
            txt_HoTen.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            txt_TenDN.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txt_SDT.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "DienThoai", true, DataSourceUpdateMode.Never));
            txt_CCCD.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "SoCanCuoc", true, DataSourceUpdateMode.Never));
            txt_NgayCap.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "NgayCap", true, DataSourceUpdateMode.Never));
            txt_NoiCap.DataBindings.Add(new Binding("Text", dgv_NV.DataSource, "NoiCap", true, DataSourceUpdateMode.Never));
        }

        //Combobox vai trò
        void loadVaiTroIntoCombobox(ComboBox cb)
        {
            cb.DataSource = VaiTro_DAO.Instance.GetListVaiTro();
            cb.DisplayMember = "TenVaiTro";
        }




        private void dgv_NV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_NV.SelectedCells.Count > 0)
                {
                    int MaVaiTro = (int)dgv_NV.SelectedCells[0].OwningRow.Cells["MaVaiTro"].Value;

                    VaiTro vaitro = VaiTro_DAO.Instance.GetMaSanPham(MaVaiTro);

                    cbo_VaiTro.SelectedItem = vaitro;

                    int index = -1;
                    int i = 0;
                    foreach (VaiTro item in cbo_VaiTro.Items)
                    {
                        if (item.MaVaiTro == vaitro.MaVaiTro)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbo_VaiTro.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txt_TenDN.Text;
            string MatKhau = txt_MatKhau.Text;
            string HoTen = txt_HoTen.Text;
            string DienThoai = txt_SDT.Text;

            int MaVaiTro = (cbo_VaiTro.SelectedItem as VaiTro).MaVaiTro;
            string soCanCuoc = txt_CCCD.Text;
            DateTime ngayCap = DateTime.Parse(txt_NgayCap.Text);
            string noiCap = txt_NoiCap.Text;

            if (NguoiDung_DAO.Instance.InsertNguoiDung(TenDangNhap, MatKhau, HoTen, DienThoai, MaVaiTro, soCanCuoc, ngayCap, noiCap))
            {
                MessageBox.Show("Thêm người dùng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadListNV();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và số CCCD không được trùng!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            int MaNguoiDung = int.Parse(txt_MaNguoiDung.Text);

            if (NguoiDung_DAO.Instance.DeleteND(MaNguoiDung))
            {
                MessageBox.Show("Xóa thành công!");
                loadListNV();
            }
            else
            {
                MessageBox.Show("Lỗi xóa người dùng!");
            }
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txt_TenDN.Text;
            string MatKhau = txt_MatKhau.Text;
            string HoTen = txt_HoTen.Text;
            string DienThoai = txt_SDT.Text;

            int MaVaiTro = (cbo_VaiTro.SelectedItem as VaiTro).MaVaiTro;

            int MaNguoiDung = int.Parse(txt_MaNguoiDung.Text);

            string soCanCuoc = txt_CCCD.Text;
            DateTime ngayCap = DateTime.Parse(txt_NgayCap.Text);
            string noiCap = txt_NoiCap.Text;

            // Cập nhật người dùng trong cơ sở dữ liệu
            if (NguoiDung_DAO.Instance.UpdateNguoiDung(MaNguoiDung, TenDangNhap, MatKhau, HoTen, DienThoai, MaVaiTro, soCanCuoc, ngayCap, noiCap))
            {
                MessageBox.Show("Cập nhật người dùng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadListNV();
            }
            else
            {
                MessageBox.Show("Cập nhật người dùng thất bại.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

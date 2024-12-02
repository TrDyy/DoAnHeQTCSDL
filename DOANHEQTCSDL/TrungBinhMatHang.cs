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
    public partial class TrungBinhMatHang : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt_loaisp = new DataTable();
        public TrungBinhMatHang()
        {
            InitializeComponent();
        }

        private void TrungBinhMatHang_Load(object sender, EventArgs e)
        {
            LoadloaiSP();
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

        private void cbo_loaisp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_loaisp.SelectedValue.ToString() != "System.Data.DataRowView")
            {

                try
                {
                    //Tạo câu truy vấn SQL để lấy dữ liệu: ở đây sử dụng funtion tính giá tb
                    string sql = "select dbo.GIATRUNGBINH_THEOLOAI("+cbo_loaisp.SelectedValue.ToString()+")";
                    lb_giatb.Text = db.getExecuteScalar(sql).ToString() + " VND";
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
    }
}

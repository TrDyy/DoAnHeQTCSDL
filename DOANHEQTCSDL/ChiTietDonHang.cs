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
    public partial class ChiTietDonHang : Form
    {
        DBConnect db = new DBConnect();
        private string maDonHang;
        public ChiTietDonHang(string maDon)
        {
            InitializeComponent();
            maDonHang = maDon;
        }

       
        private void ChiTietDonHang_Load(object sender, EventArgs e)
        {
            string query = "EXEC LayChiTietDonHang @maDonHang";
            var parameters = new Dictionary<string, object>
            {
                {"@maDonHang", maDonHang }
            };
            DataTable dt = db.getDataTableWithParams(query, parameters);
            dataGridView1.DataSource = dt;
        }
    }
}

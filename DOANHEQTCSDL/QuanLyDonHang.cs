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
    public partial class QuanLyDonHang : Form
    {
        public QuanLyDonHang()
        {
            InitializeComponent();
        }

        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            DonHang form1 = new DonHang();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KiemTraDon form1 = new KiemTraDon();
            form1.Show();
        }
    }
}

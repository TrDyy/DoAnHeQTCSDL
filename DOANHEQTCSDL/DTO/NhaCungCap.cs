using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class NhaCungCap
    {
        // Constructor nhận các tham số
        public NhaCungCap(int maNhaCungCap, string tenNhaCungCap, string diaChi, string dienThoai, string email)
        {
            this.MaNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.Email = email;
        }

        // Constructor nhận DataRow
        public NhaCungCap(DataRow row)
        {
            this.MaNhaCungCap = (int)row["MaNhaCungCap"];
            this.TenNhaCungCap = row["TenNhaCungCap"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.DienThoai = row["DienThoai"].ToString();
            this.Email = row["Email"].ToString();
        }

        // Các thuộc tính
        private int maNhaCungCap;
        public int MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }

        private string tenNhaCungCap;
        public string TenNhaCungCap
        {
            get { return tenNhaCungCap; }
            set { tenNhaCungCap = value; }
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private string dienThoai;
        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}

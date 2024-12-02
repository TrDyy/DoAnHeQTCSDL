using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class ChiTietPhieuNhap
    {
        // Constructor nhận các tham số
        public ChiTietPhieuNhap(int maPhieuNhap, int maSanPham, int maMauSac, int maKichThuoc, int soLuong, decimal giaNhap)
        {
            this.MaPhieuNhap = maPhieuNhap;
            this.MaSanPham = maSanPham;
            this.MaMauSac = maMauSac;
            this.MaKichThuoc = maKichThuoc;
            this.SoLuong = soLuong;
            this.GiaNhap = giaNhap;
        }

        // Constructor nhận DataRow
        public ChiTietPhieuNhap(DataRow row)
        {
            this.MaPhieuNhap = (int)row["MaPhieuNhap"];
            this.MaSanPham = (int)row["MaSanPham"];
            this.MaMauSac = (int)row["MaMauSac"];
            this.MaKichThuoc = (int)row["MaKichThuoc"];
            this.SoLuong = (int)row["SoLuong"];
            this.GiaNhap = (decimal)row["GiaNhap"];
        }

        // Các thuộc tính
        private int maPhieuNhap;
        public int MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set { maPhieuNhap = value; }
        }

        private int maSanPham;
        public int MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        private int maMauSac;
        public int MaMauSac
        {
            get { return maMauSac; }
            set { maMauSac = value; }
        }

        private int maKichThuoc;
        public int MaKichThuoc
        {
            get { return maKichThuoc; }
            set { maKichThuoc = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private decimal giaNhap;
        public decimal GiaNhap
        {
            get { return giaNhap; }
            set
            {
                if (value > 0)
                {
                    giaNhap = value;
                }
                else
                {
                    throw new ArgumentException("Giá nhập phải lớn hơn 0.");
                }
            }
        }
    }
}

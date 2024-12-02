using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }


        //CCCD
        public string SoCanCuoc { get; set; }
        public DateTime? NgayCap { get; set; }
        public string NoiCap { get; set; }

        //vai trò
        public int MaVaiTro { get; set; }

        // Constructor mặc định
        public NguoiDung() { }

        // Constructor đầy đủ tham số
        public NguoiDung(int maNguoiDung, string tenDangNhap, string matKhau, string hoTen, string dienThoai, int maVaiTro, string soCanCuoc, DateTime ngayCap, string noiCap)
        {
            MaNguoiDung = maNguoiDung;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            HoTen = hoTen;
            DienThoai = dienThoai;

            //CCCD
            SoCanCuoc = soCanCuoc;
            NgayCap = ngayCap;
            NoiCap = noiCap;

            //vai trò
            MaVaiTro = maVaiTro;
        }

        // Constructor nhận DataRow
        public NguoiDung(DataRow row)
        {
            MaNguoiDung = (int)row["MaNguoiDung"];
            TenDangNhap = row["TenDangNhap"].ToString();
            MatKhau = row["MatKhau"].ToString();
            HoTen = row["HoTen"].ToString();
            DienThoai = row["DienThoai"].ToString();

            //CCCD
            SoCanCuoc = row["SoCanCuoc"].ToString();
            NgayCap = row["NgayCap"] != DBNull.Value ? Convert.ToDateTime(row["NgayCap"]) : (DateTime?)null;
            NoiCap = row["NoiCap"].ToString();

            //vai trò: 
            MaVaiTro = (int)row["MaVaiTro"];
        }
    }
}

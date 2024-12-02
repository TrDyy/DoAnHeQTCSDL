using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class SP
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int MaPhanLoai { get; set; }
        public int MaThuongHieu { get; set; }
        public string GioiTinh { get; set; }
        public decimal GiaGoc { get; set; }
        public decimal GiaBan { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        // Constructor mặc định
        public SP() { }

        // Constructor nhận tham số
        public SP(DataRow row)
        {
            this.MaSanPham = row["MaSanPham"] != DBNull.Value ? Convert.ToInt32(row["MaSanPham"]) : 0;
            this.TenSanPham = row["TenSanPham"]?.ToString();
            this.MaPhanLoai = row["MaPhanLoai"] != DBNull.Value ? Convert.ToInt32(row["MaPhanLoai"]) : 0;
            this.MaThuongHieu = row["MaThuongHieu"] != DBNull.Value ? Convert.ToInt32(row["MaThuongHieu"]) : 0;
            this.GioiTinh = row["GioiTinh"]?.ToString();
            this.GiaGoc = row["GiaGoc"] != DBNull.Value ? Convert.ToDecimal(row["GiaGoc"]) : 0;
            this.GiaBan = row["GiaBan"] != DBNull.Value ? Convert.ToDecimal(row["GiaBan"]) : 0;
            this.MoTa = row["MoTa"]?.ToString();
            this.HinhAnh = row["HinhAnh"]?.ToString();
        }
    }
}

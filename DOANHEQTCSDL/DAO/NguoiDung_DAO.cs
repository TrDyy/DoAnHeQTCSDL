using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOANHEQTCSDL.DTO;
using System.Data;
using System.Data.SqlClient;

namespace DOANHEQTCSDL.DAO
{
    class NguoiDung_DAO
    {
        private static NguoiDung_DAO instance;

        public static NguoiDung_DAO Instance
        {
            get
            {
                if (instance == null) instance = new NguoiDung_DAO();
                return instance;
            }
            private set { instance = value; }
        }

        private NguoiDung_DAO() { }

        public List<NguoiDung> GetListNguoiDung()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            // Truy vấn kết hợp giữa ba bảng NguoiDung, VaiTro và CanCuocCongNhan
            string query = "SELECT * FROM GetNguoiDungDetails();";


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NguoiDung nguoiDung = new NguoiDung(row); // Sử dụng constructor DataRow
                list.Add(nguoiDung);
            }

            return list;
        }

        public bool InsertNguoiDung(string tenDangNhap, string matKhau, string hoTen, string dienThoai, int MaVaiTro, string soCanCuoc, DateTime ngayCap, string noiCap)
        {
            string query = "EXEC AddNguoiDungWithVaiTroAndCanCuoc @MaVaiTro, @TenDangNhap, @MatKhau, @HoTen, @DienThoai, @SoCanCuoc, @NgayCap, @NoiCap";

            // Thêm các tham số vào câu lệnh
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaVaiTro", MaVaiTro),
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau",matKhau),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@DienThoai", dienThoai),
                new SqlParameter("@SoCanCuoc",soCanCuoc),
                new SqlParameter("@NgayCap", ngayCap),
                new SqlParameter("@NoiCap", noiCap),
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteND(int MaNguoiDung)
        {
            string query = "EXEC DeleteNguoiDung @MaNguoiDung";
            // Thêm tham số vào câu lệnh
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNguoiDung", MaNguoiDung)
            };

            // Thực thi câu lệnh và lấy kết quả
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public bool UpdateNguoiDung(int MaNguoiDung, string TenDangNhap, string MatKhau, string HoTen, string DienThoai, int MaVaiTro, string soCanCuoc, DateTime ngayCap, string noiCap)
        {
            string query = "EXEC UpdateNguoiDungAndCCCD @MaNguoiDung, @TenDangNhap, @MatKhau, @HoTen, @DienThoai, @MaVaiTro, @SoCanCuoc, @NgayCap, @NoiCap";

            // Thêm tham số vào câu lệnh
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNguoiDung", MaNguoiDung),
                new SqlParameter("@TenDangNhap", TenDangNhap),
                new SqlParameter("@MatKhau", MatKhau),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@DienThoai", DienThoai),
                new SqlParameter("@MaVaiTro", MaVaiTro),
                new SqlParameter("@SoCanCuoc", soCanCuoc),
                new SqlParameter("@NgayCap", ngayCap),
                new SqlParameter("@NoiCap", noiCap)
            };

            // Thực thi câu lệnh và lấy kết quả
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

    }
}

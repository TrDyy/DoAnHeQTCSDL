using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DOANHEQTCSDL.DTO;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DOANHEQTCSDL.DAO
{
    class NhaCungCap_DAO
    {
        private static NhaCungCap_DAO instance;

        public static NhaCungCap_DAO Instance
        {
            get { if (instance == null) instance = new NhaCungCap_DAO(); return instance; }
            private set { instance = value; }
        }

        private NhaCungCap_DAO() { }

        // Lấy danh sách nhà cung cấp
        public List<NhaCungCap> GetListNhaCungCap()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            string query = "EXEC GetNhaCungCap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(row);
                list.Add(ncc);
            }

            return list;
        }

        // Thêm nhà cung cấp mới
        public bool InsertNhaCungCap(string tenNhaCungCap, string diaChi, string dienThoai, string email)
        {
            try
            {
                string query = "EXEC ThemNhaCungCap @TenNhaCungCap, @DiaChi, @DienThoai, @Email";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@TenNhaCungCap", SqlDbType.NVarChar) { Value = tenNhaCungCap },
                new SqlParameter("@DiaChi", SqlDbType.NVarChar) { Value = diaChi },
                new SqlParameter("@DienThoai", SqlDbType.NVarChar) { Value = dienThoai },
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email }
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                return result > 0;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        // Cập nhật thông tin nhà cung cấp
        public bool UpdateNhaCungCap(int maNCC, string tenNCC, string diaChi, string sdt, string email)
        {
            string query = "EXEC sp_UpdateNhaCungCap @MaNhaCungCap, @TenNhaCungCap, @DiaChi, @DienThoai, @Email";

            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@MaNhaCungCap", maNCC),
                    new SqlParameter("@TenNhaCungCap", tenNCC),
                    new SqlParameter("@DiaChi", diaChi),
                    new SqlParameter("@DienThoai", sdt),
                    new SqlParameter("@Email", email)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        // Xóa nhà cung cấp
        public bool DeleteNhaCungCap(int maNhaCungCap)
        {
            string query = "EXEC sp_DeleteNhaCungCap @MaNhaCungCap";

            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhaCungCap", maNhaCungCap)
                };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

    }
}

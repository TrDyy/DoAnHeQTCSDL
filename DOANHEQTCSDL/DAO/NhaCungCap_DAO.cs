using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string query = "SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai, Email FROM NhaCungCap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                NhaCungCap item = new NhaCungCap(row);
                list.Add(item);
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
            string query = string.Format("UPDATE NhaCungCap SET TenNhaCungCap = N'{0}', DiaChi = N'{1}', DienThoai = N'{2}', Email = N'{3}' WHERE MaNhaCungCap = {4}",
                                         tenNCC, diaChi, sdt, email, maNCC);

            int result = DataProvider.Instance.NonExecuteQuery(query);

            return result > 0;
        }

        // Xóa nhà cung cấp
        public bool DeleteNhaCungCap(int maNhaCungCap)
        {
            string query = string.Format("DELETE FROM NhaCungCap WHERE MaNhaCungCap = {0}", maNhaCungCap);
            int result = DataProvider.Instance.NonExecuteQuery(query);

            return result > 0;
        }

    }
}

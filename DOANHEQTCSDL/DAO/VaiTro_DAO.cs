using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DAO
{
    class VaiTro_DAO
    {
        private static VaiTro_DAO instance;

        public static VaiTro_DAO Instance
        {
            get
            {
                if (instance == null) instance = new VaiTro_DAO();
                return instance;
            }
            private set { instance = value; }
        }

        private VaiTro_DAO() { }

        public List<VaiTro> GetListVaiTro()
        {
            List<VaiTro> list = new List<VaiTro>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM VaiTro");

            foreach (DataRow row in data.Rows)
            {
                VaiTro vaiTro = new VaiTro(row); // Sử dụng constructor DataRow
                list.Add(vaiTro);
            }

            return list;
        }

        public VaiTro GetMaSanPham(int MaVaiTro)
        {
            VaiTro vaitro = null;

            string query = "select * from VaiTro where MaVaiTro = " + MaVaiTro;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                vaitro = new VaiTro(item);
                return vaitro;
            }

            return vaitro;
        }
    }
}

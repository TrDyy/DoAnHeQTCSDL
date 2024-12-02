using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DAO
{
    class SanPham_DAO
    {
        private static SanPham_DAO instance;

        public static SanPham_DAO Instance
        {
            get { if (instance == null) instance = new SanPham_DAO(); return instance; }
            private set { instance = value; }
        }

        private SanPham_DAO() { }

        public List<SP> GetListSanPham()
        {
            List<SP> list = new List<SP>();

            string query = "SELECT * FROM SanPham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                SP sp = new SP(row);
                list.Add(sp);
            }

            return list;
        }

        public SP GetMaSanPham(int MaSanPham)
        {
            SP sanpham = null;

            string query = "select * from SanPham where MaSanPham = " + MaSanPham;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                sanpham = new SP(item);
                return sanpham;
            }

            return sanpham;
        }
    }
}

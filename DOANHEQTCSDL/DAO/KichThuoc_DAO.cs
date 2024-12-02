using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DAO
{
    class KichThuoc_DAO
    {
        private static KichThuoc_DAO instance;

        public static KichThuoc_DAO Instance
        {
            get { if (instance == null) instance = new KichThuoc_DAO(); return instance; }
            private set { instance = value; }
        }

        private KichThuoc_DAO() { }

        public List<KichThuoc> GetListKichThuoc()
        {
            List<KichThuoc> list = new List<KichThuoc>();

            string query = "SELECT * FROM KichThuoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                KichThuoc kichThuoc = new KichThuoc(row);
                list.Add(kichThuoc);
            }

            return list;
        }

        public KichThuoc GetMaKichThuoc(int MaKichThuoc)
        {
            KichThuoc kichthuoc = null;

            string query = "select * from KichThuoc where MaKichThuoc = " + MaKichThuoc;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                kichthuoc = new KichThuoc(item);
                return kichthuoc;
            }

            return kichthuoc;
        }
    }
}

using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DAO
{
    class MauSac_DAO
    {
        private static MauSac_DAO instance;

        public static MauSac_DAO Instance
        {
            get { if (instance == null) instance = new MauSac_DAO(); return instance; }
            private set { instance = value; }
        }

        private MauSac_DAO() { }

        public List<MauSac> GetListMauSac()
        {
            List<MauSac> list = new List<MauSac>();

            string query = "SELECT * FROM MauSac";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                MauSac mauSac = new MauSac(row);
                list.Add(mauSac);
            }

            return list;
        }

        public MauSac GetMaMauSac(int MaMauSac)
        {
            MauSac mauSac = null;

            string query = "select * from MauSac where MaMauSac = " + MaMauSac;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                mauSac = new MauSac(item);
                return mauSac;
            }

            return mauSac;
        }


    }
}

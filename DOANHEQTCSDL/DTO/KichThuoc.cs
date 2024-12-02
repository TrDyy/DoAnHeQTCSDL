using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class KichThuoc
    {
        public int MaKichThuoc { get; set; }
        public string TenKichThuoc { get; set; }

        // Constructor mặc định
        public KichThuoc() { }

        // Constructor từ DataRow
        public KichThuoc(DataRow row)
        {
            this.MaKichThuoc = row["MaKichThuoc"] != DBNull.Value ? Convert.ToInt32(row["MaKichThuoc"]) : 0;
            this.TenKichThuoc = row["TenKichThuoc"]?.ToString();
        }
    }
}

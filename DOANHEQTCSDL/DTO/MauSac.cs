using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class MauSac
    {
        public int MaMauSac { get; set; }
        public string TenMauSac { get; set; }

        // Constructor mặc định
        public MauSac() { }

        // Constructor từ DataRow
        public MauSac(DataRow row)
        {
            this.MaMauSac = row["MaMauSac"] != DBNull.Value ? Convert.ToInt32(row["MaMauSac"]) : 0;
            this.TenMauSac = row["TenMauSac"]?.ToString();
        }
    }
}

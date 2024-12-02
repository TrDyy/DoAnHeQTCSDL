using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DTO
{
    class VaiTro
    {
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        // Constructor mặc định
        public VaiTro() { }

        // Constructor đầy đủ tham số
        public VaiTro(int maVaiTro, string tenVaiTro)
        {
            MaVaiTro = maVaiTro;
            TenVaiTro = tenVaiTro;
        }

        // Constructor nhận DataRow
        public VaiTro(DataRow row)
        {
            MaVaiTro = (int)row["MaVaiTro"];
            TenVaiTro = row["TenVaiTro"].ToString();
        }
    }
}

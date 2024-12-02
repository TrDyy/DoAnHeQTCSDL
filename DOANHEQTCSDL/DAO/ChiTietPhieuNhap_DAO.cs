using DOANHEQTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOANHEQTCSDL.DAO
{
   class ChiTietPhieuNhap_DAO
    {
        private static ChiTietPhieuNhap_DAO instance;

        public static ChiTietPhieuNhap_DAO Instance
        {
            get { if (instance == null) instance = new ChiTietPhieuNhap_DAO(); return ChiTietPhieuNhap_DAO.instance; }
            private set { ChiTietPhieuNhap_DAO.instance = value; }
        }

        private ChiTietPhieuNhap_DAO() { }

        public void deleteCTPNbyMaPN(int MaPhieuNhap)
        {
            string query = "delete ChiTietPhieuNhap where MaPhieuNhap = " + MaPhieuNhap + "";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
        }

        // Lấy danh sách chi tiết phiếu nhập
        public List<ChiTietPhieuNhap> GetListCTPN()
        {
            List<ChiTietPhieuNhap> list = new List<ChiTietPhieuNhap>();

            string query = "SELECT MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap FROM ChiTietPhieuNhap";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap(item);
                list.Add(ctpn);
            }

            return list;
        }

        // Thêm chi tiết phiếu nhập
        public bool InsertCTPN(int maPhieuNhap, int maSanPham, int maMauSac, int maKichThuoc, int soLuong, decimal giaNhap)
        {
            string query = string.Format(
                "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, MaMauSac, MaKichThuoc, SoLuong, GiaNhap) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                maPhieuNhap, maSanPham, maMauSac, maKichThuoc, soLuong, giaNhap);

            int result = DataProvider.Instance.NonExecuteQuery(query);

            return result > 0;
        }

        // Cập nhật chi tiết phiếu nhập
        public bool UpdateCTPN(int maPhieuNhap, int maSanPham, int maMauSac, int maKichThuoc, int soLuong, decimal giaNhap)
        {
            string query = string.Format(
                "UPDATE ChiTietPhieuNhap " +
                "SET SoLuong = {4}, GiaNhap = {5} " +
                "WHERE MaPhieuNhap = {0} AND MaSanPham = {1} AND MaMauSac = {2} AND MaKichThuoc = {3}",
                maPhieuNhap, maSanPham, maMauSac, maKichThuoc, soLuong, giaNhap);

            int result = DataProvider.Instance.NonExecuteQuery(query);

            return result > 0;
        }

        // Xóa chi tiết phiếu nhập
        public bool DeleteCTPN(int maPhieuNhap, int maSanPham, int maMauSac, int maKichThuoc)
        {
            string query = string.Format(
                "DELETE FROM ChiTietPhieuNhap " +
                "WHERE MaPhieuNhap = {0} AND MaSanPham = {1} AND MaMauSac = {2} AND MaKichThuoc = {3}",
                maPhieuNhap, maSanPham, maMauSac, maKichThuoc);

            int result = DataProvider.Instance.NonExecuteQuery(query);

            return result > 0;
        }
    }
}

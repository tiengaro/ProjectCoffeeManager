using ProjectCoffeeManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCoffeeManager.Control
{
    public class ControlSanPham
    {
        /// <summary>
        /// Lấy dữ liệu từ Database lên Giao diện
        /// </summary>
        /// <returns>Trả về kiểu DataTable</returns>
        public static DataTable getSanPham()
        {
            //Câu lệnh truy vấn SQL
            string query = "Select MaSanPham, TenSanPham, TenLoaiSanPham, GiaBan from SanPham sp, LoaiSanPham lsp Where sp.MaLoaiSanPham = lsp.MaLoaiSanPham Order by sp.MaLoaiSanPham";
            DataTable dt = Connector.getData(query);
            return dt;
        }
        /// <summary>
        /// Lấy sản phẩm theo từng loại
        /// </summary>
        /// <param name="loaisp">Là loại sản phẩm cần load</param>
        /// <returns></returns>
        public static DataTable getSanPhambyMaLoaiSP(string malsp)
        {
            //Câu lệnh truy vấn SQL
            string query = "Select MaSanPham, TenSanPham, TenLoaiSanPham , GiaBan from SanPham sp, LoaiSanPham lsp where sp.MaLoaiSanPham = lsp.MaLoaiSanPham and sp.MaLoaiSanPham = " + malsp;
            DataTable dt = Connector.getData(query);
            return dt;
        }
        /// <summary>
        /// Hàm Nhập 1 Sản phẩm vào SQL
        /// </summary>
        /// <param name="tensp">Tên sản hẩm cần nhập</param>
        /// <param name="maloaisp">mã loại sãn phẩm</param>
        /// <param name="giaban">giá bán</param>
        public static void insertSanPham(string tensp, string maloaisp, string giaban)
        {
            //Câu lệnh truy vấn SQL
            string query = "insert into SanPham values (N'" + tensp + "'," + maloaisp + "," + giaban + ")";
            Connector.updateInsertDelete(query);
        }
        /// <summary>
        /// Hàm cập nhật sản phẩm vào SQL
        /// </summary>
        /// <param name="masp">mã sản phẩm</param>
        /// <param name="tensp">tên sản phẩm</param>
        /// <param name="maloaisp">mã loại sản phẩm</param>
        /// <param name="giaban">giá bán</param>
        public static void updateSanPham(string masp, string tensp, string maloaisp, string giaban)
        {
            //Câu lệnh truy vấn SQL
            string query = "update SanPham set TenSanPham = N'" + tensp + "', MaLoaiSanPham = " + maloaisp + ", GiaBan = " + giaban + " where MaSanPham = " + masp;
            Connector.updateInsertDelete(query);
        }
        /// <summary>
        /// Hàm xóa 1 sản phẩm
        /// </summary>
        /// <param name="masp">mã sản phẩm</param>
        public static void deleteSanPham(string masp)
        {
            //Câu lệnh truy vấn SQL
            string query = "Delete SanPham where MaSanPham = " + masp;
            Connector.updateInsertDelete(query);
        }
    }
}

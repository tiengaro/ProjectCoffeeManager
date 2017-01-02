using ProjectCoffeeManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCoffeeManager.Control
{
    public class ControlLoaiSanPham
    {
        /// Lấy dữ liệu từ Database lên Giao diện
        public static DataTable getLoaiSanPham()
        {
            //Câu Lệnh truy vấn SQL
            string query = "Select * from LoaiSanPham";
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable
            return dt;
        }

        /// Lấy sản phẩm theo từng loại
        public static DataTable getSanPhambyLoaiSP(string loaisp)
        {
            //Câu Lệnh truy vấn SQL
            string query = "select * from SanPham where tenLoaiSanPham = " + loaisp;
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable
            return dt;
        }
        /// Thêm Loại Sản Phẩm
        public static void insertLoaiSanPham(string tenlsp)
        {
            //Câu Lệnh truy vấn SQL
            string query = "insert into LoaiSanPham values (N'" + tenlsp + "')";
            Connector.updateInsertDelete(query);
        }

        /// Xóa loại sản phẩm
        public static void deleteLoaiSanPham(string malsp)
        {
            //Câu Lệnh truy vấn SQL
            string query = "delete LoaiSanPham where MaLoaiSanPham = " + malsp;
            Connector.updateInsertDelete(query);
        }

    }
}

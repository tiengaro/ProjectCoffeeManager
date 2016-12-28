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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCoffeeManager.Model;
using System.Data;

namespace ProjectCoffeeManager.Control
{
    class ControlHoaDon
    {
        /// <summary>
        /// Hàm Lấy thông tin các hóa đơn trong SQL
        /// </summary>
        /// <returns>trả về giá trị Datatable</returns>
        public static DataTable getHoaDon()
        {
            //Câu lệnh truy vấn SQL
            string query = "select * from HoaDon";
            DataTable dt = Connector.getData(query);
            return dt;
        }
        /// <summary>
        /// Hàm trả về tổng tiền theo mã hóa đơn
        /// </summary>
        /// <param name="mahd">Mã hóa đơn đang order</param>
        /// <returns></returns>
        public static string getTongTienbyMaHD(string mahd)
        {
            //Câu lệnh truy vấn SQL
            string query = "Select sum(ThanhTien) from ChiTietHoaDon where MaHD = " + mahd;
            DataTable dt = Connector.getData(query);
            //trả về 1 chuỗi tổng tiền
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// Hàm thêm 1 hóa đơn vào
        /// </summary>
        /// <param name="ngaylap">ngày thêm vào</param>
        public static void insertHoaDon(string ngaylap)
        {
            //Câu lệnh truy vấn SQL
            string query = "set dateformat dmy Insert into HoaDon values ('" + ngaylap + "')";
            Connector.updateInsertDelete(query);
        }
        public static void deleteHoaDon(string mahd)
        {
            string query = "delete HoaDon where MaHD =" + mahd;
            Connector.updateInsertDelete(query);
        }
    }
}

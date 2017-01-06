using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCoffeeManager.Control
{
    class ControlChiTietHoaDon
    {
        /// <summary>
        /// Hàm lấy chi tiết hóa đơn theo ngày
        /// </summary>
        /// <param name="ngay">ngày cần tìm</param>
        /// <param name="thang">tháng cần tìm</param>
        /// <param name="nam">năm cần tìm</param>
        /// <returns>trả về giá trị datatable</returns>
        public static DataTable getChiTietHoaDonbyNgay(string ngay, string thang, string nam)
        {
            //Câu lệnh truy vấn SQL
            string query = "Select TenSanPham, TenLoaiSanPham, NgayLap, SL = sum(SoLuong), TongTien = sum(ThanhTien) from ChiTietHoaDon cthd, SanPham sp, LoaiSanPham lsp, HoaDon hd Where cthd.MaSanPham = sp.MaSanPham and sp.MaLoaiSanPham = lsp.MaLoaiSanPham and hd.MaHD = cthd.MaHD and day(NgayLap) = " + ngay + " and month(NgayLap) = " + thang + " and year(NgayLap) = " + nam + " group by TenSanPham, TenLoaiSanPham, NgayLap Order by SL Desc";
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable
            return dt;
        }
        /// <summary>
        /// Hàm lấy chi tiết hóa đơn theo Mã Hóa Đơn
        /// </summary>
        /// <param name="mahd">Mã hóa đơn cần lấy</param>
        /// <returns>trả về giá trị Datatable</returns>
        public static DataTable getChiTietHoaDonbyMaHD(string mahd)
        {
            //Câu lệnh truy vấn SQL
            string query = "Select sp.MaSanPham, TenSanPham, TenLoaiSanPham, SoLuong, ThanhTien from ChiTietHoaDon hd, SanPham sp,LoaiSanPham lsp Where hd.MaSanPham = sp.MaSanPham and sp.MaLoaiSanPham = lsp.MaLoaiSanPham and hd.MaHD = " + mahd;
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable
            return dt;
        }
        /// <summary>
        /// Hàm lấy tổng tiền của hoán đơn theo ngày
        /// </summary>
        /// <param name="ngay">Ngày cần lấy</param>
        /// <param name="thang">Tháng cần lấy</param>
        /// <param name="nam">Năm cần lấy</param>
        /// <returns>trả về chuỗi giá trị tổng tiền</returns>
        public static string getTongTienbyNgay(string ngay, string thang, string nam)
        {
            //Câu lệnh truy vấn SQL
            string query = "Select sum(ThanhTien)  from ChiTietHoaDon cthd, HoaDon hd where cthd.MaHD = hd.MaHD and day(NgayLap) = " + ngay + " and month(NgayLap) = " + thang + " and year(NgayLap) = " + nam;
            DataTable dt = Connector.getData(query);
            //Lấy tổng tiền từ dt do cơ sở dữ liệu trả về
            string tongtien = dt.Rows[0].ItemArray[0].ToString();
            //trả về giá trị string tổng tiền
            return tongtien;
        }
        /// <summary>
        /// Hàm kiểm tra Chi Tiết Hóa Đơn xem có chi tiết hóa đơn đó có tồn tại chưa
        /// </summary>
        /// <param name="masp">Mã sản phẩm cần tìm</param>
        /// <param name="mahd">Tên sản phẩm cần tìm</param>
        /// <returns>trả về giá trị Datatable</returns>
        public static DataTable KiemTraCTHD(string masp, string mahd)
        {
            //Câu lệnh truy vấn SQL
            string query = "SELECT MaSanPham, SoLuong, ThanhTien FROM ChiTietHoaDon cthd where MaSanPham = " + masp + "and MaHD =" + mahd;
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable         
            return dt;
        }
        /// <summary>
        /// Hàm thêm 1 chi tiết hóa đơn vào SQL
        /// </summary>
        /// <param name="mahd">Mã hóa đơn đang order</param>
        /// <param name="masp">Mã Sản phẩm cần thêm</param>
        /// <param name="soluong">Số lượng sản phẩm cần thêm</param>
        /// <param name="thanhtien">Thành tiền</param>
        public static void insertChiTietHoaDon(string mahd, string masp, string soluong, string thanhtien)
        {
            //Câu lệnh truy vấn SQL
            string query = "insert into ChiTietHoaDon values ( " + mahd + "," + masp + "," + soluong + "," + thanhtien + ")";
            Connector.updateInsertDelete(query);
        }
        /// <summary>
        /// Hàm cập nhật lại 1 chi tiết hóa đơn vào SQL
        /// </summary>
        /// <param name="mahd">Mã hóa đơn đang order</param>
        /// <param name="masp">Mã Sản phẩm cần cập nhật</param>
        /// <param name="soluong">Số lượng sản phẩm cần cập nhật</param>
        /// <param name="thanhtien">Thành tiền</param>
        public static void updateChiTietHoaDon(string mahd, string masp, string soluong, string thanhtien)
        {
            //Câu lệnh truy vấn SQL
            string query = "update ChiTietHoaDon set SoLuong = " + soluong + ", ThanhTien = " + thanhtien + " where MaHD = " + mahd + " and MaSanPham = " + masp;
            Connector.updateInsertDelete(query);
        }
        /// <summary>
        /// Hàm xóa 1 chi tiết hóa đơn trong SQL
        /// </summary>
        /// <param name="masp">Mã sản phẩm cần xóa</param>
        /// <param name="mahd">Mã hóa đơn đang order</param>
        public static void deleteChiTiethoaDon(string masp, string mahd)
        {
            //Câu lệnh truy vấn SQL
            string query = "Delete ChiTietHoaDon where MaSanPham = " + masp + "and MaHD =" + mahd;
            Connector.updateInsertDelete(query);
        }
        public static void deleteChiTietHoaDonBymahd(string mahd)
        {
            string query = "Delete ChiTietHoaDon where MaHD = " + mahd;
            Connector.updateInsertDelete(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProjectCoffeeManager.Model
{
    public class Connector
    {
        //Chuỗi Sever chưa tên Server SQL
        //Chuối kết nối vào SQL
        static string KetNoi = @"Data Source=DESKTOP-5NI4TKC\SQLEXPRESS;Initial Catalog = QLCafe; Integrated Security = True";

        /// <summary>
        /// Thực thi Thêm, Sửa, Xóa tổng quát
        /// </summary>.\QuanLyCafe\QuanLyCafe\Model\Connector.cs
        /// <param name="command">Là câu lên truy vấn SQL Thêm Sửa Xóa</param>
        public static void updateInsertDelete(string command)
        {
            //int ketqua = 0;
            //câu lệnh kết nối sql
            SqlConnection conn = new SqlConnection(KetNoi);
            //Mở kết nối sql
            conn.Open();
            //Đưa câu truy vấn vào SQL
            SqlCommand cmd = new SqlCommand(command, conn);
            //trả về 1 giá trị báo lỗi
            //ketqua = 
            cmd.ExecuteNonQuery();
            //Đóng kết nối sql
            conn.Close();
            //return ketqua;
        }
        /// <summary>
        /// Hàm này dùng để lấy dữ liệu các bản từ Database
        /// </summary>
        /// <param name="table">Là tên bảng cần lấy dữ liệu</param>
        /// <param name="command">Là câu lệnh truy vấn cho bảng đó</param>
        /// <returns>kiểu DataTable</returns>
        public static DataTable getData(string command)
        {
            DataTable dt = new DataTable();
            //Câu lệnh kết nối sql
            SqlConnection conn = new SqlConnection(KetNoi);
            //Mở kết nối sql
            conn.Open();
            //đưa chuỗi truy vấn vào sql
            SqlCommand cmd = new SqlCommand(command, conn);
            //tạo 1 table tạm để lưu trữ dữ liệu
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            //Đưa dữ liệu vào bảng tạm
            sda.Fill(ds);
            dt = ds.Tables[0];
            //Đóng kết nối sql
            conn.Close();
            return dt;
        }
    }
}

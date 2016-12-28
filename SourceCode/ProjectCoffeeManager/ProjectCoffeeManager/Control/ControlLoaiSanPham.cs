﻿using ProjectCoffeeManager.Model;
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
        /// <summary>
        /// Lấy dữ liệu từ Database lên Giao diện
        /// </summary>
        /// <returns>Trả về kiểu DataTable</returns>
        public static DataTable getLoaiSanPham()
        {
            //Câu Lệnh truy vấn SQL
            string query = "Select * from LoaiSanPham";
            DataTable dt = Connector.getData(query);
            //Trả về giá trị Datatable
            return dt;
        }
    }
}

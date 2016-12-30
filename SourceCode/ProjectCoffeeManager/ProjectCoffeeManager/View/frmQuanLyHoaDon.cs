using ProjectCoffeeManager.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectCoffeeManager.View
{
    public partial class frmQuanLyHoaDon : Form
    {
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nếu form Quản Lý Hóa Đơn được mở lên thì sẽ làm những tác vụ trong hàm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            //Đưa dữ liệu loại sản phẩm từ sql lên combobox loại
            loadcbbloaisp();
            //Đưa dữ liệu thông tin sản phẩm từ sql lên listview thông tin sản phẩm
            loadlstSanPham();

            btnThanhToan.Enabled = false;
            btnXoa.Enabled = false;
            btnHuyHD.Enabled = false;
        }

        /// <summary>
        /// Hàm load loại sản phẩm vào combobox
        /// </summary>
        private void loadcbbloaisp()
        {
            //Lấy dữ liệu thông tin loại sản phẩm từ sql
            DataTable dt = ControlLoaiSanPham.getLoaiSanPham();
            //đưa dữ liệu đó vào combobox loại sản phẩm
            cbbLoaiSanPham.DataSource = dt;
            cbbLoaiSanPham.ValueMember = "MaLoaiSanPham";
            cbbLoaiSanPham.DisplayMember = "TenLoaiSanPham";
        }

        /// <summary>
        /// Hàm load sản phẩm từ sql
        /// </summary>
        private void loadlstSanPham()
        {
            //Lấy dữ liệu sản phẩm từ sql
            DataTable dt = ControlSanPham.getSanPham();
            //Hàm đưa dữ liệu từ bảng vào listview thực đơn
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

                lstThucDon.Items.Add(item);
            }
        }

        /// <summary>
        /// Sự kiện cho nút Đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

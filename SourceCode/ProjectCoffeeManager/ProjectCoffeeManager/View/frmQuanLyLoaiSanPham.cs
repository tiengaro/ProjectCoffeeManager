using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCoffeeManager.View
{
    public partial class frmQuanLyLoaiSanPham : Form
    {
        public frmQuanLyLoaiSanPham()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            loadLoaiSP();
            txtTenLoai.Focus();
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }
        /// <summary>
        /// Hàm load loại sản phẩm từ sql lên list view danh sách
        /// </summary>
        private void loadLoaiSP()
        {
            lstDanhSach.Items.Clear();
            DataTable dt = Control.ControlLoaiSanPham.getLoaiSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString());

                lstDanhSach.Items.Add(item);
            }
        }
    }
}

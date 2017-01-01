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

        /// Hàm load loại sản phẩm từ sql lên list view danh sách
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

        private void frmQuanLyLoaiSanPham_Load_1(object sender, EventArgs e)
        {
            loadLoaiSP();
            txtTenLoai.Focus();
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// Hàm đưa dữ liệu từ listview lên textbox
        private void lstDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sodongchon = lstDanhSach.SelectedIndices.Count;
            if (sodongchon == 1)
            {
                int vitrichon = lstDanhSach.SelectedIndices[0];
                txtMaLoai.Text = lstDanhSach.Items[vitrichon].SubItems[0].Text;
                txtTenLoai.Text = lstDanhSach.Items[vitrichon].SubItems[1].Text;
            }
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //xử lý nếu chưa nhập tên loại sản phẩm
            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại sản phẩm cần thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Xử lý xem sản phẩm đó đã có trong danh sách sản phẩm chưa
            else if (!KiemTraLoaiSanPham())
            {
                MessageBox.Show("Loại Sản phẩm bạn vừa thêm đã có sẵn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtTenLoai.Clear();
            }
            //Nếu tất cả trường hợp trên đều không có thì cho phép người dùng thêm loại sản phẩm
            else
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn thêm loại sản phầm.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    Control.ControlLoaiSanPham.insertLoaiSanPham(txtTenLoai.Text);
                    txtTenLoai.Clear();
                    lstDanhSach.Items.Clear();
                    loadLoaiSP();
                }
                txtTenLoai.Clear();
            }
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }
        private bool KiemTraLoaiSanPham()
        {
            string query = "select * from LoaiSanPham where TenLoaiSanPham = N'" + txtTenLoai.Text + "'";
            DataTable dt = Model.Connector.getData(query);
            return dt.Rows.Count > 0 ? false : true;
        }
    }
}

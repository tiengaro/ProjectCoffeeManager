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
    public partial class frmQuanLySanPham : Form
    {
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void lstDanhSachSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sodongchon = lstDanhSachSP.SelectedIndices.Count;
            if (sodongchon == 1)
            {
                for (int i = 0; i < sodongchon; i++)
                {
                    int vitrichon = lstDanhSachSP.SelectedIndices[i];
                    txtTenSP.Text = lstDanhSachSP.Items[vitrichon].SubItems[1].Text;
                    cbbLoaiSP.Text = lstDanhSachSP.Items[vitrichon].SubItems[2].Text;
                    txtGiaBan.Text = lstDanhSachSP.Items[vitrichon].SubItems[3].Text;
                }
            }
            setButton(false);

        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            //Load sản phẩm vào listview thông tin sản phẩm
            LoadSanPham();
            //đưa trỏ chuột đến vị trí nhập tên sản phẩm
            txtTenSP.Focus();
            setButton(true);
            setText();

        }
        private void setButton(bool a)
        {
            btnThem.Enabled = a;
            btnClose.Enabled = a;
            btnCapNhat.Enabled = !a;
            btnXoa.Enabled = !a;
        }
        private void setText()
        {
            txtGiaBan.Text = null;
            txtTenSP.Text = null;
        }
        /// <summary>
        /// Hàm xử lý sự kiện click vào nút đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Click(object sender, EventArgs e)
        {
            //frmQuanLyHoaDon frm = new frmQuanLyHoaDon();
            //tắt form quản lý cửa hàng
            this.Hide();
            //mở lại form quản lý hóa đơn
            //frm.Show();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //xử lý nếu chưa nhập tên sản phẩm
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin sản phẩm cần thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Xử lý xem sản phẩm đó đã có trong danh sách sản phẩm chưa
            else if (!KiemTraSanPham())
            {
                MessageBox.Show("Sản phẩm bạn vừa thêm đã có sẵn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtTenSP.Clear();
                txtGiaBan.Clear();
            }
            //Nếu tất cả trường hợp trên đều không có thì cho phép người dùng thêm sản phẩm
            else
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn thêm sản phầm.", "Thông báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    Control.ControlSanPham.insertSanPham(txtTenSP.Text, cbbLoaiSP.SelectedValue.ToString(), txtGiaBan.Text);
                    txtTenSP.Clear();
                    txtGiaBan.Clear();
                    lstDanhSachSP.Items.Clear();
                    LoadSanPham();
                }
            }
            setButton(true);
            setText();

        }
        /// <summary>
        /// xử lý sự kiện click vào nút cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        /// /// <summary

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int sodongchon = lstDanhSachSP.SelectedIndices.Count;
            //xử lý nếu người dùng đã chọn 1 sản phẩm trong danh sách sản phẩm
            if (sodongchon == 1)
            {
                if (txtTenSP.Text == "" || txtGiaBan.Text == "")
                    MessageBox.Show("Bạn chưa nhập thông tin sản phẩm để cập nhật");
                else
                {
                    DialogResult tl = MessageBox.Show("Bạn có muốn cập nhật loại sản phẩm.", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tl == DialogResult.Yes)
                    {
                        int vitri = lstDanhSachSP.SelectedIndices[0];
                        string masp = lstDanhSachSP.Items[vitri].SubItems[0].Text;
                        string tensp = txtTenSP.Text;
                        string giaban = txtGiaBan.Text;
                        string loaisp = cbbLoaiSP.SelectedValue.ToString();
                        Control.ControlSanPham.updateSanPham(masp, tensp, loaisp, giaban);
                        lstDanhSachSP.Items.Clear();
                        LoadSanPham();
                    }
                }

            }
            setButton(true);
            setText();
            //nếu chưa chọn thì thống báo cho người dùng biết 
            //else
            //    MessageBox.Show("Bạn chưa chọn sản phẩm cần cập nhật.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        /// <summary>
        /// xử lý sự kiên click vào nút xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int sodongchon = lstDanhSachSP.SelectedIndices.Count;
            //xử lý nếu đã chọn 1 sản phẩm trong danh sách sản phẩm
            if (sodongchon == 1)
            {
                int vitrichon = lstDanhSachSP.SelectedIndices[0];
                string masp = lstDanhSachSP.Items[vitrichon].SubItems[0].Text;
                //kiểm tra xem sản phẩm người dùng muốn xóa đã có trong hóa đơn chưa..
                //nếu chưa có tiếp tục câu lệnh dưới
                if (KiemTraHoaDonSanPham(masp))
                {
                    DialogResult tl = MessageBox.Show("Bạn có muốn xóa sản phẩm.", "Cảnh báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tl == DialogResult.Yes)
                    {
                        Control.ControlSanPham.deleteSanPham(masp);
                        lstDanhSachSP.Items.Clear();
                        LoadSanPham();
                    }
                    txtTenSP.Text = null;
                    txtGiaBan.Text = null;
                }
                //nếu đã có thì không cho người dùng xóa
                else
                    MessageBox.Show("Sản phẩm này không thể xóa được.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            setText();
            setButton(true);
            //nếu chưa chọn sản phẩm thì thông báo cho người dùng
            //else
            //    MessageBox.Show("Bạn chưa chọn sản phẩm cần xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadSanPham()
        {
            DataTable dt = Control.ControlSanPham.getSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

                lstDanhSachSP.Items.Add(item);
            }
        }
        /// <summary>
        /// Hàm load loại sản phẩm lên combobox loại sản phẩm
        /// </summary>
        private void LoadLoaiSanPham()
        {
            DataTable dt = Control.ControlLoaiSanPham.getLoaiSanPham();
            cbbLoaiSP.DataSource = dt;
            cbbLoaiSP.ValueMember = "MaLoaiSanPham";
            cbbLoaiSP.DisplayMember = "TenLoaiSanPham";
        }
        /// <summary>
        /// Hảm kiểm tra sản phầm xem đã tồn tại chưa
        /// </summary>
        /// <returns>trả về kiểu bool. true: sản phẩm chưa tồn tại; false: sản phẩm đã tồn tại</returns>
        private bool KiemTraSanPham()
        {
            string query = "select * from SanPham where TenSanPham = N'" + txtTenSP.Text + "'";
            DataTable dt = Model.Connector.getData(query);
            return dt.Rows.Count > 0 ? false : true;
        }
        /// <summary>
        /// /Hàm kiểm tra sản phẩm xem đã được order chưa
        /// </summary>
        /// <param name="masp"></param>
        /// <returns>trả về kiểu bool, true: sản phẩm chưa order, false: sản phẩm đã order</returns>
        private bool KiemTraHoaDonSanPham(string masp)
        {
            string query = "select * from ChiTietHoaDon where MaSanPham = " + masp;
            DataTable dt = Model.Connector.getData(query);
            return dt.Rows.Count > 0 ? false : true;
        }
        /// <summary>
        /// Hàm không cho nhập chữ vào textbox giá bán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Ban nhap sai nhap lai", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstDanhSachSP_DoubleClick(object sender, EventArgs e)
        {
            int vitrichon = lstDanhSachSP.SelectedIndices[0];
            string masp = lstDanhSachSP.Items[vitrichon].SubItems[0].Text;
            //kiểm tra xem sản phẩm người dùng muốn xóa đã có trong hóa đơn chưa..
            //nếu chưa có tiếp tục câu lệnh dưới
            if (KiemTraHoaDonSanPham(masp))
            {
                DialogResult tl = MessageBox.Show("Bạn có muốn xóa sản phẩm.", "Cảnh báo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    Control.ControlSanPham.deleteSanPham(masp);
                    lstDanhSachSP.Items.Clear();
                    LoadSanPham();
                }
            }
            //nếu đã có thì không cho người dùng xóa
            else
                MessageBox.Show("Sản phẩm này không thể xóa được.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lstDanhSachSP_Click(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}

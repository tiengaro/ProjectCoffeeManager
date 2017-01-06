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

        /// <summary>
        /// Hàm xử lý sự kiện chọn 1 item trong combobox Loại Sản Phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbLoaiSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Xóa các item trong listview thực đơn
            lstThucDon.Items.Clear();
            //Lấy mã sản phẩm tự comboxbox đang chọn
            string MaSP = cbbLoaiSanPham.SelectedValue.ToString();
            //đưa dữ liệu thông tin sản phẩm theo mã sản phẩm vào bảng tạm dt
            DataTable dt = ControlSanPham.getSanPhambyMaLoaiSP(MaSP);
            //Hàm show dữ liệu lên listview Thực đơn
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //đưa dữ liệu từ sql lên 1 listview tạm
                ListViewItem item = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                //add listview tạm đó vào listview thực đơn
                lstThucDon.Items.Add(item);
            }
        }

        /// <summary>
        /// xử lý sự kiện khi click button Thêm Món
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            //Câu lệnh chuyển đổi chức năng cho 1 button thêm món
            if (btnThemMon.Text == "Tạo Hóa Đơn")
            {
                //Câu lệnh tạo hóa đớn vào csdl

                lblThongBao.Text = "Tổng tiền: 0 đồng";
                //Chuyển button Tạo hóa đơn thành Thêm Món
                btnThemMon.Text = "Thêm Món";
                //lấy mã hóa đợn hiện đang order

                btnThemMon.Enabled = false;
                btnHuyHD.Enabled = true;
                return;
            }
            else
            {
                ThemMon();
            }
        }

        /// <summary>
        /// Hàm xử lý sự kiện nếu double click vào listview thực đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstThucDon_DoubleClick(object sender, EventArgs e)
        {

            
                ThemMon();
            
        }

        /// <summary>
        /// Hàm xử lý button thêm món
        /// </summary>
        public void ThemMon()
        {
            //nếu button là thêm món thì xử lý
            //lấy số dòng chọn
            int sodongchon = lstThucDon.SelectedIndices.Count;
            //nếu có chọn trong listview thực đơn thì xử lý
            if (sodongchon == 1)
            {
                //lấy vị trí chọn hiện tại
                int vitrichon = lstThucDon.SelectedIndices[0];
                //Lấy thông tin sản phẩm tự vị trí chọn

                int soluong = int.Parse(nudSoLuong.Value.ToString());
                int giaban = int.Parse(lstThucDon.Items[vitrichon].SubItems[3].Text);
                int thanhtien;
                
                    for (int i = 0; i < lstHoaDon.Items.Count; i++)
                        if (lstHoaDon.Items[i].SubItems[0].Text == lstThucDon.Items[vitrichon].SubItems[0].Text)
                        {
                            int sl = int.Parse(nudSoLuong.Value.ToString()) + int.Parse(lstHoaDon.Items[i].SubItems[3].Text);
                            thanhtien = sl * giaban;
                            lstHoaDon.Items[i].SubItems[3].Text = sl.ToString();
                            lstHoaDon.Items[i].SubItems[4].Text = thanhtien.ToString();
                            nudSoLuong.Value = 1;
                            return;
                        }
                    ListViewItem item = new ListViewItem(lstThucDon.Items[vitrichon].SubItems[0].Text);
                    item.SubItems.Add(lstThucDon.Items[vitrichon].SubItems[1].Text);
                    item.SubItems.Add(lstThucDon.Items[vitrichon].SubItems[2].Text);
                    item.SubItems.Add(nudSoLuong.Value.ToString());
                    thanhtien = int.Parse(nudSoLuong.Value.ToString()) * giaban;
                    item.SubItems.Add(thanhtien.ToString());
                    lstHoaDon.Items.Add(item);
            }
            nudSoLuong.Value = 1;
            btnThemMon.Enabled = false;
            btnThanhToan.Enabled = true;

        }
    }


    private void nudSoLuong_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }
}

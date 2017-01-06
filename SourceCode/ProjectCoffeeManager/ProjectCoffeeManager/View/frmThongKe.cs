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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void datetime_ValueChanged(object sender, EventArgs e)
        {
            //Lấy ngày tháng năm
            string ngay = datetime.Value.Day.ToString();
            string thang = datetime.Value.Month.ToString();
            string nam = datetime.Value.Year.ToString();
            //Xóa item trong listview thống kê
            lstThongKe.Items.Clear();
            DataTable dt = Control.ControlChiTietHoaDon.getChiTietHoaDonbyNgay(ngay, thang, nam);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i].ItemArray[0].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                item.SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

                lstThongKe.Items.Add(item);
            }
            txtTongTien.Text = Control.ControlChiTietHoaDon.getTongTienbyNgay(ngay, thang, nam);
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lstThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstThongKe_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmThanhToan: Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {

            this.getChiTietHoaDonByMaHoaDonTableAdapter.Fill(this.quanLyCafeDataSet.GetChiTietHoaDonByMaHoaDon, int.Parse(frmQuanLyHoaDon.mahd));
            this.reportViewer1.RefreshReport();

        }
    }
}

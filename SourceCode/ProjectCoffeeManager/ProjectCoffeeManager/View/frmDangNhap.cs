using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ProjectCoffeeManager.View;
namespace ProjectCoffeeManager.View
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtUsename.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //câu lệnh xác nhận nhập đúng tên tài khoản và mã tài khoản
            if (txtUsename.Text == "admin" && txtPassword.Text == "admin")
            {
                //thông báo nếu đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công.", "Thông báo.!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmQuanLyHoaDon frm = new frmQuanLyHoaDon();
                //Đóng bang hiện tại
                this.Hide();
                //Mở bản Quản Lý Hóa Đơn
                frm.Show();
            }
            //nếu đăng nhập không đúng
            else
            {
                //hiện thông báo đăng nhập không thành công
                MessageBox.Show("Đăng nhập thất bại.", "Thông báo.!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xóa hết những gì người dùng nhập vào và focus tới vị trí nhập tên tài khoản
                txtUsename.Clear();
                txtPassword.Clear();
                txtUsename.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Thông báo có chắc chắn thoát không 
            DialogResult traloi = MessageBox.Show("Bạn có muốn thoát.", "Thông báo.!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (traloi == DialogResult.Yes)
                Application.Exit();

        }

        /// <summary>
        /// Sự kiện nhấp vào nút Đăng Nhập
        /// </summary>
    }

}

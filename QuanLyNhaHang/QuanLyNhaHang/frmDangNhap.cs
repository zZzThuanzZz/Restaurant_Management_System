using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát khỏi ứng dụng??", "Thông báo!!!", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result==DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //if ( MainClass.IsValidUser(txtTaiKhoan.Text, txtMatKhau.Text)==false)
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!", "Thông báo!!!",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{   
            //    this.Hide();
            //    frmMain frm = new frmMain();
            //    frm.Show();
            //}
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;

            

            if (!MainClass.IsValidUser(taiKhoan, matKhau))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!", "Thông báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
                if (!MainClass.IsAccountActive(taiKhoan))
            {
                MessageBox.Show("Tài khoản của bạn đã bị vô hiệu hóa. Vui lòng liên hệ với quản trị viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu tài khoản hợp lệ, tiến hành đăng nhập
            this.Hide();
            frmMain frm = new frmMain();
            frm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox được chọn (checked) thì hiển thị mật khẩu
            // Ngược lại, ẩn mật khẩu
            txtMatKhau.UseSystemPasswordChar= !checkBox1.Checked;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}

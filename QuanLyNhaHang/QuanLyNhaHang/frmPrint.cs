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
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của form và thay đổi kích thước tương ứng
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Nếu form đang phóng to, thu nhỏ lại kích thước bình thường
                this.WindowState = FormWindowState.Normal;
                btnMax.Text = "⇱";
            }
            else
            {
                // Nếu form không phải đang phóng to, phóng to form
                this.WindowState = FormWindowState.Maximized;
                btnMax.Text = "⇲";
            }
        }
    }
}

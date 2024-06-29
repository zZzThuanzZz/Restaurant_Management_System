using QuanLyNhaHang.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.View
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void btnDoanhThuSP_Click(object sender, EventArgs e)
        {
            frmDoanhThuSP frm = new frmDoanhThuSP();
            frm.ShowDialog();
        }
    }
}

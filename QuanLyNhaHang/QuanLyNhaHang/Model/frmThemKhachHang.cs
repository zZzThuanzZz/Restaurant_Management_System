using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Model
{
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        public string orderType = "";
        public int driverID = 0;
        public string cusName = "";
        
        public int mainID = 0;

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            if (orderType == "Mang đi")
            {
                lblTaiXe.Visible = false;
                cbTaiXe.Visible = false;
            }

            string qry = "Select IDnhanvien 'id', tennhanvien 'name' from nhanvien where chucvu = 'Shipper'";
            MainClass.CBFill(qry, cbTaiXe);

            if (mainID > 0)
            {
                cbTaiXe.SelectedValue = driverID;
            }
        }

        private void cbTaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            driverID = Convert.ToInt32(cbTaiXe.SelectedValue);
        }
    }
}

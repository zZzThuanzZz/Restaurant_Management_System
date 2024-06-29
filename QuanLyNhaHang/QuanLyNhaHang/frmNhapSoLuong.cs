using QuanLyNhaHang.Model;
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
    public partial class frmNhapSoLuong : Form
    {
        public int id = 0;
        public int SoLuong { get; set; }
        public frmNhapSoLuong()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ NumericUpDown
            SoLuong = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void SetNumericUpDownValue(int value)
        {
            numericUpDown1.Value = value;
        }

        public int SoLuongHienTai { get; set; }

    }
}

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
    public partial class MauThem : Form
    {
        public MauThem()
        {
            InitializeComponent();
        }

        public virtual void btnLuu_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

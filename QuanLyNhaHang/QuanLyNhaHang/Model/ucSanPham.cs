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
    public partial class ucSanPham : UserControl
    {
        public ucSanPham()
        {
            InitializeComponent();
            // Tạo viền xung quanh UserControl
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoScaleMode = AutoScaleMode.Dpi; // Đặt AutoScaleMode
        }

        public event EventHandler onSelect = null;

        public int id { get; set; }
        public string GiaSP 
        {
            get { return lblGiaSP.Text; }
            set { lblGiaSP.Text = value; } 
        }
        public string SLSP
        {
            get { return lblSoLuongCon.Text; }
            set { lblSoLuongCon.Text = value; }
        }

        public string DMSP { get; set; }
    
        public string PName
        {
            get { return lblTen.Text; }
            set { lblTen.Text = value; }
        }
    
        public Image PImage
        {
            get { return txtAnh.Image; }
            set { txtAnh.Image = value; }
        }

        private void txtAnh_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

    }
}

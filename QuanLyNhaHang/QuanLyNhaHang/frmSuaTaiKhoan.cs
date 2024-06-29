using System;
using System.Collections;
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
    public partial class frmSuaTaiKhoan : MauThem
    {
        public frmSuaTaiKhoan()
        {
            InitializeComponent();
        }
        public int id = 0;

        public override void btnLuu_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (string.IsNullOrWhiteSpace(txtTK.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ các mục!");
                return;
            }


            if (id == 0) //Insert
            {
                qry = "Insert into taikhoan Values (@Tk, @mk, @ten, @sdt, @quyen, @trangthai)";
            }
            else //Update
            {
                qry = "Update taikhoan Set taikhoan = @Tk, matkhau= @mk, ten= @ten, " +
                    "sdt = @sdt, quyen = @quyen, trangthai = @trangthai where id = @id ";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Tk", txtTK.Text);
            ht.Add("@mk", txtMK.Text);
            ht.Add("@ten", txtTen.Text);
            ht.Add("@sdt", txtSDT.Text);
            ht.Add("@quyen", cbQuyen.Text);
            ht.Add("@trangthai", cbTrangThai.Text);
            if (MainClass.SQl(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công!!");
                id = 0;
                txtTK.Text = "";
                txtMK.Text = "";
                txtTen.Text = "";
                txtSDT.Text = "";
                cbQuyen.SelectedIndex = -1;
                cbTrangThai.SelectedIndex = -1;
                txtTK.Focus();
            }
            this.Close();
        }
    }
}

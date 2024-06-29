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

namespace QuanLyNhaHang.Model
{
    public partial class frmThemBan : MauThem
    {
        public frmThemBan()
        {
            InitializeComponent();
        }

        public int id = 0;
        public override void btnLuu_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ các mục!");
                return;
            }


            if (id == 0) //Insert
            {
                qry = "Insert into ban Values (@Tên)";
            }
            else //Update
            {
                qry = "Update ban Set tenban = @Tên where idBan = @id ";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Tên", txtTenDanhMuc.Text);
            if (MainClass.SQl(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công!!");
                id = 0;
                txtTenDanhMuc.Text = "";
                txtTenDanhMuc.Focus();
            }
        }
    }
}

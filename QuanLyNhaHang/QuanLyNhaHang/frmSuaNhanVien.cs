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
    public partial class frmSuaNhanVien : MauThem
    {
        public frmSuaNhanVien()
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
                qry = "Insert into nhanvien Values (@Tên, @đt, @cv, @luong)";
            }
            else //Update
            {
                qry = "Update nhanvien Set tennhanvien = @Tên, sdtnhanvien= @đt, chucvu= @cv, luong= @luong where IDnhanvien = @id ";
            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Tên", txtTenDanhMuc.Text);
            ht.Add("@đt", txtSDT.Text);
            ht.Add("@cv", cbChucVu.Text);
            ht.Add("@luong", txtLuong.Text);
            if (MainClass.SQl(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công!!");
                id = 0;
                txtTenDanhMuc.Text = "";
                txtSDT.Text = "";
                cbChucVu.SelectedIndex = -1;
                txtTenDanhMuc.Focus();
            }
        }
    }
}

﻿using System;
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
    public partial class frmThemGiaTriKhuyenMai : MauThem
    {
        public frmThemGiaTriKhuyenMai()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ các mục!");
                return;
            }


            if (id == 0) //Insert
            {
                qry = "Insert into khuyenmai Values (@Tên)";
            }
            else //Update
            {
                qry = "Update khuyenmai Set giatri = @Tên where idKM = @id ";
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

﻿using QuanLyNhaHang.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.View
{
    public partial class frmHienThiNhanVien : MauHienThi
    {
        public frmHienThiNhanVien()
        {
            InitializeComponent();
        }

        private void frmHienThiNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GetData();
        }

        public void GetData()
        {
            string qry = "SELECT * FROM nhanvien WHERE tennhanvien LIKE @txtTimKiem " +
                "OR sdtnhanvien LIKE @txtTimKiem OR chucvu LIKE @txtTimKiem "; // Sử dụng tham số truy vấn
            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvTen);
            lb.Items.Add(dgvSDT);
            lb.Items.Add(dgvChucVu);
            lb.Items.Add(dgvLuong);

            string searchText = "%" + txtTimKiem.Text + "%";

            MainClass.LoadData(qry, searchText, dataGridView1, lb);
        }

        public override void btnThem_Click(object sender, EventArgs e)
        {
            //frmThemDanhMuc frm = new frmThemDanhMuc();
            //frm.ShowDialog();

            MainClass.BlurBackground(new Model.frmThemNhanVien());
            GetData();
        }

        public override void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvSua")
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Xác nhận sửa!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    frmSuaNhanVien frm = new frmSuaNhanVien();
                    frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);
                    frm.txtTenDanhMuc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvTen"].Value);
                    frm.txtSDT.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvSDT"].Value);
                    frm.cbChucVu.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvChucVu"].Value);
                    frm.txtLuong.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvLuong"].Value);
                    //frm.ShowDialog();
                    MainClass.BlurBackground(frm);
                    GetData();
                }
            }


            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvXoa")
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // Sử dụng tham số hóa để tránh tấn công SQL Injection
                    string qry = "DELETE FROM nhanvien WHERE IDnhanvien = @id";
                    Hashtable ht = new Hashtable();
                    ht.Add("@id", id);
                    MainClass.SQl(qry, ht);

                    MessageBox.Show("Đã xóa thành công!!!");
                    GetData();
                }
            }

        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Visible = true;
            btnThem.Enabled = false;
            Microsoft.Office.Interop.Excel.Application xlapp;
            Microsoft.Office.Interop.Excel.Workbook xlworkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlworksheet;
            Microsoft.Office.Interop.Excel.Range xlrange;
            try
            {
                xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlworkbook = xlapp.Workbooks.Open(label3.Text);
                xlworksheet = xlworkbook.Worksheets["Sheet1"];
                xlrange = xlworksheet.UsedRange;

                dataGridView2.ColumnCount = xlrange.Columns.Count;

                //for (int xlrow = 1; xlrow <= xlrange.Rows.Count; xlrow++)
                //{
                //    dataGridView2.Rows.Add(xlrange.Cells[xlrow, 1].Text, xlrange.Cells[xlrow, 2].Text,
                //        xlrange.Cells[xlrow, 3].Text);
                //}

                // Thêm tiêu đề từ hàng đầu tiên của Excel vào DataGridView
                for (int xlcol = 1; xlcol <= xlrange.Columns.Count; xlcol++)
                {
                    dataGridView2.Columns[xlcol - 1].HeaderText = xlrange.Cells[1, xlcol].Text;
                }

                // Bắt đầu từ hàng thứ hai để thêm dữ liệu vào DataGridView
                for (int xlrow = 2; xlrow <= xlrange.Rows.Count; xlrow++)
                {
                    dataGridView2.Rows.Add(xlrange.Cells[xlrow, 1].Text, xlrange.Cells[xlrow, 2].Text,
                        xlrange.Cells[xlrow, 3].Text, xlrange.Cells[xlrow, 4].Text);
                }

                xlworkbook.Close();
                xlapp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files Only | *.xlsx; *.xls";
                ofd.Title = "Choose the file";
                if (ofd.ShowDialog() == DialogResult.OK)
                    label3.Visible = true;
                label3.Text = ofd.FileName;
            }
        }
        SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True");
        private void btnLuu_Click(object sender, EventArgs e)
        {
            con.Open();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Insert into nhanvien(tennhanvien, sdtnhanvien, chucvu, luong) values(N'" + dataGridView2.Rows[i].Cells[0].Value + "',N'" + dataGridView2.Rows[i].Cells[1].Value + "'," +
                    "N'" + dataGridView2.Rows[i].Cells[2].Value + "', N'" + dataGridView2.Rows[i].Cells[3].Value + "' )", con);//cell 0 là ô đầu tiên
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Đã lưu vào database!!");
            dataGridView2.Visible = false;
            GetData();
            btnThem.Enabled = true;
            label3.Visible = false;
        }
    }
}

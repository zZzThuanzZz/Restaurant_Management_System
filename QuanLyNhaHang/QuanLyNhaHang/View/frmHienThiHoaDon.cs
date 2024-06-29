using QuanLyNhaHang.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.View
{
    public partial class frmHienThiHoaDon : Form
    {
        public frmHienThiHoaDon()
        {
            InitializeComponent();
        }

        private void frmHienThiHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong from tblMain
            //    where trangthai <> N'Đang chờ xử lí'";
            string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong from tblMain
                where trangthai = N'Đã thanh toán'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvNgay);
            lb.Items.Add(dgvBan);
            lb.Items.Add(dgvPhucVu);
            lb.Items.Add(dgvHinhThuc);
            lb.Items.Add(dgvTrangThai);
            lb.Items.Add(dgvTongCong);
            string searchText = "%" + txtTimKiem.Text + "%";
            MainClass.LoadData(qry, searchText, dataGridView1, lb);
        }
        public void GetData()
        {
            //string qry = "SELECT MainID, tenban, tenphucvu, kieuorder, trangthai, tongcong from tblMain" +
            //    "WHERE MainID LIKE @txtTimKiem or tenban LIKE @txtTimKiem or" +
            //    "tenphucvu LIKE @txtTimKiem or" +
            //    "kieuorder LIKE @txtTimKiem or" +
            //    "trangthai LIKE @txtTimKiem or" +
            //    "tongcong LIKE @txtTimKiem or"; // Sử dụng tham số truy vấn

            string qry = "SELECT MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong FROM tblMain " +
             "WHERE MainID LIKE @txtTimKiem OR " +
             "ngay LIKE @txtTimKiem OR " +
             "tenban LIKE @txtTimKiem OR " +
             "tenphucvu LIKE @txtTimKiem OR " +
             "kieuorder LIKE @txtTimKiem OR " +
             "tongcong LIKE @txtTimKiem";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvNgay);
            lb.Items.Add(dgvBan);
            lb.Items.Add(dgvPhucVu);
            lb.Items.Add(dgvHinhThuc);
            lb.Items.Add(dgvTrangThai);
            lb.Items.Add(dgvTongCong);

            string searchText = "%" + txtTimKiem.Text + "%";

            MainClass.LoadData(qry, searchText, dataGridView1, lb);
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }


            // Kiểm tra nếu cột hiện tại là cột "dgvDonGia" hoặc "dgvThanhTien"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvTongCong")
            {
                // Kiểm tra giá trị của ô không phải là null
                if (e.Value != null)
                {
                    // Chuyển đổi giá trị của ô sang kiểu số nguyên
                    double number;
                    if (double.TryParse(e.Value.ToString(), out number))
                    {
                        // Định dạng số nguyên không có dấu phân cách và thêm ký tự "đ"
                        e.Value = number.ToString("N0") + "đ";
                        e.FormattingApplied = true; // Đánh dấu đã xử lý định dạng
                    }
                }
            }
        }
        public int MainID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvSua")
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có muốn thanh toán/chỉnh sửa hóa đơn này?", "Xác nhận!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MainID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);
                    this.Close();
                }
            }

            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvXoa")
            {
                //in hóa đơn
                MainID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);
                string qry = @"select * from tblMain m inner join chitietban d on d.MainID = m.MainID
                                                        inner join sanpham p on p.IDsanpham = d.sanphamID
                                    where m.MainID = " + MainID + "";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                MainClass.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                MainClass.con.Close();

                frmPrint frm = new frmPrint();
                rptHoaDon cr = new rptHoaDon();

                cr.SetDatabaseLogon("sa", "123");
                cr.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cr;
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            LoadData();
        }
    }
}

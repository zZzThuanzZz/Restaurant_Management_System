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

namespace QuanLyNhaHang.Model
{
    public partial class frmGopBan : Form
    {
        public frmGopBan()
        {
            InitializeComponent();
            LoadBan(comboBox1);
            LoadBan(comboBox2);
        }

        private void frmGopBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong from tblMain
            //    where trangthai <> N'Đang chờ xử lí'";
            string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong 
               from tblMain
               where trangthai = N'Hoàn thành'
               AND kieuorder = N'Ăn tại nhà hàng'";
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
        public class Database
        {
            private string connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

            public SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
        public void LoadBan(ComboBox comboBox)
        {
            using (SqlConnection conn = new Database().GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MainID, tenban FROM tblMain where trangthai = N'Hoàn thành' " +
                    "and kieuorder = N'Ăn tại nhà hàng'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox.DataSource = dt;
                comboBox.DisplayMember = "tenban";
                comboBox.ValueMember = "MainID";
                comboBox.SelectedIndex = -1;
            }
        }
        public void GetData()
        {
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
        public void MergeTables(int mainID1, int mainID2)
        {
            using (SqlConnection conn = new Database().GetConnection())
            {
                conn.Open();

                // Cập nhật chi tiết bàn từ mainID2 sang mainID1
                SqlCommand cmd = new SqlCommand("UPDATE chitietban SET MainID = @MainID1 WHERE MainID = @MainID2", conn);
                cmd.Parameters.AddWithValue("@MainID1", mainID1);
                cmd.Parameters.AddWithValue("@MainID2", mainID2);
                cmd.ExecuteNonQuery();

                // Cập nhật tổng tiền của bàn mainID1
                SqlCommand cmdUpdateTongCong = new SqlCommand(@"
                UPDATE tblMain
                SET tongcong = (
                    SELECT SUM(thanhtien)
                    FROM chitietban
                    WHERE MainID = @MainID1
                )
                WHERE MainID = @MainID1", conn);
                cmdUpdateTongCong.Parameters.AddWithValue("@MainID1", mainID1);
                cmdUpdateTongCong.ExecuteNonQuery();

                // Xóa bàn mainID2 sau khi gộp
                SqlCommand cmdDeleteTable = new SqlCommand("DELETE FROM tblMain WHERE MainID = @MainID2", conn);
                cmdDeleteTable.Parameters.AddWithValue("@MainID2", mainID2);
                cmdDeleteTable.ExecuteNonQuery();
            }
        }



        //public void MergeTables(int mainID1, int mainID2)
        //{
        //    using (SqlConnection conn = new Database().GetConnection())
        //    {
        //        conn.Open();

        //        // Cập nhật chi tiết bàn từ mainID2 sang mainID1
        //        SqlCommand cmdUpdateChiTietBan = new SqlCommand(@"
        //    UPDATE chitietban
        //    SET MainID = @MainID1
        //    WHERE MainID = @MainID2;

        //    -- Cập nhật số lượng sản phẩm trong chitietban khi có sanphamID giống nhau
        //    UPDATE cdb1
        //    SET cdb1.soluong = cdb1.soluong + cdb2.soluong
        //    FROM chitietban AS cdb1
        //    INNER JOIN chitietban AS cdb2 ON cdb1.sanphamID = cdb2.sanphamID AND cdb2.MainID = @MainID2
        //    WHERE cdb1.MainID = @MainID1;

        //    -- Xóa bàn mainID2 sau khi đã gộp
        //    DELETE FROM tblMain WHERE MainID = @MainID2;
        //", conn);

        //        cmdUpdateChiTietBan.Parameters.AddWithValue("@MainID1", mainID1);
        //        cmdUpdateChiTietBan.Parameters.AddWithValue("@MainID2", mainID2);
        //        cmdUpdateChiTietBan.ExecuteNonQuery();
        //    }
        //}


        private void btnGopBan_Click(object sender, EventArgs e)
        {
            int mainID1 = Convert.ToInt32(comboBox1.SelectedValue);
            int mainID2 = Convert.ToInt32(comboBox2.SelectedValue);

            if (mainID1 != mainID2)
            {
                MergeTables(mainID1, mainID2);
                MessageBox.Show("Gộp bàn thành công!");

                // Refresh lại danh sách bàn
                LoadBan(comboBox1);
                LoadBan(comboBox2);
                LoadData();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn hai bàn khác nhau!");
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
        public int MainID = 0;
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
                rptChiTietBan cr = new rptChiTietBan();

                cr.SetDatabaseLogon("sa", "123");
                cr.SetDataSource(dt);
                frm.crystalReportViewer1.ReportSource = cr;
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            }
        }
    }
}

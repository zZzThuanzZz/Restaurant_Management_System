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
    public partial class frmChuyenBan : Form
    {
        public frmChuyenBan()
        {
            InitializeComponent();
            LoadBan1(comboBox1);
            LoadBan2(comboBox2);
        }
        private void LoadData()
        {
            //string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong from tblMain
            //    where trangthai <> N'Đang chờ xử lí'";
            string qry = @"select MainID, ngay, tenban, tenphucvu, kieuorder, trangthai, tongcong 
               from tblMain
               where trangthai <> N'Đã thanh toán'
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

        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            LoadData();
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
        public class Database
        {
            private string connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

            public SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
        public void LoadBan1(ComboBox comboBox)
        {
            using (SqlConnection conn = new Database().GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MainID, tenban FROM tblMain where trangthai <> N'Đã thanh toán'" +
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
        public void LoadBan2(ComboBox comboBox)
        {
            using (SqlConnection conn = new Database().GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT b.idBan, b.tenban FROM ban b LEFT JOIN tblMain h " +
                    "ON b.tenban = h.tenban AND h.trangthai IN(N'Đang chờ xử lí', N'Hoàn thành') WHERE h.tenban IS NULL", conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                comboBox.DataSource = dt1;
                comboBox.DisplayMember = "tenban";
                comboBox.ValueMember = "idBan";
                comboBox.SelectedIndex = -1;
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn nguồn và bàn đích.");
                return;
            }

            string tenBanNguon = comboBox1.Text;
            string tenBanDich = comboBox2.Text;

            if (tenBanNguon == tenBanDich)
            {
                MessageBox.Show("Bàn nguồn và bàn đích không thể giống nhau.");
                return;
            }

            try
            {
                using (SqlConnection conn = new Database().GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblMain SET tenban = @tenBanDich WHERE tenban = @tenBanNguon AND trangthai <> N'Đã thanh toán'", conn);
                    cmd.Parameters.AddWithValue("@tenBanNguon", tenBanNguon);
                    cmd.Parameters.AddWithValue("@tenBanDich", tenBanDich);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Chuyển bàn thành công!");
                        LoadData(); // Refresh the data grid view
                        LoadBan1(comboBox1); // Refresh the source table list
                        LoadBan2(comboBox2); // Refresh the destination table list
                    }
                    else
                    {
                        MessageBox.Show("Không có bàn nào được chuyển. Vui lòng kiểm tra lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}

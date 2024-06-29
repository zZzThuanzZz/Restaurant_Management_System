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
    public partial class frmChonPhucVu : Form
    {
        public frmChonPhucVu()
        {
            InitializeComponent();
        }
        public string waiterName;
        private void frmChonPhucVu_Load(object sender, EventArgs e)
        {
            string qry = "Select * from nhanvien where chucvu = N'Phục vụ'";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.Text = row["tennhanvien"].ToString();
                b.Width = 150;
                b.Height = 50;
                b.BackColor = Color.FromArgb(241, 85, 126);
                b.MouseEnter += (s, eventArgs) =>
                {
                    b.BackColor = Color.FromArgb(50, 55, 89); // Đặt màu nền mới khi con trỏ chuột hover lên nút
                };
                b.MouseLeave += (s, eventArgs) =>
                {
                    b.BackColor = Color.FromArgb(241, 85, 126); // Khôi phục màu nền ban đầu khi con trỏ chuột rời đi
                };
                //sự kiện cho click
                b.Click += new EventHandler(_Click);
                flowLayoutPanel1.Controls.Add(b);
            }
        }
        private void _Click(object sender, EventArgs e)
        {
            waiterName = (sender as System.Windows.Forms.Button).Text.ToString();
            this.Close();
        }
    }
}

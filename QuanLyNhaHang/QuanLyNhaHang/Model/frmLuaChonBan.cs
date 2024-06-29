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
    public partial class frmLuaChonBan : Form
    {
        public string TableName;
        public frmLuaChonBan()
        {
            InitializeComponent();
        }

        //private void frmLuaChonBan_Load(object sender, EventArgs e)
        //{
        //    string qry = "Select * from ban";
        //    SqlCommand cmd = new SqlCommand(qry, MainClass.con);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
        //        b.Text = row["tenban"].ToString();
        //        b.Width = 150;
        //        b.Height = 50;
        //        b.BackColor = Color.FromArgb(241, 85, 126);
        //        b.MouseEnter += (s, eventArgs) =>
        //        {
        //            b.BackColor = Color.FromArgb(50, 55, 89); // Đặt màu nền mới khi con trỏ chuột hover lên nút
        //        };
        //        b.MouseLeave += (s, eventArgs) =>
        //        {
        //            b.BackColor = Color.FromArgb(241, 85, 126); // Khôi phục màu nền ban đầu khi con trỏ chuột rời đi
        //        };
        //        //sự kiện cho click
        //        b.Click += new EventHandler(_Click);
        //        flowLayoutPanel1.Controls.Add(b);
        //    }
        //}
        //private void frmLuaChonBan_Load(object sender, EventArgs e)
        //{
        //    string qry = "SELECT b.tenban, m.trangthai FROM ban b LEFT JOIN tblMain m ON b.tenban = m.tenban";
        //    SqlCommand cmd = new SqlCommand(qry, MainClass.con);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        string tenBan = row["tenban"].ToString();
        //        string trangThai = row["trangthai"].ToString();

        //        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
        //        b.Text = tenBan;
        //        b.Width = 150;
        //        b.Height = 50;

        //        if (trangThai == "Đang chờ xử lí" || trangThai == "Hoàn thành")
        //        {
        //            b.BackColor = Color.Gray; // Đổi màu nền nếu trạng thái là "Đang chờ xử lí" hoặc "Hoàn thành"
        //            b.Enabled = false;
        //        }
        //        else
        //        {
        //            b.BackColor = Color.FromArgb(241, 85, 126);
        //        }

        //        b.MouseEnter += (s, eventArgs) =>
        //        {
        //            b.BackColor = Color.FromArgb(50, 55, 89); // Đặt màu nền mới khi con trỏ chuột hover lên nút
        //        };
        //        b.MouseLeave += (s, eventArgs) =>
        //        {
        //            if (trangThai == "Đang chờ xử lí" || trangThai == "Hoàn thành")
        //            {
        //                b.BackColor = Color.Yellow; // Giữ màu nền nếu trạng thái là "Đang chờ xử lí" hoặc "Hoàn thành"
        //            }
        //            else
        //            {
        //                b.BackColor = Color.FromArgb(241, 85, 126); // Khôi phục màu nền ban đầu khi con trỏ chuột rời đi
        //            }
        //        };
        //        // Sự kiện cho click
        //        b.Click += new EventHandler(_Click);
        //        flowLayoutPanel1.Controls.Add(b);
        //    }
        //}
        private void frmLuaChonBan_Load(object sender, EventArgs e)
        {
            // Truy vấn để lấy các bàn cùng với trạng thái của chúng (nếu có), nhóm theo tên bàn
            string qry = @"SELECT b.tenban, 
                            COALESCE(MAX(m.trangthai), N'Không có trạng thái') AS trangthai
                            FROM ban b
                            LEFT JOIN tblMain m ON b.tenban = m.tenban
                            GROUP BY b.tenban";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string tenBan = row["tenban"].ToString();
                string trangThai = row["trangthai"].ToString();

                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.Text = tenBan;
                b.Width = 150;
                b.Height = 50;

                if (trangThai == "Đang chờ xử lí" || trangThai == "Hoàn thành")
                {
                    b.BackColor = Color.Gray; // Đặt màu nền nếu trạng thái là "Đang chờ xử lí" hoặc "Hoàn thành"
                    b.Enabled = false; // Vô hiệu hóa nút
                }
                else
                {
                    b.BackColor = Color.FromArgb(241, 85, 126);
                }

                b.MouseEnter += (s, eventArgs) =>
                {
                    if (b.Enabled) // Chỉ thay đổi màu nền nếu nút được bật
                    {
                        b.BackColor = Color.FromArgb(50, 55, 89);
                    }
                };
                b.MouseLeave += (s, eventArgs) =>
                {
                    if (trangThai == "Đang chờ xử lí" || trangThai == "Hoàn thành")
                    {
                        b.BackColor = Color.Gray; // Giữ màu xám cho các nút bị vô hiệu hóa
                    }
                    else
                    {
                        b.BackColor = Color.FromArgb(241, 85, 126);
                    }
                };

                // Sự kiện click cho nút
                b.Click += new EventHandler(_Click);
                flowLayoutPanel1.Controls.Add(b);
            }
        }
        private void _Click(object sender, EventArgs e)
        {
            TableName = (sender as System.Windows.Forms.Button).Text.ToString();
            this.Close();
        }
    }
}

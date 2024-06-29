using System;
using System.Collections;
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
    public partial class frmHienThiBep : Form
    {
        public frmHienThiBep()
        {
            InitializeComponent();
        }

        private void frmHienThiBep_Load(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim().ToLower(); // Chuỗi tìm kiếm, chuyển về chữ thường và loại bỏ khoảng trắng ở đầu và cuối

            foreach (var control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    bool isVisible = false; // Mặc định là ẩn

                    foreach (var subControl in panel.Controls)
                    {
                        if (subControl is FlowLayoutPanel subPanel)
                        {
                            foreach (var labelControl in subPanel.Controls)
                            {
                                if (labelControl is Label label)
                                {
                                    // Kiểm tra nội dung của Label nếu chứa chuỗi tìm kiếm
                                    if (label.Text.ToLower().Contains(searchText))
                                    {
                                        isVisible = true; // Nếu tìm thấy, hiển thị Panel
                                        break; // Thoát khỏi vòng lặp
                                    }
                                }
                            }
                        }
                    }

                    panel.Visible = isVisible; // Ẩn hoặc hiện Panel tùy thuộc vào kết quả tìm kiếm
                }
            }
        }

        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            string qry1 = @"Select * from tblMain where trangthai = N'Đang chờ xử lí'";
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt1);

            FlowLayoutPanel p1;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                p1 = new FlowLayoutPanel();
                p1.AutoSize = true;
                p1.Width = 230;
                p1.Height = 150;
                p1.FlowDirection = FlowDirection.TopDown;
                p1.BorderStyle = BorderStyle.FixedSingle;
                p1.Margin = new Padding(10, 10, 10, 10);

                FlowLayoutPanel p2 = new FlowLayoutPanel();
                p2 = new FlowLayoutPanel();
                p2.BackColor = Color.FromArgb(50, 55, 89);
                p2.AutoSize = true;
                p2.Width = 230;
                p2.Height = 125;
                p2.FlowDirection = FlowDirection.TopDown;
                p2.Margin = new Padding(0, 0, 0, 0);

                Label lb0 = new Label();
                lb0.ForeColor = Color.White;
                lb0.Margin = new Padding(10, 5, 3, 0);
                lb0.AutoSize = true;

                Label lb6 = new Label();
                lb6.ForeColor = Color.White;
                lb6.Margin = new Padding(10, 5, 3, 0);
                lb6.AutoSize = true;

                Label lb1 = new Label();
                lb1.ForeColor = Color.White;
                lb1.Margin = new Padding(10, 10, 3, 0);
                lb1.AutoSize = true;

                Label lb2 = new Label();
                lb2.ForeColor = Color.White;
                lb2.Margin = new Padding(10, 5, 3, 0);
                lb2.AutoSize = true;

                Label lb3 = new Label();
                lb3.ForeColor = Color.White;
                lb3.Margin = new Padding(10, 5, 3, 0);
                lb3.AutoSize = true;

                Label lb4 = new Label();
                lb4.ForeColor = Color.White;
                lb4.Margin = new Padding(10, 5, 3, 10);
                lb4.AutoSize = true;

                lb0.Text = "ID : " + dt1.Rows[i]["MainID"].ToString();
                lb1.Text = "Bàn : " + dt1.Rows[i]["tenban"].ToString();
                lb2.Text = "Tên phục vụ : " + dt1.Rows[i]["tenphucvu"].ToString();
                //lb6.Text = "Ngày : " + dt1.Rows[i]["ngay"].ToString();
                lb6.Text = "Ngày : " + ((DateTime)dt1.Rows[i]["ngay"]).ToShortDateString();
                lb3.Text = "Giờ đặt : " + dt1.Rows[i]["gio"].ToString();
                lb4.Text = "Hình thức : " + dt1.Rows[i]["kieuorder"].ToString();

                p2.Controls.Add(lb0);
                p2.Controls.Add(lb1);
                p2.Controls.Add(lb2);
                p2.Controls.Add(lb6);
                p2.Controls.Add(lb3);
                p2.Controls.Add(lb4);

                p1.Controls.Add(p2);

                // thêm sản phẩm

                int mid = 0;
                mid = Convert.ToInt32(dt1.Rows[i]["MainID"].ToString());

                string qry2 = @"Select * from tblMain m 
                    inner join chitietban d on m.MainID = d.MainID 
                    inner join sanpham sp on sp.IDsanpham = d.sanphamID 
                    Where m.MainID = "+mid+"";

                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    Label lb5 = new Label();
                    lb5.ForeColor = Color.Black;
                    lb5.Margin = new Padding(10, 5, 3, 0);
                    lb5.AutoSize = true;

                    int no = j + 1;

                    lb5.Text = "" + no + "/" + dt2.Rows[j]["Tensanpham"].ToString() + "--" 
                                                + dt2.Rows[j]["soluong"].ToString();

                    p1.Controls.Add(lb5);
                }

                //thêm nút để thay đổi trạng thái đơn hàng

                System.Windows.Forms.Button b = new System.Windows.Forms.Button();
                b.FlatStyle = FlatStyle.Flat; // Đặt kiểu nút là Flat để có thể điều chỉnh góc tròn
                b.FlatAppearance.BorderSize = 0; // Xóa viền nút
                b.Size = new Size(100, 35);
                b.BackColor = Color.FromArgb(241, 85, 126); // Đặt màu nền
                b.Margin = new Padding(30, 5, 3, 10);
                b.Text = "Hoàn thành";
                b.Tag = dt1.Rows[i]["MainID"].ToString(); //store the id

                b.Click += new EventHandler(b_click);
                p1.Controls.Add(b);

                flowLayoutPanel1.Controls.Add(p1);
            }
        }

        private void b_click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as System.Windows.Forms.Button).Tag.ToString());

            DialogResult result = MessageBox.Show("Bạn có chắc là đã có món?", "Xác nhận xóa!!!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string qry = @"Update tblMain set trangthai = N'Hoàn thành' where MainID = @ID";
                Hashtable ht = new Hashtable();
                ht.Add("@ID", id);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    // Sử dụng hộp thoại thông báo của Windows Forms
                    MessageBox.Show("Lưu thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                GetOrders();
            }
        }
    }
}

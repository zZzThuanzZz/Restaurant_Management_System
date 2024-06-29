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
    public partial class frmHienThiQuangCao : Form
    {
        private int currentIndex = 0;
        private List<Image> images = new List<Image>(); // Danh sách các hình ảnh
        private Timer timer;


        public frmHienThiQuangCao()
        {
            InitializeComponent();
            InitializeTimer();
            LoadImagesFromDatabase();
            ShowImage();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 3000; // Thời gian hiển thị giữa các hình ảnh (3 giây)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void ShowNextImage()
        {
            if (images.Count != 0)
            {
                currentIndex = (currentIndex + 1) % images.Count;
                ShowImage();
            }
        }

        private void ShowImage()
        {
            if (images.Count > 0)
            {
                pictureBox1.Image = images[currentIndex];
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        private void LoadImagesFromDatabase()
        {
            string connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True"; // Thay thế bằng chuỗi kết nối của bạn
            string query = "SELECT anh FROM anhqc"; // Truy vấn lấy ảnh từ cột 'anh' trong bảng 'anhqc'

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["anh"]; // Lấy dữ liệu ảnh từ cột 'anh'
                        Image image = Image.FromStream(new System.IO.MemoryStream(imageData)); // Chuyển đổi dữ liệu ảnh thành hình ảnh
                        images.Add(image); // Thêm hình ảnh vào danh sách
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void frmHienThiQuangCao_Load(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToLongDateString() + " ** " + DateTime.Now.ToLongTimeString();
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            //label1.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}

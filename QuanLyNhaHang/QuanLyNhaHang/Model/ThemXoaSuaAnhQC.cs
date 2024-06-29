using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Model
{
    public partial class ThemXoaSuaAnhQC : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True");
        public ThemXoaSuaAnhQC()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from anhqc", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                btnThem.Enabled = true;
                pictureBox2.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
                txtTenHinh.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenHinh.Text) || pictureBox2.Image == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //byte[] b = ImageToByteArray(pictureBox2.Image);
                byte[] b = PathToByteArray(this.Text);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into anhqc values (@ten, @hinh)", conn);
                cmd.Parameters.Add("@ten", txtTenHinh.Text);
                cmd.Parameters.Add("@hinh", b);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();


                txtTenHinh.Text = "";
                pictureBox2.Image = null;
            }
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        byte[] PathToByteArray(string path)
        {
            //MemoryStream m = new MemoryStream();
            //Image img = Image. FromFile(path);
            //img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            //return m.ToArray();
            // có thể dùng class File để chuyến
            return File.ReadAllBytes(path);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            int r = dataGridView1.CurrentCell.RowIndex;
            txtTenHinh.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            byte[] b = (byte[])dataGridView1.Rows[r].Cells[1].Value;
            pictureBox2.Image = ByteArrayToImage(b);
        }
        // chuyển từ byte[] sang Image để gán cho picturebox2
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        public int id = 0;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn trong dataGridView1 không
                if (dataGridView1.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy chỉ mục của dòng được chọn đầu tiên
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                // Lấy giá trị của cột ID từ dòng được chọn
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);

                //DialogResult result = MessageBox.Show("Bạn có muốn xóa hình có ID " + id.ToString() + " không?",
                //    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                DialogResult result = MessageBox.Show("Bạn có muốn xóa hình này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM anhqc WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM anhqc WHERE tenanh LIKE @ten", conn);
                cmd.Parameters.AddWithValue("@ten", "%" + txtTimKiem.Text + "%");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

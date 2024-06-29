using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    class MainClass
    {
        //public static readonly string con_string = "Data Source=DELL;Initial Catalog=QuanLyNhaHang;" +
        //    "Integrated Security=True;User ID=sa;Password=123;";
        public static readonly string con_string = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);

        //phương thức kiểm tra tài khoản người dùng có sẵn

        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from taikhoan where taikhoan =@user AND matkhau = @pass";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["ten"].ToString();
            }

            return isValid;
        }

        public static bool IsAccountActive(string taiKhoan)
        {
            bool isActive = false;

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                string query = "SELECT trangthai FROM taikhoan WHERE taikhoan = @TaiKhoan";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    // Nếu tài khoản tồn tại và trạng thái là "Hoạt động" thì trả về true
                    if (result != null && result.ToString() == "Hoạt động")
                    {
                        isActive = true;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }

            return isActive;
        }

        //tạo thuộc tính cho tài khoản

        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        //phương thức cho CRUD

        public static int SQl(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }

        //tải dữ liệu lên

        //public static void LoadData(string qry, DataGridView gv, ListBox lb)
        //{
        //    gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(qry, con);
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        for (int i = 0; i < lb.Items.Count; i++)
        //        {
        //            string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
        //            gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
        //        }

        //        gv.DataSource = dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //        con.Close();
        //    }
        //}

        public static void LoadData(string qry, string searchText, DataGridView gv, ListBox lb)
        {
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@txtTimKiem", searchText); // Thêm tham số truy vấn

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }


        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            int count = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        //làm mờ nền khi 1 form nhỏ hơn hiện ra
        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = frmMain.Instance.Size;
                Background.Location = frmMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        //cho đầy cb

        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType= CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }
    }
}
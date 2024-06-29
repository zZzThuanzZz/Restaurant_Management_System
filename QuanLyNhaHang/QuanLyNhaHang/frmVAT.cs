using QuanLyNhaHang.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmVAT : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        //private string connectionString = "Data Source=DELL;Initial Catalog=QuanLyNhaHang;" +
        //    "Integrated Security=True;User ID=sa;Password=123;";

        public static readonly string connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";

        public frmVAT()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị mới từ ô TextBox
                string newVATValue = txtThue.Text;

                // Kiểm tra xem giá trị nhập vào có phải là số hay không
                double vat;
                if (!double.TryParse(newVATValue, out vat))
                {
                    MessageBox.Show("Vui lòng nhập một giá trị số cho giá trị VAT!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn SQL để cập nhật giá trị VAT trong cơ sở dữ liệu
                    string query = "UPDATE VAT SET giatriVAT = @NewValue WHERE id = 1"; // Giả sử cập nhật cho dòng đầu tiên
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewValue", vat);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật giá trị VAT thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không có dòng nào được cập nhật!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}

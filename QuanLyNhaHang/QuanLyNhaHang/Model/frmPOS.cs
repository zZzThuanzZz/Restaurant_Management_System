using QuanLyNhaHang.View;
using System;
using System.Collections;
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
    public partial class frmPOS : Form
    {
        //private Button[] allButtons;
        private Button[] allButtons1;
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private string connectionString = "Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        public frmPOS()
        {
            InitializeComponent();
            // Gọi hàm để lấy và hiển thị giá trị VAT khi form được khởi tạo
            DisplayVAT();
            //// Gán tham chiếu của form hiện tại cho biến tĩnh tên là currentInstance
            //currentInstance = this;
            LoadDataIntoComboBox();
        }
        public int driverID = 0;
        public string customerName = "";
        public string customerPhone = "";
        public string customerAddress = "";
        //Color x = Color.Yellow;//đổi màu nút
        Color y = Color.Coral;//đổi màu nút
        //private void SetAllButtonsColor(Color color)
        //{
        //    foreach (Button button in allButtons)
        //    {
        //        button.BackColor = color;
        //    }
        //}

        private void SetAllButtonsColor1(Color color)
        {
            foreach (Button button1 in allButtons1)
            {
                button1.BackColor = color;
            }
        }
        private void DisplayVAT()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn SQL để lấy giá trị VAT
                    string query = "SELECT giatriVAT FROM VAT";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Hiển thị giá trị VAT lấy được từ cơ sở dữ liệu vào ô TextBox
                        txtVAT.Text = reader["giatriVAT"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //// Biến tĩnh để lưu trữ tham chiếu của form hiện tại
        //public static frmPOS currentInstance;

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi màn hình POS không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                MessageBox.Show("Để quay lại màn hình POS, vui lòng click chuột vào nút chức năng POS !!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            //allButtons = new Button[] { /*btnAnTaiNhaHang, btnGiaoHang, btnMangDi,*/ btnThemMoi, btnGuiDonDatMon };
            allButtons1 = new Button[] { btnAnTaiNhaHang, btnGiaoHang, btnMangDi/*, btnThemMoi, btnGuiDonDatMon*/ };
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            PanelSanPham.Controls.Clear();
            LoadProducts();
        }

        private void AddCategory()
        {
            string qry = "Select * from danhmuc";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            PanelDanhMuc.Controls.Clear();

            // Thêm nút "All Categories"
            Button allCategoriesButton = new Button();
            allCategoriesButton.BackColor = Color.FromArgb(50, 55, 89);
            allCategoriesButton.Size = new Size(166, 52);
            allCategoriesButton.FlatStyle = FlatStyle.Flat;
            allCategoriesButton.FlatAppearance.BorderSize = 0;
            allCategoriesButton.Text = "Tất cả";
            allCategoriesButton.ForeColor = Color.White;
            allCategoriesButton.Click += new EventHandler(AllCategories_Click);
            PanelDanhMuc.Controls.Add(allCategoriesButton);

            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            //        b.FillColor = Color.FromArgb(50, 55, 89);
            //        b.Size = new Size(166, 52);
            //        b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            //        b.Text = row["Tendanhmuc"].ToString();

            //        PanelDanhMuc.Controls.Add(b);
            //    }
            //}

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Button b = new Button();
                    b.BackColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(166, 52);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Text = row["Tendanhmuc"].ToString();
                    b.ForeColor = Color.White;

                    //sự kiện cho click
                    b.Click += new EventHandler(_Click);

                    PanelDanhMuc.Controls.Add(b);
                }
            }
        }

        private void AllCategories_Click(object sender, EventArgs e)
        {
            PanelSanPham.Controls.Clear();
            LoadProducts();
        }


        private void _Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            foreach (var item in PanelSanPham.Controls)
            {
                var pro = (ucSanPham)item;
                pro.Visible = pro.DMSP.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        //private void AddCategory()
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM danhmuc", MainClass.con))
        //    {
        //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            PanelDanhMuc.Controls.Clear();

        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    Button b = new Button();
        //                    b.BackColor = Color.FromArgb(50, 55, 89);
        //                    b.Size = new Size(166, 52);
        //                    b.FlatStyle = FlatStyle.Flat;
        //                    b.FlatAppearance.BorderSize = 0;
        //                    b.Text = row["Tendanhmuc"].ToString();
        //                    b.ForeColor = Color.White;

        //                    PanelDanhMuc.Controls.Add(b);
        //                }
        //            }
        //        }
        //    }
        //}
        private void AddItems(string id, string spID, string ten, string dm, string gia, string soluongcon, Image anhdm)
        {
            var w = new ucSanPham()
            {
                SLSP = soluongcon,
                PName = ten,
                GiaSP = gia,
                DMSP = dm,
                PImage = anhdm,
                id = Convert.ToInt32(spID)
            };

            PanelSanPham.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucSanPham)ss;

                bool existed = false; // Biến để kiểm tra sản phẩm đã tồn tại hay chưa

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvspID"].Value) == wdg.id)
                    {
                        // Sản phẩm đã có trong DataGridView, hiển thị thông báo và đặt existed thành true
                        MessageBox.Show("Sản phẩm đã có trong danh sách. Để thay đổi số lượng món, vui lòng chọn món trong danh mục và nhấn nút sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        existed = true;
                        break;
                    }
                }

                if (!existed) // Nếu sản phẩm chưa tồn tại trong DataGridView
                {
                    using (var frmNhapSoLuong = new frmNhapSoLuong())
                    {
                        if (frmNhapSoLuong.ShowDialog() == DialogResult.OK)
                        {
                            int soLuongNhap = frmNhapSoLuong.SoLuong;

                            // Nếu số lượng nhập lớn hơn 0 thì thêm vào DataGridView
                            if (soLuongNhap > 0)
                            {
                                foreach (DataGridViewRow item in dataGridView1.Rows)
                                {
                                    // Đoạn mã này sẽ kiểm tra xem sản phẩm đã có trong danh sách chưa,
                                    // sau đó tăng số lượng lên một và cập nhật giá.
                                    if (Convert.ToInt32(item.Cells["dgvspID"].Value) == wdg.id)
                                    {
                                        //item.Cells["dgvSoLuong"].Value = int.Parse(item.Cells["dgvSoLuong"].Value.ToString()) + 1;
                                        //item.Cells["dgvThanhTien"].Value = int.Parse(item.Cells["dgvSoLuong"].Value.ToString()) *
                                        //double.Parse(item.Cells["dgvDonGia"].Value.ToString());

                                        item.Cells["dgvSoLuong"].Value = soLuongNhap;
                                        item.Cells["dgvThanhTien"].Value = (soLuongNhap *
                                            double.Parse(item.Cells["dgvDonGia"].Value.ToString())).ToString("N0") + "đ";

                                        GetTotal();
                                        return;
                                    }
                                }

                                //Đoạn mã này thêm sản phẩm mới
                                //dataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.GiaSP, wdg.GiaSP });
                                dataGridView1.Rows.Add(new object[] { 0, 0, wdg.id, wdg.PName, soLuongNhap, wdg.GiaSP, soLuongNhap * double.Parse(wdg.GiaSP) });

                                GetTotal();
                            };

                        }
                    }
                }
            };
        }
        private bool HienThiThongBaoSPNgungBan = false; // Biến để kiểm tra xem đã hiển thị thông báo ngừng bán hay chưa

        //lấy sản phẩm từ cơ sở dữ liệu
        private void LoadProducts()
        {
            string qry = "Select * from sanpham inner join danhmuc on IDdanhmuc = IDdm ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //foreach (DataRow item in dt.Rows)
            //{
            //    Byte[] imagearray = (byte[])item["Anhsanpham"];
            //    byte[] immagebytearray = imagearray;
            //    AddItems("0", item["IDsanpham"].ToString(), item["Tensanpham"].ToString(), item["Tendanhmuc"].ToString(),
            //        item["Giasanpham"].ToString(), Image.FromStream(new MemoryStream(imagearray)));
            //}

            // Biến cờ để kiểm soát việc hiển thị thông báo lỗi
            bool daHienThiThongBaoLoi = false;
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    // Kiểm tra trạng thái của sản phẩm
                    string trangThai = item["trangthai"].ToString();

                    // Nếu sản phẩm đang được bán (trạng thái != "Ngừng bán")
                    if (trangThai != "Ngừng bán")
                    {
                        Byte[] imagearray = (byte[])item["Anhsanpham"];
                        byte[] immagebytearray = imagearray;
                        AddItems("0", item["IDsanpham"].ToString(), item["Tensanpham"].ToString(), item["Tendanhmuc"].ToString(),
                            item["Giasanpham"].ToString(), item["soluong"].ToString(), Image.FromStream(new MemoryStream(imagearray)));
                    }
                    //else
                    //MessageBox.Show("Đang có sản phẩm ngừng bán, vui lòng liên hệ admin!!!!");
                    // Nếu sản phẩm có trạng thái "Ngừng bán", không thực hiện gì cả
                    else
                    {
                        // Nếu sản phẩm có trạng thái "Ngừng bán" và chưa hiển thị thông báo
                        if (!HienThiThongBaoSPNgungBan)
                        {
                            MessageBox.Show("Đang có sản phẩm ngừng bán, vui lòng liên hệ admin!!!!");
                            HienThiThongBaoSPNgungBan = true; // Đánh dấu đã hiển thị thông báo
                        }
                    }
                }
                catch
                {
                    // Hiển thị thông báo lỗi chỉ một lần
                    if (!daHienThiThongBaoLoi)
                    {
                        MessageBox.Show("Vui lòng liên hệ admin thêm đủ ảnh sản phẩm!!!");
                        daHienThiThongBaoLoi = true; // Đánh dấu đã hiển thị thông báo lỗi
                    }
                }
                
            }
        }
        //private void LoadProducts()
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT * FROM sanpham INNER JOIN danhmuc ON IDdanhmuc = IDdm", MainClass.con))
        //    {
        //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //        {
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                byte[] imageArray = (byte[])row["Anhsanpham"];
        //                Image image;
        //                using (MemoryStream ms = new MemoryStream(imageArray))
        //                {
        //                    image = Image.FromStream(ms);
        //                }

        //                AddItems(
        //                    row["IDsanpham"].ToString(),
        //                    row["Tensanpham"].ToString(),
        //                    row["Tendanhmuc"].ToString(),
        //                    row["Giasanpham"].ToString(),
        //                    image
        //                );
        //            }
        //        }
        //    }
        //}

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in PanelSanPham.Controls)
            {
                var pro = (ucSanPham)item;
                pro.Visible = pro.PName.ToLower().Contains(txtTimKiem.Text.Trim().ToLower());
            }
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvDonGia" || dataGridView1.Columns[e.ColumnIndex].Name == "dgvThanhTien")
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

        private void GetTotal()
        {
            //double tongTien = 0;
            //lblTong.Text = "";
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    tongTien += double.Parse(item.Cells["dgvThanhTien"].Value.ToString());
            //}
            //lblTong.Text = tongTien.ToString("N0")+"đ";


            //double tongTien = 0;
            //lblTong.Text = "";
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    // Kiểm tra nếu giá trị trong ô có thể được chuyển đổi thành số thực
            //    double thanhTien;
            //    if (double.TryParse(item.Cells["dgvThanhTien"].Value.ToString(), out thanhTien))
            //    {
            //        tongTien += thanhTien;
            //    }
            //}
            //lblTong.Text = tongTien.ToString("N0") + "đ";



            double tongTien = 0;

            // Tính tổng tiền từ cột "Thành tiền" của DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["dgvThanhTien"].Value != null)
                {
                    //double thanhTien;
                    //if (double.TryParse(row.Cells["dgvThanhTien"].Value.ToString(), out thanhTien))
                    //{
                    //    tongTien += thanhTien;
                    //}

                    double thanhTien;
                    // Thử chuyển đổi giá trị thành số
                    if (double.TryParse(row.Cells["dgvThanhTien"].Value.ToString().Replace("đ", "").Replace(",", ""), out thanhTien))
                    {
                        tongTien += thanhTien;
                    }
                }
            }

            // Tính thuế VAT từ TextBox
            double thueVAT = 0;
            if (!string.IsNullOrEmpty(txtVAT.Text) && double.TryParse(txtVAT.Text, out thueVAT))
            {
                // Tính tổng tiền sau khi đã tính thuế VAT
                double tongTienSauThue = tongTien * (1 + thueVAT / 100);

                // Áp dụng khuyến mãi từ ComboBox nếu có
                if (cbKM.SelectedIndex != -1)
                {
                    // Lấy giá trị khuyến mãi từ ComboBox
                    double khuyenMai;
                    if (double.TryParse(cbKM.SelectedItem.ToString().Replace("%", ""), out khuyenMai))
                    {
                        // Tính giá trị khuyến mãi
                        double giaTriKhuyenMai = tongTienSauThue * khuyenMai / 100;

                        // Áp dụng giá trị khuyến mãi
                        tongTienSauThue -= giaTriKhuyenMai;
                    }
                }

                // Hiển thị tổng tiền đã tính lên Label
                lblTong.Text = tongTienSauThue.ToString("N0") + "đ";
            }
            else
            {
                // Xử lý trường hợp khi thueVAT không hợp lệ
                lblTong.Text = tongTien.ToString("N0") + "đ";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy ra chỉ mục của dòng được chọn
            int selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0)
            {
                // Lấy ra giá trị của ô trong cột dgvTen từ dòng được chọn
                object cellValue = dataGridView1.Rows[selectedRowIndex].Cells["dgvTen"].Value;
                if (cellValue != null)
                {
                    string ten = cellValue.ToString();

                    // Hiển thị thông tin của dòng được chọn
                    MessageBox.Show($"Bạn đã chọn dòng có món ăn/thức uống tên: {ten}");
                }
                else
                {
                    MessageBox.Show("Giá trị của ô không hợp lệ.");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Xóa các dòng chứa cell được chọn
                //foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                //{
                //    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                //}
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                            dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một dòng trong DataGridView chưa
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy giá trị của cột "Số lượng" trong dòng được chọn
                int soLuongHienTai = Convert.ToInt32(selectedRow.Cells["dgvSoLuong"].Value);

                // Tạo và hiển thị formNhapSoLuong
                frmNhapSoLuong frm = new frmNhapSoLuong();
                frm.SoLuongHienTai = soLuongHienTai;

                // Hiển thị giá trị cũ trong NumericUpDown trên formNhapSoLuong
                frm.numericUpDown1.Value = soLuongHienTai;

                // Nếu người dùng click OK trên formNhapSoLuong
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật giá trị của cột "Số lượng" trong DataGridView
                    selectedRow.Cells["dgvSoLuong"].Value = frm.SoLuong;

                    // Lấy giá trị của cột "Đơn giá"
                    double donGia = Convert.ToDouble(selectedRow.Cells["dgvDonGia"].Value);

                    // Lấy giá trị của cột "Số lượng" sau khi đã cập nhật
                    int soLuong = frm.SoLuong;

                    // Tính toán và cập nhật giá trị cho cột "Thành tiền"
                    selectedRow.Cells["dgvThanhTien"].Value = donGia * soLuong;

                    // Cập nhật tổng tiền
                    GetTotal();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetTotal();
        }

        private void cbKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        public int MainID = 0;
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            //// Đặt màu cho tất cả các nút về màu ban đầu
            //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            //// Thay đổi màu của nút được click
            //Button clickedButton = (Button)sender;//đổi màu nút
            //clickedButton.BackColor = x; // Hoặc màu mong muốn khác
            DialogResult result = MessageBox.Show("Bạn có muốn tạo mới không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblTenTaiXe.Text = "";
                lblBan.Text = "";
                lblPhucVu.Text = "";
                lblBan.Visible = false;
                lblPhucVu.Visible = false;
                dataGridView1.Rows.Clear();
                MainID = 0;
                //lblTong.Text = "00";
                lblTong.Text = (0).ToString("N0") + "đ";
                cbKM.SelectedIndex = -1;
                OrderType = "";
                // Đặt màu cho tất cả các nút về màu ban đầu
                //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút
                // Đặt màu cho tất cả các nút về màu ban đầu
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
                lblHinhThucAn.Text = "";
                lblHinhThucAn.Visible = false;
                PanelSanPham.Enabled = true;
                btnThanhToan.Visible = false;
            }
            //else
                // Đặt màu cho tất cả các nút về màu ban đầu
                //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút
        }

        public string OrderType = "";
        private void btnGiaoHang_Click(object sender, EventArgs e)
        {

            if (lblHinhThucAn.Text == "Chưa xác định")
            {
                // Cập nhật kieuorder thành "Giao hàng"
                string updateOrderTypeQuery = "UPDATE tblMain SET tenban = @tenban, tenphucvu= @tenphucvu," +
                    " kieuorder = @OrderType WHERE MainID = @MainID";

                using (SqlCommand cmdUpdateOrderType = new SqlCommand(updateOrderTypeQuery, MainClass.con))
                {
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenban", "");
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenphucvu", "");
                    cmdUpdateOrderType.Parameters.AddWithValue("@OrderType", "Giao hàng");
                    cmdUpdateOrderType.Parameters.AddWithValue("@MainID", MainID);

                    try
                    {
                        if (MainClass.con.State == ConnectionState.Closed)
                        {
                            MainClass.con.Open();
                        }

                        cmdUpdateOrderType.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật kieuorder: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (MainClass.con.State == ConnectionState.Open)
                        {
                            MainClass.con.Close();
                        }
                    }
                }
            }
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = y; // Hoặc màu mong muốn khác

            DialogResult result = MessageBox.Show("Bạn muốn chọn hình thức giao hàng?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblBan.Text = "";
                lblPhucVu.Text = "";
                lblBan.Visible = false;
                lblPhucVu.Visible = false;
                OrderType = "Giao hàng";
                lblHinhThucAn.Visible = true;
                lblHinhThucAn.Text = "Giao hàng";

                frmThemKhachHang frm = new frmThemKhachHang();
                frm.mainID = MainID;
                frm.orderType = OrderType;
                MainClass.BlurBackground(frm);

                if (frm.txtTen.Text != "")//vì mang đi thì không có thông tin tài xế 
                {
                    driverID = frm.driverID;
                    lblTenTaiXe.Text = "Tên khách hàng: " + frm.txtTen.Text + " - Số điện thoại: " +
                        frm.txtSoDienThoai.Text + " - Driver: " + frm.cbTaiXe.Text + " - Địa chỉ: " + frm.txtDiaChi.Text;
                    lblTenTaiXe.Visible = true;
                    customerName = frm.txtTen.Text;
                    customerPhone = frm.txtSoDienThoai.Text;
                    customerAddress = frm.txtDiaChi.Text;
                }
            }
            else
                // Đặt màu cho tất cả các nút về màu ban đầu
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
        }

        private void btnMangDi_Click(object sender, EventArgs e)
        {
            if (lblHinhThucAn.Text == "Chưa xác định")
            {
                // Cập nhật kieuorder thành "Giao hàng"
                string updateOrderTypeQuery = "UPDATE tblMain SET tenban = @tenban, tenphucvu= @tenphucvu," +
                    " kieuorder = @OrderType WHERE MainID = @MainID";

                using (SqlCommand cmdUpdateOrderType = new SqlCommand(updateOrderTypeQuery, MainClass.con))
                {
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenban", "");
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenphucvu", "");
                    cmdUpdateOrderType.Parameters.AddWithValue("@OrderType", "Mang đi");
                    cmdUpdateOrderType.Parameters.AddWithValue("@MainID", MainID);

                    try
                    {
                        if (MainClass.con.State == ConnectionState.Closed)
                        {
                            MainClass.con.Open();
                        }

                        cmdUpdateOrderType.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật kieuorder: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (MainClass.con.State == ConnectionState.Open)
                        {
                            MainClass.con.Close();
                        }
                    }
                }
            }

            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = y; // Hoặc màu mong muốn khác

            DialogResult result = MessageBox.Show("Bạn muốn chọn hình thức mang đi?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lblBan.Text = "";
                lblPhucVu.Text = "";
                lblBan.Visible = false;
                lblPhucVu.Visible = false;
                OrderType = "Mang đi";
                lblHinhThucAn.Visible = true;
                lblHinhThucAn.Text = "Mang đi";

                frmThemKhachHang frm = new frmThemKhachHang();
                frm.mainID = MainID;
                frm.orderType = OrderType;
                MainClass.BlurBackground(frm);

                if (frm.txtTen.Text !="")//vì mang đi thì không có thông tin tài xế 
                {
                    driverID = frm.driverID;
                    lblTenTaiXe.Text = "Tên khách hàng: " + frm.txtTen.Text + " - Số điện thoại: " + 
                        frm.txtSoDienThoai.Text;
                    lblTenTaiXe.Visible = true;
                    customerName = frm.txtTen.Text;
                    customerPhone = frm.txtSoDienThoai.Text;
                    customerAddress = frm.txtDiaChi.Text;
                }
            }
            else
                // Đặt màu cho tất cả các nút về màu ban đầu
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
        }

        private void btnAnTaiNhaHang_Click(object sender, EventArgs e)
        {
            if (lblHinhThucAn.Text == "Chưa xác định")
            {
                // Cập nhật kieuorder thành "Giao hàng"
                string updateOrderTypeQuery = "UPDATE tblMain SET tenban = @tenban, tenphucvu= @tenphucvu," +
                     " kieuorder = @OrderType WHERE MainID = @MainID";

                using (SqlCommand cmdUpdateOrderType = new SqlCommand(updateOrderTypeQuery, MainClass.con))
                {
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenban", lblBan.Text);
                    cmdUpdateOrderType.Parameters.AddWithValue("@tenphucvu", lblPhucVu.Text);
                    cmdUpdateOrderType.Parameters.AddWithValue("@OrderType", "Ăn tại nhà hàng");
                    cmdUpdateOrderType.Parameters.AddWithValue("@MainID", MainID);

                    try
                    {
                        if (MainClass.con.State == ConnectionState.Closed)
                        {
                            MainClass.con.Open();
                        }

                        cmdUpdateOrderType.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật kieuorder: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (MainClass.con.State == ConnectionState.Open)
                        {
                            MainClass.con.Close();
                        }
                    }
                }
            }

            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = y; // Hoặc màu mong muốn khác

            DialogResult result = MessageBox.Show("Bạn muốn chọn hình thức ăn tại nhà hàng?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OrderType = "Ăn tại nhà hàng";
                lblTenTaiXe.Visible = false;
                frmLuaChonBan frm = new frmLuaChonBan();
                MainClass.BlurBackground(frm);
                if (frm.TableName != "")
                {
                    lblBan.Text = frm.TableName;
                    lblBan.Visible = true;
                    lblHinhThucAn.Visible = true;
                    lblHinhThucAn.Text = "Ăn tại nhà hàng";
                }
                else
                {
                    lblBan.Text = "";
                    lblBan.Visible = false;
                }

                frmChonPhucVu frm2 = new frmChonPhucVu();
                MainClass.BlurBackground(frm2);
                if (frm2.waiterName != "")
                {
                    lblPhucVu.Text = frm2.waiterName;
                    lblPhucVu.Visible = true;
                }
                else
                {
                    lblPhucVu.Text = "";
                    lblPhucVu.Visible = false;
                }
            }
            else
                // Đặt màu cho tất cả các nút về màu ban đầu
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
        }

        private void btnGuiDonDatMon1_Click(object sender, EventArgs e)
        {
            // Đặt màu cho tất cả các nút về màu ban đầu
            //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            //Button clickedButton = (Button)sender;//đổi màu nút
            //clickedButton.BackColor = x; // Hoặc màu mong muốn khác

            DialogResult result = MessageBox.Show("Bạn có chắc gửi đơn đặt món?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Save the data in database
                //Create tables
                //need to add field to table to store additional info

                string qry1 = ""; // Main table
                string qry2 = ""; // Detail table

                int detailID = 0;
                if (MainID == 0) //Insert
                {
                    qry1 = @"Insert into tblMain Values (@ngay, @gio, @tenban, @tenphucvu, 
                            @trangthai, @kieuorder, @tongcong, @danhan, @thaydoi, @taixeID, @tenkhachhang, @sdtkhach, @khuyenmai);
                                    select SCOPE_IDENTITY()";
                    //Dòng này sẽ lấy giá trị id được thêm mới gần đây.
                }

                else //Update
                {
                    qry1 = @"Update tblMain Set trangthai = @trangthai, tongcong = @tongcong,
                            danhan = @danhan, thaydoi = @thaydoi where MainID = @ID";

                }

                if (string.IsNullOrEmpty(OrderType) || !double.TryParse(lblTong.Text.Replace("đ", "").Replace(",", ""), out double total) /*!double.TryParse(lblTong.Text, out double total)*/ || total == 0) // Kiểm tra xem OrderType có giá trị hay không
                {
                    MessageBox.Show("Vui lòng chọn loại hình thức ăn uống và điền đủ thông tin trước khi đặt bếp làm món!!!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                    cmd.Parameters.AddWithValue("@ID", MainID);
                    cmd.Parameters.AddWithValue("@ngay", Convert.ToDateTime(DateTime.Now.Date));
                    cmd.Parameters.AddWithValue("@gio", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@tenban", lblBan.Text);
                    cmd.Parameters.AddWithValue("@tenphucvu", lblPhucVu.Text);
                    cmd.Parameters.AddWithValue("@trangthai", "Đang chờ xử lí");
                    cmd.Parameters.AddWithValue("@kieuorder", OrderType);
                    //cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text)); //Vì chúng ta chỉ lưu trữ dữ liệu cho phòng bếp, giá trị sẽ được cập nhật khi thanh toán được nhận
                    cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text.Replace("đ", "").Replace(",", ""))); // Loại bỏ ký tự "đ" và dấu phân cách
                    cmd.Parameters.AddWithValue("@danhan", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@thaydoi", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@taixeID", driverID);
                    cmd.Parameters.AddWithValue("@tenkhachhang", customerName);
                    cmd.Parameters.AddWithValue("@sdtkhach", customerPhone);
                    cmd.Parameters.AddWithValue("@khuyenmai", cbKM.Text);
                    cmd.Parameters.AddWithValue("@diachi", customerAddress);

                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        detailID = Convert.ToInt32(row.Cells["dgvID"].Value);
                        if (detailID == 0) //insert
                        {
                            qry2 = @" Insert into chitietban Values(@MainID,@sanphamID,@soluong,@gia, @thanhtien)";
                        }
                        else //Update
                        {
                            qry2 = @" UPdate chitietban Set sanphamID= @sanphamID, soluong = @soluong,gia= @gia, 
                                thanhtien= @thanhtien where chitietID = @ID";
                        }

                        SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                        cmd2.Parameters.AddWithValue("@ID", detailID);
                        cmd2.Parameters.AddWithValue("@MainID", MainID);
                        cmd2.Parameters.AddWithValue("@sanphamID", Convert.ToInt32(row.Cells["dgvspID"].Value));
                        cmd2.Parameters.AddWithValue("@soluong", Convert.ToInt32(row.Cells["dgvSoLuong"].Value));
                        cmd2.Parameters.AddWithValue("@gia", Convert.ToDouble(row.Cells["dgvDonGia"].Value));
                        cmd2.Parameters.AddWithValue("@thanhtien", Convert.ToDouble(row.Cells["dgvThanhTien"].Value));

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        cmd2.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                    }

                    //thông báo insert
                    //if (detailID == 0)
                    //{
                    //MainID = 0;
                    //detailID = 0;
                    MessageBox.Show("Đặt bếp làm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainID = 0;
                    detailID = 0;

                    dataGridView1.Rows.Clear();
                    lblBan.Text = "";
                    lblPhucVu.Text = "";
                    lblBan.Visible = false;
                    lblPhucVu.Visible = false;
                    //lblTong.Text = "00";
                    lblTong.Text = (0).ToString("N0") + "đ";
                    cbKM.SelectedIndex = -1;
                    OrderType = "";
                    lblHinhThucAn.Text = "";
                    lblTenTaiXe.Text = "";
                    PanelSanPham.Enabled = true;
                    btnGuiDonDatMon1.Visible = false;
                    btnGuiDonDatMon.Visible = true;
                    //ThongBaoDatThanhCong();
                    //}
                    ////thông báo update
                    //else
                    //{
                    //    //đặt và làm hàm thông báo update ở đây
                    //}
                }
                // Đặt màu cho tất cả các nút về màu ban đầu
                //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
            }
            //else
            //    // Đặt màu cho tất cả các nút về màu ban đầu
            //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút
        }

        private void btnGuiDonDatMon_Click(object sender, EventArgs e)
        {
            // Đặt màu cho tất cả các nút về màu ban đầu
            //SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            //Button clickedButton = (Button)sender;//đổi màu nút
            //clickedButton.BackColor = x; // Hoặc màu mong muốn khác

            DialogResult result = MessageBox.Show("Bạn có chắc gửi đơn đặt món?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string qry1 = ""; // Main table
                string qry2 = ""; // Detail table
                int detailID = 0;
                if (MainID == 0) //Insert
                {
                    qry1 = @"Insert into tblMain Values (@ngay, @gio, @tenban, @tenphucvu, 
                    @trangthai, @kieuorder, @tongcong, @danhan, @thaydoi, @taixeID, @tenkhachhang, @sdtkhach, @khuyenmai, @diachi);
                    select SCOPE_IDENTITY()";
                    //Dòng này sẽ lấy giá trị id được thêm mới gần đây.
                }
                else //Update
                {
                    qry1 = @"Update tblMain Set trangthai = @trangthai, tongcong = @tongcong,
                    danhan = @danhan, thaydoi = @thaydoi where MainID = @ID";
                }

                if (string.IsNullOrEmpty(OrderType) || !double.TryParse(lblTong.Text.Replace("đ", "").Replace(",", ""), out double total) || total == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại hình thức ăn uống và điền đủ thông tin trước khi đặt bếp làm món!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                    cmd.Parameters.AddWithValue("@ID", MainID);
                    cmd.Parameters.AddWithValue("@ngay", Convert.ToDateTime(DateTime.Now.Date));
                    cmd.Parameters.AddWithValue("@gio", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@tenban", lblBan.Text);
                    cmd.Parameters.AddWithValue("@tenphucvu", lblPhucVu.Text);
                    cmd.Parameters.AddWithValue("@trangthai", "Đang chờ xử lí");
                    cmd.Parameters.AddWithValue("@kieuorder", OrderType);
                    cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text.Replace("đ", "").Replace(",", "")));
                    cmd.Parameters.AddWithValue("@danhan", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@thaydoi", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@taixeID", driverID);
                    cmd.Parameters.AddWithValue("@tenkhachhang", customerName);
                    cmd.Parameters.AddWithValue("@sdtkhach", customerPhone);
                    cmd.Parameters.AddWithValue("@khuyenmai", cbKM.Text);
                    cmd.Parameters.AddWithValue("@diachi", customerAddress);

                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int productID = Convert.ToInt32(row.Cells["dgvspID"].Value);
                        int orderQuantity = Convert.ToInt32(row.Cells["dgvSoLuong"].Value);

                        // Kiểm tra số lượng sản phẩm hiện có
                        string checkQtyQuery = "SELECT soluong FROM sanpham WHERE idsanpham = @productID";
                        SqlCommand checkQtyCmd = new SqlCommand(checkQtyQuery, MainClass.con);
                        checkQtyCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        int availableQty = (int)checkQtyCmd.ExecuteScalar();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        if (orderQuantity > availableQty)
                        {
                            MessageBox.Show($"Số lượng sản phẩm (ID: {productID}) không đủ. Số lượng hiện có: {availableQty}.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Tiếp tục xử lý đơn hàng nếu số lượng đủ
                        detailID = Convert.ToInt32(row.Cells["dgvID"].Value);
                        if (detailID == 0) //insert
                        {
                            qry2 = @"Insert into chitietban Values(@MainID,@sanphamID,@soluong,@gia, @thanhtien)";
                        }
                        else //Update
                        {
                            qry2 = @"Update chitietban Set sanphamID = @sanphamID, soluong = @soluong, gia = @gia, thanhtien = @thanhtien where chitietID = @ID";
                        }

                        SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                        cmd2.Parameters.AddWithValue("@ID", detailID);
                        cmd2.Parameters.AddWithValue("@MainID", MainID);
                        cmd2.Parameters.AddWithValue("@sanphamID", productID);
                        cmd2.Parameters.AddWithValue("@soluong", orderQuantity);
                        cmd2.Parameters.AddWithValue("@gia", Convert.ToDouble(row.Cells["dgvDonGia"].Value));
                        cmd2.Parameters.AddWithValue("@thanhtien", Convert.ToDouble(row.Cells["dgvThanhTien"].Value));

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        cmd2.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        // Cập nhật số lượng sản phẩm sau khi đặt món
                        string updateQtyQuery = "UPDATE sanpham SET soluong = soluong - @orderQuantity WHERE idsanpham = @productID";
                        SqlCommand updateQtyCmd = new SqlCommand(updateQtyQuery, MainClass.con);
                        updateQtyCmd.Parameters.AddWithValue("@orderQuantity", orderQuantity);
                        updateQtyCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        updateQtyCmd.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        // Cập nhật trạng thái nếu số lượng bằng 0
                        string updateStatusQuery = "UPDATE sanpham SET trangthai = N'Ngừng bán' WHERE idsanpham = @productID AND soluong = 0";
                        SqlCommand updateStatusCmd = new SqlCommand(updateStatusQuery, MainClass.con);
                        updateStatusCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        updateStatusCmd.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                    }

                    MessageBox.Show("Đặt bếp làm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainID = 0;
                    detailID = 0;
                    PanelSanPham.Controls.Clear();
                    LoadProducts();

                    dataGridView1.Rows.Clear();
                    lblBan.Text = "";
                    lblPhucVu.Text = "";
                    lblBan.Visible = false;
                    lblPhucVu.Visible = false;
                    lblTong.Text = (0).ToString("N0") + "đ";
                    cbKM.SelectedIndex = -1;
                    OrderType = "";
                    lblHinhThucAn.Text = "";
                    lblTenTaiXe.Text = "";
                    PanelSanPham.Enabled = true;
                    SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
                    btnGuiDonDatMon1.Visible = false;
                    btnGuiDonDatMon.Visible = true;
                }
            }
        }

        //private void ThongBaoDatThanhCong()
        //{
        //    MessageBox.Show("Đặt bếp làm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    dataGridView1.Rows.Clear();
        //    lblBan.Text = "";
        //    lblPhucVu.Text = "";
        //    lblBan.Visible = false;
        //    lblPhucVu.Visible = false;
        //    //lblTong.Text = "00";
        //    lblTong.Text = (0).ToString("N0") + "đ";
        //    cbKM.SelectedIndex = -1;
        //    OrderType = "";
        //    lblHinhThucAn.Text = "";
        //}

        public int id = 0;
        private void btnDanhMucHoaDon_Click(object sender, EventArgs e)
        {
            frmDanhMucHoaDon frm = new frmDanhMucHoaDon();
            MainClass.BlurBackground(frm);

            if (frm.MainID > 0)
            {
                //PanelSanPham.Enabled = false;
                lblKM.Visible = true;
                lblVAT.Visible = true;
                cbKM.Visible = true;
                txtVAT.Visible = true;
                lblHinhThucAn.Text = frm.TrangThai;
                lblHinhThucAn.Visible = true;
                if (lblHinhThucAn.Text == "Tạm dừng")
                {
                    btnThanhToan.Visible = false;
                    btnGuiDonDatMon.Visible = false;
                    btnGuiDonDatMon1.Visible = true;
                }
                else
                {
                    btnThanhToan.Visible = true;
                }
                   
                id = frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
            }
        }
        private void LoadEntries()
        {
            string qry = @"Select * from tblMain m 
                    inner join chitietban d on m.MainID = d.MainID 
                    inner join sanpham sp on sp.IDsanpham = d.sanphamID 
                    Where m.MainID = " + id + "";

            SqlCommand cmd2 = new SqlCommand(qry, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            if (dt2.Rows[0]["kieuorder"].ToString() == "Giao hàng")
            {
                btnGiaoHang.BackColor = Color.Coral;
                lblPhucVu.Visible = false;
                lblBan.Visible = false;
            }
            else if (dt2.Rows[0]["kieuorder"].ToString() == "Mang đi")
            {
                btnMangDi.BackColor = Color.Coral;
                lblPhucVu.Visible = false;
                lblBan.Visible = false;
            }
            else if (dt2.Rows[0]["kieuorder"].ToString() == "Chưa xác định")
            {
                lblHinhThucAn.Visible = true;
                lblHinhThucAn.Text = "Chưa xác định";
                PanelSanPham.Enabled = true;
                lblKM.Visible = true;
                lblVAT.Visible = true;
                cbKM.Visible = true;
                txtVAT.Visible = true;
                btnThanhToan.Visible = false;
            }
            else
            {
                btnAnTaiNhaHang.BackColor = Color.Coral;
                lblPhucVu.Visible = true;
                lblBan.Visible = true;
            }

            dataGridView1.Rows.Clear();

            foreach (DataRow item in dt2.Rows)
            {
                lblBan.Text = item["tenban"].ToString();
                lblPhucVu.Text = item["tenphucvu"].ToString();

                string detailid = item["chitietID"].ToString();
                string proName = item["Tensanpham"].ToString();
                string proid = item["sanphamID"].ToString();
                string qty = item["soluong"].ToString();
                string price = item["gia"].ToString();
                string amount = item["thanhtien"].ToString();
                object[] obj = { 0, detailid, proid, proName, qty, price, amount }; 
                dataGridView1.Rows.Add(obj);
            }
            GetTotal();
        }

        // Xử lý sự kiện LuuButtonClicked
        private void Frm_LuuButtonClicked(object sender, EventArgs e)
        {
            TrangThaiMoi(sender, e);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan();
            frm.LuuButtonClicked += Frm_LuuButtonClicked; // Đăng ký sự kiện LuuButtonClicked
            frm.label5.Text = cbKM.Text;
            frm.MainID = id;
            string cleanedString = lblTong.Text.Replace("đ", "").Replace(",", ""); // Loại bỏ ký tự "đ" và dấu phẩy
            frm.amt = Convert.ToDouble(cleanedString);
            MainClass.BlurBackground(frm);
            
            //MainID = 0;
            //dataGridView1.Rows.Clear();
            //lblBan.Text = "";
            //lblPhucVu.Text = "";
            //lblBan.Visible = false;
            //lblPhucVu.Visible = false;
            ////lblTong.Text = "00";
            //lblTong.Text = (0).ToString("N0") + "đ";
            //cbKM.SelectedIndex = -1;
            //OrderType = "";
            //lblHinhThucAn.Text = "";
            //btnThanhToan.Visible = false;
            //lblKM.Visible = true;
            //lblVAT.Visible = true;
            //cbKM.Visible = true;
            //txtVAT.Visible = true;
            //PanelSanPham.Enabled = true;
            //SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
        }

        private void TrangThaiMoi(object sender, EventArgs e)
        {
            // Thực hiện dòng code khi nút "Lưu" được nhấn
            MainID = 0;
            dataGridView1.Rows.Clear();
            lblBan.Text = "";
            lblPhucVu.Text = "";
            lblBan.Visible = false;
            lblPhucVu.Visible = false;
            //lblTong.Text = "00";
            lblTong.Text = (0).ToString("N0") + "đ";
            cbKM.SelectedIndex = -1;
            OrderType = "";
            lblHinhThucAn.Text = "";
            btnThanhToan.Visible = false;
            lblKM.Visible = true;
            lblVAT.Visible = true;
            cbKM.Visible = true;
            txtVAT.Visible = true;
            PanelSanPham.Enabled = true;
            SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue)); // Đổi màu nút
        }

        //private void btnTamDung_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn có muốn giữ đơn đặt món?",
        //        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    btnThanhToan.Visible = false;
        //    if (result == DialogResult.Yes)
        //    {
        //        string qry1 = ""; // Main table
        //        string qry2 = ""; // Detail table

        //        int detailID = 0;
        //        if (MainID == 0) //Insert
        //        {
        //            qry1 = @"Insert into tblMain Values (@ngay, @gio, @tenban, @tenphucvu, 
        //                    @trangthai, @kieuorder, @tongcong, @danhan, @thaydoi, @taixeID, @tenkhachhang, @sdtkhach, @khuyenmai, @diachi);
        //                            select SCOPE_IDENTITY()";
        //            //Dòng này sẽ lấy giá trị id được thêm mới gần đây.
        //        }

        //        else //Update
        //        {
        //            qry1 = @"Update tblMain Set trangthai = @trangthai, tongcong = @tongcong,
        //                    danhan = @danhan, thaydoi = @thaydoi where MainID = @ID";

        //        }

        //        if (/*string.IsNullOrEmpty(OrderType) ||*/ !double.TryParse(lblTong.Text.Replace("đ", "").Replace(",", ""), out double total) /*!double.TryParse(lblTong.Text, out double total)*/ || total == 0) // Kiểm tra xem OrderType có giá trị hay không
        //        {
        //            MessageBox.Show("Vui lòng chọn loại hình thức ăn uống và điền đủ thông tin trước khi đặt bếp làm món!!!",
        //                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //        {
        //            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
        //            cmd.Parameters.AddWithValue("@ID", MainID);
        //            cmd.Parameters.AddWithValue("@ngay", Convert.ToDateTime(DateTime.Now.Date));
        //            cmd.Parameters.AddWithValue("@gio", DateTime.Now.ToShortTimeString());
        //            cmd.Parameters.AddWithValue("@tenban", lblBan.Text);
        //            cmd.Parameters.AddWithValue("@tenphucvu", lblPhucVu.Text);
        //            cmd.Parameters.AddWithValue("@trangthai", "Tạm dừng");
        //            cmd.Parameters.AddWithValue("@kieuorder", "Chưa xác định");
        //            //cmd.Parameters.AddWithValue("@kieuorder", OrderType);
        //            //cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text)); //Vì chúng ta chỉ lưu trữ dữ liệu cho phòng bếp, giá trị sẽ được cập nhật khi thanh toán được nhận
        //            cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text.Replace("đ", "").Replace(",", ""))); // Loại bỏ ký tự "đ" và dấu phân cách
        //            cmd.Parameters.AddWithValue("@danhan", Convert.ToDouble(0));
        //            cmd.Parameters.AddWithValue("@thaydoi", Convert.ToDouble(0));
        //            cmd.Parameters.AddWithValue("@taixeID", driverID);
        //            cmd.Parameters.AddWithValue("@tenkhachhang", customerName);
        //            cmd.Parameters.AddWithValue("@sdtkhach", customerPhone);
        //            cmd.Parameters.AddWithValue("@khuyenmai", cbKM.Text);
        //            cmd.Parameters.AddWithValue("@diachi", customerAddress);

        //            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
        //            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
        //            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

        //            foreach (DataGridViewRow row in dataGridView1.Rows)
        //            {
        //                detailID = Convert.ToInt32(row.Cells["dgvID"].Value);
        //                if (detailID == 0) //insert
        //                {
        //                    qry2 = @" Insert into chitietban Values(@MainID,@sanphamID,@soluong,@gia, @thanhtien)";
        //                }
        //                else //Update
        //                {
        //                    qry2 = @" UPdate chitietban Set sanphamID= @sanphamID, soluong = @soluong,gia= @gia, 
        //                        thanhtien= @thanhtien where chitietID = @ID";
        //                }

        //                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
        //                cmd2.Parameters.AddWithValue("@ID", detailID);
        //                cmd2.Parameters.AddWithValue("@MainID", MainID);
        //                cmd2.Parameters.AddWithValue("@sanphamID", Convert.ToInt32(row.Cells["dgvspID"].Value));
        //                cmd2.Parameters.AddWithValue("@soluong", Convert.ToInt32(row.Cells["dgvSoLuong"].Value));
        //                cmd2.Parameters.AddWithValue("@gia", Convert.ToDouble(row.Cells["dgvDonGia"].Value));
        //                cmd2.Parameters.AddWithValue("@thanhtien", Convert.ToDouble(row.Cells["dgvThanhTien"].Value));

        //                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
        //                cmd2.ExecuteNonQuery();
        //                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
        //            }
        //            MessageBox.Show("Đã giữ đơn đặt món! Mã đơn hàng: " + MainID.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            MainID = 0;
        //            detailID = 0;

        //            dataGridView1.Rows.Clear();
        //            lblBan.Text = "";
        //            lblPhucVu.Text = "";
        //            lblBan.Visible = false;
        //            lblPhucVu.Visible = false;
        //            lblTong.Text = (0).ToString("N0") + "đ";
        //            cbKM.SelectedIndex = -1;
        //            OrderType = "";
        //            lblHinhThucAn.Text = "";
        //            lblTenTaiXe.Text = "";
        //        }
        //        SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue));//đổi màu nút
        //    }
        //}

        private void btnTamDung_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn giữ đơn đặt món?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            btnThanhToan.Visible = false;
            if (result == DialogResult.Yes)
            {
                string qry1 = ""; // Main table
                string qry2 = ""; // Detail table

                int detailID = 0;
                if (MainID == 0) // Insert
                {
                    qry1 = @"Insert into tblMain Values (@ngay, @gio, @tenban, @tenphucvu, 
                    @trangthai, @kieuorder, @tongcong, @danhan, @thaydoi, @taixeID, @tenkhachhang, @sdtkhach, @khuyenmai, @diachi);
                    select SCOPE_IDENTITY()";
                }
                else // Update
                {
                    qry1 = @"Update tblMain Set trangthai = @trangthai, tongcong = @tongcong,
                    danhan = @danhan, thaydoi = @thaydoi where MainID = @ID";
                }

                if (!double.TryParse(lblTong.Text.Replace("đ", "").Replace(",", ""), out double total) || total == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại hình thức ăn uống và điền đủ thông tin trước khi đặt bếp làm món!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                    cmd.Parameters.AddWithValue("@ID", MainID);
                    cmd.Parameters.AddWithValue("@ngay", Convert.ToDateTime(DateTime.Now.Date));
                    cmd.Parameters.AddWithValue("@gio", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@tenban", lblBan.Text);
                    cmd.Parameters.AddWithValue("@tenphucvu", lblPhucVu.Text);
                    cmd.Parameters.AddWithValue("@trangthai", "Tạm dừng");
                    cmd.Parameters.AddWithValue("@kieuorder", "Chưa xác định");
                    cmd.Parameters.AddWithValue("@tongcong", Convert.ToDouble(lblTong.Text.Replace("đ", "").Replace(",", "")));
                    cmd.Parameters.AddWithValue("@danhan", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@thaydoi", Convert.ToDouble(0));
                    cmd.Parameters.AddWithValue("@taixeID", driverID);
                    cmd.Parameters.AddWithValue("@tenkhachhang", customerName);
                    cmd.Parameters.AddWithValue("@sdtkhach", customerPhone);
                    cmd.Parameters.AddWithValue("@khuyenmai", cbKM.Text);
                    cmd.Parameters.AddWithValue("@diachi", customerAddress);

                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int productID = Convert.ToInt32(row.Cells["dgvspID"].Value);
                        int orderQuantity = Convert.ToInt32(row.Cells["dgvSoLuong"].Value);

                        // Check product quantity
                        string checkQtyQuery = "SELECT soluong FROM sanpham WHERE idsanpham = @productID";
                        SqlCommand checkQtyCmd = new SqlCommand(checkQtyQuery, MainClass.con);
                        checkQtyCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        int availableQty = (int)checkQtyCmd.ExecuteScalar();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        if (orderQuantity > availableQty)
                        {
                            MessageBox.Show($"Số lượng sản phẩm (ID: {productID}) không đủ. Số lượng hiện có: {availableQty}.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        detailID = Convert.ToInt32(row.Cells["dgvID"].Value);
                        if (detailID == 0) // Insert
                        {
                            qry2 = @"Insert into chitietban Values(@MainID,@sanphamID,@soluong,@gia, @thanhtien)";
                        }
                        else // Update
                        {
                            qry2 = @"Update chitietban Set sanphamID= @sanphamID, soluong = @soluong, gia= @gia, thanhtien= @thanhtien where chitietID = @ID";
                        }

                        SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                        cmd2.Parameters.AddWithValue("@ID", detailID);
                        cmd2.Parameters.AddWithValue("@MainID", MainID);
                        cmd2.Parameters.AddWithValue("@sanphamID", productID);
                        cmd2.Parameters.AddWithValue("@soluong", orderQuantity);
                        cmd2.Parameters.AddWithValue("@gia", Convert.ToDouble(row.Cells["dgvDonGia"].Value));
                        cmd2.Parameters.AddWithValue("@thanhtien", Convert.ToDouble(row.Cells["dgvThanhTien"].Value));

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        cmd2.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        // Update product quantity
                        string updateQtyQuery = "UPDATE sanpham SET soluong = soluong - @orderQuantity WHERE idsanpham = @productID";
                        SqlCommand updateQtyCmd = new SqlCommand(updateQtyQuery, MainClass.con);
                        updateQtyCmd.Parameters.AddWithValue("@orderQuantity", orderQuantity);
                        updateQtyCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        updateQtyCmd.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                        // Update product status if quantity is 0
                        string updateStatusQuery = "UPDATE sanpham SET trangthai = N'Ngừng bán' WHERE idsanpham = @productID AND soluong = 0";
                        SqlCommand updateStatusCmd = new SqlCommand(updateStatusQuery, MainClass.con);
                        updateStatusCmd.Parameters.AddWithValue("@productID", productID);

                        if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                        updateStatusCmd.ExecuteNonQuery();
                        if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                    }

                    MessageBox.Show("Đã giữ đơn đặt món! Mã đơn hàng: " + MainID.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainID = 0;
                    detailID = 0;

                    dataGridView1.Rows.Clear();
                    lblBan.Text = "";
                    lblPhucVu.Text = "";
                    lblBan.Visible = false;
                    lblPhucVu.Visible = false;
                    lblTong.Text = (0).ToString("N0") + "đ";
                    cbKM.SelectedIndex = -1;
                    OrderType = "";
                    lblHinhThucAn.Text = "";
                    lblTenTaiXe.Text = "";

                    PanelSanPham.Controls.Clear();
                    LoadProducts();
                }
                SetAllButtonsColor1(Color.FromKnownColor(KnownColor.CornflowerBlue)); // Đổi màu nút
            }
        }
        private void LoadDataIntoComboBox()
        {
            string query = "SELECT DISTINCT giatri FROM khuyenmai ORDER BY giatri ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cbKM.Items.Add(reader["giatri"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
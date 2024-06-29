using QuanLyNhaHang.Model;
using QuanLyNhaHang.Report;
using QuanLyNhaHang.View;
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
using static QuanLyNhaHang.MainClass;

namespace QuanLyNhaHang
{
    public partial class frmMain : Form
    {
        private string userRole; // Biến lưu trữ vai trò của người dùng
        public frmMain()
        {
            InitializeComponent();
        }
        // tham chiếu vào frmMain
        private static frmMain frmMain_obj; // Đổi _obj thành frmMain_obj

        public static frmMain Instance
        {
            get
            {
                if (frmMain_obj == null) // Thay _obj thành frmMain_obj
                {
                    frmMain_obj = new frmMain(); // Thay _obj thành frmMain_obj
                }
                return frmMain_obj;
            }
        }

        //phương thức để thêm điều khiển vào trong form main
        public void AddControls(Form f)
        {
            pnlDieuKhien.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            pnlDieuKhien.Controls.Add(f);
            f.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát khỏi ứng dụng??", "Thông báo!!!",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //Application.Exit();
                this.Close();
                frmDangNhap frm = new frmDangNhap();
                frm.Show();
            }
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private Button[] allButtons;
        private void frmMain_Load(object sender, EventArgs e)
        {
            AddControls(new frmHienThiQuangCao());
            lblTen.Text = MainClass.USER;
            frmMain_obj = this;
            allButtons = new Button[] { btnAdmin, btnPOS, btnBep, btnXemBan, btnGopBan, btnMenu, btnChuyenBan, btnHoaDon };

            //--------------------------------------------------------------------
            // Kết nối đến cơ sở dữ liệu
            //using (SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=QuanLyNhaHang;" +
            //"Integrated Security=True;User ID=sa;Password=123;"))
            using (SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True"))
            {
                con.Open();

                // Truy vấn kiểm tra vai trò của người dùng
                SqlCommand cmd = new SqlCommand("SELECT quyen FROM taikhoan WHERE ten = @username", con);
                cmd.Parameters.AddWithValue("@username", lblTen.Text);

                userRole = cmd.ExecuteScalar()?.ToString();

                con.Close();
            }
            if (userRole == "Admin")
            {
                // Hiển thị nút cho admin
                btnAdmin.Visible = true;
            }
            else
            {
                // Ẩn nút cho user
                btnAdmin.Visible = false;
            }
        }
        private void SetAllButtonsColor(Color color)
        {
            foreach (Button button in allButtons)
            {
                button.BackColor = color;
            }
        }
        //-------------------------------------------------------------------

        Color x = Color.Red;//đổi màu nút

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AddControls(new frmAdmin());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        //private void btnDanhMuc_Click(object sender, EventArgs e)
        //{

        //    AddControls(new frmHienThiDanhMuc());
        //    // Đặt màu cho tất cả các nút về màu ban đầu
        //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

        //    // Thay đổi màu của nút được click
        //    Button clickedButton = (Button)sender;//đổi màu nút
        //    clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        //}

        //private void btnBan_Click(object sender, EventArgs e)
        //{
        //    AddControls(new frmHienThiBan());
        //    // Đặt màu cho tất cả các nút về màu ban đầu
        //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

        //    // Thay đổi màu của nút được click
        //    Button clickedButton = (Button)sender;//đổi màu nút
        //    clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        //}

        //private void btnNhanVien_Click(object sender, EventArgs e)
        //{

        //    AddControls(new frmHienThiNhanVien());
        //    // Đặt màu cho tất cả các nút về màu ban đầu
        //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

        //    // Thay đổi màu của nút được click
        //    Button clickedButton = (Button)sender;//đổi màu nút
        //    clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        //}

        //private void btnSanPham_Click(object sender, EventArgs e)
        //{
        //    AddControls(new frmHienThiSanPham());
        //    // Đặt màu cho tất cả các nút về màu ban đầu
        //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

        //    // Thay đổi màu của nút được click
        //    Button clickedButton = (Button)sender;//đổi màu nút
        //    clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        //}

        //private void btnTaiKhoan_Click(object sender, EventArgs e)
        //{
        //    AddControls(new frmHienThiTaiKhoan());
        //    // Đặt màu cho tất cả các nút về màu ban đầu
        //    SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

        //    // Thay đổi màu của nút được click
        //    Button clickedButton = (Button)sender;//đổi màu nút
        //    clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        //}

        private void btnPOS_Click(object sender, EventArgs e)
        {
            frmPOS frm = new frmPOS();
            frm.Show();
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
            pnlDieuKhien.Controls.Clear();
        }

        private void btnBep_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiBep());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiQuangCao());
        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {
            AddControls(new frmLuaChonBan());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            AddControls(new frmThongBaoMenu());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
            string qry = @"select * from sanpham";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            MainClass.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            MainClass.con.Close();

            frmPrint frm = new frmPrint();
            rptMenu cr = new rptMenu();

            cr.SetDatabaseLogon("sa", "123");
            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.crystalReportViewer1.EnableDrillDown = true;
            frm.crystalReportViewer1.DisplayToolbar = true;
            frm.Show();
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            AddControls(new frmGopBan());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            AddControls(new frmChuyenBan());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiHoaDon());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }
    }
}



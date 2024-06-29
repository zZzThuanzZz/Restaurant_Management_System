using QuanLyNhaHang.Model;
using QuanLyNhaHang.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmAdmin : Form
    {
        private Button[] allButtons;
        public frmAdmin()
        {
            InitializeComponent();
        }

        Color x = Color.Yellow;//đổi màu nút
        public void AddControls(Form f)
        {
            pnlDieuKhien.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            pnlDieuKhien.Controls.Add(f);
            f.Show();
        }

        private void SetAllButtonsColor(Color color)
        {
            foreach (Button button in allButtons)
            {
                button.BackColor = color;
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiTaiKhoan());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            allButtons = new Button[] { btnBan, btnDanhMuc, btnNhanVien, btnSanPham, btnTaiKhoan, btnVAT, btnAnhQC,
                btnBaoCao, btnKhuyenMai, btnNguyenLieu, btnCongThuc };
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiDanhMuc());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiSanPham());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiBan());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiNhanVien());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnVAT_Click(object sender, EventArgs e)
        {
            AddControls(new frmVAT());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnAnhQC_Click(object sender, EventArgs e)
        {
            AddControls(new ThemXoaSuaAnhQC());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            AddControls(new frmBaoCao());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiKhuyenMai());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiNguyenLieu());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnCongThuc_Click(object sender, EventArgs e)
        {
            AddControls(new frmHienThiCongThuc());
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }
    }
}

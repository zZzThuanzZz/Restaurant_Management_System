using QuanLyNhaHang.Report;
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

namespace QuanLyNhaHang.Model
{
    public partial class frmThanhToan : MauThem
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        public double amt;
        public int MainID = 0;

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            double.TryParse(txtTienCanThanhToan.Text, out amt);
            double.TryParse(txtTienKhachDua.Text, out receipt);

            //change = Math.Abs(amt -receipt);
            change = receipt - amt;

            txtTienThoi.Text = change.ToString();

            if (string.IsNullOrWhiteSpace(txtTienKhachDua.Text))
            {
                txtTienThoi.Text = "";
            }
        }

        // Tạo một biến để kiểm tra xem thông báo đã được hiển thị hay chưa
        private bool savedMessageShown = false;
        // Tạo một sự kiện để thông báo rằng nút btnLuu đã được nhấn
        public event EventHandler LuuButtonClicked;
        public override void btnLuu_Click(object sender, EventArgs e)
        {
            double change;
            double.TryParse(txtTienThoi.Text, out change);

            // Kiểm tra nếu change bé hơn 0, hiển thị thông báo và không thực hiện lưu
            if (change < 0)
            {
                if (!savedMessageShown)
                {
                    MessageBox.Show("Số tiền khách đưa không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    savedMessageShown = true; // Đánh dấu là thông báo đã được hiển thị
                    return; // Ngăn không cho phần code phía dưới thực hiện
                }
            }

            // Kiểm tra nếu txtTienKhachDua để trống, mặc định là đã thanh toán
            if (string.IsNullOrWhiteSpace(txtTienKhachDua.Text) || change >=0)
            {
                string qry = @" Update tblMain set tongcong = @tongcong, danhan = @danhan, thaydoi = @thaydoi, khuyenmai=@khuyenmai,
                            trangthai = N'Đã thanh toán' where MainID = @id";

                Hashtable ht = new Hashtable();
                ht.Add("@id", MainID);
                ht.Add("@tongcong", txtTienCanThanhToan.Text);
                ht.Add("@danhan", txtTienKhachDua.Text);
                ht.Add("@thaydoi", txtTienThoi.Text);
                ht.Add("@khuyenmai", label5.Text);

                if (MainClass.SQl(qry, ht) > 0)
                {
                    if (!savedMessageShown)
                    {
                        MessageBox.Show("Đã thanh toán!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        savedMessageShown = true; // Đánh dấu là thông báo đã được hiển thị

                        //in hóa đơn
                        string qry1 = @"select * from tblMain m inner join chitietban d on d.MainID = m.MainID
                                                        inner join sanpham p on p.IDsanpham = d.sanphamID
                                    where m.MainID = " + MainID + "";
                        SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
                        MainClass.con.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        MainClass.con.Close();

                        frmPrint frm = new frmPrint();
                        rptHoaDon cr = new rptHoaDon();

                        cr.SetDatabaseLogon("sa", "123");
                        cr.SetDataSource(dt);
                        frm.crystalReportViewer1.ReportSource = cr;
                        frm.crystalReportViewer1.Refresh();
                        frm.Show();
                    }
                    this.Close();
                    // Kiểm tra và gọi sự kiện LuuButtonClicked
                    if (LuuButtonClicked != null)
                    {
                        LuuButtonClicked(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            txtTienCanThanhToan.Text = amt.ToString();
            allButtons = new Button[] { btnTienMat, btnMomo, btnZalopay, btnNganHang };
            ptbQR.Visible = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Button[] allButtons;
        private void SetAllButtonsColor(Color color)
        {
            foreach (Button button in allButtons)
            {
                button.BackColor = color;
            }
        }
        Color x = Color.Pink;//đổi màu nút

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            txtTienThoi.Visible = true;
            txtTienKhachDua.Visible = true;
            ptbQR.Visible = false;
            
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnMomo_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            txtTienThoi.Visible = false;
            txtTienKhachDua.Visible = false;
            ptbQR.Visible = true;
            ptbQR.Image = QuanLyNhaHang.Properties.Resources.qrmomo;
            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnZalopay_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            txtTienThoi.Visible = false;
            txtTienKhachDua.Visible = false;
            ptbQR.Visible = true;
            ptbQR.Image = QuanLyNhaHang.Properties.Resources.QRzalopay;

            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }

        private void btnNganHang_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            txtTienThoi.Visible = false;
            txtTienKhachDua.Visible = false;
            ptbQR.Visible = true;
            ptbQR.Image = QuanLyNhaHang.Properties.Resources.QRNH;

            // Đặt màu cho tất cả các nút về màu ban đầu
            SetAllButtonsColor(Color.FromKnownColor(KnownColor.Control));//đổi màu nút

            // Thay đổi màu của nút được click
            Button clickedButton = (Button)sender;//đổi màu nút
            clickedButton.BackColor = x; // Hoặc màu mong muốn khác
        }
    }
}

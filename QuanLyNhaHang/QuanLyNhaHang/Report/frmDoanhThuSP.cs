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

namespace QuanLyNhaHang.Report
{
    public partial class frmDoanhThuSP : Form
    {
        public frmDoanhThuSP()
        {
            InitializeComponent();
        }

        //private void btnXem_Click(object sender, EventArgs e)
        //{
        //    string qry = @"Select * from tblMain m
        //                    inner join chitietban d on m.MainID = d.MainID
        //                    inner join sanpham p on p.IDsanpham = d.sanphamID
        //                    inner join danhmuc c on c.IDdanhmuc = p.IDdm
        //                    where m.ngay between @sdate and @edate";
        //    SqlCommand cmd = new SqlCommand(qry, MainClass.con);
        //    cmd.Parameters.AddWithValue("@sdate", Convert.ToDateTime(dateTimePicker1.Value).Date);
        //    cmd.Parameters.AddWithValue("@edate", Convert.ToDateTime(dateTimePicker2.Value).Date);

        //    MainClass.con.Open();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    MainClass.con.Close();

        //    frmPrint frm = new frmPrint();
        //    rptDoanhThuSP cr = new rptDoanhThuSP();

        //    cr.SetDatabaseLogon("sa", "123");
        //    cr.SetDataSource(dt);
        //    frm.crystalReportViewer1.ReportSource = cr;
        //    frm.crystalReportViewer1.Refresh();
        //    frm.crystalReportViewer1.EnableDrillDown = true;
        //    frm.crystalReportViewer1.DisplayToolbar = true;
        //    frm.Show();
        //}
        private void btnXem_Click(object sender, EventArgs e)
        {
            string qry = @"Select * from tblMain m
                    inner join chitietban d on m.MainID = d.MainID
                    inner join sanpham p on p.IDsanpham = d.sanphamID
                    inner join danhmuc c on c.IDdanhmuc = p.IDdm
                    where m.ngay between @sdate and @edate
                    AND m.trangthai = N'Đã thanh toán';";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@sdate", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@edate", dateTimePicker2.Value.Date);

            MainClass.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            MainClass.con.Close();

            // Kiểm tra dữ liệu trong DataTable
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["ngay"]);
            }

            frmPrint frm = new frmPrint();
            rptDoanhThuSP cr = new rptDoanhThuSP();

            cr.SetDatabaseLogon("sa", "123");
            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.crystalReportViewer1.EnableDrillDown = true;
            frm.crystalReportViewer1.DisplayToolbar = true;
            frm.Show();
        }
    }
}

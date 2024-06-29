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
    public partial class frmThemSanPham : MauThem
    {
        public frmThemSanPham()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int IDdm = 0;

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            //cho đầy cb
            string qry = "Select IDdanhmuc 'id', Tendanhmuc 'name' from danhmuc ";

            MainClass.CBFill(qry, cbDM);

            if (IDdm > 0) // For update
            {
                cbDM.SelectedValue = IDdm;
            }

            if(id>0)
            {
                ForUpdateLoadData();
            }
        }

        string filePath;
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (.jpg, .png)|*.png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtAnh.Image = new Bitmap(filePath);
            }
        }

        public override void btnLuu_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ các mục!");
                return;
            }

            if (id == 0) //Insert
            {
                qry = "Insert into sanpham Values (@Tên, @Giá, @Ảnh, @DM, @tt, @sl)";
            }
            else //Update
            {
                qry = "Update sanpham Set Tensanpham = @Tên, Giasanpham= @Giá, IDdm= @DM," +
                    "Anhsanpham= @Ảnh, trangthai = @tt, soluong=@sl where IDsanpham = @id ";
            }

            //cho ảnh
            Image temp = new Bitmap(txtAnh.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Tên", txtTenDanhMuc.Text);
            ht.Add("@Giá", txtGia.Text);
            ht.Add("@DM", Convert.ToInt32(cbDM.SelectedValue));
            ht.Add("@Ảnh", imageByteArray);
            ht.Add("@tt", cbTrangThai.Text);
            ht.Add("@sl", txtSoLuong.Text);

            if (MainClass.SQl(qry, ht) > 0)
            {
                MessageBox.Show("Lưu thành công!!");
                id = 0;
                IDdm = 0;
                txtTenDanhMuc.Text = "";
                txtGia.Text = "";
                cbDM.SelectedIndex = 0;
                cbDM.SelectedIndex = -1;
                txtAnh.Image = QuanLyNhaHang.Properties.Resources.bowl_and_choptick;
                cbTrangThai.SelectedIndex = -1;

                txtTenDanhMuc.Focus();
            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Select * from sanpham where IDsanpham = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtTenDanhMuc.Text = dt.Rows[0]["Tensanpham"].ToString();
                txtGia.Text = dt.Rows[0]["Giasanpham"].ToString();
                cbTrangThai.Text = dt.Rows[0]["trangthai"].ToString();
                txtSoLuong.Text = dt.Rows[0]["soluong"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["Anhsanpham"]);
                byte[] imageByteArray = imageArray;
                txtAnh.Image = Image.FromStream(new MemoryStream(imageArray));
            }
        }
    }
}

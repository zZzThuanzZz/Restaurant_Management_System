
namespace QuanLyNhaHang
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDieuKhien = new System.Windows.Forms.Panel();
            this.btnCongThuc = new System.Windows.Forms.Button();
            this.btnNguyenLieu = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnAnhQC = new System.Windows.Forms.Button();
            this.btnVAT = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCongThuc);
            this.panel1.Controls.Add(this.btnNguyenLieu);
            this.panel1.Controls.Add(this.btnKhuyenMai);
            this.panel1.Controls.Add(this.btnBaoCao);
            this.panel1.Controls.Add(this.btnAnhQC);
            this.panel1.Controls.Add(this.btnVAT);
            this.panel1.Controls.Add(this.btnNhanVien);
            this.panel1.Controls.Add(this.btnBan);
            this.panel1.Controls.Add(this.btnSanPham);
            this.panel1.Controls.Add(this.btnDanhMuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTaiKhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 1060);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "CÁC DANH MỤC QUẢN LÍ";
            // 
            // pnlDieuKhien
            // 
            this.pnlDieuKhien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDieuKhien.Location = new System.Drawing.Point(286, 0);
            this.pnlDieuKhien.Name = "pnlDieuKhien";
            this.pnlDieuKhien.Size = new System.Drawing.Size(902, 1060);
            this.pnlDieuKhien.TabIndex = 1;
            // 
            // btnCongThuc
            // 
            this.btnCongThuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCongThuc.Image = global::QuanLyNhaHang.Properties.Resources.molecule;
            this.btnCongThuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCongThuc.Location = new System.Drawing.Point(46, 899);
            this.btnCongThuc.Name = "btnCongThuc";
            this.btnCongThuc.Size = new System.Drawing.Size(195, 65);
            this.btnCongThuc.TabIndex = 1;
            this.btnCongThuc.Text = "Công thức";
            this.btnCongThuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCongThuc.UseVisualStyleBackColor = true;
            this.btnCongThuc.Click += new System.EventHandler(this.btnCongThuc_Click);
            // 
            // btnNguyenLieu
            // 
            this.btnNguyenLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNguyenLieu.Image = global::QuanLyNhaHang.Properties.Resources.grocery;
            this.btnNguyenLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguyenLieu.Location = new System.Drawing.Point(46, 828);
            this.btnNguyenLieu.Name = "btnNguyenLieu";
            this.btnNguyenLieu.Size = new System.Drawing.Size(195, 65);
            this.btnNguyenLieu.TabIndex = 1;
            this.btnNguyenLieu.Text = "Nguyên liệu";
            this.btnNguyenLieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNguyenLieu.UseVisualStyleBackColor = true;
            this.btnNguyenLieu.Click += new System.EventHandler(this.btnNguyenLieu_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhuyenMai.Image = global::QuanLyNhaHang.Properties.Resources.discount_tag;
            this.btnKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.Location = new System.Drawing.Point(46, 757);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(195, 65);
            this.btnKhuyenMai.TabIndex = 1;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaoCao.Image = global::QuanLyNhaHang.Properties.Resources.report1;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(46, 686);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(195, 65);
            this.btnBaoCao.TabIndex = 1;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnAnhQC
            // 
            this.btnAnhQC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnhQC.Image = global::QuanLyNhaHang.Properties.Resources.carrousel;
            this.btnAnhQC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnhQC.Location = new System.Drawing.Point(46, 615);
            this.btnAnhQC.Name = "btnAnhQC";
            this.btnAnhQC.Size = new System.Drawing.Size(195, 65);
            this.btnAnhQC.TabIndex = 1;
            this.btnAnhQC.Text = "Ảnh QC";
            this.btnAnhQC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnhQC.UseVisualStyleBackColor = true;
            this.btnAnhQC.Click += new System.EventHandler(this.btnAnhQC_Click);
            // 
            // btnVAT
            // 
            this.btnVAT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVAT.Image = global::QuanLyNhaHang.Properties.Resources.vat11;
            this.btnVAT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVAT.Location = new System.Drawing.Point(46, 544);
            this.btnVAT.Name = "btnVAT";
            this.btnVAT.Size = new System.Drawing.Size(195, 65);
            this.btnVAT.TabIndex = 1;
            this.btnVAT.Text = "VAT";
            this.btnVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVAT.UseVisualStyleBackColor = true;
            this.btnVAT.Click += new System.EventHandler(this.btnVAT_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhanVien.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.Image = global::QuanLyNhaHang.Properties.Resources.staff;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(46, 473);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(195, 65);
            this.btnNhanVien.TabIndex = 5;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnBan
            // 
            this.btnBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBan.Image = global::QuanLyNhaHang.Properties.Resources.table;
            this.btnBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBan.Location = new System.Drawing.Point(46, 402);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(195, 65);
            this.btnBan.TabIndex = 6;
            this.btnBan.Text = "Bàn";
            this.btnBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSanPham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.Image = global::QuanLyNhaHang.Properties.Resources.product_icon;
            this.btnSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.Location = new System.Drawing.Point(46, 331);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(195, 65);
            this.btnSanPham.TabIndex = 7;
            this.btnSanPham.Text = "Sản phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDanhMuc.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDanhMuc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnDanhMuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnDanhMuc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhMuc.Image = global::QuanLyNhaHang.Properties.Resources.List_Icon2;
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.Location = new System.Drawing.Point(46, 260);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(195, 65);
            this.btnDanhMuc.TabIndex = 8;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiKhoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Image = global::QuanLyNhaHang.Properties.Resources.account1;
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(46, 189);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(195, 65);
            this.btnTaiKhoan.TabIndex = 3;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1188, 1060);
            this.Controls.Add(this.pnlDieuKhien);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrangChu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDieuKhien;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnVAT;
        private System.Windows.Forms.Button btnAnhQC;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Button btnCongThuc;
        private System.Windows.Forms.Button btnNguyenLieu;
    }
}
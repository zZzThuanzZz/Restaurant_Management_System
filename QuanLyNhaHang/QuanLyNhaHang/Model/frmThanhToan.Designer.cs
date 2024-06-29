
namespace QuanLyNhaHang.Model
{
    partial class frmThanhToan
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTienCanThanhToan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienThoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNganHang = new System.Windows.Forms.Button();
            this.btnZalopay = new System.Windows.Forms.Button();
            this.btnMomo = new System.Windows.Forms.Button();
            this.btnTienMat = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ptbQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQR)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.Text = "Thanh toán";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhaHang.Properties.Resources.browser;
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnLuu
            // 
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnLuu.FlatAppearance.BorderSize = 3;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnLuu.Location = new System.Drawing.Point(413, 13);
            this.btnLuu.Text = "Thanh toán";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDong.FlatAppearance.BorderSize = 3;
            this.btnDong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.btnDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnDong.Location = new System.Drawing.Point(612, 13);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Size = new System.Drawing.Size(1095, 115);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnThoat, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 619);
            this.panel2.Size = new System.Drawing.Size(1095, 80);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(1027, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(56, 44);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "X";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // txtTienCanThanhToan
            // 
            this.txtTienCanThanhToan.Enabled = false;
            this.txtTienCanThanhToan.Location = new System.Drawing.Point(11, 34);
            this.txtTienCanThanhToan.Name = "txtTienCanThanhToan";
            this.txtTienCanThanhToan.Size = new System.Drawing.Size(345, 35);
            this.txtTienCanThanhToan.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số tiền cần thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tiền thừa";
            this.label3.Visible = false;
            // 
            // txtTienThoi
            // 
            this.txtTienThoi.Enabled = false;
            this.txtTienThoi.Location = new System.Drawing.Point(11, 138);
            this.txtTienThoi.Name = "txtTienThoi";
            this.txtTienThoi.Size = new System.Drawing.Size(345, 35);
            this.txtTienThoi.TabIndex = 12;
            this.txtTienThoi.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tiền khách đưa";
            this.label4.Visible = false;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Location = new System.Drawing.Point(402, 34);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(345, 35);
            this.txtTienKhachDua.TabIndex = 12;
            this.txtTienKhachDua.Visible = false;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNganHang);
            this.panel3.Controls.Add(this.btnZalopay);
            this.panel3.Controls.Add(this.btnMomo);
            this.panel3.Controls.Add(this.btnTienMat);
            this.panel3.Location = new System.Drawing.Point(12, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 307);
            this.panel3.TabIndex = 14;
            // 
            // btnNganHang
            // 
            this.btnNganHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNganHang.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNganHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnNganHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnNganHang.Image = global::QuanLyNhaHang.Properties.Resources.vcb;
            this.btnNganHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNganHang.Location = new System.Drawing.Point(3, 216);
            this.btnNganHang.Name = "btnNganHang";
            this.btnNganHang.Size = new System.Drawing.Size(243, 65);
            this.btnNganHang.TabIndex = 1;
            this.btnNganHang.Text = "Ngân hàng";
            this.btnNganHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNganHang.UseVisualStyleBackColor = true;
            this.btnNganHang.Click += new System.EventHandler(this.btnNganHang_Click);
            // 
            // btnZalopay
            // 
            this.btnZalopay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZalopay.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnZalopay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnZalopay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnZalopay.Image = global::QuanLyNhaHang.Properties.Resources.zalopay;
            this.btnZalopay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZalopay.Location = new System.Drawing.Point(3, 145);
            this.btnZalopay.Name = "btnZalopay";
            this.btnZalopay.Size = new System.Drawing.Size(243, 65);
            this.btnZalopay.TabIndex = 1;
            this.btnZalopay.Text = "Zalo Pay";
            this.btnZalopay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZalopay.UseVisualStyleBackColor = true;
            this.btnZalopay.Click += new System.EventHandler(this.btnZalopay_Click);
            // 
            // btnMomo
            // 
            this.btnMomo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMomo.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnMomo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnMomo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMomo.Image = global::QuanLyNhaHang.Properties.Resources.MoMo_Logo;
            this.btnMomo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMomo.Location = new System.Drawing.Point(3, 74);
            this.btnMomo.Name = "btnMomo";
            this.btnMomo.Size = new System.Drawing.Size(243, 65);
            this.btnMomo.TabIndex = 1;
            this.btnMomo.Text = "Momo";
            this.btnMomo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMomo.UseVisualStyleBackColor = true;
            this.btnMomo.Click += new System.EventHandler(this.btnMomo_Click);
            // 
            // btnTienMat
            // 
            this.btnTienMat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTienMat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnTienMat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnTienMat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnTienMat.Image = global::QuanLyNhaHang.Properties.Resources.money1;
            this.btnTienMat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTienMat.Location = new System.Drawing.Point(3, 3);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(243, 65);
            this.btnTienMat.TabIndex = 1;
            this.btnTienMat.Text = "Tiền mặt";
            this.btnTienMat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTienMat.UseVisualStyleBackColor = true;
            this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.ptbQR);
            this.panel4.Controls.Add(this.txtTienKhachDua);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtTienCanThanhToan);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtTienThoi);
            this.panel4.Location = new System.Drawing.Point(279, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 492);
            this.panel4.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // ptbQR
            // 
            this.ptbQR.Image = global::QuanLyNhaHang.Properties.Resources.QRzalopay;
            this.ptbQR.Location = new System.Drawing.Point(231, 95);
            this.ptbQR.Name = "ptbQR";
            this.ptbQR.Size = new System.Drawing.Size(361, 384);
            this.ptbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbQR.TabIndex = 14;
            this.ptbQR.TabStop = false;
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 699);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "frmThanhToan";
            this.Text = "frmThanhToan";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.TextBox txtTienCanThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTienThoi;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNganHang;
        private System.Windows.Forms.Button btnZalopay;
        private System.Windows.Forms.Button btnMomo;
        private System.Windows.Forms.Button btnTienMat;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox ptbQR;
        public System.Windows.Forms.Label label5;
    }
}
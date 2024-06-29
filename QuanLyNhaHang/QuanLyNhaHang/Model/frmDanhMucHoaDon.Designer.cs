
namespace QuanLyNhaHang.Model
{
    partial class frmDanhMucHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvSoThuTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSua = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvXoa = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(216, 29);
            this.label1.Text = "Danh mục hóa đơn";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhaHang.Properties.Resources.bill;
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnLuu
            // 
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnLuu.FlatAppearance.BorderSize = 3;
            this.btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDong.FlatAppearance.BorderSize = 3;
            this.btnDong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Pink;
            this.btnDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Size = new System.Drawing.Size(948, 115);
            this.panel1.Controls.SetChildIndex(this.pictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnThoat, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 741);
            this.panel2.Size = new System.Drawing.Size(948, 10);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Location = new System.Drawing.Point(880, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(56, 44);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "X";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSoThuTu,
            this.dgvID,
            this.dgvNgay,
            this.dgvBan,
            this.dgvPhucVu,
            this.dgvHinhThuc,
            this.dgvTrangThai,
            this.dgvTongCong,
            this.dgvSua,
            this.dgvXoa});
            this.dataGridView1.Location = new System.Drawing.Point(40, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 436);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 29);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(150, 141);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(288, 34);
            this.txtTimKiem.TabIndex = 9;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // button1
            // 
            this.button1.Image = global::QuanLyNhaHang.Properties.Resources.reload2;
            this.button1.Location = new System.Drawing.Point(444, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "\r\n      ⟳\r\n     ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvSoThuTu
            // 
            this.dgvSoThuTu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSoThuTu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoThuTu.FillWeight = 70F;
            this.dgvSoThuTu.HeaderText = "STT";
            this.dgvSoThuTu.MinimumWidth = 70;
            this.dgvSoThuTu.Name = "dgvSoThuTu";
            this.dgvSoThuTu.ReadOnly = true;
            this.dgvSoThuTu.Width = 70;
            // 
            // dgvID
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvID.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvID.HeaderText = "id";
            this.dgvID.MinimumWidth = 6;
            this.dgvID.Name = "dgvID";
            this.dgvID.ReadOnly = true;
            // 
            // dgvNgay
            // 
            this.dgvNgay.HeaderText = "Ngày";
            this.dgvNgay.MinimumWidth = 6;
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            // 
            // dgvBan
            // 
            this.dgvBan.HeaderText = "Bàn";
            this.dgvBan.MinimumWidth = 6;
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.ReadOnly = true;
            // 
            // dgvPhucVu
            // 
            this.dgvPhucVu.HeaderText = "Phục vụ";
            this.dgvPhucVu.MinimumWidth = 6;
            this.dgvPhucVu.Name = "dgvPhucVu";
            this.dgvPhucVu.ReadOnly = true;
            // 
            // dgvHinhThuc
            // 
            this.dgvHinhThuc.HeaderText = "Hình thức";
            this.dgvHinhThuc.MinimumWidth = 6;
            this.dgvHinhThuc.Name = "dgvHinhThuc";
            this.dgvHinhThuc.ReadOnly = true;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.MinimumWidth = 6;
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            // 
            // dgvTongCong
            // 
            this.dgvTongCong.HeaderText = "Tổng cộng";
            this.dgvTongCong.MinimumWidth = 6;
            this.dgvTongCong.Name = "dgvTongCong";
            this.dgvTongCong.ReadOnly = true;
            this.dgvTongCong.Visible = false;
            // 
            // dgvSua
            // 
            this.dgvSua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvSua.FillWeight = 50F;
            this.dgvSua.HeaderText = "";
            this.dgvSua.Image = global::QuanLyNhaHang.Properties.Resources.pencil;
            this.dgvSua.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvSua.MinimumWidth = 50;
            this.dgvSua.Name = "dgvSua";
            this.dgvSua.ReadOnly = true;
            this.dgvSua.Width = 50;
            // 
            // dgvXoa
            // 
            this.dgvXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvXoa.FillWeight = 50F;
            this.dgvXoa.HeaderText = "";
            this.dgvXoa.Image = global::QuanLyNhaHang.Properties.Resources.eye1;
            this.dgvXoa.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvXoa.MinimumWidth = 50;
            this.dgvXoa.Name = "dgvXoa";
            this.dgvXoa.ReadOnly = true;
            this.dgvXoa.Width = 50;
            // 
            // frmDanhMucHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 751);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmDanhMucHoaDon";
            this.Text = "frmDanhMucHoaDon";
            this.Load += new System.EventHandler(this.frmDanhMucHoaDon_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.txtTimKiem, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtTimKiem;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSoThuTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHinhThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTongCong;
        private System.Windows.Forms.DataGridViewImageColumn dgvSua;
        private System.Windows.Forms.DataGridViewImageColumn dgvXoa;
    }
}
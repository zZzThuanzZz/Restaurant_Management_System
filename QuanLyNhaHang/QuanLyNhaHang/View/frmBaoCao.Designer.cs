
namespace QuanLyNhaHang.View
{
    partial class frmBaoCao
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoanhThuSP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doanh thu theo thời gian:";
            // 
            // btnDoanhThuSP
            // 
            this.btnDoanhThuSP.Image = global::QuanLyNhaHang.Properties.Resources.preview2;
            this.btnDoanhThuSP.Location = new System.Drawing.Point(310, 12);
            this.btnDoanhThuSP.Name = "btnDoanhThuSP";
            this.btnDoanhThuSP.Size = new System.Drawing.Size(61, 58);
            this.btnDoanhThuSP.TabIndex = 2;
            this.btnDoanhThuSP.UseVisualStyleBackColor = true;
            this.btnDoanhThuSP.Click += new System.EventHandler(this.btnDoanhThuSP_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDoanhThuSP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDoanhThuSP;
    }
}
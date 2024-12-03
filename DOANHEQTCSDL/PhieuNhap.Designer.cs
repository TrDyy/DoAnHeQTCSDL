namespace DOANHEQTCSDL
{
    partial class PhieuNhap
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
            this.dgv_phieuNhap = new System.Windows.Forms.DataGridView();
            this.dgv_chiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.btnThemPN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chiTietPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_phieuNhap
            // 
            this.dgv_phieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_phieuNhap.Location = new System.Drawing.Point(18, 18);
            this.dgv_phieuNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_phieuNhap.Name = "dgv_phieuNhap";
            this.dgv_phieuNhap.Size = new System.Drawing.Size(375, 385);
            this.dgv_phieuNhap.TabIndex = 0;
            // 
            // dgv_chiTietPhieuNhap
            // 
            this.dgv_chiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chiTietPhieuNhap.Location = new System.Drawing.Point(434, 18);
            this.dgv_chiTietPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_chiTietPhieuNhap.Name = "dgv_chiTietPhieuNhap";
            this.dgv_chiTietPhieuNhap.Size = new System.Drawing.Size(375, 385);
            this.dgv_chiTietPhieuNhap.TabIndex = 1;
            // 
            // btnThemPN
            // 
            this.btnThemPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPN.Location = new System.Drawing.Point(509, 415);
            this.btnThemPN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThemPN.Name = "btnThemPN";
            this.btnThemPN.Size = new System.Drawing.Size(217, 52);
            this.btnThemPN.TabIndex = 2;
            this.btnThemPN.Text = "Thêm phiếu nhập";
            this.btnThemPN.UseVisualStyleBackColor = true;
            this.btnThemPN.Click += new System.EventHandler(this.btnThemPN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 431);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tổng tiền";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(158, 426);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(148, 26);
            this.txtTongTien.TabIndex = 5;
            // 
            // PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 489);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThemPN);
            this.Controls.Add(this.dgv_chiTietPhieuNhap);
            this.Controls.Add(this.dgv_phieuNhap);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.PhieuNhap_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_phieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chiTietPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_phieuNhap;
        private System.Windows.Forms.DataGridView dgv_chiTietPhieuNhap;
        private System.Windows.Forms.Button btnThemPN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}
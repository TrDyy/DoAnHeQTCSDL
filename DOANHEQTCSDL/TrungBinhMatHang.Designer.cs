namespace DOANHEQTCSDL
{
    partial class TrungBinhMatHang
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
            this.cbo_loaisp = new System.Windows.Forms.ComboBox();
            this.lb_giatb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá trung bình theo loại";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_loaisp
            // 
            this.cbo_loaisp.FormattingEnabled = true;
            this.cbo_loaisp.Location = new System.Drawing.Point(12, 69);
            this.cbo_loaisp.Name = "cbo_loaisp";
            this.cbo_loaisp.Size = new System.Drawing.Size(219, 29);
            this.cbo_loaisp.TabIndex = 3;
            this.cbo_loaisp.SelectedValueChanged += new System.EventHandler(this.cbo_loaisp_SelectedValueChanged);
            // 
            // lb_giatb
            // 
            this.lb_giatb.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_giatb.Location = new System.Drawing.Point(253, 69);
            this.lb_giatb.Name = "lb_giatb";
            this.lb_giatb.Size = new System.Drawing.Size(213, 29);
            this.lb_giatb.TabIndex = 4;
            this.lb_giatb.Text = "0";
            this.lb_giatb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrungBinhMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 127);
            this.Controls.Add(this.lb_giatb);
            this.Controls.Add(this.cbo_loaisp);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrungBinhMatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trung Bình Giá";
            this.Load += new System.EventHandler(this.TrungBinhMatHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_loaisp;
        private System.Windows.Forms.Label lb_giatb;
    }
}
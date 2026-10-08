namespace QuanLyKhoHang.QuanLyPhieuNhap
{
	partial class fChiTietPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChiTietPhieuNhap));
            this.gcChiTiet = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbKho = new System.Windows.Forms.Label();
            this.lbMa = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbTotal = new System.Windows.Forms.Label();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lbNgayNhap = new System.Windows.Forms.Label();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lbNV = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbNCC = new System.Windows.Forms.Label();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcChiTiet
            // 
            this.gcChiTiet.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gcChiTiet.Location = new System.Drawing.Point(15, 189);
            this.gcChiTiet.MainView = this.gridView1;
            this.gcChiTiet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcChiTiet.Name = "gcChiTiet";
            this.gcChiTiet.Size = new System.Drawing.Size(1064, 457);
            this.gcChiTiet.TabIndex = 0;
            this.gcChiTiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gcChiTiet;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // lbKho
            // 
            this.lbKho.AutoSize = true;
            this.lbKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbKho.Location = new System.Drawing.Point(170, 52);
            this.lbKho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKho.Name = "lbKho";
            this.lbKho.Size = new System.Drawing.Size(50, 20);
            this.lbKho.TabIndex = 3;
            this.lbKho.Text = "label1";
            // 
            // lbMa
            // 
            this.lbMa.AutoSize = true;
            this.lbMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbMa.Location = new System.Drawing.Point(170, 15);
            this.lbMa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMa.Name = "lbMa";
            this.lbMa.Size = new System.Drawing.Size(50, 20);
            this.lbMa.TabIndex = 2;
            this.lbMa.Text = "label1";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(66, 52);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Kho:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(66, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã phiếu nhập:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.lbTotal);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lbNgayNhap);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.lbNV);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.lbNCC);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lbKho);
            this.panelControl1.Controls.Add(this.lbMa);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(14, 7);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1064, 174);
            this.panelControl1.TabIndex = 2;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbTotal.Location = new System.Drawing.Point(898, 52);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(50, 20);
            this.lbTotal.TabIndex = 11;
            this.lbTotal.Text = "label1";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(760, 52);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(136, 20);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Tổng số lượng nhập:";
            // 
            // lbNgayNhap
            // 
            this.lbNgayNhap.AutoSize = true;
            this.lbNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbNgayNhap.Location = new System.Drawing.Point(898, 15);
            this.lbNgayNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNgayNhap.Name = "lbNgayNhap";
            this.lbNgayNhap.Size = new System.Drawing.Size(50, 20);
            this.lbNgayNhap.TabIndex = 9;
            this.lbNgayNhap.Text = "label1";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(760, 15);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 20);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Ngày nhập:";
            // 
            // lbNV
            // 
            this.lbNV.AutoSize = true;
            this.lbNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbNV.Location = new System.Drawing.Point(477, 52);
            this.lbNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNV.Name = "lbNV";
            this.lbNV.Size = new System.Drawing.Size(50, 20);
            this.lbNV.TabIndex = 7;
            this.lbNV.Text = "label1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(380, 52);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(94, 20);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Nhân viên lập:";
            // 
            // lbNCC
            // 
            this.lbNCC.AutoSize = true;
            this.lbNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbNCC.Location = new System.Drawing.Point(477, 15);
            this.lbNCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNCC.Name = "lbNCC";
            this.lbNCC.Size = new System.Drawing.Size(50, 20);
            this.lbNCC.TabIndex = 5;
            this.lbNCC.Text = "label1";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(380, 15);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Nhà cung cấp:";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(902, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(127, 60);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Xuất phiếu";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // fChiTietPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 659);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcChiTiet);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fChiTietPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phiếu nhập";
            this.Load += new System.EventHandler(this.fChiTietChaoGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcChiTiet;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.Label lbKho;
		private System.Windows.Forms.Label lbMa;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lbNCC;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Label lbNgayNhap;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label lbNV;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label lbTotal;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}
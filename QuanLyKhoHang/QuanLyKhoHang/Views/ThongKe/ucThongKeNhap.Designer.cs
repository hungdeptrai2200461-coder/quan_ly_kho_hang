namespace QuanLyKhoHang.ThongKe
{
    partial class ucThongKeNhap
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbbNCC = new System.Windows.Forms.ComboBox();
            this.cbbKho = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbSoPhieu = new DevExpress.XtraEditors.LabelControl();
            this.grControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbNCC
            // 
            this.cbbNCC.FormattingEnabled = true;
            this.cbbNCC.Location = new System.Drawing.Point(695, 197);
            this.cbbNCC.Name = "cbbNCC";
            this.cbbNCC.Size = new System.Drawing.Size(196, 25);
            this.cbbNCC.TabIndex = 47;
            this.cbbNCC.SelectedIndexChanged += new System.EventHandler(this.cbbNCC_SelectedIndexChanged);
            // 
            // cbbKho
            // 
            this.cbbKho.FormattingEnabled = true;
            this.cbbKho.Location = new System.Drawing.Point(695, 151);
            this.cbbKho.Name = "cbbKho";
            this.cbbKho.Size = new System.Drawing.Size(163, 25);
            this.cbbKho.TabIndex = 46;
            this.cbbKho.SelectedIndexChanged += new System.EventHandler(this.cbbKho_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(578, 202);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 17);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "Nhà cung cấp";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(579, 159);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 17);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "Kho hàng";
            // 
            // lbTotal
            // 
            this.lbTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Appearance.Options.UseFont = true;
            this.lbTotal.Location = new System.Drawing.Point(695, 101);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(10, 18);
            this.lbTotal.TabIndex = 41;
            this.lbTotal.Text = "0";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(546, 101);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(129, 17);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "Tổng số lượng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(298, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(546, 45);
            this.label3.TabIndex = 39;
            this.label3.Text = "THỐNG KÊ NHẬP HÀNG HÓA";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(270, 159);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 17);
            this.labelControl5.TabIndex = 48;
            this.labelControl5.Text = "Ngày bắt đầu";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(380, 153);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(138, 23);
            this.dtpStart.TabIndex = 49;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(380, 197);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(138, 23);
            this.dtpEnd.TabIndex = 51;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(270, 203);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(87, 17);
            this.labelControl6.TabIndex = 50;
            this.labelControl6.Text = "Ngày kết thúc";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(360, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 17);
            this.labelControl4.TabIndex = 52;
            this.labelControl4.Text = "Tổng số phiếu:";
            // 
            // lbSoPhieu
            // 
            this.lbSoPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoPhieu.Appearance.Options.UseFont = true;
            this.lbSoPhieu.Location = new System.Drawing.Point(472, 101);
            this.lbSoPhieu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbSoPhieu.Name = "lbSoPhieu";
            this.lbSoPhieu.Size = new System.Drawing.Size(10, 18);
            this.lbSoPhieu.TabIndex = 53;
            this.lbSoPhieu.Text = "0";
            // 
            // grControl
            // 
            this.grControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grControl.Location = new System.Drawing.Point(0, 240);
            this.grControl.MainView = this.gridView1;
            this.grControl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grControl.Name = "grControl";
            this.grControl.Size = new System.Drawing.Size(1211, 652);
            this.grControl.TabIndex = 54;
            this.grControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 371;
            this.gridView1.GridControl = this.grControl;
            this.gridView1.Name = "gridView1";
            // 
            // ucThongKeNhap
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grControl);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbSoPhieu);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cbbNCC);
            this.Controls.Add(this.cbbKho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbTotal);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "ucThongKeNhap";
            this.Size = new System.Drawing.Size(1216, 895);
            ((System.ComponentModel.ISupportInitialize)(this.grControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbNCC;
        private System.Windows.Forms.ComboBox cbbKho;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbTotal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lbSoPhieu;
        private DevExpress.XtraGrid.GridControl grControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}

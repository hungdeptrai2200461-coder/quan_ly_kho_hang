namespace QuanLyKhoHang.ThongKe
{
    partial class ucThongKeHangHoa
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grControl = new DevExpress.XtraGrid.GridControl();
            this.label3 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbHH = new DevExpress.XtraEditors.LabelControl();
            this.lbTon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbbKho = new System.Windows.Forms.ComboBox();
            this.cbbKe = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 371;
            this.gridView1.GridControl = this.grControl;
            this.gridView1.Name = "gridView1";
            // 
            // grControl
            // 
            this.grControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grControl.Location = new System.Drawing.Point(0, 203);
            this.grControl.MainView = this.gridView1;
            this.grControl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grControl.Name = "grControl";
            this.grControl.Size = new System.Drawing.Size(1211, 774);
            this.grControl.TabIndex = 11;
            this.grControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(372, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 45);
            this.label3.TabIndex = 17;
            this.label3.Text = "THỐNG KÊ HÀNG HÓA";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(365, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 17);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Tổng số hàng hóa:";
            // 
            // lbHH
            // 
            this.lbHH.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHH.Appearance.Options.UseFont = true;
            this.lbHH.Location = new System.Drawing.Point(517, 77);
            this.lbHH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbHH.Name = "lbHH";
            this.lbHH.Size = new System.Drawing.Size(8, 17);
            this.lbHH.TabIndex = 19;
            this.lbHH.Text = "0";
            // 
            // lbTon
            // 
            this.lbTon.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTon.Appearance.Options.UseFont = true;
            this.lbTon.Location = new System.Drawing.Point(788, 77);
            this.lbTon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbTon.Name = "lbTon";
            this.lbTon.Size = new System.Drawing.Size(8, 17);
            this.lbTon.TabIndex = 21;
            this.lbTon.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(642, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(119, 17);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Tổng số lượng tồn:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(244, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 17);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Kho hàng";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(630, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 17);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Kệ hàng";
            // 
            // cbbKho
            // 
            this.cbbKho.FormattingEnabled = true;
            this.cbbKho.Location = new System.Drawing.Point(326, 130);
            this.cbbKho.Name = "cbbKho";
            this.cbbKho.Size = new System.Drawing.Size(217, 25);
            this.cbbKho.TabIndex = 26;
            this.cbbKho.SelectedIndexChanged += new System.EventHandler(this.cbbKho_SelectedIndexChanged);
            // 
            // cbbKe
            // 
            this.cbbKe.FormattingEnabled = true;
            this.cbbKe.Location = new System.Drawing.Point(711, 130);
            this.cbbKe.Name = "cbbKe";
            this.cbbKe.Size = new System.Drawing.Size(219, 25);
            this.cbbKe.TabIndex = 27;
            this.cbbKe.SelectedIndexChanged += new System.EventHandler(this.cbbKe_SelectedIndexChanged);
            // 
            // ucThongKeHangHoa
            // 
            this.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbKe);
            this.Controls.Add(this.cbbKho);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbTon);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbHH);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grControl);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "ucThongKeHangHoa";
            this.Size = new System.Drawing.Size(1216, 977);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grControl;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbHH;
        private DevExpress.XtraEditors.LabelControl lbTon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox cbbKho;
        private System.Windows.Forms.ComboBox cbbKe;
    }
}

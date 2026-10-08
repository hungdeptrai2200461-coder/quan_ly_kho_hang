namespace QuanLyKhoHang.QuanLyPhieuXuat
{
    partial class ucPhieuXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhieuXuat));
            this.gcChaoGia = new DevExpress.XtraGrid.GridControl();
            this.gvChaoGia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rbcChaogia = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDuyet = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.cbbDuyetTT = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnChiTiet = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gcChaoGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChaoGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbcChaogia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcChaoGia
            // 
            this.gcChaoGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChaoGia.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcChaoGia.Location = new System.Drawing.Point(0, 154);
            this.gcChaoGia.MainView = this.gvChaoGia;
            this.gcChaoGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcChaoGia.MenuManager = this.rbcChaogia;
            this.gcChaoGia.Name = "gcChaoGia";
            this.gcChaoGia.Size = new System.Drawing.Size(1014, 584);
            this.gcChaoGia.TabIndex = 2;
            this.gcChaoGia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChaoGia});
            // 
            // gvChaoGia
            // 
            this.gvChaoGia.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvChaoGia.DetailHeight = 431;
            this.gvChaoGia.GridControl = this.gcChaoGia;
            this.gvChaoGia.Name = "gvChaoGia";
            this.gvChaoGia.OptionsBehavior.Editable = false;
            this.gvChaoGia.OptionsBehavior.ReadOnly = true;
            // 
            // rbcChaogia
            // 
            this.rbcChaogia.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            this.rbcChaogia.ExpandCollapseItem.Id = 0;
            this.rbcChaogia.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcChaogia.ExpandCollapseItem,
            this.rbcChaogia.SearchEditItem,
            this.btnDuyet,
            this.bsiRecordsCount,
            this.btnThem,
            this.btnLamMoi,
            this.cbbDuyetTT,
            this.btnChiTiet});
            this.rbcChaogia.Location = new System.Drawing.Point(0, 0);
            this.rbcChaogia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbcChaogia.MaxItemId = 23;
            this.rbcChaogia.Name = "rbcChaogia";
            this.rbcChaogia.OptionsMenuMinWidth = 385;
            this.rbcChaogia.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.rbcChaogia.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rbcChaogia.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchControl1,
            this.repositoryItemImageComboBox1});
            this.rbcChaogia.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.rbcChaogia.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rbcChaogia.Size = new System.Drawing.Size(1014, 154);
            this.rbcChaogia.StatusBar = this.ribbonStatusBar;
            this.rbcChaogia.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Caption = "Duyệt";
            this.btnDuyet.Id = 14;
            this.btnDuyet.ImageOptions.ImageUri.Uri = "Preview";
            this.btnDuyet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDuyet.ImageOptions.SvgImage")));
            this.btnDuyet.Name = "btnDuyet";
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 16;
            this.btnThem.ImageOptions.ImageUri.Uri = "New";
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm mới";
            this.btnLamMoi.Id = 19;
            this.btnLamMoi.ImageOptions.ImageUri.Uri = "Refresh";
            this.btnLamMoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLamMoi.ImageOptions.SvgImage")));
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick);
            // 
            // cbbDuyetTT
            // 
            this.cbbDuyetTT.Caption = "Duyệt";
            this.cbbDuyetTT.Edit = this.repositoryItemImageComboBox1;
            this.cbbDuyetTT.Id = 21;
            this.cbbDuyetTT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cbbDuyetTT.ImageOptions.SvgImage")));
            this.cbbDuyetTT.Name = "cbbDuyetTT";
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Caption = "Chi tiết";
            this.btnChiTiet.Id = 22;
            this.btnChiTiet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTiet.ImageOptions.Image")));
            this.btnChiTiet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChiTiet.ImageOptions.LargeImage")));
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiTiet_ItemClick);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ribbonPage1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPage1.ImageOptions.SvgImage")));
            this.ribbonPage1.ImageOptions.SvgImageSize = new System.Drawing.Size(-2, 0);
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Phiếu xuât";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThem);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLamMoi);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Nhiệm Vụ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChiTiet);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Chi tiết";
            // 
            // repositoryItemSearchControl1
            // 
            this.repositoryItemSearchControl1.AutoHeight = false;
            this.repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 705);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.rbcChaogia;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1014, 33);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Duyệt";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Duyệt";
            // 
            // ucPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gcChaoGia);
            this.Controls.Add(this.rbcChaogia);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucPhieuXuat";
            this.Size = new System.Drawing.Size(1014, 738);
            this.Load += new System.EventHandler(this.ucchaogia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcChaoGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChaoGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbcChaogia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcChaoGia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChaoGia;
        private DevExpress.XtraBars.Ribbon.RibbonControl rbcChaogia;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnDuyet;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem cbbDuyetTT;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraBars.BarButtonItem btnChiTiet;
    }
}

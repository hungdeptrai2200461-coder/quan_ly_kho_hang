using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace QuanLyKhoHang.QuanLyPhieuXuat
{
    public partial class fChiTietPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        public string maPhieu { get; set; }
        private List<ChiTietXuat> listChiTiet;
        public static string TypeForm = "";
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        private PhieuXuat phieuXuat;
        public fChiTietPhieuXuat()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
        private void LoadForm()
        {
            phieuXuat = _context.PhieuXuat
                .Include(x => x.NhanVien)
                .Include(x => x.KhoHang)
                .Include(x => x.ChiTietXuat)
                .Include("ChiTietXuat.HangHoa")
                .SingleOrDefault(x => x.MaPhieuXuat.Equals(maPhieu));
            if (phieuXuat == null)
                return;

            lbMa.Text = maPhieu;
            lbKho.Text = phieuXuat.KhoHang.TenKho;
            lbNV.Text = phieuXuat.NhanVien.TenNhanVien + " - " + phieuXuat.MaNhanVien;
            lbNgayXuat.Text = phieuXuat.NgayXuat.ToString();
            lbTotal.Text = phieuXuat.ChiTietXuat.Sum(x => x.SoLuong).ToString();

            listChiTiet = phieuXuat.ChiTietXuat.ToList();
            LoadDataTable();
        }

        private void CustomizeGridControl()
        {
            var gridView = gcChiTiet.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns["MaHangHoa"].Caption = "Mã hàng hóa";
                gridView.Columns["TenHangHoa"].Caption = "Tên hàng hóa";
                gridView.Columns["SoLuong"].Caption = "Số lượng xuất";
                gridView.Columns["DonViTinh"].Caption = "Đơn vị tính";
            }
        }

        private void LoadDataTable()
        {
            gcChiTiet.DataSource = listChiTiet.Select(x => new
            {
                MaHangHoa = x.MaHangHoa,
                TenHangHoa = x.HangHoa.TenHangHoa,
                SoLuong = x.SoLuong,
                DonViTinh = x.HangHoa.DonViTinh
            }).ToList();

            CustomizeGridControl();
        }

        private void fChiTietChaoGia_Load(object sender, System.EventArgs e)
        {
            LoadForm();
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps);

            // Gắn GridControl vào printable link
            link.Component = gcChiTiet;

            // Tùy chỉnh khổ giấy, hướng in
            link.PaperKind = PaperKind.A4;
            link.Landscape = false; // Dọc
            link.Margins = new Margins(50, 50, 150, 50);

            // Tạo tiêu đề / thông tin phiếu xuất
            link.CreateReportHeaderArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;

                // Tiêu đề lớn
                g.StringFormat = new BrickStringFormat(StringAlignment.Center);
                g.Font = new Font("Tahoma", 16, FontStyle.Bold);
                g.DrawString("PHIẾU XUẤT KHO", Color.Black,
                    new RectangleF(0, 0, pageWidth, 30), BorderSide.None);

                g.Font = new Font("Tahoma", 10);
                g.StringFormat = new BrickStringFormat(StringAlignment.Near);

                float top = 50;

                // Các thông tin phiếu
                g.DrawString($"Mã phiếu xuất: {lbMa.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);

                g.DrawString($"Nhân viên lập: {lbNV.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 20), BorderSide.None);

                top += 30;
                g.DrawString($"Kho: {lbKho.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);

                g.DrawString($"Ngày xuất: {lbNgayXuat.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 20), BorderSide.None);

                top += 30;
                g.DrawString($"Tổng số lượng xuất: {lbTotal.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);
            };

            // (Tuỳ chọn) Footer
            link.CreateReportFooterArea += (s, ev) =>
            {
                ev.Graph.Font = new Font("Tahoma", 9, FontStyle.Italic);
                ev.Graph.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}",
                    Color.Gray, new RectangleF(0, 0, ev.Graph.ClientPageSize.Width, 20),
                    BorderSide.None);
            };

            // Tạo tài liệu và hiển thị preview
            link.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }
    }
}
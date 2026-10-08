using DevExpress.XtraPrinting;
using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace QuanLyKhoHang.QuanLyPhieuNhap
{
    public partial class fChiTietPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public string maPhieu { get; set; }
        private List<ChiTietNhap> listChiTiet;
        public static string TypeForm = "";
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        private PhieuNhap phieuNhap;
        public fChiTietPhieuNhap()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
        private void LoadForm()
        {
            phieuNhap = _context.PhieuNhap
                .Include(x => x.NhanVien)
                .Include(x => x.KhoHang)
                .Include(x => x.NhaCungCap)
                .Include(x => x.ChiTietNhap)
                .Include("ChiTietNhap.HangHoa")
                .SingleOrDefault(x => x.MaPhieuNhap.Equals(maPhieu));
            if (phieuNhap == null)
                return;

            lbMa.Text = maPhieu;
            lbKho.Text = phieuNhap.KhoHang.TenKho;
            lbNCC.Text = phieuNhap.NhaCungCap.TenNhaCungCap + " - " + phieuNhap.MaNhaCungCap;
            lbNV.Text = phieuNhap.NhanVien.TenNhanVien + " - " + phieuNhap.MaNhanVien;
            lbNgayNhap.Text = phieuNhap.NgayNhap.ToString();
            lbTotal.Text = phieuNhap.ChiTietNhap.Sum(x => x.SoLuong).ToString();

            listChiTiet = phieuNhap.ChiTietNhap.ToList();
            LoadDataTable();
        }

        private void CustomizeGridControl()
        {
            var gridView = gcChiTiet.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns["MaHangHoa"].Caption = "Mã hàng hóa";
                gridView.Columns["TenHangHoa"].Caption = "Tên hàng hóa";
                gridView.Columns["SoLuong"].Caption = "Số lượng nhập";
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

            // Tạo tiêu đề / thông tin phiếu nhập
            link.CreateReportHeaderArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;

                // Tiêu đề lớn
                g.StringFormat = new BrickStringFormat(StringAlignment.Center);
                g.Font = new Font("Tahoma", 16, FontStyle.Bold);
                g.DrawString("PHIẾU NHẬP HÀNG", Color.Black,
                    new RectangleF(0, 0, pageWidth, 30), BorderSide.None);

                g.Font = new Font("Tahoma", 10);
                g.StringFormat = new BrickStringFormat(StringAlignment.Near);

                float top = 50;

                // Các thông tin phiếu
                g.DrawString($"Mã phiếu nhập: {lbMa.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);

                g.DrawString($"Nhân viên lập: {lbNV.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 20), BorderSide.None);

                top += 30;
                g.DrawString($"Kho: {lbKho.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);

                g.DrawString($"Ngày nhập: {lbNgayNhap.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 20), BorderSide.None);

                top += 30;
                g.DrawString($"Tổng số lượng nhập: {lbTotal.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 20), BorderSide.None);

                g.DrawString($"Nhà cung cấp: {lbNCC.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 20), BorderSide.None);
                top += 30;
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
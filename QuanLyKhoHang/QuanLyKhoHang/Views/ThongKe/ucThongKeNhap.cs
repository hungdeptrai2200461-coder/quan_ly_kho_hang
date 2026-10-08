using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using QuanLyKhoHang.Entities;
using QuanLyKhoHang.Views.ThongKe;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;

namespace QuanLyKhoHang.ThongKe
{
    public partial class ucThongKeNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public static string maKho;
        public static string maNCC;
        private readonly QuanLyKhoEntities _context;
        public ucThongKeNhap()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
            LoadForm();
        }

        private void LoadKhoHang()
        {
            var khoList = _context.KhoHang.ToList();

            cbbKho.DataSource = khoList;
            cbbKho.DisplayMember = "TenKho"; // Hiển thị tên kho
            cbbKho.ValueMember = "MaKho";    // Giá trị thực tế
        }

        private void LoadNhaCungCap()
        {
            var suppliers = _context.NhaCungCap.ToList();
            suppliers.Insert(0, new NhaCungCap
            {
                MaNhaCungCap = "all",
                TenNhaCungCap = "Tất cả"
            });

            cbbNCC.DisplayMember = "TenNhaCungCap";
            cbbNCC.ValueMember = "MaNhaCungCap";
            cbbNCC.DataSource = suppliers;
        }

        private void LoadForm()
        {
            LoadKhoHang();
            LoadNhaCungCap();
            dtpStart.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            string maKho = cbbKho.SelectedValue.ToString();
            string maNCC = cbbNCC.SelectedValue != null ? cbbNCC.SelectedValue.ToString() : "all";
            var query = _context.PhieuNhap
                .Include(x => x.NhanVien)
                .Include(x => x.NhaCungCap)
                .Include(x => x.KhoHang)
                .Include(x => x.ChiTietNhap)
                .Where(x => x.NgayNhap >= dtpStart.Value && x.NgayNhap <= dtpEnd.Value)
                .Select(x => new
                {
                    MaPhieu = x.MaPhieuNhap,
                    KhoHang = x.KhoHang.TenKho,
                    NhaCC = x.NhaCungCap.TenNhaCungCap,
                    NhanVien = x.NhanVien.TenNhanVien,
                    SoLuong = x.ChiTietNhap.Sum(s => s.SoLuong),
                    NgayNhap = x.NgayNhap,
                    MaKho = x.KhoHang.MaKho,
                    MaNCC = x.MaNhaCungCap
                });
            
            if (!string.IsNullOrEmpty(maKho))
            {
                query = query.Where(x => x.MaKho.Equals(maKho));
            }
            if (!string.IsNullOrEmpty(maNCC) && !maNCC.Equals("all"))
            {
                query = query.Where(x => x.MaNCC.Equals(maNCC));
            }
            var list = query.OrderBy(x => x.NgayNhap)
                            .ToList();
            lbTotal.Text = list.Sum(x => x.SoLuong).ToString();
            lbSoPhieu.Text = list.Count().ToString();
            grControl.DataSource = list;
            CustomHeader();
        }

        private void CustomHeader()
        {
            var gridView = grControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns["MaPhieu"].Caption = "Mã phiếu";
                gridView.Columns["KhoHang"].Caption = "Kho hàng";
                gridView.Columns["NhaCC"].Caption = "Nhà cung cấp";
                gridView.Columns["NhanVien"].Caption = "Nhân viên";
                gridView.Columns["SoLuong"].Caption = "Tổng số lượng nhập";
                gridView.Columns["NgayNhap"].Caption = "Ngày nhập";
            }
        }

        public void XuatBaoCao()
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps);

            link.Component = grControl;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.Margins = new System.Drawing.Printing.Margins(50, 50, 100, 50);
            link.Landscape = false;

            // Header của báo cáo
            link.CreateReportHeaderArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;

                // Tiêu đề chính
                g.StringFormat = new BrickStringFormat(StringAlignment.Center);
                g.Font = new Font("Tahoma", 18, FontStyle.Bold);
                g.DrawString("BÁO CÁO HÀNG HÓA", Color.Black,
                    new RectangleF(0, 0, pageWidth, 40), BorderSide.None);

                float top = 50;
                g.StringFormat = new BrickStringFormat(StringAlignment.Near);
                g.Font = new Font("Tahoma", 11);

                // Tổng số hàng hóa
                g.DrawString($"Tổng số hàng hóa: {lbTotal.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 25), BorderSide.None);

                top += 35; // khoảng cách giữa phần header và bảng
            };

            // Footer (ngày in, người in, trang)
            link.CreateReportFooterArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;

                g.Font = new Font("Tahoma", 9, FontStyle.Italic);
                g.StringFormat = new BrickStringFormat(StringAlignment.Far);

                g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy}", Color.Gray,
                    new RectangleF(0, 0, pageWidth, 20), BorderSide.None);
            };

            // Tùy chọn hiển thị
            ps.Links.Add(link);
            link.CreateDocument();

            // Hiển thị Preview
            ps.PreviewFormEx.ShowDialog();
        }

        public void ExportReport()
        {
            PhieuNhapRP report = new PhieuNhapRP(maKho, maNCC, dtpStart.Value, dtpEnd.Value);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void cbbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            maKho = cbbKho.SelectedValue.ToString();
            LoadData();
            
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            maNCC = cbbNCC.SelectedValue.ToString();
            LoadData();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    
}

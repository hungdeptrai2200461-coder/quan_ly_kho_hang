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
    public partial class ucThongKeHangHoa : DevExpress.XtraEditors.XtraUserControl
    {
        public static string maKho;
        public static string maKe;
        private readonly QuanLyKhoEntities _context;
        public ucThongKeHangHoa()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
            LoadForm();
        }

        private void LoadKhoHang()
        {
            var khoList = _context.KhoHang.ToList();
            khoList.Insert(0, new KhoHang
            {
                MaKho = "all",
                TenKho = "Tất cả"
            });

            cbbKho.DataSource = khoList;
            cbbKho.DisplayMember = "TenKho"; // Hiển thị tên kho
            cbbKho.ValueMember = "MaKho";    // Giá trị thực tế
        }

        private void LoadKeHang()
        {
            var keList = _context.KeHang.ToList();
            if(!string.IsNullOrEmpty(cbbKho.SelectedValue.ToString()))
            {
                keList = keList.Where(x => x.MaKho.Equals(cbbKho.SelectedValue.ToString())).ToList();
            }    
            keList.Insert(0, new KeHang
            {
                MaKe = "all",
                TenKe = "Tất cả"
            });

            cbbKe.DataSource = keList;
            cbbKe.DisplayMember = "TenKe";
            cbbKe.ValueMember = "MaKe";
        }

        private void LoadForm()
        {
            LoadKhoHang();
            LoadKeHang();
            LoadData();
        }

        private void LoadData()
        {
            string maKho = cbbKho.SelectedValue != null ? cbbKho.SelectedValue.ToString() : "all";
            string maKe = cbbKe.SelectedValue != null ? cbbKe.SelectedValue.ToString() : "all";
            var query = _context.HangHoa
                .Include(x => x.KeHang)
                .Include("KeHang.KhoHang")
                .Select(x => new
                {
                    MaHangHoa = x.MaHangHoa,
                    TenHangHoa = x.TenHangHoa,
                    KeHang = x.KeHang.TenKe,
                    KhoHang = x.KeHang.KhoHang.TenKho,
                    SoLuong = x.SoLuong,
                    DonViTinh = x.DonViTinh,
                    MaKe = x.MaKe,
                    MaKho = x.KeHang.MaKho
                });

            if (!string.IsNullOrEmpty(maKho) && !maKho.Equals("all"))
            {
                query = query.Where(x => x.MaKho.Equals(maKho));
            }
            if (!string.IsNullOrEmpty(maKe) && !maKe.Equals("all"))
            {
                query = query.Where(x => x.MaKe.Equals(maKe));
            }
            var list = query.OrderBy(x => x.KhoHang)
                            .ThenBy(x => x.KeHang)
                            .ToList();
            lbHH.Text = list.Count.ToString();
            lbTon.Text = list.Sum(x => x.SoLuong).ToString();
            grControl.DataSource = list;
            CustomHeader();
        }

        private void CustomHeader()
        {
            var gridView = grControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns["MaHangHoa"].Caption = "Mã hàng hóa";
                gridView.Columns["TenHangHoa"].Caption = "Tên hàng hóa";
                gridView.Columns["KeHang"].Caption = "Kệ hàng";
                gridView.Columns["KhoHang"].Caption = "Kho hàng";
                gridView.Columns["SoLuong"].Caption = "Số lượng tồn";
                gridView.Columns["DonViTinh"].Caption = "Đơn vị tính";
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
                g.DrawString($"Tổng số hàng hóa: {lbHH.Text}", Color.Black,
                    new RectangleF(0, top, pageWidth / 2, 25), BorderSide.None);

                // Tổng số lượng tồn
                g.DrawString($"Tổng số lượng tồn: {lbTon.Text}", Color.Black,
                    new RectangleF(pageWidth / 2, top, pageWidth / 2, 25), BorderSide.None);

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
            HangHoaRP report = new HangHoaRP(maKho, maKe);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void cbbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            maKho = cbbKho.SelectedValue.ToString();
            LoadKeHang();
            LoadData();
            
        }

        private void cbbKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            maKe = cbbKe.SelectedValue.ToString();
            LoadData();
        }
    }

    
}

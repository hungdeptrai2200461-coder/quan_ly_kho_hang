using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;

namespace QuanLyKhoHang.ThongKe
{
    public partial class ucThongKeTinhTrang : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context;
        public ucThongKeTinhTrang()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
            LoadData();
        }

        private void LoadData()
        {
            var list = _context.HangHoa
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
                    TinhTrang = x.SoLuong < 10 ? "Sắp hết hàng" :
                                x.SoLuong < 20 ? "Còn ít" :
                                x.SoLuong > 50 ? "Tồn dư" : "Đủ hàng"
                })
                .OrderBy(x => x.KhoHang)
                .OrderBy(x => x.KeHang)
                .ToList();
            lbHH.Text = list.Count.ToString();
            lbSapHet.Text = list.Where(x => x.SoLuong < 10).Count().ToString();
            lbConIt.Text = list.Where(x => x.SoLuong < 20).Count().ToString();
            lbTonDu.Text = list.Where(x => x.SoLuong > 50).Count().ToString();
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
                gridView.Columns["TinhTrang"].Caption = "Tình trạng";
            }
            gridView.RowStyle += gridView_RowStyle;
        }

        private void gridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.RowHandle < 0) return;

            string tinhTrang = view.GetRowCellValue(e.RowHandle, "TinhTrang")?.ToString();

            switch (tinhTrang)
            {
                case "Sắp hết hàng":
                    e.Appearance.BackColor = Color.LightCoral;
                    break;
                case "Còn ít":
                    e.Appearance.BackColor = Color.LightYellow;
                    break;
                case "Đủ hàng":
                    e.Appearance.BackColor = Color.LightGreen;
                    break;
                case "Tồn dư":
                    e.Appearance.BackColor = Color.LightBlue;
                    break;
            }
        }

        public void XuatBaoCao()
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps)
            {
                Component = grControl,
                PaperKind = System.Drawing.Printing.PaperKind.A4,
                Landscape = false,
                Margins = new System.Drawing.Printing.Margins(50, 50, 120, 50)
            };

            link.CreateReportHeaderArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;

                // Tiêu đề lớn
                g.StringFormat = new BrickStringFormat(StringAlignment.Center);
                g.Font = new Font("Tahoma", 20, FontStyle.Bold);
                g.DrawString("BÁO CÁO TÌNH TRẠNG HÀNG HÓA", Color.Black,
                    new RectangleF(0, 0, pageWidth, 40), BorderSide.None);

                // Dòng tổng hợp
                float top = 50;
                g.StringFormat = new BrickStringFormat(StringAlignment.Near);
                g.Font = new Font("Tahoma", 11);

                float colWidth = pageWidth / 4;

                g.DrawString($"Tổng số hàng hóa: {lbHH.Text}", Color.Black,
                    new RectangleF(0, top, colWidth, 25), BorderSide.None);

                g.DrawString($"Sắp hết: {lbSapHet.Text}", Color.Black,
                    new RectangleF(colWidth, top, colWidth, 25), BorderSide.None);

                g.DrawString($"Còn ít: {lbConIt.Text}", Color.Black,
                    new RectangleF(colWidth * 2, top, colWidth, 25), BorderSide.None);

                g.DrawString($"Tồn dư: {lbTonDu.Text}", Color.Black,
                    new RectangleF(colWidth * 3, top, colWidth, 25), BorderSide.None);

                top += 35;
            };

            link.CreateReportFooterArea += (s, ev) =>
            {
                var g = ev.Graph;
                float pageWidth = g.ClientPageSize.Width;
                g.Font = new Font("Tahoma", 9, FontStyle.Italic);
                g.StringFormat = new BrickStringFormat(StringAlignment.Far);

                g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}", Color.Gray,
                    new RectangleF(0, 0, pageWidth, 20), BorderSide.None);
            };

            ps.Links.Add(link);
            link.CreateDocument();

            // Hiển thị preview
            ps.PreviewFormEx.ShowDialog();
        }
    }
}

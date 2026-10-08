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
    public partial class ucThongKeXuat : DevExpress.XtraEditors.XtraUserControl
    {
        public static string maKho;
        private readonly QuanLyKhoEntities _context;
        public ucThongKeXuat()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
            LoadForm();
        }

        private void LoadKhoHang()
        {
            var khoList = _context.KhoHang.ToList();

            cbbKho.DisplayMember = "TenKho"; // Hiển thị tên kho
            cbbKho.ValueMember = "MaKho";    // Giá trị thực tế
            cbbKho.DataSource = khoList;
        }

        private void LoadForm()
        {
            LoadKhoHang();
            dtpStart.Value = DateTime.Now.AddDays(-1);
            dtpEnd.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            string maKho = cbbKho.SelectedValue.ToString();
            var query = _context.PhieuXuat
                .Include(x => x.NhanVien)
                .Include(x => x.KhoHang)
                .Include(x => x.ChiTietXuat)
                .Where(x => x.NgayXuat >= dtpStart.Value && x.NgayXuat <= dtpEnd.Value);

            if (!string.IsNullOrEmpty(maKho))
            {
                query = query.Where(x => x.MaKho.Equals(maKho));
            }

            var list = query
                    .Select(x => new
                    {
                        MaPhieu = x.MaPhieuXuat,
                        KhoHang = x.KhoHang.TenKho,
                        NhanVien = x.NhanVien.TenNhanVien,
                        SoLuong = x.ChiTietXuat.Sum(s => s.SoLuong),
                        NgayXuat = x.NgayXuat
                    })
                    .OrderBy(x => x.NgayXuat)
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
                gridView.Columns["NhanVien"].Caption = "Nhân viên";
                gridView.Columns["SoLuong"].Caption = "Tổng số lượng bán";
                gridView.Columns["NgayXuat"].Caption = "Ngày xuất";
            }
        }

        public void ExportReport()
        {
            PhieuXuatRP report = new PhieuXuatRP(cbbKho.SelectedValue.ToString(), dtpStart.Value, dtpEnd.Value);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void cbbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            maKho = cbbKho.SelectedValue.ToString();
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

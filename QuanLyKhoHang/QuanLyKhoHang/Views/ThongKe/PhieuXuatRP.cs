using DevExpress.XtraReports.UI;
using QuanLyKhoHang.Entities;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;

namespace QuanLyKhoHang.Views.ThongKe
{
    public partial class PhieuXuatRP : DevExpress.XtraReports.UI.XtraReport
    {
        private string maKho;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        public PhieuXuatRP(string maKho, DateTime ngayBD, DateTime ngayKT)
        {
            InitializeComponent();
            this.maKho = maKho;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            LoadForm();
        }
        private void LoadForm()
        {
            // Tạo DataTable có cấu trúc giống DataSet
            var dt = new DataTable();
            dt.Columns.Add("MaPhieu", typeof(string));
            dt.Columns.Add("NhanVien", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("NgayXuat", typeof(string));

            // Lấy dữ liệu từ database
            var query = _context.PhieuXuat
                .Include(x => x.NhanVien)
                .Include(x => x.KhoHang)
                .Include(x => x.ChiTietXuat)
                .Where(x => x.NgayXuat >= ngayBD
                    && x.NgayXuat <= ngayKT
                    && x.MaKho.Equals(maKho))
                .Select(x => new
                {
                    MaPhieu = x.MaPhieuXuat,
                    KhoHang = x.KhoHang.TenKho,
                    NhanVien = x.NhanVien.TenNhanVien,
                    SoLuong = x.ChiTietXuat.Sum(s => s.SoLuong),
                    NgayNhap = x.NgayXuat
                });

            var list = query.OrderBy(x => x.NgayNhap)
                            .ToList();

            foreach (var item in list)
            {
                dt.Rows.Add(item.MaPhieu, item.NhanVien, item.SoLuong, item.NgayNhap.ToString("dd/MM/yyyy"));
            }

            // Gán DataTable làm nguồn dữ liệu cho report
            this.DataSource = dt;
            this.DataMember = "";
            cellTotal.Text = list.Sum(x => x.SoLuong).ToString();
            lbNgayIn.Text = "Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy");
            lbStart.Text = "Từ ngày: " + ngayBD.ToString("dd/MM/yyyy");
            lbEnd.Text = "Đến ngày: " + ngayKT.ToString("dd/MM/yyyy");
            lbKho.Text = "Kho hàng: " + list.FirstOrDefault().KhoHang;
        }
    }
}

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
    public partial class PhieuNhapRP : DevExpress.XtraReports.UI.XtraReport
    {
        private string maKho;
        private string maNCC;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        public PhieuNhapRP(string maKho, string maNCC, DateTime ngayBD, DateTime ngayKT)
        {
            InitializeComponent();
            this.maKho = maKho;
            this.maNCC = maNCC;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            LoadForm();
        }
        private void LoadForm()
        {
            // Tạo DataTable có cấu trúc giống DataSet
            var dt = new DataTable();
            dt.Columns.Add("MaPhieu", typeof(string));
            dt.Columns.Add("KhoHang", typeof(string));
            dt.Columns.Add("NhaCC", typeof(string));
            dt.Columns.Add("NhanVien", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("NgayNhap", typeof(string));

            // Lấy dữ liệu từ database
            var query = _context.PhieuNhap
                .Include(x => x.NhanVien)
                .Include(x => x.NhaCungCap)
                .Include(x => x.KhoHang)
                .Include(x => x.ChiTietNhap)
                .Where(x => x.NgayNhap >= ngayBD
                    && x.NgayNhap <= ngayKT
                    && x.MaKho.Equals(maKho))
                .Select(x => new
                {
                    MaPhieu = x.MaPhieuNhap,
                    KhoHang = x.KhoHang.TenKho,
                    NhaCC = x.NhaCungCap.TenNhaCungCap,
                    NhanVien = x.NhanVien.TenNhanVien,
                    SoLuong = x.ChiTietNhap.Sum(s => s.SoLuong),
                    NgayNhap = x.NgayNhap,
                    MaNCC = x.MaNhaCungCap
                });

            if (!string.IsNullOrEmpty(maNCC) && !maNCC.Equals("all"))
            {
                query = query.Where(x => x.MaNCC.Equals(maNCC));
            }
            var list = query.OrderBy(x => x.NgayNhap)
                            .ToList();

            foreach (var item in list)
            {
                dt.Rows.Add(item.MaPhieu, item.KhoHang, item.NhaCC,
                            item.NhanVien, item.SoLuong, item.NgayNhap.ToString("dd/MM/yyyy"));
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

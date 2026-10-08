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
    public partial class HangHoaRP : DevExpress.XtraReports.UI.XtraReport
    {
        private string maKho;
        private string maKe;
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        public HangHoaRP(string maKho, string maKe)
        {
            InitializeComponent();
            this.maKho = maKho;
            this.maKe = maKe;
            LoadForm();
        }
        private void LoadForm()
        {
            // Tạo DataTable có cấu trúc giống DataSet
            var dt = new DataTable();
            dt.Columns.Add("MaHangHoa", typeof(string));
            dt.Columns.Add("TenHangHoa", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonViTinh", typeof(string));
            dt.Columns.Add("KeHang", typeof(string));
            dt.Columns.Add("KhoHang", typeof(string));

            // Lấy dữ liệu từ database
            var query = _context.HangHoa
                .Include(x => x.KeHang)
                .Include(x => x.KeHang.KhoHang)
                .Select(x => new
                {
                    x.MaHangHoa,
                    x.TenHangHoa,
                    x.SoLuong,
                    x.DonViTinh,
                    KeHang = x.KeHang.TenKe,
                    KhoHang = x.KeHang.KhoHang.TenKho,
                    MaKho = x.KeHang.KhoHang.MaKho,
                    MaKe = x.KeHang.MaKe
                });

            // Lọc nếu có
            if (!string.IsNullOrEmpty(maKho) && !maKho.Equals("all"))
                query = query.Where(x => x.MaKho == maKho);

            if (!string.IsNullOrEmpty(maKe) && !maKe.Equals("all"))
                query = query.Where(x => x.MaKe == maKe);

            // Đổ dữ liệu vào DataTable
            var data = query.ToList();
            foreach (var item in data)
            {
                dt.Rows.Add(item.MaHangHoa, item.TenHangHoa, item.SoLuong,
                            item.DonViTinh, item.KeHang, item.KhoHang);
            }

            // Gán DataTable làm nguồn dữ liệu cho report
            this.DataSource = dt;
            this.DataMember = "";
            cellTotal.Text = data.Sum(x => x.SoLuong).ToString();
            lbNgayIn.Text = "Ngày in: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
    }
}

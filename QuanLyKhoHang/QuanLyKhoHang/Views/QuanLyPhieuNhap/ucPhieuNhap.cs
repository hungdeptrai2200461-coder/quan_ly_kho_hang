using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace QuanLyKhoHang.QuanLyPhieuNhap
{
    public partial class ucPhieuNhap : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context = new QuanLyKhoEntities();
        string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        public ucPhieuNhap()
        {
            InitializeComponent();
        }
        #region Methods

        private void CustomHeader()
        {
            var gribView = gcChaoGia.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaPhieuNhap"].Caption = "Mã phiếu nhập";
                gribView.Columns["NhanVien"].Caption = "Nhân viên lập";
                gribView.Columns["Kho"].Caption = "Kho hàng";
                gribView.Columns["NhaCungCap"].Caption = "Nhà cung cấp";
                gribView.Columns["Total"].Caption = "Tổng số lượng nhập";
                gribView.Columns["NgayNhap"].Caption = "Ngày nhập";
            }
        }
        private void LoadData()
        {
            var list = _context.PhieuNhap
                .Include(x => x.NhanVien)
                .Include(x => x.KhoHang)
                .Include(x => x.NhaCungCap)
                .Include(x => x.ChiTietNhap)
                .Select(x => new
                {
                    MaPhieuNhap = x.MaPhieuNhap,
                    NhanVien = x.NhanVien.TenNhanVien + " - " + x.MaNhanVien,
                    Kho = x.KhoHang.TenKho,
                    NhaCungCap = x.NhaCungCap.TenNhaCungCap + " - " + x.MaNhaCungCap,
                    Total = x.ChiTietNhap.Sum(ct => ct.SoLuong),
                    NgayNhap = x.NgayNhap
                }).ToList();
            gcChaoGia.DataSource = list;
            bsiRecordsCount.Caption = "RECORDS : " + list.Count;
            CustomHeader();
        }

        private void RefreshData()
        {
            LoadData();
        }

        private string GetIdByTableSelected()
        {
            var gridView = gcChaoGia.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maCGValue = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaPhieuNhap");
                if (maCGValue != null)
                {
                    string maCG = maCGValue.ToString();
                    return maCG;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu");
            }
            return null;
        }

        private void ShowMessage(string message)
        { MessageBox.Show(message); }

        #endregion

        #region Events
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemPhieuNhap form2 = new ThemPhieuNhap(this);
            form2.DataAdded += Form_DataAdded;
            form2.ShowDialog();
        }

        private void ucchaogia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void Form_DataAdded(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            string maPhieu = GetIdByTableSelected();
            if (maPhieu != null)
            {
                var form = new fChiTietPhieuNhap();
                form.maPhieu = maPhieu;
                form.ShowDialog();
            }
        }
        #endregion
    }
}

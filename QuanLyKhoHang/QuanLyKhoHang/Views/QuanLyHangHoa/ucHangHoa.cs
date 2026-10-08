using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyKhoHang.QuanLyHangHoa
{
    public partial class ucHangHoa : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context;
        public ucHangHoa()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
        }

        #region Methods

        private void LoadData()
        {
            gridControl.DataSource = _context.HangHoa
                .Include(x => x.KeHang)
                .Select(x => new
                {
                    MaHangHoa = x.MaHangHoa,
                    TenHangHoa = x.TenHangHoa,
                    TenKe = x.KeHang.TenKe,
                    SoLuong = x.SoLuong,
                    DonViTinh = x.DonViTinh,
                    KichThuoc = x.KichThuoc,
                    MauSac = x.MauSac,
                    ChatLieu = x.ChatLieu,
                    ThuongHieu = x.ThuongHieu,
                    XuatXu = x.XuatXu,
                    GhiChu = x.GhiChu
                }).ToList();
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaHangHoa"].Caption = "Mã hàng";
                gribView.Columns["TenHangHoa"].Caption = "Tên hàng";
                gribView.Columns["TenKe"].Caption = "Kệ hàng";
                gribView.Columns["SoLuong"].Caption = "Số lượng";
                gribView.Columns["DonViTinh"].Caption = "Đơn vị tính";
                gribView.Columns["KichThuoc"].Caption = "Kích thước";
                gribView.Columns["MauSac"].Caption = "Màu sắc";
                gribView.Columns["ChatLieu"].Caption = "Chất liệu";
                gribView.Columns["ThuongHieu"].Caption = "Thương hiệu";
                gribView.Columns["XuatXu"].Caption = "Xuất xứ";
                gribView.Columns["GhiChu"].Caption = "Ghi chú";
            }
        }

        private bool ExistsAnotherTable(string maHang)
        {
            return _context.ChiTietNhap.Any(x => x.MaHangHoa.ToUpper().Trim().Equals(maHang.ToUpper().Trim()))
                || _context.ChiTietXuat.Any(x => x.MaHangHoa.ToUpper().Trim().Equals(maHang.ToUpper().Trim()));
        }
        #endregion

        #region Events

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }


        private void Form2_DataAdded(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            fCUHangHoa form2 = new fCUHangHoa();
            form2.DataAdded += Form2_DataAdded;
            form2.ShowDialog();
            LoadData();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maHangVal = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaHangHoa");
                if (maHangVal != null)
                {
                    string maHang = maHangVal.ToString();
                    fCUHangHoa form2 = new fCUHangHoa();
                    form2.DataAdded += Form2_DataAdded;
                    form2.TypeForm = "update";
                    form2.MaHang = maHang;
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maHangVal = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaHangHoa");
                if (maHangVal != null)
                {
                    if (ExistsAnotherTable(maHangVal.ToString()))
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu đã tồn tại bên bảng khác");
                        return;
                    }
                    if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.HangHoa.Remove(_context.HangHoa.Find(maHangVal.ToString()));
                        _context.SaveChanges();
                        LoadData();
                    }    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
            }
        }

        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void ucHangHoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var query = _context.HangHoa.AsQueryable();
            if(!string.IsNullOrEmpty(txbMa.Text))
            {
                query = query.Where(x => x.MaHangHoa.ToUpper().Contains(txbMa.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbTen.Text))
            {
                query = query.Where(x => x.TenHangHoa.ToUpper().Contains(txbTen.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbKichThuoc.Text))
            {
                query = query.Where(x => x.KichThuoc.ToUpper().Contains(txbKichThuoc.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbMau.Text))
            {
                query = query.Where(x => x.MauSac.ToUpper().Contains(txbMau.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbChat.Text))
            {
                query = query.Where(x => x.ChatLieu.ToUpper().Contains(txbChat.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbThuongHieu.Text))
            {
                query = query.Where(x => x.ThuongHieu.ToUpper().Contains(txbThuongHieu.Text.ToUpper()));
            }
            if (!string.IsNullOrEmpty(txbXuatXu.Text))
            {
                query = query.Where(x => x.XuatXu.ToUpper().Contains(txbXuatXu.Text.ToUpper()));
            }
            gridControl.DataSource = query
                .Include(x => x.KeHang)
                .Select(x => new
                {
                    MaHangHoa = x.MaHangHoa,
                    TenHangHoa = x.TenHangHoa,
                    TenKe = x.KeHang.TenKe,
                    SoLuong = x.SoLuong,
                    DonViTinh = x.DonViTinh,
                    KichThuoc = x.KichThuoc,
                    MauSac = x.MauSac,
                    ChatLieu = x.ChatLieu,
                    ThuongHieu = x.ThuongHieu,
                    XuatXu = x.XuatXu,
                    GhiChu = x.GhiChu
                }).ToList();
        }

        private void btnHuyTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            txbMa.Text = "";
            txbTen.Text = "";
            txbKichThuoc.Text = "";
            txbMau.Text = "";
            txbChat.Text = "";
            txbThuongHieu.Text = "";
            txbXuatXu.Text = "";
            LoadData();
        }
        #endregion

    }
}

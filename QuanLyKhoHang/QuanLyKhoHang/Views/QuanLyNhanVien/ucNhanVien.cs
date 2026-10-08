using DevExpress.XtraBars;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyKhoHang.QuanLyNhanVien
{
    public partial class ucNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context;
        public ucNhanVien()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
        }

        #region Methods

        private void LoadData()
        {
            gridControl.DataSource = _context.NhanVien.Select(x => new
            {
                MaNhanVien = x.MaNhanVien,
                TenNhanVien = x.TenNhanVien,
                VaiTro = x.VaiTro == true ? "Quản lý" : "Nhân viên",
                Email = x.Email,
                SoDienThoai = x.SoDienThoai,
                CCCD = x.CCCD,
                DiaChi = x.DiaChi,
                TenTaiKhoan = x.TenTaiKhoan
            }).ToList();
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaNhanVien"].Caption = "Mã nhân viên";
                gribView.Columns["TenNhanVien"].Caption = "Tên nhân viên";
                gribView.Columns["VaiTro"].Caption = "Vai trò";
                gribView.Columns["Email"].Caption = "Email";
                gribView.Columns["SoDienThoai"].Caption = "Số điện thoại";
                gribView.Columns["CCCD"].Caption = "CCCD";
                gribView.Columns["DiaChi"].Caption = "Địa chỉ";
                gribView.Columns["TenTaiKhoan"].Caption = "Tên tài khoản";
            }
        }

        private bool ExistsAnotherTable(string maNV)
        {
            return _context.PhieuNhap.Any(x => x.MaNhanVien.ToUpper().Trim().Equals(maNV.ToUpper().Trim()))
                || _context.PhieuXuat.Any(x => x.MaNhanVien.ToUpper().Trim().Equals(maNV.ToUpper().Trim()));
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
            fCUNhanVien form2 = new fCUNhanVien();
            form2.DataAdded += Form2_DataAdded;
            form2.ShowDialog();
            LoadData();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maNV = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaNhanVien");
                if (maNV != null)
                {
                    fCUNhanVien form2 = new fCUNhanVien();
                    form2.DataAdded += Form2_DataAdded;
                    form2.TypeForm = "update";
                    form2.maNV = maNV.ToString();
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maNV = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaNhanVien");
                if (maNV != null)
                {
                    var username = gridView.GetRowCellValue(gridView.FocusedRowHandle, "TenTaiKhoan");
                    if(username.Equals("admin"))
                    {
                        MessageBox.Show("Không thể xóa tài khoản admin!!!");
                        return;
                    }    
                    if (ExistsAnotherTable(maNV.ToString()))
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu đã tồn tại bên bảng khác");
                        return;
                    }
                    if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.NhanVien.Remove(_context.NhanVien.Find(maNV.ToString()));
                        _context.SaveChanges();
                        LoadData();
                    }    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
        }

        private void btnLamMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }
        private void ucForm_load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
    }
}

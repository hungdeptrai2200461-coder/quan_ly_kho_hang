using DevExpress.XtraBars;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyKhoHang.QuanLyNhaCungCap
{
    public partial class ucNhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context;
        public ucNhaCungCap()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
        }

        #region Methods

        private void LoadData()
        {
            gridControl.DataSource = _context.NhaCungCap.Select(x => new
            {
                MaNhaCungCap = x.MaNhaCungCap,
                TenNhaCungCap = x.TenNhaCungCap,
                Email = x.Email,
                SoDienThoai = x.SoDienThoai,
                DiaChi = x.DiaChi
            }).ToList();
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaNhaCungCap"].Caption = "Mã NCC";
                gribView.Columns["TenNhaCungCap"].Caption = "Tên NCC";
                gribView.Columns["Email"].Caption = "Email";
                gribView.Columns["SoDienThoai"].Caption = "Số điện thoại";
                gribView.Columns["DiaChi"].Caption = "Địa chỉ";
            }
        }

        private bool ExistsAnotherTable(string maNCC)
        {
            return _context.PhieuNhap.Any(x => x.MaNhaCungCap.ToUpper().Trim().Equals(maNCC.ToUpper().Trim()));
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
            fCUNhaCungCap form2 = new fCUNhaCungCap();
            form2.DataAdded += Form2_DataAdded;
            form2.ShowDialog();
            LoadData();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maNCC = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaNhaCungCap");
                if (maNCC != null)
                {
                    fCUNhaCungCap form2 = new fCUNhaCungCap();
                    form2.DataAdded += Form2_DataAdded;
                    form2.TypeForm = "update";
                    form2.maNhaCC = maNCC.ToString();
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maNCC = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaNhaCungCap");
                if (maNCC != null)
                {
                    if (ExistsAnotherTable(maNCC.ToString()))
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu đã tồn tại bên bảng khác");
                        return;
                    }
                    if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.NhaCungCap.Remove(_context.NhaCungCap.Find(maNCC.ToString()));
                        _context.SaveChanges();
                        LoadData();
                    }    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp");
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

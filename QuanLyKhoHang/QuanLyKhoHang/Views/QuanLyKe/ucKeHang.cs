using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyKhoHang.QuanLyKe
{
    public partial class ucKeHang : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities _context;
        public ucKeHang()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
        }

        #region Methods

        private void LoadData()
        {
            gridControl.DataSource = _context.KeHang
                .Include(x => x.KhoHang)
                .Select(x => new
                {
                    MaKe = x.MaKe,
                    TenKe = x.TenKe,
                    ViTri = x.ViTri,
                    TenKho = x.KhoHang.TenKho
                }).ToList();
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaKe"].Caption = "Mã kệ";
                gribView.Columns["TenKe"].Caption = "Tên kệ";
                gribView.Columns["TenKho"].Caption = "Kho hàng";
                gribView.Columns["ViTri"].Caption = "Vị trí";
            }
        }

        private bool ExistsAnotherTable(string maKe)
        {
            return _context.HangHoa.Any(x => x.MaKe.ToUpper().Trim().Equals(maKe.ToUpper().Trim()));
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
            fCUKeHang form2 = new fCUKeHang();
            form2.DataAdded += Form2_DataAdded;
            form2.ShowDialog();
            LoadData();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maKe = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaKe");
                if (maKe != null)
                {
                    fCUKeHang form2 = new fCUKeHang();
                    form2.DataAdded += Form2_DataAdded;
                    form2.TypeForm = "update";
                    form2.MaKe = maKe.ToString();
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kệ hàng");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maKe = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaKe");
                if (maKe != null)
                {
                    if (ExistsAnotherTable(maKe.ToString()))
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu đã tồn tại bên bảng khác");
                        return;
                    }
                    if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _context.KeHang.Remove(_context.KeHang.Find(maKe.ToString()));
                        _context.SaveChanges();
                        LoadData();
                    }    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kệ hàng");
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
        #endregion
    }
}

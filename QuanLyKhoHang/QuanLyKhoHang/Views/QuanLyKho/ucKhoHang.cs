using DevExpress.XtraBars;
using QuanLyKhoHang.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyKhoHang.QuanLyKho
{
    public partial class ucKhoHang : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly QuanLyKhoEntities db;
        public ucKhoHang()
        {
            InitializeComponent();
            db = new QuanLyKhoEntities();
        }

        #region Methods

        private void LoadData()
        {
            gridControl.DataSource = db.KhoHang
                .Select(x => new
                {
                    MaKho = x.MaKho,
                    TenKho = x.TenKho,
                    DiaChi = x.DiaChi,
                }).ToList();
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaKho"].Caption = "Mã kho";
                gribView.Columns["TenKho"].Caption = "Tên kho";
                gribView.Columns["DiaChi"].Caption = "Địa chỉ";
            }
        }

        private bool ExistsAnotherTable(string maKho)
        {
            return db.PhieuNhap.Any(x => x.MaKho.ToUpper().Trim().Equals(maKho.ToUpper().Trim()))
                || db.PhieuXuat.Any(x => x.MaKho.ToUpper().Trim().Equals(maKho.ToUpper().Trim()))
                || db.KeHang.Any(x => x.MaKho.ToUpper().Trim().Equals(maKho.ToUpper().Trim()));
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
            fCUKhoHang form2 = new fCUKhoHang();
            form2.DataAdded += Form2_DataAdded;
            form2.ShowDialog();
            LoadData();
        }

        private void btnSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maKho = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaKho");
                if (maKho != null)
                {
                    fCUKhoHang form2 = new fCUKhoHang();
                    form2.DataAdded += Form2_DataAdded;
                    form2.TypeForm = "update";
                    form2.MaKho = maKho.ToString();
                    form2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kho hàng");
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = gridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maKho = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaKho");
                if (maKho != null)
                {
                    if (ExistsAnotherTable(maKho.ToString()))
                    {
                        MessageBox.Show("Không thể xóa! Dữ liệu đã tồn tại bên bảng khác");
                        return;
                    }
                    if(MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        db.KhoHang.Remove(db.KhoHang.Find(maKho.ToString()));
                        db.SaveChanges();
                        LoadData();
                    }    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kho hàng");
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

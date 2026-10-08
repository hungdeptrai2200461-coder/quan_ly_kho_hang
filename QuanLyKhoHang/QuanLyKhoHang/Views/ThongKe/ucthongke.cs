using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QuanLyKhoHang.Entities;
using System;
using System.Windows.Forms;

namespace QuanLyKhoHang.ThongKe
{
    public partial class ucthongke : DevExpress.XtraEditors.XtraUserControl
    {
        public string[] TypeForms = new[] { "hang-hoa", "tinh-trang", "nhap-hang", "xuat-hang" };
        private string typeForm;
        private readonly QuanLyKhoEntities _context;
        private ucThongKeHangHoa ucThongKeHangHoa;
        private ucThongKeTinhTrang ucThongKeTinhTrang;
        private ucThongKeNhap ucThongKeNhap;
        private ucThongKeXuat ucThongKeXuat;
        public ucthongke()
        {
            InitializeComponent();
            _context = new QuanLyKhoEntities();
            LoadForm();
        }

        private void LoadForm()
        {
            btnBaoCaoHH_ItemClick(null, null);
        }

        private void LoadUC(XtraUserControl uc)
        {
            MainPanel.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnBaoCaoHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            typeForm = TypeForms[0];
            ucThongKeHangHoa = new ucThongKeHangHoa();
            LoadUC(ucThongKeHangHoa);
        }

        private void btnBaoCaoTinhTrang_ItemClick(object sender, ItemClickEventArgs e)
        {
            typeForm = TypeForms[1];
            ucThongKeTinhTrang = new ucThongKeTinhTrang();
            LoadUC(ucThongKeTinhTrang);
        }

        private void btnXuatBaoCao_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (typeForm == TypeForms[0])
            {
                ucThongKeHangHoa.ExportReport();
            }
            else if (typeForm == TypeForms[1])
            {
                ucThongKeTinhTrang.XuatBaoCao();
            }
            else if(typeForm == TypeForms[2])
            {
                ucThongKeNhap.ExportReport();
            }
            else if(typeForm == TypeForms[3])
            {
                ucThongKeXuat.ExportReport();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            typeForm = TypeForms[2];
            ucThongKeNhap = new ucThongKeNhap();
            LoadUC(ucThongKeNhap);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            typeForm = TypeForms[3];
            ucThongKeXuat = new ucThongKeXuat();
            LoadUC(ucThongKeXuat);
        }
    }
}

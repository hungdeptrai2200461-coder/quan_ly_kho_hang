using QuanLyKhoHang.Data;
using QuanLyKhoHang.QuanLyHangHoa;
using QuanLyKhoHang.QuanLyKe;
using QuanLyKhoHang.QuanLyKho;
using QuanLyKhoHang.QuanLyNhaCungCap;
using QuanLyKhoHang.QuanLyNhanVien;
using QuanLyKhoHang.QuanLyPhieuNhap;
using QuanLyKhoHang.QuanLyPhieuXuat;
using QuanLyKhoHang.ThongKe;
using System;
using System.Windows.Forms;

namespace Views
{
    public partial class MENU : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MENU()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            MainContainer.Controls.Add(uc);
            uc.BringToFront();
        }
        private void MENU_Load(object sender, EventArgs e)
        {
            LoadUC(new ucKhoHang());
            if(!UserData.VaiTro)
            {
                accordionControlElement16.Enabled = false;
                accordionControlElement9.Enabled = false;
            }    
        }
        private void accDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Event
        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            LoadUC(new ucKhoHang());
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            LoadUC(new ucKeHang());
        }

        private void itemHangHoa_Click(object sender, EventArgs e)
        {
            LoadUC(new ucHangHoa());
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            LoadUC(new ucNhaCungCap());
        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
            LoadUC(new ucNhanVien());
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            LoadUC(new ucPhieuNhap());
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            LoadUC(new ucPhieuXuat());
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            LoadUC(new ucthongke());
        }

        private void accQuanLyND_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void accDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

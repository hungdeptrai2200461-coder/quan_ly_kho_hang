using QuanLyKhoHang.Entities;
using QuanLyKhoHang.ModelView;
using QuanLyKhoHang.QuanLyHangHoa;
using QuanLyKhoHang.QuanLyNhanVien;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;


namespace QuanLyKhoHang.QuanLyPhieuNhap
{
    public partial class ThemPhieuNhap : Form
    {
        public List<ChiTietPhieuNhapModelView> chiTiets;
        public event EventHandler DataAdded;
        private bool isSuccess = false;
        private readonly QuanLyKhoEntities _context;
        private readonly ucPhieuNhap _ucParent;
        private string previousMaKho;
        private bool _suppressCbbKhoEvent = false;
        public ThemPhieuNhap(ucPhieuNhap ucParent)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
            chiTiets = new List<ChiTietPhieuNhapModelView>();
            _ucParent = ucParent;
        }

        #region Methods
        private void LoadForm()
        {
            // load ncc
            List<NhaCungCap> ncc = _context.NhaCungCap.ToList();
            if (ncc != null && ncc.Count() > 0)
            {
                cbbNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbbNhaCungCap.DataSource = ncc;
                cbbNhaCungCap.DisplayMember = "TenNhaCungCap";
                cbbNhaCungCap.ValueMember = "MaNhaCungCap";
            }

            // load nhanvien
            List<NhanVien> nhanViens = _context.NhanVien.ToList();
            if (nhanViens != null && nhanViens.Count() > 0)
            {
                cbbNhanVien.DataSource = nhanViens;
                cbbNhanVien.DisplayMember = "TenNhanVien";
                cbbNhanVien.ValueMember = "MaNhanVien";
            }

            // load kho
            List<KhoHang> khos = _context.KhoHang.ToList();
            if (khos != null && khos.Count() > 0)
            {
                cbbKho.DataSource = khos;
                cbbKho.DisplayMember = "TenKho";
                cbbKho.ValueMember = "MaKho";
            }

            previousMaKho = cbbKho.SelectedValue.ToString();
        }

        private void LoadData()
        {
            gcSanPham.DataSource = chiTiets.Select(x => new
            {
                MaHangHoa = x.MaHangHoa,
                TenHangHoa = x.TenHangHoa,
                DonViTinh = x.DonViTinh,
                SoLuong = x.SoLuong
            });
            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gcSanPham.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaHangHoa"].Caption = "Mã hàng hóa";
                gribView.Columns["TenHangHoa"].Caption = "Tên hàng hóa";
                gribView.Columns["DonViTinh"].Caption = "Đơn vị tính";
                gribView.Columns["SoLuong"].Caption = "Số lượng nhập";
            }
        }

        private PhieuNhap GetDataByForm()
        {
            PhieuNhap model = new PhieuNhap();
            try
            {
                model.MaPhieuNhap = txtMaPhieuNhap.Text;
                model.MaNhanVien = cbbNhanVien.SelectedValue as string;
                model.MaNhaCungCap = cbbNhaCungCap.SelectedValue as string;
                model.MaKho = cbbKho.SelectedValue as string;
                model.NgayNhap = dtpNgayNhap.Value;

                return model;
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi dữ liệu đầu vào, vui lòng kiểm tra lại");
            }

            return null;
        }

        private void RefreshData()
        {
            gcSanPham.DataSource = null;
            LoadData();
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                ShowMessage("Mã phiếu nhập không được bỏ trống");
                return false;
            }
            if (cbbNhaCungCap.Items.Count == 0)
            {
                ShowMessage("Không có dữ liệu nhà cung cấp");
                return false;
            }
            if (cbbNhanVien.Items.Count == 0)
            {
                ShowMessage("Không có dữ liệu nhân viên");
                return false;
            }
            if (cbbKho.Items.Count == 0)
            {
                ShowMessage("Không có dữ liệu kho hàng");
                return false;
            }
            return true;
        }

        private void SaveData()
        {
            if (!ValidateData())
                return;
            PhieuNhap model = GetDataByForm();
            if (_context.PhieuNhap.Find(model.MaPhieuNhap) != null)
            {
                ShowMessage("Mã phiếu nhập đã tồn tại.");
                return;
            }
            if (chiTiets == null || chiTiets.Count == 0)
            {
                ShowMessage("Vui lòng chọn hàng hóa");
                return;
            }
            try
            {
                _context.PhieuNhap.Add(model);

                foreach (var detail in chiTiets)
                {
                    detail.MaPhieuNhap = model.MaPhieuNhap;
                    var ct = ChiTietPhieuNhapModelView.ConvertToModel(detail);
                    _context.ChiTietNhap.Add(ct);

                    var hang = _context.HangHoa.Find(ct.MaHangHoa);
                    if(hang != null)
                    {
                        hang.SoLuong += ct.SoLuong;
                        _context.Entry(hang).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                ShowMessage($"Có lỗi xảy ra: {ex.Message}");
            }

        }

        private string GetDataByTableSelected()
        {
            var gridView = gcSanPham.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // Lấy GridView
            if (gridView != null)
            {
                var maHangVal = gridView.GetRowCellValue(gridView.FocusedRowHandle, "MaHangHoa");
                if (maHangVal != null)
                {
                    string maHang = maHangVal.ToString();

                    return maHang;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
            }
            return null;
        }

        private void ShowMessage(string info)
        {
            MessageBox.Show(info);
        }

        private void XoaPhieu()
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu này không?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                CloseForm();
            }
        }

        private void ChooseSanPham()
        {
            var frm = new TimKiemSanPham(cbbKho.SelectedValue.ToString(), chiTiets);
            frm.DataAdded += Form_DataAdded;
            frm.ShowDialog();
        }

        private void XoaSanPham()
        {
            string maSP = GetDataByTableSelected();
            if (maSP != null)
            {
                var sanPham = chiTiets.SingleOrDefault(x => x.MaHangHoa == maSP);
                chiTiets.Remove(sanPham);
                LoadData();
            }
        }

        private void SuaSanPham()
        {
            string maSP = GetDataByTableSelected();
            if (maSP != null)
            {
                SuaThongTinSanPham form = new SuaThongTinSanPham();
                form.DataAdded += Form_DataAdded;
                form.chiTiet = chiTiets.SingleOrDefault(x => x.MaHangHoa == maSP);
                form.ShowDialog();
                LoadData();
            }
        }

        private void ResetData()
        {
            txtMaPhieuNhap.Text = "";
            chiTiets = new List<ChiTietPhieuNhapModelView>();
            LoadData();
        }

        private void CloseForm()
        {
            DataAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
        #endregion

        #region Events
        private void ThemChaoGiaMoi_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void Form_DataAdded(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            ChooseSanPham();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa hàng hóa này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                XoaSanPham();
        }

        private void btnLuuDong_Click(object sender, EventArgs e)
        {
            SaveData();
            if (isSuccess)
            {
                CloseForm();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            XoaPhieu();
        }
        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            SaveData();
            if (isSuccess)
            {
                ResetData();
                _ucParent.Form_DataAdded(null, null);
            }
            else
            {
                isSuccess = false;
            }
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            fCUHangHoa form = new fCUHangHoa();
            form.DataAdded += Form_DataAdded;
            form.ShowDialog();
        }
        private void cbbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressCbbKhoEvent)
                return;
            var currentValue = cbbKho.SelectedValue.ToString();

            // Nếu previous chưa được khởi tạo (lần đầu), lưu và thoát
            if (previousMaKho == null)
            {
                previousMaKho = currentValue;
                return;
            }

            if (chiTiets != null && chiTiets.Count > 0)
            {
                if(MessageBox.Show("Nếu bạn thay đổi kho, dữ liệu hàng hóa nhập sẽ bị mất", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chiTiets = new List<ChiTietPhieuNhapModelView>();
                    LoadData();
                    previousMaKho = currentValue;
                }
                else
                {
                    _suppressCbbKhoEvent = true;
                    try
                    {
                        if (previousMaKho != null)
                            cbbKho.SelectedValue = previousMaKho;
                    }
                    finally
                    {
                        _suppressCbbKhoEvent = false;
                    }
                    return;
                }
            }
            else
                previousMaKho = currentValue;
        }
        #endregion


    }
}

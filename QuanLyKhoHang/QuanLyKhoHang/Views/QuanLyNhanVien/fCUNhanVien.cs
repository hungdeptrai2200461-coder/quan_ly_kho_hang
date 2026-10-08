using DevExpress.XtraRichEdit.Fields;
using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyNhanVien
{
    public partial class fCUNhanVien : Form
    {
        public event EventHandler DataAdded;
        private readonly QuanLyKhoEntities _context;
        public string TypeForm { get; set; }
        public string maNV { get; set; }
        public NhanVien nhanVien { get; set; }
        private string passwordDefault = "123456";
        Dictionary<bool, string> roles = new Dictionary<bool, string>()
        {
            { false, "Nhân viên" },
            { true, "Quản lý" }
        };
        public fCUNhanVien()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
        }

        private void LoadForm()
        {
            LoadVaiTro();
            if (!string.IsNullOrEmpty(TypeForm) && TypeForm == "update")
            {
                SetData();
            }
        }

        private void LoadVaiTro()
        {
            cbbVaiTro.DataSource = new BindingSource(roles, null);
            cbbVaiTro.DisplayMember = "Value";
            cbbVaiTro.ValueMember = "Key";
        }

        private void SetData()
        {
            nhanVien = _context.NhanVien.Find(maNV);
            txtMaNV.Text = nhanVien.MaNhanVien;
            txtTenNV.Text = nhanVien.TenNhanVien;
            txtEmail.Text = nhanVien.Email;
            txtSDT.Text = nhanVien.SoDienThoai;
            rtxtDiaChi.Text = nhanVien.DiaChi;
            txtCCCD.Text = nhanVien.CCCD;
            txtTaiKhoan.Text = nhanVien.TenTaiKhoan;
            txtMatKhau.Text = nhanVien.MatKhau;
            cbbVaiTro.SelectedValue = nhanVien.VaiTro;

            txtMaNV.ReadOnly = true;
            this.Text = "Sửa thông tin";
        }

        private NhanVien GetDataByForm()
        {
            NhanVien model = new NhanVien();
            model.MaNhanVien = txtMaNV.Text;
            model.TenNhanVien = txtTenNV.Text;
            model.Email = txtEmail.Text;
            model.SoDienThoai = txtSDT.Text;
            model.DiaChi = rtxtDiaChi.Text;
            model.TenTaiKhoan = txtTaiKhoan.Text;
            model.MatKhau = txtMatKhau.Text;
            model.CCCD = txtCCCD.Text;
            model.VaiTro = bool.Parse(cbbVaiTro.SelectedValue.ToString());
            return model;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                txtMaNV.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống");
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống");
                txtSDT.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtSDT.Text, @"^0\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                txtSDT.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("CCCD không được bỏ trống");
                txtCCCD.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
            {
                MessageBox.Show("CCCD không hợp lệ! (phải gồm 12 chữ số)");
                txtCCCD.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tên tài khoản không được bỏ trống");
                txtTaiKhoan.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(TypeForm) && TypeForm == "update" && string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                txtMatKhau.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(rtxtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được bỏ trống");
                rtxtDiaChi.Focus();
                return false;
            }

            return true;
        }



        private void Save()
        {
            if (!ValidateData())
                return;
            NhanVien model = GetDataByForm();
            if (TypeForm == "update")
            {
                try
                {
                    NhanVien nv = _context.NhanVien.Find(model.MaNhanVien);
                    nv.TenNhanVien = model.TenNhanVien;
                    nv.Email = model.Email;
                    nv.SoDienThoai = model.SoDienThoai;
                    nv.DiaChi = model.DiaChi;
                    nv.CCCD = model.CCCD;
                    nv.TenTaiKhoan = model.TenTaiKhoan;
                    nv.MatKhau = model.MatKhau;
                    nv.VaiTro = model.VaiTro;
                    _context.Entry(nhanVien).State = EntityState.Modified;
                    _context.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!");
                }
            }
            else
            {
                if (_context.NhanVien.Find(model.MaNhanVien) != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại.");
                    return;
                }
                if (_context.NhanVien.SingleOrDefault(x => x.SoDienThoai.Equals(model.SoDienThoai)) != null)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.");
                    return;
                }
                if (_context.NhanVien.SingleOrDefault(x => x.CCCD.Equals(model.CCCD)) != null)
                {
                    MessageBox.Show("CCCD đã tồn tại.");
                    return;
                }
                if (_context.NhanVien.SingleOrDefault(x => x.TenTaiKhoan.Equals(model.TenTaiKhoan)) != null)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại.");
                    return;
                }
                try
                {
                    model.MatKhau = string.IsNullOrEmpty(model.MatKhau) ? passwordDefault : model.MatKhau;
                    _context.NhanVien.Add(model);
                    _context.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!");
                }
            }
            if (DataAdded != null)
                DataAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void ResetData()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            rtxtDiaChi.Text = "";
        }


        #region Events
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        #endregion
    }
}

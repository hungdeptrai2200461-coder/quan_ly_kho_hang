using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyNhaCungCap
{
    public partial class fCUNhaCungCap : Form
    {
        public event EventHandler DataAdded;
        private readonly QuanLyKhoEntities _context;
        public string TypeForm { get; set; }
        public string maNhaCC { get; set; }
        public NhaCungCap nhaCC { get; set; }
        public fCUNhaCungCap()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
        }

        private void LoadForm()
        {
            if (!string.IsNullOrEmpty(TypeForm) && TypeForm == "update")
            {
                SetData();
            }
        }

        private void SetData()
        {
            nhaCC = _context.NhaCungCap.Find(maNhaCC);
            txtMaNCC.Text = nhaCC.MaNhaCungCap;
            txtTenNCC.Text = nhaCC.TenNhaCungCap;
            txtEmail.Text = nhaCC.Email;
            txtSDT.Text = nhaCC.SoDienThoai;
            rtxtDiaChi.Text = nhaCC.DiaChi;

            txtMaNCC.ReadOnly = true;
            this.Text = "Sửa thông tin";
        }

        private NhaCungCap GetDataByForm()
        {
            NhaCungCap model = new NhaCungCap();
            model.MaNhaCungCap = txtMaNCC.Text;
            model.TenNhaCungCap = txtTenNCC.Text;
            model.Email = txtEmail.Text;
            model.SoDienThoai = txtSDT.Text;
            model.DiaChi = rtxtDiaChi.Text;
            return model;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được bỏ trống");
                txtMaNCC.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được bỏ trống");
                txtTenNCC.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống");
                return false;
            }
            else if (!Regex.IsMatch(txtSDT.Text, @"^0\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return false;
            }

            if(!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ");
                return false;
            }
            if (string.IsNullOrEmpty(rtxtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được bỏ trống");
                return false;
            }

            return true;
        }


        private void Save()
        {
            if (!ValidateData())
                return;
            NhaCungCap model = GetDataByForm();
            if (TypeForm == "update")
            {
                try
                {
                    NhaCungCap ncc = _context.NhaCungCap.Find(model.MaNhaCungCap);
                    ncc.TenNhaCungCap = model.TenNhaCungCap;
                    ncc.Email = model.Email;
                    ncc.SoDienThoai = model.SoDienThoai;
                    ncc.DiaChi = model.DiaChi;
                    _context.Entry(nhaCC).State = EntityState.Modified;
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
                if (_context.NhaCungCap.Find(model.MaNhaCungCap) != null)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại.");
                    return;
                }
                try
                {
                    _context.NhaCungCap.Add(model);
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
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
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

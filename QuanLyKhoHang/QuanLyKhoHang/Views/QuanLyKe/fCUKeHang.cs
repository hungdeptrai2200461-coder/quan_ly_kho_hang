using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyKe
{
    public partial class fCUKeHang : Form
    {
        public event EventHandler DataAdded;
        private readonly QuanLyKhoEntities _context;
        public string TypeForm { get; set; }
        public string MaKe { get; set; }
        public KeHang keHang { get; set; }
        public fCUKeHang()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
        }

        private void LoadForm()
        {
            LoadKhoHang();

            if (!string.IsNullOrEmpty(TypeForm) && TypeForm == "update")
            {
                SetData();
            }
        }

        private void LoadKhoHang()
        {
            cbbKho.DataSource = _context.KhoHang.ToList();
            cbbKho.DisplayMember = "TenKho";
            cbbKho.ValueMember = "MaKho";
        }

        private void SetData()
        {
            keHang = _context.KeHang.Find(MaKe);
            txtMaKe.Text = keHang.MaKe;
            txtTenKe.Text = keHang.TenKe;
            txtViTri.Text = keHang.ViTri;
            cbbKho.SelectedValue = keHang.MaKho;

            txtMaKe.ReadOnly = true;
            this.Text = "Sửa thông tin";
        }

        private KeHang GetDataByForm()
        {
            KeHang model = new KeHang();
            model.MaKe = txtMaKe.Text;
            model.TenKe = txtTenKe.Text;
            model.MaKho = cbbKho.SelectedValue as string;
            model.ViTri = txtViTri.Text;
            return model;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaKe.Text))
            {
                MessageBox.Show("Mã kệ hàng không được bỏ trống");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKe.Text))
            {
                MessageBox.Show("Tên kệ hàng không được bỏ trống");
                return false;
            }
            return true;
        }


        private void Save()
        {
            if (!ValidateData())
                return;
            KeHang model = GetDataByForm();
            if (TypeForm == "update")
            {
                try
                {
                    KeHang hang = _context.KeHang.Find(model.MaKe);
                    hang.TenKe = model.TenKe;
                    hang.ViTri = model.ViTri;
                    hang.MaKho = model.MaKho;
                    _context.Entry(keHang).State = EntityState.Modified;
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
                if (_context.KeHang.Find(model.MaKe) != null)
                {
                    MessageBox.Show("Mã kệ hàng này đã tồn tại");
                    return;
                }
                try
                {
                    _context.KeHang.Add(model);
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
            txtMaKe.Text = "";
            txtTenKe.Text = "";
            txtViTri.Text = "";
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

        private void ThemHangHoa_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        #endregion
    }
}

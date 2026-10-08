using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyKho
{
    public partial class fCUKhoHang : Form
    {
        public event EventHandler DataAdded;
        private readonly QuanLyKhoEntities db;
        public string TypeForm { get; set; }
        public string MaKho { get; set; }
        public KhoHang khoHang { get; set; }
        public fCUKhoHang()
        {
            InitializeComponent();
            db = new QuanLyKhoEntities();
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
            khoHang = db.KhoHang.Find(MaKho);
            txtMaKho.Text = khoHang.MaKho;
            txtTenKho.Text = khoHang.TenKho;
            rtxtDiaChi.Text = khoHang.DiaChi;

            txtMaKho.ReadOnly = true;
            this.Text = "Sửa thông tin";
        }

        private KhoHang GetDataByForm()
        {
            KhoHang model = new KhoHang();
            model.MaKho = txtMaKho.Text;
            model.TenKho = txtTenKho.Text;
            model.DiaChi = rtxtDiaChi.Text;
            return model;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaKho.Text))
            {
                MessageBox.Show("Mã kho hàng không được bỏ trống");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKho.Text))
            {
                MessageBox.Show("Tên kho hàng không được bỏ trống");
                return false;
            }
            if(string.IsNullOrEmpty(rtxtDiaChi.Text))
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
            KhoHang model = GetDataByForm();
            if (TypeForm == "update")
            {
                try
                {
                    KhoHang hang = db.KhoHang.Find(model.MaKho);
                    hang.TenKho = model.TenKho;
                    hang.DiaChi = model.DiaChi;
                    db.Entry(khoHang).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!");
                }
            }
            else
            {
                if (db.KhoHang.Find(model.MaKho) != null)
                {
                    MessageBox.Show("Mã kho này đã tồn tại");
                    return;
                }
                try
                {
                    db.KhoHang.Add(model);
                    db.SaveChanges();
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
            txtMaKho.Text = "";
            txtTenKho.Text = "";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

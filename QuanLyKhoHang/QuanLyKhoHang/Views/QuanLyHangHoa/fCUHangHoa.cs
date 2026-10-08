using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyHangHoa
{
    public partial class fCUHangHoa : Form
    {
        public event EventHandler DataAdded;
        private readonly QuanLyKhoEntities _context;
        public string TypeForm { get; set; }
        public string MaHang { get; set; }
        public HangHoa hangHoa { get; set; }
        public static List<string> DanhSachDonViTinh = new List<string>
        {
            "Cái",
            "Hộp",
            "Thùng",
            "Chiếc",
            "Bộ",
            "Kg",
            "Gam",
            "Lít",
            "Mét",
            "Cuộn",
            "Gói",
            "Viên",
            "Tấm",
            "Chai",
            "Lon",
            "Túi",
            "Thẻ",
        };
        public fCUHangHoa()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
        }

        private void LoadForm()
        {
            LoadKeHang();
            LoadDonViTinh();

            if (!string.IsNullOrEmpty(TypeForm) && TypeForm == "update")
            {
                SetData();
            }
        }

        private void LoadKeHang()
        {
            cbbKeHang.DataSource = _context.KeHang
                .Include(x => x.KhoHang)
                .Select(x => new
                {
                    TenKe = x.TenKe + " - " + x.KhoHang.TenKho,
                    MaKe = x.MaKe,
                    MaKho = x.MaKho
                })
                .OrderBy(x => x.MaKho)
                .ToList();
            cbbKeHang.DisplayMember = "TenKe";
            cbbKeHang.ValueMember = "MaKe";
        }

        private void LoadDonViTinh()
        {
            cbbDonVi.DataSource = DanhSachDonViTinh;
        }

        private void SetData()
        {
            hangHoa = _context.HangHoa.Find(MaHang);
            txtMaHang.Text = hangHoa.MaHangHoa;
            txtTenHang.Text = hangHoa.TenHangHoa;
            cbbDonVi.SelectedItem = hangHoa.DonViTinh;
            cbbKeHang.SelectedValue = hangHoa.MaKe;
            txtSoLuong.Text = hangHoa.SoLuong.ToString();
            txbKichThuoc.Text = hangHoa.KichThuoc;
            txbMau.Text = hangHoa.MauSac;
            txbChat.Text = hangHoa.ChatLieu;
            txbThuongHieu.Text = hangHoa.ThuongHieu;
            txbXuatXu.Text = hangHoa.XuatXu;
            rtxbGhiChu.Text = hangHoa.GhiChu;


            txtMaHang.ReadOnly = true;
            txtSoLuong.ReadOnly = true;
            this.Text = "Sửa thông tin";
        }

        private HangHoa GetDataByForm()
        {
            HangHoa model = new HangHoa();
            model.MaHangHoa = txtMaHang.Text;
            model.TenHangHoa = txtTenHang.Text;
            model.MaKe = cbbKeHang.SelectedValue as string;
            model.DonViTinh = cbbDonVi.SelectedItem as string;
            model.SoLuong = int.Parse(txtSoLuong.Text);
            model.KichThuoc = txbKichThuoc.Text;
            model.MauSac = txbMau.Text;
            model.ChatLieu = txbChat.Text;
            model.ThuongHieu = txbThuongHieu.Text;
            model.XuatXu = txbXuatXu.Text;
            model.GhiChu = rtxbGhiChu.Text;
            return model;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtMaHang.Text))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenHang.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống");
                return false;
            }
            if(string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống");
                return false;
            }
            else if(!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }
            else if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }
            return true;
        }


        private void Save()
        {
            if (!ValidateData())
                return;
            HangHoa model = GetDataByForm();
            if (TypeForm == "update")
            {
                try
                {
                    HangHoa hang = _context.HangHoa.Find(model.MaHangHoa);
                    hang.TenHangHoa = model.TenHangHoa;
                    hang.DonViTinh = model.DonViTinh;
                    hang.MaKe = model.MaKe;
                    hang.KichThuoc = model.KichThuoc;
                    hang.MauSac = model.MauSac;
                    hang.ChatLieu = model.ChatLieu;
                    hang.ThuongHieu = model.ThuongHieu;
                    hang.XuatXu = model.XuatXu;
                    hang.GhiChu = model.GhiChu;
                    _context.Entry(hangHoa).State = EntityState.Modified;
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
                if (_context.HangHoa.Find(model.MaHangHoa) != null)
                {
                    MessageBox.Show("Mã hàng này đã tồn tại");
                    return;
                }
                try
                {
                    _context.HangHoa.Add(model);
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
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

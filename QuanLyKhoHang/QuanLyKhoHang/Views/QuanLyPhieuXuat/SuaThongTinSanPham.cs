using QuanLyKhoHang.Entities;
using QuanLyKhoHang.ModelView;
using System;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyPhieuXuat
{
    public partial class SuaThongTinSanPham : Form
    {
        public event EventHandler DataAdded;
        public ChiTietPhieuXuatModelView chiTiet { get; set; }
        private readonly QuanLyKhoEntities _context;
        public SuaThongTinSanPham()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
        }

        #region Methods
        private void LoadForm()
        {
            txtSoLuong.KeyPress += textEdit_KeyPress;
            txtSoLuong.Text = chiTiet.SoLuong.ToString();
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống");
                return false;
            }
            else if (int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.");
                return false;
            }
            return true;
        }


        private void ChooseProduct()
        {
            if (!ValidateData())
            {
                return;
            }
            if (_context.HangHoa.Find(chiTiet.MaHangHoa).SoLuong < int.Parse(txtSoLuong.Text))
            {
                MessageBox.Show("Số lượng hàng trong kho không đủ.");
                return;
            }
            chiTiet.SoLuong = int.Parse(txtSoLuong.Text);

            DataAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        #endregion

        private void textEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textEdit = sender as TextBox;
            if (textEdit != null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && textEdit.Text.Contains("."))
                {
                    e.Handled = true;
                }

                if (textEdit.Text == "0" && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void TimKiemSanPham_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            ChooseProduct();
        }
    }
}


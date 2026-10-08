using QuanLyKhoHang.Entities;
using QuanLyKhoHang.ModelView;
using System;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyPhieuNhap
{
    public partial class SuaThongTinSanPham : Form
    {
        public event EventHandler DataAdded;
        public ChiTietPhieuNhapModelView chiTiet { get; set; }

        public SuaThongTinSanPham()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            return true;
        }


        private void ChooseProduct()
        {
            if (!ValidateData())
            {
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


using QuanLyKhoHang.Entities;
using System;
using System.Linq;
using System.Windows.Forms;
using Views;

namespace QuanLyKhoHang.Views
{
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private readonly QuanLyKhoEntities db;
        public fDangNhap()
        {
            InitializeComponent();
            db = new QuanLyKhoEntities();
        }

        private void CheckLogin()
        {
            string username = txtTenTK.Text;
            string password = txtMatKhau.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống");
                return;
            }
            // Tìm nhân viên có tên tài khoản trùng với username
            NhanVien user = null;
            foreach (var nv in db.NhanVien)
            {
                if (nv.TenTaiKhoan == username && nv.MatKhau == password)
                {
                    user = nv;
                    break; // tìm thấy thì dừng vòng lặp
                }
            }

            // Kiểm tra kết quả
            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;
            }

            Data.UserData.LoginSuccess(user);
            var form = new MENU();
            this.Hide();
            form.ShowDialog();
            this.Show();
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void txtTenTK_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
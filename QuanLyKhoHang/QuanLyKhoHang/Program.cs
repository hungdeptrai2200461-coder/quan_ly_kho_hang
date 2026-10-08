using QuanLyKhoHang.QuanLyHangHoa;
using QuanLyKhoHang.Views;
using System;
using System.Windows.Forms;
using Views;

namespace QuanLyKhoHang
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MENU());
            Application.Run(new fDangNhap());

        }
    }
}

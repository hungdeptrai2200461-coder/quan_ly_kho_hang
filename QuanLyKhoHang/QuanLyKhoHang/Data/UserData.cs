using QuanLyKhoHang.Entities;
using System.Collections.Generic;

namespace QuanLyKhoHang.Data
{
    public class UserData
    {
        // Lưu mã nhân viên đăng nhập
        public static string MaNhanVien;

        // Lưu vai trò của nhân viên
        // true  : Nhân viên
        // false : Không có quyền (hoặc quyền khác tùy bạn)
        public static bool VaiTro = true;

        // Lưu tên nhân viên
        public static string TenNhanVien ;

        // Hàm được gọi khi đăng nhập thành công
        public static void LoginSuccess(NhanVien user)
        {
            // Gán mã nhân viên
            MaNhanVien = user.MaNhanVien;

            // Kiểm tra vai trò có null không
            if (user.VaiTro == null)
            {
                VaiTro = false;
            }
            else
            {
                VaiTro = user.VaiTro.Value;
            }

            // Gán tên nhân viên
            TenNhanVien = user.TenNhanVien;
        }
    }
}

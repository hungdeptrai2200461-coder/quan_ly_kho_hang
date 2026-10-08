using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.ModelView
{
    public class ChiTietPhieuNhapModelView
    {
        public int MaChiTiet { get; set; }
        public string MaPhieuNhap { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }

        public static ChiTietNhap ConvertToModel(ChiTietPhieuNhapModelView model)
        {
            return new ChiTietNhap
            {
                MaChiTiet = model.MaChiTiet,
                MaPhieuNhap = model.MaPhieuNhap,
                MaHangHoa = model.MaHangHoa,
                SoLuong = model.SoLuong
            };
        }
    }
}

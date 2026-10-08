using QuanLyKhoHang.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.ModelView
{
    public class ChiTietPhieuXuatModelView
    {
        public int MaChiTiet { get; set; }
        public string MaPhieuXuat { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }

        public static ChiTietXuat ConvertToModel(ChiTietPhieuXuatModelView model)
        {
            return new ChiTietXuat
            {
                MaChiTiet = model.MaChiTiet,
                MaPhieuXuat = model.MaPhieuXuat,
                MaHangHoa = model.MaHangHoa,
                SoLuong = model.SoLuong
            };
        }
    }
}

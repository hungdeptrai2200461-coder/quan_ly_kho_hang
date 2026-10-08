using QuanLyKhoHang.Entities;
using QuanLyKhoHang.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyKhoHang.QuanLyPhieuNhap
{
    public partial class TimKiemSanPham : Form
    {
        private readonly QuanLyKhoEntities _context;
        public event EventHandler DataAdded;
        private List<ChiTietPhieuNhapModelView> _chiTiets;
        private string _maKho = "";
        public TimKiemSanPham(string maKho, List<ChiTietPhieuNhapModelView> chiTiets)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            _context = new QuanLyKhoEntities();
            _chiTiets = chiTiets;
            _maKho = maKho;
            LoadForm();
        }

        #region Methods
        private void LoadForm()
        {
            txtSoLuong.KeyPress += textEdit_KeyPress;
            LoadData();
        }

        private void LoadData()
        {
            gcHangHoa.DataSource = _context.HangHoa
                .Include(x => x.KeHang)
                .Where(x => x.KeHang.MaKho.Equals(_maKho))
                .Select(x => new
                {
                    MaHangHoa = x.MaHangHoa,
                    TenHangHoa = x.TenHangHoa,
                    DonViTinh = x.DonViTinh
                }).ToList();

            EditHeader();
        }

        private void EditHeader()
        {
            var gribView = gcHangHoa.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gribView != null)
            {
                gribView.Columns["MaHangHoa"].Caption = "Mã hàng hóa";
                gribView.Columns["TenHangHoa"].Caption = "Tên hàng hóa";
                gribView.Columns["DonViTinh"].Caption = "Đơn vị tính";
            }
        }

        private ChiTietPhieuNhapModelView GetDataByForm()
        {
            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                return new ChiTietPhieuNhapModelView()
                {
                    SoLuong = soLuong
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu các trường không hợp lệ");
            }
            return null;
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

        private HangHoa GetDataByRowIndex()
        {
            if (gcHangHoa.MainView is DevExpress.XtraGrid.Views.Grid.GridView gridView)
            {
                int focusedRow = gridView.FocusedRowHandle;
                int rowIndex = focusedRow >= 0 ? focusedRow : -1;
                if (rowIndex == -1)
                {
                    MessageBox.Show($"Vui lòng chọn hàng hóa");
                    return null;
                }
                dynamic rowData = gridView.GetRow(rowIndex);

                HangHoa selectedData = new HangHoa
                {
                    MaHangHoa = rowData.MaHangHoa,
                    TenHangHoa = rowData.TenHangHoa,
                    DonViTinh = rowData.DonViTinh
                };
                if (selectedData == null)
                {
                    try
                    {
                        var data = rowData as dynamic;
                        selectedData = _context.HangHoa.Find(data.MaHang);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}");
                    }
                }
                return selectedData;
            }
            return null;
        }

        private void ChooseProduct()
        {
            if (!ValidateData())
            {
                return;
            }
            HangHoa prod = GetDataByRowIndex();
            ChiTietPhieuNhapModelView chiTiet = GetDataByForm();
            if (prod == null)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
                return;
            }
            if (chiTiet == null)
            {
                MessageBox.Show("Vui lòng nhập đúng dữ liệu");
                return;
            }

            chiTiet.MaHangHoa = prod.MaHangHoa;
            chiTiet.TenHangHoa = prod.TenHangHoa;
            chiTiet.DonViTinh = prod.DonViTinh;

            if (_chiTiets.Any(x => x.MaHangHoa == chiTiet.MaHangHoa))
            {
                var existingItem = _chiTiets.SingleOrDefault(x => x.MaHangHoa == chiTiet.MaHangHoa);

                existingItem.SoLuong += chiTiet.SoLuong;
            }
            else
            {
                _chiTiets.Add(chiTiet);
            }

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

        private void btnChon_Click(object sender, EventArgs e)
        {
            ChooseProduct();
        }
    }
}


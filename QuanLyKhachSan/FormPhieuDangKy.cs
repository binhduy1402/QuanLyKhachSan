using QuanLyKhachSan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormPhieuDangKy : Form
    {
        public FormPhieuDangKy()
        {
            InitializeComponent();
        }
        QLKhachSanDbContext _db = new QLKhachSanDbContext();
        BindingSource _src = new BindingSource();
        private void FormPhieuDangKy_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaKH();
            LoadComboBoxMaNV();
            LoadComboBoxMaHD();
            LoadComboBoxMaPhong();
            gridData.ReadOnly = true;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            LoadGridData();
        }

        private void LoadComboBoxMaPhong()
        {
            cboMaPhong.DataSource = _db.Phong.AsNoTracking().ToList();
            cboMaPhong.ValueMember = "MaP";
            cboMaPhong.DisplayMember = "MaP";
        }

        private void LoadComboBoxMaHD()
        {
            cboMaHD.DataSource = _db.Hoadon.AsNoTracking().ToList();
            cboMaHD.ValueMember = "MaHD";
            cboMaHD.DisplayMember = "MaHD";
        }

        private void LoadComboBoxMaNV()
        {
            cboMaNV.DataSource = _db.Nhanvien.AsNoTracking().ToList();
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "TenNV";
        }

        private void LoadComboBoxMaKH()
        {
            cboMaKH.DataSource = _db.Khachhang.AsNoTracking().ToList();
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.DisplayMember = "TenKH";
        }

        private void LoadGridData()
        {
            
            _src.DataSource = _db.Phieudangky.ToList();
            _src.ResetBindings(true);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            txtMa.Text = "";
            cboMaKH.SelectedIndex = 0;
            cboMaNV.SelectedIndex = 0;
            cboMaHD.SelectedIndex = 0;
            dtpNgayO.Value = DateTime.Now;
            cboMaPhong.SelectedIndex = 0;
            txtTraTruoc.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã phiếu đăng ký không được để trống !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (cboMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo");
                cboMaKH.Focus();
                return;
            }

            if (cboMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo");
                cboMaNV.Focus();
                return;
            }

            if (cboMaHD.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hoá đơn", "Thông báo");
                cboMaHD.Focus();
                return;
            }

            if (dtpNgayO.Value < DateTime.Now)
            {
                MessageBox.Show("Ngày ở phải lớn hơn hoặc bằng ngày hiện tại !", "Thông báo");
                dtpNgayO.Focus();
                return;
            }

            if (cboMaPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng", "Thông báo");
                cboMaPhong.Focus();
                return;
            }

            if (!int.TryParse(txtTraTruoc.Text, out int traTruoc))
            {
                MessageBox.Show("Giá trị trả trước không hợp lệ !", "Thông báo");
                txtTraTruoc.Focus();
                return;
            }

            if (traTruoc < 0)
            {
                MessageBox.Show("Giá trị trả trước phải lớn hơn hoặc bằng 0 !", "Thông báo");
                txtTraTruoc.Focus();
                return;
            }

            Phieudangky obj = new Phieudangky();
            obj.Mapdk = txtMa.Text;
            obj.Makh = cboMaKH.SelectedValue.ToString();
            obj.Manv = cboMaNV.SelectedValue.ToString();
            obj.Mahd = cboMaHD.SelectedValue.ToString();
            obj.Ngayo = dtpNgayO.Value;
            obj.Map = cboMaPhong.SelectedValue.ToString();
            obj.Tratruoc = traTruoc;

            _db.Phieudangky.AddOrUpdate(obj);

            try
            {
                _db.SaveChanges();
                MessageBox.Show("Lưu phiếu đăng ký thành công !", "Thông báo");
                LoadGridData();
                ResetFormControls();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lưu phiếu đăng ký không thành công !", "Thông báo");
                return;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã phiếu đăng ký không được để trống !", "Thông báo");
                txtMa.Focus();
                return;
            }

            var obj = _db.Phieudangky.Find(txtMa.Text);

            if (obj == null)
            {
                MessageBox.Show("Không tìm thấy phiếu cần xoá !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá phiếu đăng ký !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _db.Phieudangky.Remove(obj);

                try
                {
                    _db.SaveChanges();
                    LoadGridData();
                    ResetFormControls();
                    MessageBox.Show("Xoá phiếu đăng ký thành công !", "Thông báo");
                    return;
                } catch (Exception ex)
                {
                    MessageBox.Show("Xoá phiếu đăng ký không thành công !", "Thông báo");
                    return;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<Phieudangky> dsPhieuDangKy = _db.Phieudangky.ToList();

            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                dsPhieuDangKy = dsPhieuDangKy.Where (x => x.Map.Contains(txtMa.Text))
                    .ToList();
            }

            _src.DataSource = dsPhieuDangKy;
            _src.ResetBindings(true);
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;
            var obj = gridData.CurrentRow.DataBoundItem as Phieudangky;
           
            if (obj == null)
                return;
            HienThi(obj);
        }

        private void HienThi(Phieudangky obj)
        {
            if (obj.Makh == null)
                return;

            txtMa.Text = obj.Mapdk;
            cboMaKH.SelectedValue = obj.Makh;
            cboMaNV.SelectedValue = obj.Manv;
            cboMaHD.SelectedValue = obj.Mahd;
            dtpNgayO.Value = obj.Ngayo;
            cboMaPhong.SelectedValue = obj.Map;
            txtTraTruoc.Text = obj.Tratruoc.ToString();    
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FormKhachHang f = new FormKhachHang();
            f.ShowDialog();
            LoadComboBoxMaKH();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            FormHoaDon f = new FormHoaDon();
            f.ShowDialog();
            LoadComboBoxMaHD();
        }
    }
}

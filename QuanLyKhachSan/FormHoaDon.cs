using QuanLyKhachSan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        
        Hoadon _obj;

        public FormHoaDon(Hoadon obj) :
            this()
        {
            _obj = obj;
        }

        private void LoadData(Hoadon obj)
        {
            txtMa.Text = obj.Mahd;
            dtpNgayTT.Value = obj.Ngaythanhtoan;
            cboNhanVien.SelectedValue = obj.Manv;
            txtSoTien.Text = obj.Sotien.ToString();
            cboPhong.SelectedIndex = 0;
            dtpNgayDi.Value = obj.Ngaythanhtoan;
            List<CtHoadon> listCT = _db.CtHoadon
                .Where(x => x.Mahd == obj.Mahd)
                .ToList();
            LoadDSChiTiet(listCT);
        }

        QLKhachSanDbContext _db = new QLKhachSanDbContext();

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            gridDataCT.AutoGenerateColumns = false;
            gridDataCT.ReadOnly = true;
            gridDataCT.AllowUserToResizeRows = false;
            gridDataCT.DataSource = _srcCTHoaDon;
            LoadComboBoxNhanVien();
            LoadComboBoxPhong();
            if (_obj != null)
                LoadData(_obj);
        }

        private void LoadComboBoxPhong()
        {
            cboPhong.DataSource = _db.Phong.AsNoTracking().ToList();
            cboPhong.DisplayMember = "MaP";
            cboPhong.ValueMember = "MaP";
        }

        private void LoadComboBoxNhanVien()
        {
            cboNhanVien.DataSource = _db.Nhanvien.AsNoTracking().ToList();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            dtpNgayTT.Value = DateTime.Now;
            cboNhanVien.SelectedIndex = 0;
            cboPhong.SelectedIndex = 0;
            dtpNgayDi.Value = DateTime.Now.AddDays(1);
            LoadDSChiTiet(new List<CtHoadon>());
        }

        BindingSource _srcCTHoaDon = new BindingSource();
        private void LoadDSChiTiet(List<CtHoadon> ctHoadons)
        {
            _srcCTHoaDon.DataSource = ctHoadons;
            _srcCTHoaDon.ResetBindings(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã hoá đơn không được để trống !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (cboNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên !", "Thông báo");
                cboNhanVien.Focus();
                return;
            }

            if (!int.TryParse(txtSoTien.Text, out int soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ !", "Thông báo");
                txtSoTien.Focus();
                return;
            }

            if (soTien < 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0 !", "Thông báo");
                txtSoTien.Focus();
                return;
            }

            // Tìm hoá đơn có mã trùng với mã hoá đơn đang thao tác
            var old = _db.Hoadon.Find(txtMa.Text);
            // Nếu tìm thấy thì xóa hết chi tiết hoá đơn cũ
            if (old != null)
            {
                var listCT = _db.CtHoadon.Where(x => x.Mahd == old.Mahd)
                    .ToList();
                _db.CtHoadon.RemoveRange(listCT);
            }
            // Lưu lại các thay đổi
            try
            {
                _db.SaveChanges();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin hoá đơn không thành công !", "Thông báo");
                return;
            }
            // Tạo một hoá đơn mới
            Hoadon newObj = new Hoadon();
            newObj.Mahd = txtMa.Text;
            newObj.Ngaythanhtoan = dtpNgayTT.Value;
            newObj.Manv = cboNhanVien.SelectedValue.ToString();
            newObj.Sotien = soTien;
            _db.Hoadon.AddOrUpdate(newObj);
            // Thêm danh sách chi tiết 
            List<CtHoadon> dsCT = _srcCTHoaDon.DataSource as List<CtHoadon>;
            
            if (dsCT != null)
            {
                foreach (var ct in dsCT)
                {
                    CtHoadon newCT = new CtHoadon();
                    newCT.Mahd = newObj.Mahd;
                    newCT.Map = ct.Map;
                    newCT.Ngaydi = ct.Ngaydi;
                    _db.CtHoadon.AddOrUpdate(newCT);
                }
            }
            // Lưu lại các thay đổi
            try
            {
                _db.SaveChanges();
                MessageBox.Show("Lưu thông tin hoá đơn thành công !", "Thông báo");
                LoadDSChiTiet(_db.CtHoadon.Where(x => x.Mahd == txtMa.Text).ToList());
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin hoá đơn không thành công !", "Thông báo");
                return;
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Không có mã hoá đơn nào được chọn !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (cboPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phong !", "Thông báo");
                cboPhong.Focus();
                return;
            }

            if (dtpNgayDi.Value < dtpNgayTT.Value)
            {
                MessageBox.Show("Ngày đi phải lớn hơn ngày thanh toán !", "Thông báo");
                dtpNgayDi.Focus();
                return;
            }

            CtHoadon ct = new CtHoadon();
            ct.Mahd = txtMa.Text;
            ct.Map = cboPhong.SelectedValue.ToString();
            ct.Ngaydi = dtpNgayDi.Value;
            // Lấy danh sách chi tiết hoá đơn hiện có trên lưới
            List<CtHoadon> dsCT = _srcCTHoaDon.DataSource as List<CtHoadon>;
            
            if (dsCT == null)
                dsCT = new List<CtHoadon>();

            // Nếu có tồn tại chi tiết thì kiểm tra xem có cập nhật hay thêm mới
            
            bool isUpdate = false;

            foreach (var item in dsCT)
            {
                if (item.Map == ct.Map)
                {
                    item.Ngaydi = ct.Ngaydi;
                    isUpdate = true;
                    break;
                }
            }

            if (!isUpdate)
            {
                dsCT.Add(ct);
            }

            _srcCTHoaDon.DataSource = dsCT;
            _srcCTHoaDon.ResetBindings(true);
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (gridDataCT.CurrentRow == null || gridDataCT.CurrentRow.IsNewRow)
                return;

            // Lấy chi tiết hoá đơn được chọn trên lưới
            var obj = gridDataCT.CurrentRow.DataBoundItem as CtHoadon;
            
            if (obj == null) return;
            
            // Lấy danh sách chi tiết hoá đơn hiện tại trên lưới
            List<CtHoadon> dsCT = _srcCTHoaDon.DataSource as List<CtHoadon>;
            
            if (dsCT == null)
                return;

            // Xoá chi tiết hoá đơn được chọn
            dsCT.Remove(obj);

            // Hiển thị lại lưới
            _srcCTHoaDon.DataSource = dsCT;
            _srcCTHoaDon.ResetBindings(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Không có mã hoá đơn nào được chọn !", "Thông báo");
                txtMa.Focus();
                return;
            }

            var obj = _db.Hoadon.Find(txtMa.Text);

            if (obj == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn cần xoá !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá hoá đơn ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var listCT = _db.CtHoadon.Where(x => x.Mahd == txtMa.Text).ToList();
                
                _db.CtHoadon.RemoveRange(listCT);
                
                try
                {
                    _db.SaveChanges();
                } catch (Exception ex)
                {
                    MessageBox.Show("Xoá hoá đơn không thành công !", "Thông báo");
                    return;
                }

                _db.Hoadon.Remove(obj);

                try
                {
                    _db.SaveChanges();
                    MessageBox.Show("Xoá hoá đơn thành công !", "Thông báo");
                    LoadDSChiTiet(new List<CtHoadon>());

                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá hoá đơn không thành công !", "Thông báo");
                    return;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                Hoadon hd = _db.Hoadon.Find(txtMa.Text);
                
                if (hd != null)
                {
                    LoadData(hd);
                }
            }
        }
    }
}

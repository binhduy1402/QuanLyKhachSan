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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        QLKhachSanDbContext _db = new QLKhachSanDbContext();
        BindingSource _src = new BindingSource();
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            ShowGridData();
        }

        private void ShowGridData()
        {
            _src.DataSource = _db.Nhanvien.ToList();
            _src.ResetBindings(true);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            cboGioiTinh.SelectedItem = "Nam";
            dtpNgaySinh.Value = new DateTime(1970, 01, 01);
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            Nhanvien obj = new Nhanvien();
            obj.Manv = txtMa.Text;
            obj.Tennv = txtTen.Text;
            obj.Ngaysinh = dtpNgaySinh.Value;
            obj.Diachi = txtDiaChi.Text;
            obj.Gioitinh = (string) cboGioiTinh.SelectedItem;
            obj.Sdt = txtSDT.Text;
            
            _db.Nhanvien.AddOrUpdate(obj);

            try
            {
                _db.SaveChanges();

                MessageBox.Show("Lưu thông tin nhân viên thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowGridData();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin nhân viên không thành công ! " + ex.Message
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            Nhanvien oldObj = _db.Nhanvien.Find(txtMa.Text);
            
            if (oldObj == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xoá"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này không ?"
                               , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _db.Nhanvien.Remove(oldObj);

                try
                {
                    _db.SaveChanges();
                    MessageBox.Show("Xoá nhân viên thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowGridData();
                    ClearControls();
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá nhân viên không thành công ! " + ex.Message
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow) 
                return;
            Nhanvien obj = gridData.CurrentRow.DataBoundItem as Nhanvien;
            if (obj == null)
                return;
            ShowData(obj);
        }

        private void ShowData(Nhanvien obj)
        {
            txtMa.Text = obj.Manv;
            txtTen.Text = obj.Tennv;
            txtDiaChi.Text = obj.Diachi;
            cboGioiTinh.SelectedItem = obj.Gioitinh;
            dtpNgaySinh.Value = obj.Ngaysinh;
            txtSDT.Text = obj.Sdt;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<Nhanvien> list = _db.Nhanvien.AsNoTracking().ToList();
            
            if (!string.IsNullOrEmpty(txtMa.Text) )
            {
                list = list.Where(x => 
                        x.Manv.IndexOf(txtMa.Text, 0, StringComparison.InvariantCultureIgnoreCase) != -1)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(txtTen.Text) )
            {
                list = list.Where(x => 
                        x.Tennv.IndexOf(txtTen.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(txtDiaChi.Text))
            {
                list = list.Where(x => 
                        x.Diachi.IndexOf(txtDiaChi.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            _src.DataSource = list;
            _src.ResetBindings(true);
        }
    }
}

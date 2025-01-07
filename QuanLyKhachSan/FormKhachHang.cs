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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        QLKhachSanDbContext _db = new QLKhachSanDbContext();
        BindingSource _src = new BindingSource();

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            LoadGridData();
        }

        private void LoadGridData()
        {
            _src.DataSource = _db.Khachhang.ToList();
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
            txtCMND.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }

            Khachhang obj = new Khachhang();
            obj.Makh = txtMa.Text;
            obj.Tenkh = txtTen.Text;
            obj.Cmnd = txtCMND.Text;
            obj.Diachi = txtDiaChi.Text;
            obj.Gioitinh = (string)cboGioiTinh.SelectedItem;
            obj.Sdt = txtSDT.Text;

            _db.Khachhang.AddOrUpdate(obj);

            try
            {
                _db.SaveChanges();

                MessageBox.Show("Lưu thông tin khách hàng thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin khách hàng không thành công ! " + ex.Message
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            Khachhang oldObj = _db.Khachhang.Find(txtMa.Text);

            if (oldObj == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng cần xoá"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này không ?"
                               , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _db.Khachhang.Remove(oldObj);

                try
                {
                    _db.SaveChanges();
                    MessageBox.Show("Xoá khách hàng thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xoá khách hàng không thành công ! " + ex.Message
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;
            Khachhang obj = gridData.CurrentRow.DataBoundItem as Khachhang;
            if (obj == null)
                return;
            ShowData(obj);
        }

        private void ShowData(Khachhang obj)
        {
            txtMa.Text = obj.Makh;
            txtTen.Text = obj.Tenkh;
            txtDiaChi.Text = obj.Diachi;
            cboGioiTinh.SelectedItem = obj.Gioitinh;
            txtCMND.Text = obj.Cmnd;
            txtSDT.Text = obj.Sdt;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<Khachhang> list = _db.Khachhang.AsNoTracking().ToList();

            // Sử dụng linq để lọc các kết quả
            // StringComparison.InvariantCultureIgnoreCase: không phân biệt hoa thường

            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                list = list
                    .Where(x =>
                        x.Makh.IndexOf(txtMa.Text, 0, StringComparison.InvariantCultureIgnoreCase) != -1)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(txtTen.Text))
            {
                list = list
                    .Where(x =>
                        x.Tenkh.IndexOf(txtTen.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(txtDiaChi.Text))
            {
                list = list
                    .Where(x =>
                        x.Diachi.IndexOf(txtDiaChi.Text, 0, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            _src.DataSource = list;
            _src.ResetBindings(true);
        }
    }
}

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
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
        }

        public FormPhong(Phong p)
            : this()
        {
            _p = p;
        }
        QLKhachSanDbContext _db = new QLKhachSanDbContext();
        BindingSource _src = new BindingSource();
        private readonly Phong _p;

        private void FormPhong_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            
            LoadGridData();

            if (_p != null)
            {
                HienThi(_p);
            }
        }

        private void LoadGridData()
        {
            _src.DataSource = _db.Phong.ToList();
            _src.ResetBindings(true);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearControlsData();
        }

        private void ClearControlsData()
        {
            txtMa.Text = "";
            cboLoaiPhong.SelectedItem = "Thường";
            cboTinhTrang.SelectedItem = "Chưa có khách";
            txtGiaPhong.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Mã phòng không được để trống !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại phong !", "Thông báo");
                cboLoaiPhong.Focus();
                return;
            }

            if (cboTinhTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng phòng !", "Thông báo");
                cboTinhTrang.Focus();
                return;
            }

            if (!int.TryParse(txtGiaPhong.Text, out int giaPHong))
            {
                MessageBox.Show("Giá phòng không hợp lệ !", "Thông báo");
                txtGiaPhong.Focus();
                return;
            }

            if (giaPHong < 0)
            {
                MessageBox.Show("Giá phòng phải lớn hơn 0 !", "Thông báo");
                txtGiaPhong.Focus();
                return;
            }

            Phong obj = new Phong();
            obj.Map = txtMa.Text;
            obj.Loaiphong = cboLoaiPhong.SelectedItem as string;
            obj.Tinhtrang = cboTinhTrang.SelectedItem as string;
            obj.Giaphong = giaPHong;

            _db.Phong.AddOrUpdate(obj);

            try
            {
                _db.SaveChanges();
                MessageBox.Show("Lưu thông tin phòng thành công", "Thông báo");
                LoadGridData();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thông tin phòng không thành công !", "Thông báo");
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa !", "Thông báo");
                txtMa.Focus();
                return;
            }

            var old = _db.Phong.Find(txtMa.Text);
            
            if (old == null)
            {
                MessageBox.Show("Phòng cần xoá không tồn tại !", "Thông báo");
                txtMa.Focus();
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá phòng ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _db.Phong.Remove(old);

                try
                {
                    _db.SaveChanges();
                    MessageBox.Show("Xoá phòng thành công !", "Thông báo");
                    LoadGridData();
                    ClearControlsData();
                    return;
                } catch (Exception ex)
                {
                    MessageBox.Show("Xoá phòng khôn thành công ! " + ex.Message, "Thông báo");
                    return;
                }
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<Phong> dsPhong = _db.Phong.ToList();
            
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                dsPhong = dsPhong
                    .Where(p => p.Map.Contains(txtMa.Text))
                    .ToList();
            }

            if (cboLoaiPhong.SelectedIndex != -1)
            {
                dsPhong = dsPhong
                    .Where(p => p.Loaiphong.Contains((string) cboLoaiPhong.SelectedItem))
                    .ToList();
            }

            if (cboTinhTrang.SelectedIndex != -1)
            {
                dsPhong = dsPhong
                    .Where(p => p.Tinhtrang.Contains((string)cboTinhTrang.SelectedItem))
                    .ToList();
            }

            _src.DataSource = dsPhong;
            _src.ResetBindings(true);
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow) 
                return;

            var obj = gridData.CurrentRow.DataBoundItem as Phong;
            if (obj == null) 
                return;
            HienThi(obj);
        }

        private void HienThi(Phong obj)
        {
            txtMa.Text = obj.Map;
            cboLoaiPhong.SelectedItem = obj.Loaiphong;
            cboTinhTrang.SelectedItem = obj.Tinhtrang;
            txtGiaPhong.Text = obj.Giaphong.ToString();
        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

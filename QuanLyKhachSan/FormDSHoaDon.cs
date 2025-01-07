using QuanLyKhachSan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormDSHoaDon : Form
    {
        public FormDSHoaDon()
        {
            InitializeComponent();
        }

        QLKhachSanDbContext _db = new QLKhachSanDbContext();
        // Đối tượng sử dụng để hiển thị dữ liệu trên lưới
        BindingSource _src = new BindingSource();
        private void FormDSHoaDon_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToResizeRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = _src;
            LoadGridData();
        }

        private void LoadGridData()
        {
            _src.DataSource = _db.Hoadon.AsNoTracking().ToList();
            _src.ResetBindings(true);
        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            var obj = gridData.CurrentRow.DataBoundItem as Hoadon;

            if (obj == null)
                return;

            FormHoaDon form = new FormHoaDon(obj);
            form.ShowDialog();
            LoadGridData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<Hoadon> dsHoaDon = _db.Hoadon
                .AsNoTracking()
                .ToList();

            if (!string.IsNullOrEmpty(txtMaHD.Text))
            {
               dsHoaDon = dsHoaDon
                    .Where(x => x.Mahd.Contains(txtMaHD.Text))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(txtMaPDK.Text)) {
                
                var pdk = _db.Phieudangky
                    .Where(x => x.Mapdk.Contains(txtMaPDK.Text))
                    .FirstOrDefault();

                if (pdk != null)
                    dsHoaDon = dsHoaDon.Where(x => x.Mahd == pdk.Mahd)
                        .ToList();
            }

            if (!string.IsNullOrEmpty(txtMaKH.Text))
            {
                var dsPDK = _db.Phieudangky
                    .Where(x => x.Makh.Contains(txtMaKH.Text))
                    .ToList();

                foreach (var pdk in dsPDK)
                {
                    dsHoaDon = dsHoaDon
                        .Where(x => 1 == 1 || x.Mahd == pdk.Mahd)
                        .ToList();
                }
            }
            _src.DataSource = dsHoaDon;
            _src.ResetBindings(true);
        }
    }
}

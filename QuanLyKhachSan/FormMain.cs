using QuanLyKhachSan.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        QLKhachSanDbContext _db = new QLKhachSanDbContext();

        private void FormMain_Load(object sender, EventArgs e)
        {
            lvDSPhong.View = View.LargeIcon;
            LoadDSPhong();
        }

        private void LoadDSPhong()
        {
            lvDSPhong.Items.Clear();
            var dsPhong = _db.Phong.AsNoTracking().ToList();
            foreach (var phong in dsPhong)
            {
                ListViewItem item = new ListViewItem(phong.Map);
                item.SubItems.Add(phong.Loaiphong);
                item.SubItems.Add(phong.Tinhtrang);
                item.SubItems.Add(phong.Giaphong.ToString());
                if (phong.Tinhtrang == "Chua co khach")
                    item.ImageIndex = 0;
                else
                    item.ImageIndex = 1;
                lvDSPhong.Items.Add(item);
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien f = new FormNhanVien();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang f = new FormKhachHang();
            f.ShowDialog();
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon f = new FormHoaDon();
            f.ShowDialog();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhong f = new FormPhong();
            f.ShowDialog();
        }

        private void danhSáchHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDSHoaDon f = new FormDSHoaDon();
            f.ShowDialog();
        }

        private void phiếuĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhieuDangKy f = new FormPhieuDangKy();
            f.ShowDialog();
        }

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đóng ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

      

        private void danhSáchHoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDSHoaDon f = new FormDSHoaDon();
            f.ShowDialog();
        }

        private void lvDSPhong_Click(object sender, EventArgs e)
        {
            var selectedItem = lvDSPhong.SelectedItems[0];
            string maP = selectedItem.SubItems[0].Text;
            if (!string.IsNullOrEmpty(maP))
            {
                Phong p = _db.Phong.Where(x => x.Map ==  maP)
                    .FirstOrDefault();
                if (p != null)
                {
                    FormPhong f = new FormPhong(p);
                    f.ShowDialog();
                    LoadDSPhong();
                }
            }
        }

        private void lvDSPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
    }
}

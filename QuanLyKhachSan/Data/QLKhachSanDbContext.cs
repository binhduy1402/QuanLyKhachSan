using System;
using System.Data.Entity;

namespace QuanLyKhachSan.Data
{
    public partial class QLKhachSanDbContext : DbContext
    {
        public QLKhachSanDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<CtHoadon> CtHoadon { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phieudangky> Phieudangky { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
    }
}
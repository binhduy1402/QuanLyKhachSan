using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            DSChiTietHD = new HashSet<CtHoadon>();
            DSPhieuDangKy = new HashSet<Phieudangky>();
        }

        [Key]
        [Column("MAHD")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Column("NGAYTHANHTOAN", TypeName = "datetime")]
        public DateTime Ngaythanhtoan { get; set; }
        [Column("SOTIEN")]
        public int? Sotien { get; set; }
        [Required]
        [Column("MANV")]
        [StringLength(5)]
        public string Manv { get; set; }

        [ForeignKey(nameof(Manv))]
        public virtual Nhanvien NhanVien { get; set; }
        public virtual ICollection<CtHoadon> DSChiTietHD { get; set; }
        public virtual ICollection<Phieudangky> DSPhieuDangKy { get; set; }
    }
}
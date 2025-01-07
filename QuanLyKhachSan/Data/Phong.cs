using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("PHONG")]
    public partial class Phong
    {
        public Phong()
        {
            DSChiTietHD = new HashSet<CtHoadon>();
            DSPhieuDangKy = new HashSet<Phieudangky>();
        }

        [Key]
        [Column("MAP")]
        [StringLength(5)]
        public string Map { get; set; }
        [Required]
        [Column("LOAIPHONG")]
        [StringLength(10)]
        public string Loaiphong { get; set; }
        [Required]
        [Column("TINHTRANG")]
        [StringLength(20)]
        public string Tinhtrang { get; set; }
        [Column("GIAPHONG")]
        public int? Giaphong { get; set; }

        public virtual ICollection<CtHoadon> DSChiTietHD { get; set; }
        public virtual ICollection<Phieudangky> DSPhieuDangKy { get; set; }
    }
}
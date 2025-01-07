using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("KHACHHANG")]
    public partial class Khachhang
    {
        public Khachhang()
        {
            DSPhieuDangKy = new HashSet<Phieudangky>();
        }

        [Key]
        [Column("MAKH")]
        [StringLength(5)]
        public string Makh { get; set; }
        [Required]
        [Column("TENKH")]
        [StringLength(30)]
        public string Tenkh { get; set; }
        [Column("DIACHI")]
        [StringLength(50)]
        public string Diachi { get; set; }
        [Column("GIOITINH")]
        [StringLength(5)]
        public string Gioitinh { get; set; }
        [Column("CMND")]
        [StringLength(14)]
        public string Cmnd { get; set; }
        [Column("SDT")]
        [StringLength(13)]
        public string Sdt { get; set; }

        public virtual ICollection<Phieudangky> DSPhieuDangKy { get; set; }
    }
}
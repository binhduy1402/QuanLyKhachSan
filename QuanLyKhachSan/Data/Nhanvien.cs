using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("NHANVIEN")]
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            DSHoaDon = new HashSet<Hoadon>();
            DSPhieuDangKy = new HashSet<Phieudangky>();
        }

        [Key]
        [Column("MANV")]
        [StringLength(5)]
        public string Manv { get; set; }
        [Required]
        [Column("TENNV")]
        [StringLength(30)]
        public string Tennv { get; set; }
        [Column("GIOITINH")]
        [StringLength(5)]
        public string Gioitinh { get; set; }
        [Column("NGAYSINH", TypeName = "smalldatetime")]
        public DateTime Ngaysinh { get; set; }
        [Column("DIACHI")]
        [StringLength(50)]
        public string Diachi { get; set; }
        [Column("SDT")]
        [StringLength(15)]
        public string Sdt { get; set; }
        public virtual ICollection<Hoadon> DSHoaDon { get; set; }
        public virtual ICollection<Phieudangky> DSPhieuDangKy { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("PHIEUDANGKY")]
    public partial class Phieudangky
    {
        [Key]
        [Column("MAPDK")]
        [StringLength(15)]
        public string Mapdk { get; set; }
        [Required]
        [Column("MAKH")]
        [StringLength(5)]
        public string Makh { get; set; }
        [Required]
        [Column("MANV")]
        [StringLength(5)]
        public string Manv { get; set; }
        [Required]
        [Column("MAHD")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Column("NGAYO", TypeName = "datetime")]
        public DateTime Ngayo { get; set; }
        [Required]
        [Column("MAP")]
        [StringLength(5)]
        public string Map { get; set; }
        [Column("TRATRUOC")]
        public int? Tratruoc { get; set; }

        [ForeignKey(nameof(Mahd))]
        public virtual Hoadon HoaDon { get; set; }
        [ForeignKey(nameof(Makh))]
        public virtual Khachhang KhachHang { get; set; }
        [ForeignKey(nameof(Manv))]
        public virtual Nhanvien NhanVien { get; set; }
        [ForeignKey(nameof(Map))]
        public virtual Phong Phong { get; set; }
    }
}
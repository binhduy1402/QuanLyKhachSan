
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Data
{
    [Table("CT_HOADON")]
    public partial class CtHoadon
    {
        [Key]
        [Column("MAHD", Order = 1)]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Key]
        [Column("MAP", Order = 2)]
        [StringLength(5)]
        public string Map { get; set; }
        [Column("NGAYDI", TypeName = "datetime")]
        public DateTime Ngaydi { get; set; }

        [ForeignKey(nameof(Mahd))]
        public virtual Hoadon HoaDon { get; set; }
        [ForeignKey(nameof(Map))]
        public virtual Phong Phong { get; set; }
    }
}
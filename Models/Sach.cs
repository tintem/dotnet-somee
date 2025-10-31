using baithi2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baithi2.Models
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public int Masach { get; set; }

        [Required]
        public string TenSach { get; set; } = default!;

        [Range(0, 9999)]
        public decimal GiaBan { get; set; }

        [Display(Name = "Chủ Đề")]
        public int MaChuDe { get; set; }

        [ForeignKey("MaNXB")]
        public ChuDe? ChuDe { get; set; }
    }
}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baithi2.Models
{
    [Table("ChuDe")]
    public class ChuDe
    {
       
        [Key]
        public int MaChuDe { get; set; }

        [Required, StringLength(100)]
        public string TenChuDe { get; set; } = default!;

        public ICollection<Sach>? Sachs { get; set; }
    }
}

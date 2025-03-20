using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _90phut.Models
{
    [Table("Goods")]
    public class HangHoa
    {
        [Key]
        [StringLength(9)]
        public string MaHangHoa { get; set; }

        [Required]
        [Unicode(true)]
        public string TenHangHoa { get; set; }

        public int SoLuong { get; set; }

        public string? GhiChu { get; set; }
    }
}

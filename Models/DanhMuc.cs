using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TenDanhMuc { get; set; } = string.Empty;

        public bool TrangThai { get; set; } = true;

        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}

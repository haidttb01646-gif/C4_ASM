using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TenSanPham { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? GiaGiam { get; set; }

        public int DanhMucId { get; set; }

        public bool LaCombo { get; set; }

        public int SoLuongTon { get; set; } = 100;

        public bool TrangThai { get; set; } = true;

        [ForeignKey("DanhMucId")]
        public DanhMuc DanhMuc { get; set; } = null!;

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

        // Navigation cho combo
        public ICollection<SanPhamCombo> ComboChiTiet { get; set; } = new List<SanPhamCombo>();
        public ICollection<SanPhamCombo> SanPhamTrongCombo { get; set; } = new List<SanPhamCombo>();
    }
}

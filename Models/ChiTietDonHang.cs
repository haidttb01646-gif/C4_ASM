using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã chi tiết")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã đơn hàng")]
        public int DonHangId { get; set; }

        [Required]
        [Display(Name = "Mã sản phẩm")]
        public int SanPhamId { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giảm giá")]
        public decimal? GiamGia { get; set; }

        // Navigation
        [ForeignKey("DonHangId")]
        public virtual DonHang DonHang { get; set; } = null!;

        [ForeignKey("SanPhamId")]
        public virtual SanPham SanPham { get; set; } = null!;
    }
}
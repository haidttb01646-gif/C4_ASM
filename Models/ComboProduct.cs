using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("ComboProducts")]
    public class ComboProduct
    {
        [Required]
        public int ComboId { get; set; } // ProductId của combo

        [Required]
        public int ProductId { get; set; } // ProductId của sản phẩm trong combo

        [Required]
        public int Quantity { get; set; } = 1;

        // Navigation properties
        [ForeignKey("ComboId")]
        public virtual Product Combo { get; set; } = null!;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
    }
}
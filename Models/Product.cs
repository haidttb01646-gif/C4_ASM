using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 1000000)]
        public decimal? DiscountPrice { get; set; }

        [Required]
        public string ImageUrl { get; set; } = "/images/default-food.jpg";

        public bool IsAvailable { get; set; } = true;
        public bool IsCombo { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign keys
        public int CategoryId { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ComboProduct> ComboProducts { get; set; } = new List<ComboProduct>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
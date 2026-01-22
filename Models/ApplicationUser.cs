using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FastFoodShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? ProfilePicture { get; set; }

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
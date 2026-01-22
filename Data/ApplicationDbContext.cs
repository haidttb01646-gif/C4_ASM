using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FastFoodShop.Models;

namespace FastFoodShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ComboProduct> ComboProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite key
            builder.Entity<ComboProduct>()
                .HasKey(cp => new { cp.ComboId, cp.ProductId });

            // Relationships
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ComboProduct>()
                .HasOne(cp => cp.Combo)
                .WithMany(p => p.ComboProducts)
                .HasForeignKey(cp => cp.ComboId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ComboProduct>()
                .HasOne(cp => cp.Product)
                .WithMany()
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Fixed seed time
            var seedTime = new DateTime(2026, 01, 01);

            // Seed Categories
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Burgers", Description = "Various types of burgers", IsActive = true, CreatedAt = seedTime },
                new Category { CategoryId = 2, Name = "Pizza", Description = "Italian style pizza", IsActive = true, CreatedAt = seedTime },
                new Category { CategoryId = 3, Name = "Drinks", Description = "Cold and hot beverages", IsActive = true, CreatedAt = seedTime },
                new Category { CategoryId = 4, Name = "Combos", Description = "Special meal packages", IsActive = true, CreatedAt = seedTime }
            );

            // Seed Products
            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Classic Burger", Description = "Beef burger with cheese and vegetables", Price = 8.99m, ImageUrl = "/images/burger1.jpg", IsAvailable = true, IsCombo = false, CategoryId = 1, CreatedAt = seedTime },
                new Product { ProductId = 2, Name = "Family Combo", Description = "4 Burgers + 4 Drinks + 1 Large Fries", Price = 35.99m, DiscountPrice = 29.99m, ImageUrl = "/images/combo1.jpg", IsAvailable = true, IsCombo = true, CategoryId = 4, CreatedAt = seedTime },
                new Product { ProductId = 3, Name = "Pepsi Cola", Description = "Cold Pepsi 330ml", Price = 2.50m, ImageUrl = "/images/pepsi.jpg", IsAvailable = true, IsCombo = false, CategoryId = 3, CreatedAt = seedTime },
                new Product { ProductId = 4, Name = "Margherita Pizza", Description = "Classic Italian pizza with tomato and mozzarella", Price = 12.99m, ImageUrl = "/images/pizza1.jpg", IsAvailable = true, IsCombo = false, CategoryId = 2, CreatedAt = seedTime },
                new Product { ProductId = 5, Name = "Chicken Nuggets", Description = "Crispy chicken nuggets with dipping sauce", Price = 6.99m, ImageUrl = "/images/nuggets.jpg", IsAvailable = true, IsCombo = false, CategoryId = 1, CreatedAt = seedTime }
            );

            // Seed ComboProducts
            builder.Entity<ComboProduct>().HasData(
                new ComboProduct { ComboId = 2, ProductId = 1, Quantity = 4 },
                new ComboProduct { ComboId = 2, ProductId = 3, Quantity = 4 },
                new ComboProduct { ComboId = 2, ProductId = 5, Quantity = 1 }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using FastFoodShop.Models;

namespace FastFoodShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<SanPhamCombo> SanPhamCombos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Khóa chính kép cho bảng combo
            builder.Entity<SanPhamCombo>()
                .HasKey(x => new { x.MaCombo, x.MaSanPham });

            builder.Entity<SanPhamCombo>()
                .HasOne(x => x.Combo)
                .WithMany(s => s.ComboChiTiet)
                .HasForeignKey(x => x.MaCombo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SanPhamCombo>()
                .HasOne(x => x.SanPham)
                .WithMany(s => s.SanPhamTrongCombo)
                .HasForeignKey(x => x.MaSanPham)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SanPham>()
                .HasOne(s => s.DanhMuc)
                .WithMany(d => d.SanPhams)
                .HasForeignKey(s => s.DanhMucId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DonHang>()
                .HasOne(d => d.NguoiDung)
                .WithMany(n => n.DonHangs)
                .HasForeignKey(d => d.NguoiDungId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ChiTietDonHang>()
                .HasOne(c => c.DonHang)
                .WithMany(d => d.ChiTietDonHangs)
                .HasForeignKey(c => c.DonHangId);

            builder.Entity<ChiTietDonHang>()
                .HasOne(c => c.SanPham)
                .WithMany(s => s.ChiTietDonHangs)
                .HasForeignKey(c => c.SanPhamId);

            // Seed danh mục
            builder.Entity<DanhMuc>().HasData(
                new DanhMuc { Id = 1, TenDanhMuc = "Burger" },
                new DanhMuc { Id = 2, TenDanhMuc = "Pizza" },
                new DanhMuc { Id = 3, TenDanhMuc = "Đồ uống" },
                new DanhMuc { Id = 4, TenDanhMuc = "Combo" }
            );

            // Seed sản phẩm
            builder.Entity<SanPham>().HasData(
                new SanPham
                {
                    Id = 1,
                    TenSanPham = "Burger Bò Phô Mai",
                    Gia = 45000,
                    GiaGiam = 39000,
                    DanhMucId = 1,
                    LaCombo = false
                },
                new SanPham
                {
                    Id = 2,
                    TenSanPham = "Pizza Hải Sản",
                    Gia = 120000,
                    DanhMucId = 2,
                    LaCombo = false
                },
                new SanPham
                {
                    Id = 3,
                    TenSanPham = "Combo Gia Đình",
                    Gia = 250000,
                    GiaGiam = 199000,
                    DanhMucId = 4,
                    LaCombo = true
                }
            );
        }
    }
}

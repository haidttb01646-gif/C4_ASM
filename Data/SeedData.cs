using FastFoodShop.Models;

namespace FastFoodShop.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.NguoiDungs.Any()) return;

            context.NguoiDungs.AddRange(
                new NguoiDung
                {
                    Email = "admin@fastfood.com",
                    MatKhau = "123456",
                    HoTen = "Quản trị",
                    VaiTro = "QuanTri"
                },
                new NguoiDung
                {
                    Email = "khach@test.com",
                    MatKhau = "123456",
                    HoTen = "Khách hàng"
                }
            );

            context.SaveChanges();
        }
    }
}

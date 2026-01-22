using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }

        [Required] public string Email { get; set; } = string.Empty;
        [Required] public string MatKhau { get; set; } = string.Empty;
        [Required] public string HoTen { get; set; } = string.Empty;
        [Required] public string SoDienThoai { get; set; } = "0000000000";
        [Required] public string DiaChi { get; set; } = "Chưa cập nhật";

        public DateTime NgaySinh { get; set; } = new DateTime(2000,1,1);

        public string VaiTro { get; set; } = "KhachHang";

        public ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
    }
}

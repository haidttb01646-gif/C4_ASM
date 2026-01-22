using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int Id { get; set; }

        public int NguoiDungId { get; set; }

        public string MaDon { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();

        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        public string DiaChiGiaoHang { get; set; } = string.Empty;
        public string SoDienThoaiNhan { get; set; } = string.Empty;

        public string TrangThai { get; set; } = "ChoXacNhan";

        [ForeignKey("NguoiDungId")]
        public NguoiDung NguoiDung { get; set; } = null!;

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace FastFoodShop.Models
{
    [Table("SanPhamCombo")]
    public class SanPhamCombo
    {
        public int MaCombo { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; } = 1;

        [ForeignKey(nameof(MaCombo))]
        public SanPham Combo { get; set; } = null!;

        [ForeignKey(nameof(MaSanPham))]
        public SanPham SanPham { get; set; } = null!;
    }
}

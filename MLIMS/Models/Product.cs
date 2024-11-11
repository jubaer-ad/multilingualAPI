using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLIMS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        public PublishedStatus PublishedStatus { get; set; } = PublishedStatus.StatusThree;
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductTranslation> ProductTranslations { get; set; }
    }
}

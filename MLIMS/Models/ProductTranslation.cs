using System.ComponentModel.DataAnnotations;

namespace MLIMS.Models
{
    public class ProductTranslation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string LanguageCode { get; set; } = "en";
        public Language Language { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
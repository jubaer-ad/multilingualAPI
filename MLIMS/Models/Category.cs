namespace MLIMS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public PublishedStatus PublishedStatus { get; set; }
        public ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
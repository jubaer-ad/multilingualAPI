using MLIMS.Data;
using MLIMS.Models;

namespace MLIMS.Helper
{
    public static class DbSeeder
    {
        public static void Seed(MLIMSDbContext context)
        {
            // Add Languages
            var english = new Language { LanguageCode = "en", LanguageName = "English" };
            var french = new Language { LanguageCode = "fr", LanguageName = "French" };

            context.Languages.AddRange(english, french);
            context.SaveChanges();

            // Add Products
            var product1 = new Product { Price = 5.5m,  };
            var product2 = new Product { Price = 7.99m, PublishedStatus = PublishedStatus.StatusTwo };

            context.Products.AddRange(product1, product2);
            context.SaveChanges();

            // Add Product Translations
            context.ProductTranslations.AddRange(
                new ProductTranslation { ProductId = product1.Id, LanguageCode = "en", Name = "Product 1", Description = "Description of Product 1" },
                new ProductTranslation { ProductId = product1.Id, LanguageCode = "fr", Name = "Produit 1", Description = "Description du Produit 1" },
                new ProductTranslation { ProductId = product2.Id, LanguageCode = "en", Name = "Product 2", Description = "Description of Product 2" },
                new ProductTranslation { ProductId = product2.Id, LanguageCode = "fr", Name = "Produit 2", Description = "Description du Produit 2" }
            );

            // Add Categories
            var category1 = new Category { PublishedStatus = PublishedStatus.StatusOne };
            var category2 = new Category { PublishedStatus = PublishedStatus.StatusThree };

            context.Categories.AddRange(category1, category2);
            context.SaveChanges();

            // Add Category Translations
            context.CategoryTranslations.AddRange(
                new CategoryTranslation { CategoryId = category1.Id, LanguageCode = "en", Name = "Category 1" },
                new CategoryTranslation { CategoryId = category1.Id, LanguageCode = "fr", Name = "Catégorie 1" },
                new CategoryTranslation { CategoryId = category2.Id, LanguageCode = "en", Name = "Category 2" },
                new CategoryTranslation { CategoryId = category2.Id, LanguageCode = "fr", Name = "Catégorie 2" }
            );

            // Add Product-Category associations
            context.ProductCategories.AddRange(
                new ProductCategory { ProductId = product1.Id, CategoryId = category1.Id },
                new ProductCategory { ProductId = product2.Id, CategoryId = category2.Id }
            );

            context.SaveChanges();
        }
    }
}

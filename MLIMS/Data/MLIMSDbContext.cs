using Microsoft.EntityFrameworkCore;
using MLIMS.Models;
using System.Reflection.Emit;

namespace MLIMS.Data
{
    public class MLIMSDbContext : DbContext
    {
        public MLIMSDbContext(DbContextOptions<MLIMSDbContext> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ProductCategory>().
                HasKey(pc => new { pc.ProductId, pc.CategoryId });

            mb.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            mb.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);


            mb.Entity<ProductTranslation>()
                .HasKey(pt => pt.Id);
            mb.Entity<ProductTranslation>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTranslations)
                .HasForeignKey(pt => pt.ProductId);
            mb.Entity<ProductTranslation>()
                .HasOne(pt => pt.Language)
                .WithMany()
                .HasForeignKey(pt => pt.LanguageCode);


            mb.Entity<CategoryTranslation>()
                .HasKey(ct => ct.Id);
            mb.Entity<CategoryTranslation>()
                .HasOne(ct => ct.Category)
                .WithMany(c => c.CategoryTranslations)
                .HasForeignKey(ct => ct.CategoryId);
            mb.Entity<CategoryTranslation>()
                .HasOne(ct => ct.Language)
                .WithMany()
                .HasForeignKey(ct => ct.LanguageCode);


            //mb.Entity<Language>()
            //    .HasData(
            //    new () { LanguageCode = "en", LanguageName = "English" },
            //    new () { LanguageCode = "fr", LanguageName = "French" }
            //    );

            //mb.Entity<Product>()
            //    .HasData(
            //    new() { Id = 1, Price = 5.5m, StockAmount = 10, PublishedStatus = PublishedStatus.StatusOne },
            //    new() { Id = 2, Price = 53.5m, StockAmount = 17, PublishedStatus = PublishedStatus.StatusThree }
            //    );

            //mb.Entity<Category>()
            //    .HasData(
            //    new() { Id = 1, PublishedStatus = PublishedStatus.StatusFour },
            //    new() { Id = 2, PublishedStatus = PublishedStatus.StatusFour }
            //    );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MLIMS.Data;
using MLIMS.Helper;
using MLIMS.Models;

namespace MLIMS.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        private readonly MLIMSDbContext _ctx;

        public ProductRepository(MLIMSDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<IEnumerable<object>> GetAllAsync()
        {
            var langCode = Misc.GetLanguageCode();
            //langCode = "fr";
            var data = await _ctx.Set<Product>()
                .Include(p => p.ProductTranslations.Where(t => t.LanguageCode == langCode))
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ThenInclude(c => c.CategoryTranslations
                    .Where(ct => ct.LanguageCode == langCode))
                .Select(p => new
                {
                    p.Id,
                    Categories = p.ProductCategories.Select(pc => new
                    {
                        pc.Category.Id,
                        Translation = pc.Category.CategoryTranslations.Where(ct => ct.LanguageCode == langCode).ToList()
                    }),
                    Translations = p.ProductTranslations.Where(pt => pt.LanguageCode == langCode).ToList()
                    
                })
                .ToListAsync();

            return data;
        }



        public override async Task<object?> GetByIdAsync(int id, string langCode)
        {
            return await _ctx.Set<Product>()
                .Where(p => p.Id == id)
                .Include(p => p.ProductTranslations.Where(t => t.LanguageCode == langCode))
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ThenInclude(c => c.CategoryTranslations
                    .Where(ct => ct.LanguageCode == langCode))
                .Select(p => new
                {
                    p.Id,
                    Categories = p.ProductCategories.Select(pc => new
                    {
                        pc.Category.Id,
                        Translation = pc.Category.CategoryTranslations.Where(ct => ct.LanguageCode == langCode).ToList()
                    }),
                    Translations = p.ProductTranslations.Where(pt => pt.LanguageCode == langCode).ToList()

                })
                .FirstOrDefaultAsync();
        }

    }
}

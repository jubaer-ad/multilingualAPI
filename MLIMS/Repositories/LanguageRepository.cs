using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLIMS.Data;
using MLIMS.Models;

namespace MLIMS.Repositories
{
    public class LanguageRepository : Repository<Language>
    {
        private readonly MLIMSDbContext _ctx;

        public LanguageRepository(MLIMSDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<string> CheckAndResolveByCodeAsync(string langCode)
        {
            if (langCode == null) return "en";
            var res = await _ctx.Languages.Where(l => l.IsActive && l.LanguageCode == langCode).FirstOrDefaultAsync();
            if (res == null)
            {
                return "en";
            }
            return res.LanguageCode;
        }
    }
}

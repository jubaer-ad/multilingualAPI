using MLIMS.Data;
using MLIMS.Models;

namespace MLIMS.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(MLIMSDbContext ctx) : base(ctx)
        {
        }
    }
}

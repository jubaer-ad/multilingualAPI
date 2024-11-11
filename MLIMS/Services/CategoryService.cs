using MLIMS.Models;
using MLIMS.Repositories;

namespace MLIMS.Services
{
    public class CategoryService : Service<Category>
    {
        public CategoryService([FromKeyedServices("CategoryRepository")] Repository<Category> repository) : base(repository)
        {
        }
    }
}

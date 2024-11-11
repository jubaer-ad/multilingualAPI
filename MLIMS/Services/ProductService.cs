using MLIMS.Models;
using MLIMS.Repositories;

namespace MLIMS.Services
{
    public class ProductService : Service<Product>
    {
        public ProductService([FromKeyedServices("ProductRepository")] Repository<Product> repository) : base(repository)
        {
        }
    }
}

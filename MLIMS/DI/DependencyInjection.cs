using MLIMS.Models;
using MLIMS.Repositories;
using MLIMS.Services;

namespace MLIMS.DI
{
    public static class DependencyInjection
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            services.AddKeyedScoped<Repository<Product>, ProductRepository>("ProductRepository");
            services.AddKeyedScoped<Service<Product>, ProductService>("ProductService");

            services.AddKeyedScoped<Repository<Category>, CategoryRepository>("CategoryRepository");
            services.AddKeyedScoped<Service<Category>, CategoryService>("CategoryService");
            services.AddKeyedScoped<LanguageRepository>("LangRepo");
        }
    }
}

using MLIMS.Models;
using MLIMS.Repositories;

namespace MLIMS.Services
{
    public class LanguageService : Service<Language>
    {
        public LanguageService(Repository<Language> repository) : base(repository)
        {
        }
    }
}

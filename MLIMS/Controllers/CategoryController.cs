using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLIMS.Models;
using MLIMS.Services;

namespace MLIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Service<Category> _services;

        public CategoryController([FromKeyedServices("CategoryService")] Service<Category> services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }
    }
}

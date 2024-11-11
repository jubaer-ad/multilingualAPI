using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLIMS.Models;
using MLIMS.Services;

namespace MLIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Service<Product> _service;

        public ProductController([FromKeyedServices("ProductService")] Service<Product> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("${langCode}/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromRoute] string langCode)
        {
            return Ok(await _service.GetByIdAsync(id, langCode));
        }
    }
}

using FeatureTogglingEnahancementWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FeatureTogglingEnahancementWebApi.Controllers
{
    [ApiController]
    [Route("features")]
    public class FeatureController : ControllerBase
    {
        private readonly IRepository repo;
        public FeatureController(IRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeaturesAsync()
        {
            return Ok(await repo.GetAllFeaturesAsync());
        }
        [HttpGet("(name)")]
        public async Task<IActionResult> GetFeaturesByNameAsync(string name)
        {
            var feature = await repo.GetFeaturesByNameAsync(name);
            if (feature == null) return BadRequest();
            return Ok(feature);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon_API.Services;

namespace Pokemon_API.Controllers
{
    [ApiController]
    [Route("info")]
    public class PokemonInfoController : ControllerBase
    {
        private readonly ILogger<PokemonInfoController> _logger;
        private readonly IPokemonInfoService _pokemonInfoService;

        public PokemonInfoController(ILogger<PokemonInfoController> logger, IPokemonInfoService pokemonInfoService)
        {
            _logger = logger;
            _pokemonInfoService = pokemonInfoService;
        }

        /// <summary>
        /// Get Pokemon Info
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult> GetInfo()
        {
            _logger.LogDebug("---Controller---GetInfo---");

            var response = await _pokemonInfoService.GetPokemonInfo();
            return Ok(response);
        }
    }
}

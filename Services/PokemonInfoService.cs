using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pokemon_API.Models.InternalModels;
using Pokemon_API.Models.Response;

namespace Pokemon_API.Services
{
    public interface IPokemonInfoService
    {
        Task<List<PokemonInfoResponse>> GetPokemonInfo();
    }

    public class PokemonInfoService : IPokemonInfoService
    {
        private readonly ILogger<PokemonInfoService> _logger;

        public PokemonInfoService(ILogger<PokemonInfoService> logger)
        {
            _logger = logger;
        }

        // Simulate Data from Database
        private static readonly List<PokemonInfoInternalModels> PokemonInfoFromDatabase = new List<PokemonInfoInternalModels>
        {
            new PokemonInfoInternalModels{ Generation = 1, Name = "Pikachu", Type = new[] {"Electric"}},
            new PokemonInfoInternalModels{ Generation = 1, Name = "Eevee", Type = new[] {"Normal"}},
            new PokemonInfoInternalModels{ Generation = 1, Name = "Charmander", Type = new[] {"Fire"}},
            new PokemonInfoInternalModels{ Generation = 1, Name = "Bulbasaur", Type = new[] {"Grass", "Poison"}},
            new PokemonInfoInternalModels{ Generation = 1, Name = "Squirtle", Type = new[] {"Water"}},
            new PokemonInfoInternalModels{ Generation = 2, Name = "Chikorita", Type = new[] {"Grass"}},
            new PokemonInfoInternalModels{ Generation = 2, Name = "Cyndaquil", Type = new[] {"Fire"}},
            new PokemonInfoInternalModels{ Generation = 2, Name = "Totodile", Type = new[] {"Water"}},
        };

        public Task<List<PokemonInfoResponse>> GetPokemonInfo()
        {
            _logger.LogDebug("---Service---GetPokemonInfo---");

            var response = new List<PokemonInfoResponse>();
            var uniqueGenerations = PokemonInfoFromDatabase.Select(x => x.Generation).Distinct();

            response = uniqueGenerations.Select(x =>
            new PokemonInfoResponse
            {
                Generation = $"Gen {x}",
                PokemonInfos = PokemonInfoFromDatabase.Where(y => y.Generation == x).Select(x => new PokemonInfo
                {
                    Name = x.Name,
                    Type = string.Join(", ", x.Type),
                }),
            }).ToList();

            return Task.Run(() => response);
        }
    }
}

using System.Collections.Generic;

namespace Pokemon_API.Models.Response
{
    public class PokemonInfoResponse
    {
        public string Generation { get; set; }
        public IEnumerable<PokemonInfo> PokemonInfos { get; set; }
    }

    public class PokemonInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

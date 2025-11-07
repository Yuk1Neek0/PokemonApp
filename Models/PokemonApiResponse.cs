using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonApp.Models
{
    public class PokemonApiResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}

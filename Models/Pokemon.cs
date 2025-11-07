using SQLite;
using System.Text.Json.Serialization;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        // Additional property to store Pokemon number extracted from URL
        public int PokemonNumber { get; set; }
    }
}

using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public class PokemonApiService : IPokemonApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";

        public PokemonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetPokemonListAsync(int limit = 20)
        {
            try
            {
                var url = $"{BaseUrl}?limit={limit}";
                var response = await _httpClient.GetFromJsonAsync<PokemonApiResponse>(url);

                if (response?.Results != null)
                {
                    // Extract Pokemon number from URL for better display
                    foreach (var pokemon in response.Results)
                    {
                        if (!string.IsNullOrEmpty(pokemon.Url))
                        {
                            var urlParts = pokemon.Url.TrimEnd('/').Split('/');
                            if (int.TryParse(urlParts[^1], out int pokemonNumber))
                            {
                                pokemon.PokemonNumber = pokemonNumber;
                            }
                        }
                    }
                    return response.Results;
                }

                return new List<Pokemon>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Pokemon data: {ex.Message}");
                throw;
            }
        }
    }
}

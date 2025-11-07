using PokemonApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public interface IPokemonRepository
    {
        Task InitializeAsync();
        Task<List<Pokemon>> GetAllAsync();
        Task<int> InsertAllAsync(List<Pokemon> pokemons);
        Task<int> DeleteAllAsync();
    }
}

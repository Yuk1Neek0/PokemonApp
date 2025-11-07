using PokemonApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public interface IPokemonApiService
    {
        Task<List<Pokemon>> GetPokemonListAsync(int limit = 20);
    }
}

using PokemonApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PokemonApp.Services
{
    public class PokemonRepository : IPokemonRepository
    {
        private SQLiteAsyncConnection _database;
        private readonly string _databasePath;

        public PokemonRepository()
        {
            // Set the database path in the app's local data folder
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _databasePath = Path.Combine(appDataPath, "pokemon.db3");
        }

        public async Task InitializeAsync()
        {
            if (_database != null)
                return;

            _database = new SQLiteAsyncConnection(_databasePath);
            await _database.CreateTableAsync<Pokemon>();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            await InitializeAsync();
            return await _database.Table<Pokemon>().ToListAsync();
        }

        public async Task<int> InsertAllAsync(List<Pokemon> pokemons)
        {
            await InitializeAsync();
            // First, clear existing data to avoid duplicates
            await DeleteAllAsync();
            return await _database.InsertAllAsync(pokemons);
        }

        public async Task<int> DeleteAllAsync()
        {
            await InitializeAsync();
            return await _database.DeleteAllAsync<Pokemon>();
        }
    }
}

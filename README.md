# Pokemon Data Manager

A .NET MAUI Blazor Hybrid application that demonstrates the integration of REST API data with local SQLite database storage using the Repository Pattern and Dependency Injection.

## Project Overview

This application fetches Pokemon data from a public API, stores it in a local SQLite database, and displays it in the UI. It showcases:

- **Network Requests**: Using HttpClient to fetch data from REST APIs
- **JSON Deserialization**: Converting API responses into C# objects
- **Repository Pattern**: Clean separation of data access logic
- **Dependency Injection**: Loose coupling and testable architecture
- **Asynchronous Programming**: Async/await for non-blocking operations
- **SQLite Database**: Local persistent storage

## API Used

This application uses the **PokéAPI**, a free and open RESTful API for Pokemon data.

**API Documentation**: [https://pokeapi.co/docs/v2](https://pokeapi.co/docs/v2)

**Endpoint Used**: `https://pokeapi.co/api/v2/pokemon?limit=20`

The PokéAPI is completely free and does not require authentication. It returns data in JSON format containing information about Pokemon, including their names, URLs, and other attributes.

## Features

- **Fetch and Save Data Button**: Click to perform the complete data flow
- **API Integration**: Fetches 20 Pokemon from the PokéAPI
- **Database Storage**: Saves fetched data to local SQLite database
- **Data Display**: Shows Pokemon data retrieved from the database in a table
- **Status Messages**: Real-time feedback on each operation step
- **Error Handling**: Displays any errors that occur during operations

## Architecture

### Models
- `Pokemon.cs`: Data model representing a Pokemon with SQLite attributes
- `PokemonApiResponse.cs`: Response model for deserializing API JSON

### Services
- **IPokemonApiService** / **PokemonApiService**: Handles HTTP requests to PokéAPI
- **IPokemonRepository** / **PokemonRepository**: Manages SQLite database operations

### Dependency Injection
Services are registered in `MauiProgram.cs`:
- HttpClient for API service (AddHttpClient)
- Repository as Singleton (AddSingleton)

### UI
- `Home.razor`: Main page with button to trigger data flow and display results

## Data Flow

1. User clicks "Fetch and Save Data" button
2. App calls `PokemonApiService.GetPokemonListAsync()` to fetch data from API
3. App calls `PokemonRepository.InsertAllAsync()` to save data to SQLite database
4. App calls `PokemonRepository.GetAllAsync()` to retrieve data from database
5. App displays retrieved data in a table

## Technologies Used

- .NET MAUI (Multi-platform App UI)
- Blazor (Web UI framework)
- SQLite (Local database)
- HttpClient (HTTP requests)
- System.Text.Json (JSON serialization)

## NuGet Packages

- `sqlite-net-pcl`: SQLite database library for .NET
- `SQLitePCLRaw.bundle_green`: SQLite platform dependencies

## Building and Running

1. Open the solution in Visual Studio 2022 or later
2. Ensure you have .NET 9.0 SDK or later installed
3. Select your target platform (Android, iOS, Windows, or MacCatalyst)
4. Press F5 to build and run

## Requirements Met

- [x] Connects to a public API and successfully deserializes the JSON response
- [x] Implements a separate service for API calls (PokemonApiService)
- [x] Implements a separate service for database operations (PokemonRepository)
- [x] Correctly registers both services for Dependency Injection in MauiProgram.cs
- [x] Saves the data from the API into a local SQLite database
- [x] Retrieves the data from the database and displays it in the UI
- [x] Includes a README.md file with a link to the chosen API
- [x] Ready to be committed to a GitHub repository

## License

This project is for educational purposes as part of a course assignment.

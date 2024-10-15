using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using MediaLibrary.Domain.Services;

namespace MediaLibrary.Api.Config;

/// <summary>
/// Static class that provides methods to register application services in DI container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers services for the application in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection where services are registered.</param>
    /// <param name="configuration">The configuration settings for the application.</param>
    /// <returns>Updated IServiceCollection with registered services.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ISongService, SongService>();

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryInMemory<>));
        services.AddSingleton<IRepositoryArtist, RepositoryInMemoryArtist>();
        services.AddSingleton<IRepositoryAlbum, RepositoryInMemoryAlbum>();
        services.AddSingleton<IRepositoryGenre, RepositoryInMemoryGenre>();
        services.AddSingleton<IRepositorySong, RepositoryInMemorySong>();

        services.AddSingleton(new List<Artist>());
        services.AddSingleton(new List<Album>());
        services.AddSingleton(new List<Genre>());
        services.AddSingleton(new List<Song>());

        return services;
    }
}

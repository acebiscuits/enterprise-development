using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Repositories;
using MediaLibrary.Domain.Services;
using Microsoft.EntityFrameworkCore;

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
    /// <returns>Updated IServiceCollection with registered services.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ISongService, SongService>();

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryInDb<>));
        services.AddScoped<IRepositoryArtist, RepositoryInDbArtist>();
        services.AddScoped<IRepositoryAlbum, RepositoryInDbAlbum>();
        services.AddScoped<IRepositoryGenre, RepositoryInDbGenre>();
        services.AddScoped<IRepositorySong, RepositoryInDbSong>();

        return services;
    }
}

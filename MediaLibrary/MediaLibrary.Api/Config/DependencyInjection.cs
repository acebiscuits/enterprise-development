using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;
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

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryInDB<>));
        services.AddScoped<IRepositoryArtist, RepositoryInDBArtist>();
        services.AddScoped<IRepositoryAlbum, RepositoryInDBAlbum>();
        services.AddScoped<IRepositoryGenre, RepositoryInDBGenre>();
        services.AddScoped<IRepositorySong, RepositoryInDBSong>();

        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"),
                new MySqlServerVersion(new Version(8, 0, 32))), ServiceLifetime.Singleton);

        return services;
    }
}

using MediaLibrary.Domain.Repositories;
using MediaLibrary.Domain.Services;

namespace MediaLibrary.Api.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<IAlbumService, AlbumService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ISongService, SongService>();

        services.AddScoped(typeof(IRepositoryInMemory<>), typeof(RepositoryInMemory<>));
        services.AddSingleton<IRepositoryInMemoryArtist, RepositoryInMemoryArtist>();
        services.AddSingleton<IRepositoryInMemoryAlbum, RepositoryInMemoryAlbum>();
        services.AddSingleton<IRepositoryInMemoryGenre, RepositoryInMemoryGenre>();
        services.AddSingleton<IRepositoryInMemorySong, RepositoryInMemorySong>();

        return services;
    }
}

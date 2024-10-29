using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;
/// <summary>
/// Service for managing artist entities. Provides operations for adding, updating, retrieving, and deleting artists.
/// </summary>
public class ArtistService : IArtistService
{
    private readonly IRepositoryArtist _repositoryInDBArtist;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtistService"/> class.
    /// </summary>
    /// <param name="repositoryInDBArtist">Repository for managing artist data.</param>
    public ArtistService(IRepositoryArtist repositoryInDBArtist)
    {
        _repositoryInDBArtist = repositoryInDBArtist;
    }

    /// <inheritdoc />
    public async Task<ArtistDto?> GetById(int id)
    {
        var artist = await _repositoryInDBArtist.GetById(id);
        if (artist == null)
        {
            return null;
        }

        return new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        };
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ArtistDto>> GetAll()
    {
        var artists = await _repositoryInDBArtist.GetAll();
        return artists.Select(artist => new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    /// <inheritdoc />
    public async Task Add(ArtistCreateDto artist)
    {
        await _repositoryInDBArtist.Add(new Artist
        {
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    /// <inheritdoc />
    public async Task Update(ArtistDto artistDto)
    {
        var existingArtist = await _repositoryInDBArtist.GetById(artistDto.Id);
        if (existingArtist != null)
        {
            await _repositoryInDBArtist.Update(new Artist
            {
                Id = artistDto.Id,
                Name = artistDto.Name,
                AlbumIds = artistDto.AlbumIds,
                GenreIds = artistDto.GenreIds,
                Description = artistDto.Description ?? existingArtist.Description
            });
        }
    }

    /// <inheritdoc />
    public async Task Delete(int id)
    {
        await _repositoryInDBArtist.Delete(id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ArtistDto>> GetMaxAlbumsCountArtists()
    {
        var artists = await _repositoryInDBArtist.GetAll();
        var maxAlbumCount = artists.Max(a => a.AlbumIds.Count);

        // Фильтрация и преобразование в ArtistDto
        return artists
            .Where(a => a.AlbumIds.Count == maxAlbumCount)
            .Select(artist => new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Description = artist.Description,
                AlbumIds = artist.AlbumIds,
                GenreIds = artist.GenreIds
            });
    }
}

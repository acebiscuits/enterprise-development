using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;
/// <summary>
/// Service for managing artist entities. Provides operations for adding, updating, retrieving, and deleting artists.
/// </summary>
public class ArtistService : IArtistService
{
    private readonly IRepositoryArtist _repositoryInMemoryArtist;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtistService"/> class.
    /// </summary>
    /// <param name="repositoryInMemoryArtist">Repository for managing artist data.</param>
    public ArtistService(IRepositoryArtist repositoryInMemoryArtist)
    {
        _repositoryInMemoryArtist = repositoryInMemoryArtist;
    }

    /// <inheritdoc />
    public ArtistDto? GetById(int id)
    {
        var artist = _repositoryInMemoryArtist.GetById(id);
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
    public IEnumerable<ArtistDto> GetAll()
    {
        var artists = _repositoryInMemoryArtist.GetAll();
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
    public void Add(ArtistCreateDto artist)
    {
        _repositoryInMemoryArtist.Add(new Artist
        {
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    /// <inheritdoc />
    public void Update(ArtistDto artist)
    {
        var existingArtist = _repositoryInMemoryArtist.GetById(artist.Id);
        if (existingArtist != null)
        {
            existingArtist.Name = artist.Name;
            existingArtist.AlbumIds = artist.AlbumIds;
            existingArtist.GenreIds = artist.GenreIds;
            existingArtist.Description = artist.Description ?? existingArtist.Description;
        }
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        _repositoryInMemoryArtist.Delete(id);
    }

    /// <inheritdoc />
    public IEnumerable<ArtistDto> GetMaxAlbumsCountArtists()
    {
        return _repositoryInMemoryArtist
            .GetAll()
            .Where(a => a.AlbumIds.Count == _repositoryInMemoryArtist.GetAll().Max(a => a.AlbumIds.Count))
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

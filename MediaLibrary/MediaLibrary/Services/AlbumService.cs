using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service for managing album entities. Provides operations for adding, updating, retrieving, and deleting albums.
/// </summary>
public class AlbumService : IAlbumService
{
    private readonly IRepositoryAlbum _repositoryAlbum;
    private readonly IRepositorySong _repositorySong;

    /// <summary>
    /// Initializes a new instance of the <see cref="AlbumService"/> class.
    /// </summary>
    /// <param name="repositoryAlbum">Repository for managing album data.</param>
    /// <param name="repositorySong">Repository for managing song data.</param>
    public AlbumService(IRepositoryAlbum repositoryAlbum, IRepositorySong repositorySong)
    {
        _repositoryAlbum = repositoryAlbum;
        _repositorySong = repositorySong;
    }

    /// <inheritdoc />
    public async Task<AlbumDto?> GetById(int id)
    {
        var album = await _repositoryAlbum.GetById(id);
        if (album == null)
        {
            return null;
        }
        return new AlbumDto
        {
            Id = album.Id,
            ArtistId = album.ArtistId,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds,
            Title = album.Title
        };
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AlbumDto>> GetAll()
    {
        var albums = await _repositoryAlbum.GetAll();
        return albums.Select(album => new AlbumDto
        {
            Id = album.Id,
            ArtistId = album.ArtistId,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds,
            Title = album.Title
        });
    }

    /// <inheritdoc />
    public async Task Add(AlbumCreateDto album)
    {
        await _repositoryAlbum.Add(new Album
        {
            ArtistId = album.ArtistId,
            Title = album.Title,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds
        });
    }

    /// <inheritdoc />
    public async Task Update(AlbumDto albumDto)
    {
        var existingAlbum = await _repositoryAlbum.GetById(albumDto.Id);
        if (existingAlbum != null)
        {
            await _repositoryAlbum.Update(new Album
            {
                Id = albumDto.Id,
                ArtistId = albumDto.ArtistId ?? existingAlbum.ArtistId,
                ReleaseDate = albumDto.ReleaseDate ?? existingAlbum.ReleaseDate,
                SongIds = albumDto.SongIds,
                Title = albumDto.Title ?? existingAlbum.Title
            });
        }
    }

    /// <inheritdoc />
    public async Task Delete(int id)
    {
        await _repositoryAlbum.Delete(id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AlbumInfoAndDurationDto>> GetInfoAboutAlbumsInCertainYear(int year)
    {

        var albums = await _repositoryAlbum.GetAll();

        return albums
            .Where(a => a.ReleaseDate == year)
            .Select(a => new AlbumInfoAndDurationDto
            {
                ArtistId = a.ArtistId,
                Title = a.Title,
                ReleaseDate = a.ReleaseDate,
                SongIds = a.SongIds,
                Id = a.Id,
                SongsCount = a.SongIds.Count
            });
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AlbumDto>> GetTopFiveAlbumsByDuration()
    {
        var songs = await _repositorySong.GetAll();
        var albums = await _repositoryAlbum.GetAll();

        var albumDurations = songs
            .Where(s => s.AlbumName != null)
            .GroupBy(s => s.AlbumName)
            .Select(group => new
            {
                AlbumName = group.Key,
                TotalDuration = group.Sum(s => s.Duration.TotalSeconds)
            })
            .Where(group => albums.Any(album => album.Title == group.AlbumName))
            .OrderByDescending(group => group.TotalDuration)
            .Take(5)
            .ToList();

        return albumDurations
            .Select(albumDuration =>
            {
                var album = albums.FirstOrDefault(al => al.Title == albumDuration.AlbumName);
                return album != null
                    ? new AlbumDto
                    {
                        ArtistId = album.ArtistId,
                        Title = album.Title,
                        ReleaseDate = album.ReleaseDate,
                        SongIds = album.SongIds,
                        Id = album.Id
                    }
                    : null;
            })
            .Where(album => album != null)!;
    }

    /// <inheritdoc />
    public async Task<MinAvgMaxDurationDto> GetMinAvgMaxAlbumsDuration()
    {
        var songs = await _repositorySong.GetAll();

        var durationsByAlbum = songs
            .Where(s => s.AlbumName != null && s.Duration.TotalSeconds > 0)
            .GroupBy(s => s.AlbumName)
            .Select(group => new
            {
                AlbumName = group.Key,
                TotalDuration = group.Sum(s => s.Duration.TotalSeconds)
            })
            .ToList();

        return new MinAvgMaxDurationDto
        {
            Min = durationsByAlbum.Min(d => d.TotalDuration),
            Max = durationsByAlbum.Max(d => d.TotalDuration),
            Avg = durationsByAlbum.Average(d => d.TotalDuration)
        };
    }
}

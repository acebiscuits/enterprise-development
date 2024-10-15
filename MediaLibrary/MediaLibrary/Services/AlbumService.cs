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
    public AlbumDto? GetById(int id)
    {
        var album = _repositoryAlbum.GetById(id);
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
    public IEnumerable<AlbumDto> GetAll()
    {
        var albums = _repositoryAlbum.GetAll();
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
    public void Add(AlbumCreateDto album)
    {
        _repositoryAlbum.Add(new Album
        {
            ArtistId = album.ArtistId,
            Title = album.Title,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds
        });
    }

    /// <inheritdoc />
    public void Update(AlbumDto album)
    {
        var existingAlbum = _repositoryAlbum.GetById(album.Id);
        if (existingAlbum != null)
        {
            existingAlbum.ArtistId = album.ArtistId ?? existingAlbum.ArtistId;
            existingAlbum.Title = album.Title ?? existingAlbum.Title;
            existingAlbum.ReleaseDate = album.ReleaseDate ?? existingAlbum.ReleaseDate;
            existingAlbum.SongIds = album.SongIds;
        }
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        _repositoryAlbum.Delete(id);
    }

    /// <inheritdoc />
    public IEnumerable<AlbumInfoAndDurationDto> GetInfoAboutAlbumsInCertainYear(int year)
    {
        return _repositoryAlbum.GetAll()
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
    public IEnumerable<AlbumDto> GetTopFiveAlbumsByDuration()
    {
        return _repositorySong.GetAll().GroupBy(s => s.AlbumName)
              .Select(group => new
              {
                  AlbumName = group.Key,
                  TotalDuration = group.Sum(s => s.Duration.TotalSeconds)
              })
              .Where(group => _repositoryAlbum.GetAll().Any(album => album.Title == group.AlbumName))
              .OrderByDescending(sia => sia.TotalDuration)
              .Take(5)
              .Select(album => _repositoryAlbum.GetAll().FirstOrDefault(al => al.Title == album.AlbumName))
              .Where(album => album != null)
              .Select(a => new AlbumDto
              {
                  ArtistId = a!.ArtistId,
                  Title = a.Title,
                  ReleaseDate = a.ReleaseDate,
                  SongIds = a.SongIds,
                  Id = a.Id
              });
    }

    /// <inheritdoc />
    public MinAvgMaxDurationDto GetMinAvgMaxAlbumsDuration()
    {
        var durationsByAlbum = _repositorySong.GetAll()
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

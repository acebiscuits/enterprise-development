using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service for managing song entities. Provides operations for adding, updating, retrieving, and deleting songs.
/// </summary>
public class SongService : ISongService
{
    private readonly IRepositorySong _repositoryInMemorySong;

    /// <inheritdoc />
    public SongService(IRepositorySong repositoryInMemorySong)
    {
        _repositoryInMemorySong = repositoryInMemorySong;
    }

    /// <inheritdoc />
    public SongDto? GetById(int id)
    {
        var song = _repositoryInMemorySong.GetById(id);
        if (song == null)
        {
            return null;
        }
        return new SongDto
        {
            Id = song.Id,
            AlbumName = song.AlbumName,
            NumberInAlbum = song.NumberInAlbum,
            Duration = song.Duration,
            Name = song.Name
        };
    }

    /// <inheritdoc />
    public IEnumerable<SongDto> GetAll()
    {
        var songs = _repositoryInMemorySong.GetAll();
        return songs.Select(song => new SongDto
        {
            Id = song.Id,
            AlbumName = song.AlbumName,
            NumberInAlbum = song.NumberInAlbum,
            Duration = song.Duration,
            Name = song.Name
        });
    }

    /// <inheritdoc />
    public void Add(SongCreateDto songCreateDto)
    {
        _repositoryInMemorySong.Add(new Song
        {
            AlbumName = songCreateDto.AlbumName,
            NumberInAlbum = songCreateDto.NumberInAlbum,
            Duration = songCreateDto.Duration,
            Name = songCreateDto.Name
        });
    }

    /// <inheritdoc />
    public void Update(SongDto songDto)
    {
        var existingSong = _repositoryInMemorySong.GetById(songDto.Id);
        if (existingSong != null)
        {
            existingSong.Duration = songDto.Duration ?? existingSong.Duration;
            existingSong.Name = songDto.Name ?? existingSong.Name;
            existingSong.AlbumName = songDto.AlbumName ?? existingSong.Name;
            existingSong.NumberInAlbum = songDto.NumberInAlbum ?? existingSong.NumberInAlbum;
        }
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        _repositoryInMemorySong?.Delete(id);
    }
    /// <inheritdoc />
    public IEnumerable<SongDto> GetOrderedSongsInCertainAlbum(string albumTitle)
    {
        return _repositoryInMemorySong.GetAll()
           .Where(s => s.AlbumName == albumTitle)
           .OrderBy(s => s.NumberInAlbum)
           .Select(s => new SongDto
           {
               AlbumName = s.AlbumName,
               NumberInAlbum = s.NumberInAlbum,
               Duration = s.Duration,
               Id = s.Id,
               Name = s.Name
           });
    }

}

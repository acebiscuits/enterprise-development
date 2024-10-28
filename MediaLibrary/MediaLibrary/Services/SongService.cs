using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service for managing song entities. Provides operations for adding, updating, retrieving, and deleting songs.
/// </summary>
public class SongService : ISongService
{
    private readonly IRepositorySong _repositorySong;

    /// <summary>
    /// Initializes a new instance of the <see cref="SongService"/> class.
    /// </summary>
    /// <param name="repositorySong">Repository for managing song data.</param>
    public SongService(IRepositorySong repositorySong)
    {
        _repositorySong = repositorySong;
    }

    /// <inheritdoc />
    public async Task<SongDto?> GetById(int id)
    {
        var song = await _repositorySong.GetById(id);
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
    public async Task<IEnumerable<SongDto>> GetAll()
    {
        var songs = await _repositorySong.GetAll();
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
    public async Task Add(SongCreateDto songCreateDto)
    {
        await _repositorySong.Add(new Song
        {
            AlbumName = songCreateDto.AlbumName,
            NumberInAlbum = songCreateDto.NumberInAlbum,
            Duration = songCreateDto.Duration,
            Name = songCreateDto.Name
        });
    }

    /// <inheritdoc />
    public async Task Update(SongDto songDto)
    {
        var existingSong = await _repositorySong.GetById(songDto.Id);
        if (existingSong != null)
        {
            existingSong.Duration = songDto.Duration ?? existingSong.Duration;
            existingSong.Name = songDto.Name;
            existingSong.AlbumName = songDto.AlbumName ?? existingSong.AlbumName;
            existingSong.NumberInAlbum = songDto.NumberInAlbum ?? existingSong.NumberInAlbum;
        }
    }

    /// <inheritdoc />
    public async Task Delete(int id)
    {
        await _repositorySong.Delete(id);
    }
    /// <inheritdoc />
    public async Task<IEnumerable<SongDto>> GetOrderedSongsInCertainAlbum(string albumTitle)
    {
        var songs = await _repositorySong.GetAll();
        return songs
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

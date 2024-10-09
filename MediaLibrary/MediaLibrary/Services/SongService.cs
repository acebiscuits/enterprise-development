using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public class SongService : ISongService
{
    private readonly IRepositoryInMemorySong _repositoryInMemorySong;
    public SongService(IRepositoryInMemorySong repositoryInMemorySong)
    {
        _repositoryInMemorySong = repositoryInMemorySong;
    }
    public SongDto GetById(int id)
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
    public void Delete(int id)
    {
        _repositoryInMemorySong?.Delete(id);
    }

}

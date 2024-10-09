using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public class AlbumService : IAlbumService
{
    private readonly IRepositoryInMemoryAlbum _repositoryInMemoryAlbum;

    public AlbumService(IRepositoryInMemoryAlbum repositoryInMemoryAlbum)
    {
        _repositoryInMemoryAlbum = repositoryInMemoryAlbum;
    }

    public AlbumDto GetById(int id)
    {
        var album = _repositoryInMemoryAlbum.GetById(id);
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

    public IEnumerable<AlbumDto> GetAll()
    {
        var albums = _repositoryInMemoryAlbum.GetAll();
        return albums.Select(album => new AlbumDto
        {
            Id = album.Id,
            ArtistId = album.ArtistId,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds,
            Title = album.Title
        });
    }

    public void Add(AlbumCreateDto album)
    {
        _repositoryInMemoryAlbum.Add(new Album
        {
            ArtistId = album.ArtistId,
            Title = album.Title,
            ReleaseDate = album.ReleaseDate,
            SongIds = album.SongIds
        });
    }
    public void Update(AlbumDto album)
    { 
        var existingAlbum = _repositoryInMemoryAlbum.GetById(album.Id);
        if (existingAlbum != null)
        {
            existingAlbum.ArtistId = album.ArtistId ?? existingAlbum.ArtistId;
            existingAlbum.Title = album.Title ?? existingAlbum.Title;
            existingAlbum.ReleaseDate = album.ReleaseDate ?? existingAlbum.ReleaseDate;
            existingAlbum.SongIds = album.SongIds ?? existingAlbum.SongIds;
        }
    }
    public void Delete(int id)
    {
        _repositoryInMemoryAlbum.Delete(id);
    }
}

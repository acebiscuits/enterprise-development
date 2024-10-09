using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public class RepositoryInMemoryAlbum : RepositoryInMemory<Album>, IRepositoryInMemoryAlbum
{
    override public void Update(Album album)
    {
        var existingAlbum = GetById(album.Id);
        if (existingAlbum != null)
        {
            existingAlbum.ArtistId = album.ArtistId;
            existingAlbum.SongIds = album.SongIds;
            existingAlbum.ReleaseDate = album.ReleaseDate;
            existingAlbum .Title = album.Title;
        }
    }
}

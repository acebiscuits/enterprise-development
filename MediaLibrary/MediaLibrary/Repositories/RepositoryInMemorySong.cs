using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public class RepositoryInMemorySong : RepositoryInMemory<Song>, IRepositoryInMemorySong
{
    public override void Update(Song song)
    {
        var existingSong = GetById(song.Id);
        if (existingSong != null)
        {
            existingSong.Duration = song.Duration;
            existingSong.Name = song.Name;
            existingSong.AlbumName = song.AlbumName;
            existingSong.NumberInAlbum = song.NumberInAlbum;
        }
    }
}

using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public class RepositoryInMemoryArtist : RepositoryInMemory<Artist>, IRepositoryInMemoryArtist
{
    public override void Update(Artist artist)
    {
        var existingArtist = GetById(artist.Id);
        if (existingArtist != null)
        {
            existingArtist.AlbumIds = artist.AlbumIds;
            existingArtist.Name = artist.Name;
            existingArtist.Description = artist.Description;
            existingArtist.GenreIds = artist.GenreIds;
        }
    }
}

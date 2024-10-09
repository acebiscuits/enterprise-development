using MediaLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Repositories;

public class RepositoryInMemoryGenre : RepositoryInMemory<Genre>, IRepositoryInMemoryGenre
{
    public override void Update(Genre genre)
    {
        var existingGenre = GetById(genre.Id);
        if (existingGenre != null)
        {
            existingGenre.Title = genre.Title;
            existingGenre.ArtistIds = genre.ArtistIds;
        }
    }
}

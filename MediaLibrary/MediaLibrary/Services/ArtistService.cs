using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Services;

public class ArtistService : IArtistService
{
    private readonly IRepositoryInMemoryArtist _repositoryInMemoryArtist;

    public ArtistService(IRepositoryInMemoryArtist repositoryInMemoryArtist)
    {
        _repositoryInMemoryArtist = repositoryInMemoryArtist;
    }

    public ArtistDto GetById(int id)
    {
        var artist = _repositoryInMemoryArtist.GetById(id);
        if (artist == null)
        {
            return null;
        }

        return new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        };
    }

    public IEnumerable<ArtistDto> GetAll()
    {
        var artists = _repositoryInMemoryArtist.GetAll();
        return artists.Select(artist => new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    public void Add(ArtistCreateDto artist)
    {
        _repositoryInMemoryArtist.Add(new Artist 
        { 
            Name =  artist.Name, 
            Description = artist.Description, 
            AlbumIds = artist.AlbumIds, 
            GenreIds = artist.GenreIds 
        });
    }

    public void Update(ArtistDto artist)
    {
        var existingArtist = _repositoryInMemoryArtist.GetById(artist.Id);
        if(existingArtist != null)
        {
            existingArtist.Name = artist.Name ?? existingArtist.Name;
            existingArtist.AlbumIds = artist.AlbumIds ?? existingArtist.AlbumIds;
            existingArtist.GenreIds = artist.GenreIds ?? existingArtist.GenreIds;
            existingArtist.Description = artist.Description ?? existingArtist.Description;
        }
    }

    public void Delete(int id)
    {
        _repositoryInMemoryArtist.Delete(id);
    }
}

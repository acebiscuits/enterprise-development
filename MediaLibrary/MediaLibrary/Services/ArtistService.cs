﻿using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;
/// <summary>
/// Service for managing artist entities. Provides operations for adding, updating, retrieving, and deleting artists.
/// </summary>
public class ArtistService : IArtistService
{
    private readonly IRepositoryArtist _repositoryArtist;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtistService"/> class.
    /// </summary>
    /// <param name="repositoryArtist">Repository for managing artist data.</param>
    public ArtistService(IRepositoryArtist repositoryArtist)
    {
        _repositoryArtist = repositoryArtist;
    }

    /// <inheritdoc />
    public async Task<ArtistDto?> GetById(int id)
    {
        var artist = await _repositoryArtist.GetById(id);
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

    /// <inheritdoc />
    public async Task<IEnumerable<ArtistDto>> GetAll()
    {
        var artists = await _repositoryArtist.GetAll();
        return artists.Select(artist => new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    /// <inheritdoc />
    public async Task Add(ArtistCreateDto artist)
    {
        await _repositoryArtist.Add(new Artist
        {
            Name = artist.Name,
            Description = artist.Description,
            AlbumIds = artist.AlbumIds,
            GenreIds = artist.GenreIds
        });
    }

    /// <inheritdoc />
    public async Task Update(ArtistDto artistDto)
    {
        var existingArtist = await _repositoryArtist.GetById(artistDto.Id);
        if (existingArtist != null)
        {
            existingArtist.Name = artistDto.Name;
            existingArtist.AlbumIds = artistDto.AlbumIds;
            existingArtist.GenreIds = artistDto.GenreIds;
            existingArtist.Description = artistDto.Description ?? existingArtist.Description;
            await _repositoryArtist.Update(existingArtist);
        }
    }

    /// <inheritdoc />
    public async Task Delete(int id)
    {
        await _repositoryArtist.Delete(id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ArtistDto>> GetMaxAlbumsCountArtists()
    {
        var artists = await _repositoryArtist.GetAll();
        var maxAlbumCount = artists.Max(a => a.AlbumIds.Count);

        return artists
            .Where(a => a.AlbumIds.Count == maxAlbumCount)
            .Select(artist => new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Description = artist.Description,
                AlbumIds = artist.AlbumIds,
                GenreIds = artist.GenreIds
            });
    }
}

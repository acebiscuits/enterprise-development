﻿using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service for managing genre entities. Provides operations for adding, updating, retrieving, and deleting genres.
/// </summary>
public class GenreService : IGenreService
{
    private readonly IRepositoryGenre _repositoryGenre;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenreService"/> class.
    /// </summary>
    /// <param name="repositoryGenre">Repository for managing genre data.</param>
    public GenreService(IRepositoryGenre repositoryGenre)
    {
        _repositoryGenre = repositoryGenre;
    }

    /// <inheritdoc />
    public async Task<GenreDto?> GetById(int id)
    {
        var genre = await _repositoryGenre.GetById(id);
        if (genre == null)
        {
            return null;
        }
        return new GenreDto
        {
            Id = genre.Id,
            ArtistIds = genre.ArtistIds,
            Title = genre.Title
        };
    }

    /// <inheritdoc />
    public async Task<IEnumerable<GenreDto>> GetAll()
    {
        var genres = await _repositoryGenre.GetAll();
        return genres.Select(genre => new GenreDto
        {
            Id = genre.Id,
            ArtistIds = genre.ArtistIds,
            Title = genre.Title
        });
    }
    /// <inheritdoc />
    public async Task Add(GenreCreateDto genreCreateDto)
    {
        await _repositoryGenre.Add(new Genre
        {
            ArtistIds = genreCreateDto.ArtistIds,
            Title = genreCreateDto.Title
        });
    }
    /// <inheritdoc />
    public async Task Update(GenreDto genreDto)
    {
        var existingGenre = await _repositoryGenre.GetById(genreDto.Id);
        if (existingGenre != null)
        {
            existingGenre.ArtistIds = genreDto.ArtistIds;
            existingGenre.Title = genreDto.Title ?? existingGenre.Title;
            await _repositoryGenre.Update(existingGenre);
        }
    }
    /// <inheritdoc />
    public async Task Delete(int id)
    {
        await _repositoryGenre.Delete(id);
    }
}

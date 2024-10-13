using MediaLibrary.Domain.Dto;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service for managing genre entities. Provides operations for adding, updating, retrieving, and deleting genres.
/// </summary>
public class GenreService : IGenreService
{
    private readonly IRepositoryGenre _repositoryInMemoryGenre;

    /// <inheritdoc />
    public GenreService(IRepositoryGenre repositoryInMemoryGenre)
    {
        _repositoryInMemoryGenre = repositoryInMemoryGenre;
    }

    /// <inheritdoc />
    public GenreDto? GetById(int id)
    {
        var genre = _repositoryInMemoryGenre.GetById(id);
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
    public IEnumerable<GenreDto> GetAll()
    {
        var genres = _repositoryInMemoryGenre.GetAll();
        return genres.Select(genre => new GenreDto
        {
            Id = genre.Id,
            ArtistIds = genre.ArtistIds,
            Title = genre.Title
        });
    }
    /// <inheritdoc />
    public void Add(GenreCreateDto genreCreateDto)
    {
        _repositoryInMemoryGenre.Add(new Genre
        {
            ArtistIds = genreCreateDto.ArtistIds,
            Title = genreCreateDto.Title
        });
    }
    /// <inheritdoc />
    public void Update(GenreDto genreDto)
    {
        var genre = _repositoryInMemoryGenre.GetById(genreDto.Id);
        if (genre != null)
        {
            genre.ArtistIds = genreDto.ArtistIds ?? genre.ArtistIds;
            genre.Title = genreDto.Title ?? genre.Title;
        }
    }
    /// <inheritdoc />
    public void Delete(int id)
    {
        _repositoryInMemoryGenre.Delete(id);
    }
}

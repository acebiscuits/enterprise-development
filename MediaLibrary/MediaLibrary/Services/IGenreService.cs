using MediaLibrary.Domain.Dto;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Interface for managing genre-related operations in the media library.
/// Provides methods for retrieving, adding, updating, and deleting genres.
/// </summary>
public interface IGenreService
{
    /// <summary>
    /// Retrieves a genre by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the genre.</param>
    /// <returns>A <see cref="GenreDto"/> if found, otherwise null.</returns>
    public GenreDto? GetById(int id);
    /// <summary>
    /// Retrieves all genres in the media library.
    /// </summary>
    /// <returns>A collection of <see cref="GenreDto"/> representing all genres.</returns>
    public IEnumerable<GenreDto> GetAll();
    /// <summary>
    /// Adds a new genre to the media library.
    /// </summary>
    /// <param name="genreCreateDto">The DTO containing the data for the new genre.</param>
    public void Add(GenreCreateDto genreCreateDto);
    /// <summary>
    /// Updates an existing genre with new data.
    /// </summary>
    /// <param name="genreDto">The DTO containing the updated data for the genre.</param>
    public void Update(GenreDto genreDto);
    /// <summary>
    /// Deletes a genre by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the genre to be deleted.</param>
    public void Delete(int id);
}

using MediaLibrary.Domain.Dto;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Interface for managing artist-related operations in the media library.
/// Provides methods for retrieving, adding, updating, and deleting artists.
/// </summary>
public interface IArtistService
{
    /// <summary>
    /// Retrieves an artist by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the artist.</param>
    /// <returns>An <see cref="ArtistDto"/> if found, otherwise null.</returns>
    public ArtistDto? GetById(int id);
    /// <summary>
    /// Retrieves all artists in the media library.
    /// </summary>
    /// <returns>A collection of <see cref="ArtistDto"/> representing all artists.</returns>
    public IEnumerable<ArtistDto> GetAll();
    /// <summary>
    /// Adds a new artist to the media library.
    /// </summary>
    /// <param name="artistDto">The DTO containing the data for the new artist.</param>
    public void Add(ArtistCreateDto artistDto);
    /// <summary>
    /// Updates an existing artist with new data.
    /// </summary>
    /// <param name="artistDto">The DTO containing the updated data for the artist.</param>
    public void Update(ArtistDto artistDto);
    /// <summary>
    /// Deletes an artist by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the artist to be deleted.</param>
    public void Delete(int id);

    /// <summary>
    /// Retrieves the artists who have the maximum number of albums.
    /// </summary>
    /// <returns>A collection of <see cref="ArtistDto"/> representing the artists with the highest album count.</returns>
    public IEnumerable<ArtistDto> GetMaxAlbumsCountArtists();
}

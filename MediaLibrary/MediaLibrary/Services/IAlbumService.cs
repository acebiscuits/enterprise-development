using MediaLibrary.Domain.Dto;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Service interface for managing albums in the media library.
/// Provides methods for retrieving, adding, updating, and deleting albums.
/// </summary>
public interface IAlbumService
{
    /// <summary>
    /// Retrieves an album by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the album.</param>
    /// <returns>An <see cref="AlbumDto"/> if found, otherwise null.</returns>
    public Task<AlbumDto?> GetById(int id);
    /// <summary>
    /// Retrieves all albums in the media library.
    /// </summary>
    /// <returns>A collection of <see cref="AlbumDto"/> representing all albums.</returns>
    public Task<IEnumerable<AlbumDto>> GetAll();
    /// <summary>
    /// Adds a new album to the media library.
    /// </summary>
    /// <param name="albumCreateDto">The DTO containing the data for the new album.</param>
    public Task Add(AlbumCreateDto albumCreateDto);
    /// <summary>
    /// Updates an existing album with new data.
    /// </summary>
    /// <param name="albumDto">The DTO containing the updated data for the album.</param>
    public Task Update(AlbumDto albumDto);
    /// <summary>
    /// Deletes an album by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the album to be deleted.</param>
    public Task Delete(int id);

    /// <summary>
    /// Retrieves albums from a specific year, including track count.
    /// </summary>
    /// <param name="year">Year of album release.</param>
    /// <returns>Albums with track counts.</returns>
    public Task<IEnumerable<AlbumInfoAndDurationDto>> GetInfoAboutAlbumsInCertainYear(int year);

    /// <summary>
    /// Gets the top 5 albums by total duration.
    /// </summary>
    /// <returns>Top 5 longest albums.</returns>
    public Task<IEnumerable<AlbumDto>> GetTopFiveAlbumsByDuration();

    /// <summary>
    /// Gets min, avg, and max album durations.
    /// </summary>
    /// <returns>Duration stats.</returns>
    public Task<MinAvgMaxDurationDto> GetMinAvgMaxAlbumsDuration();
}

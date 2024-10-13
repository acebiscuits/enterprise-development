using MediaLibrary.Domain.Dto;

namespace MediaLibrary.Domain.Services;

/// <summary>
/// Interface for managing song-related operations in the media library.
/// Provides methods for retrieving, adding, updating, and deleting songs.
/// </summary>
public interface ISongService
{
    /// <summary>
    /// Retrieves a song by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the song.</param>
    /// <returns>A <see cref="SongDto"/> if found, otherwise null.</returns>
    public SongDto? GetById(int id);
    /// <summary>
    /// Retrieves all songs in the media library.
    /// </summary>
    /// <returns>A collection of <see cref="SongDto"/> representing all songs.</returns>
    public IEnumerable<SongDto> GetAll();
    /// <summary>
    /// Adds a new song to the media library.
    /// </summary>
    /// <param name="song">The DTO containing the data for the new song.</param>
    public void Add(SongCreateDto song);
    /// <summary>
    /// Updates an existing song with new data.
    /// </summary>
    /// <param name="song">The DTO containing the updated data for the song.</param>
    public void Update(SongDto song);
    /// <summary>
    /// Deletes a song by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the song to be deleted.</param>
    public void Delete(int id);
    /// <summary>
    /// Retrieves all songs in a specified album, ordered by their number in the album.
    /// </summary>
    /// <param name="albumTitle">The title of the album to retrieve the songs from.</param>
    /// <returns>A collection of <see cref="SongDto"/> representing all songs in the specified album, ordered by their number.</returns>
    public IEnumerable<SongDto> GetOrderedSongsInCertainAlbum(string albumTitle);
}

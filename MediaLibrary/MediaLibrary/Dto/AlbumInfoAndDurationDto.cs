namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for transferring album information along with the number of songs in the album.
/// </summary>
public class AlbumInfoAndDurationDto
{
    /// <summary>
    /// The unique identifier of the album.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The title of the album.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The unique identifier of the artist who created the album.
    /// </summary>
    public required int ArtistId { get; set; }

    /// <summary>
    /// The year the album was released.
    /// </summary>
    public required int ReleaseDate { get; set; }

    /// <summary>
    /// The list of song IDs associated with this album.
    /// </summary>
    public required List<int> SongIds { get; set; } = new();


    /// <summary>
    /// The total number of songs in the album.
    /// </summary>
    public required int SongsCount { get; set; }
}

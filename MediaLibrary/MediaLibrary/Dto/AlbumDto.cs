using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for transferring album data between layers in the media library.
/// </summary>
public class AlbumDto
{
    /// <summary>
    /// The unique identifier of the album.
    /// </summary>
    [Required]
    public required int Id { get; set; }

    /// <summary>
    /// The unique identifier of the artist who created the album.
    /// </summary>
    public int? ArtistId { get; set; }

    /// <summary>
    /// The title of the album.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The release date of the album (year).
    /// </summary>
    public int? ReleaseDate { get; set; }

    /// <summary>
    /// The list of song IDs associated with this album.
    /// </summary>
    public List<int> SongIds { get; set; } = new();
}

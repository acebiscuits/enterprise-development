using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.Domain.Dto;

/// <summary>
/// DTO for transferring artist data between layers in the media library.
/// </summary>
public class ArtistDto
{
    /// <summary>
    /// The unique identifier of the artist.
    /// </summary>
    [Required]
    public required int Id { get; set; }

    /// <summary>
    /// The name of the artist.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// A description of the artist.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The list of album IDs associated with the artist.
    /// </summary>
    public List<int> AlbumIds { get; set; } = [];

    /// <summary>
    /// The list of genre IDs associated with the artist.
    /// </summary>
    public List<int> GenreIds { get; set; } = [];
}
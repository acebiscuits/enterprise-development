using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Artist entities.
/// Inherits from the generic RepositoryInMemory class.
/// </summary>
public class RepositoryInMemoryArtist : RepositoryInMemory<Artist>, IRepositoryArtist
{
    /// <inheritdoc />
    public RepositoryInMemoryArtist(List<Artist> initData) : base(initData) { }
    /// <inheritdoc />
    public override void Update(Artist artist)
    {
        var existingArtist = GetById(artist.Id);
        if (existingArtist != null)
        {
            existingArtist.AlbumIds = artist.AlbumIds;
            existingArtist.Name = artist.Name;
            existingArtist.Description = artist.Description;
            existingArtist.GenreIds = artist.GenreIds;
        }
    }
}

using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository for managing Genre entities.
/// Inherits from the generic Repository class.
/// </summary>
public class RepositoryInMemoryGenre : RepositoryInMemory<Genre>, IRepositoryGenre
{
    /// <inheritdoc />
    public RepositoryInMemoryGenre(List<Genre> initData) : base(initData) { }
    /// <inheritdoc />
    public override void Update(Genre genre)
    {
        var existingGenre = GetById(genre.Id);
        if (existingGenre != null)
        {
            existingGenre.Title = genre.Title;
            existingGenre.ArtistIds = genre.ArtistIds;
        }
    }
}

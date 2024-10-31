using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Artist entities, inheriting from the generic RepositoryInDb.
/// </summary>
public class RepositoryInDbArtist : RepositoryInDb<Artist>, IRepositoryArtist
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDbArtist"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public RepositoryInDbArtist(ApplicationDbContext context) : base(context) { }
}

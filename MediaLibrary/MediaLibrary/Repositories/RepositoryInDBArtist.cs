using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Artist entities, inheriting from the generic RepositoryInDB.
/// </summary>
public class RepositoryInDBArtist : RepositoryInDB<Artist>, IRepositoryArtist
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDBArtist"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public RepositoryInDBArtist(ApplicationDbContext context) : base(context) { }
}

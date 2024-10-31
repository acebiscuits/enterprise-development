using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Album entities, inheriting from the generic RepositoryInDb.
/// </summary>
public class RepositoryInDbAlbum : RepositoryInDb<Album>, IRepositoryAlbum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDbAlbum"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public RepositoryInDbAlbum(ApplicationDbContext context) : base(context) { }
}

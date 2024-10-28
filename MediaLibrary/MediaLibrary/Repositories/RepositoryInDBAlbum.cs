using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Album entities, inheriting from the generic RepositoryInDB.
/// </summary>
public class RepositoryInDBAlbum : RepositoryInDB<Album>, IRepositoryAlbum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDBAlbum"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public RepositoryInDBAlbum(ApplicationDbContext context) : base(context) { }
}

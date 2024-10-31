using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Genre entities, inheriting from the generic RepositoryInDb.
/// </summary>
public class RepositoryInDbGenre : RepositoryInDb<Genre>, IRepositoryGenre
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDbGenre"/> class.
    /// </summary>
    /// <param name="context">The database context to be used for data operations.</param>
    public RepositoryInDbGenre(ApplicationDbContext context) : base(context) { }
}

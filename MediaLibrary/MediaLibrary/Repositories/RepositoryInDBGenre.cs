using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Repository for handling database operations for Genre entities, inheriting from the generic RepositoryInDB.
/// </summary>
public class RepositoryInDBGenre : RepositoryInDB<Genre>, IRepositoryGenre
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDBGenre"/> class.
    /// </summary>
    /// <param name="context">The database context to be used for data operations.</param>
    public RepositoryInDBGenre(ApplicationDbContext context) : base(context) { }
}

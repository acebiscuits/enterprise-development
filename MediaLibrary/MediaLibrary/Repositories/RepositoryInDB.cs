using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// Generic repository for performing CRUD operations on database entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity, must implement IEntity.</typeparam>
public class RepositoryInDB<T> : IRepository<T> where T : class, IEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryInDB{T}"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public RepositoryInDB(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Gets all entities of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <returns>A collection of all entities.</returns>
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity with updated values.</param>
    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}

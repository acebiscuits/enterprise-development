﻿using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// A generic in-memory repository interface that provides CRUD (Create, Read, Update, Delete) operations for entities.
/// </summary>
/// <typeparam name="T">The type of the entity that implements IEntity interface.</typeparam>
public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Adds a new entity to the in-memory collection.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    public Task Add(T entity);
    /// <summary>
    /// Updates an existing entity in the in-memory collection.
    /// </summary>
    /// <param name="entity">The entity with updated information.</param>
    public Task Update(T entity);
    /// <summary>
    /// Deletes an entity from the in-memory collection by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    public Task Delete(int id);
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>The entity with the given identifier, or null if not found.</returns>
    public Task<T?> GetById(int id);
    /// <summary>
    /// Retrieves all entities in the in-memory collection.
    /// </summary>
    /// <returns>An enumerable collection of all entities.</returns>
    public Task<IEnumerable<T>> GetAll();
}

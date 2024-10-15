using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository interface for managing genre entities.
/// Inherits standard CRUD operations from IRepository.
/// </summary>
public interface IRepositoryGenre : IRepository<Genre>;
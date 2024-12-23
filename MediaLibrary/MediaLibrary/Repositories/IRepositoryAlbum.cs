﻿using MediaLibrary.Domain.Models;

namespace MediaLibrary.Domain.Repositories;

/// <summary>
/// In-memory repository interface specifically for managing album entities.
/// Inherits generic CRUD operations from IRepository.
/// </summary>
public interface IRepositoryAlbum : IRepository<Album>;
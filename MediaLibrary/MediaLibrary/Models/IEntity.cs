namespace MediaLibrary.Domain.Models;

/// <summary>
/// Interface representing an entity in the media library system.
/// All entities that have a unique identifier (ID) should implement this interface.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// The unique identifier of the entity.
    /// </summary>
    int Id { get; set; }
}

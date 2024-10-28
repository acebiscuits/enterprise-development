using MediaLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Domain.Data;

/// <summary>
/// Database context.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the Artists DbSet.
    /// </summary>
    public DbSet<Artist> Artists { get; set; }
    /// <summary>
    /// Gets or sets the Albums DbSet.
    /// </summary>
    public DbSet<Album> Albums { get; set; }
    /// <summary>
    /// Gets or sets the Genres DbSet.
    /// </summary>
    public DbSet<Genre> Genres { get; set; }
    /// <summary>
    /// Gets or sets the Songs DbSet.
    /// </summary>
    public DbSet<Song> Songs { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by this DbContext.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    /// <summary>
    /// Configures the model for the context by setting keys and auto-increment properties.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Album>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Artist>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Artist>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Genre>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Genre>()
            .Property(g => g.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Song>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Song>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();

    }
}

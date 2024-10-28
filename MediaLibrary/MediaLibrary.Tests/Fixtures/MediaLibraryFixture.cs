﻿using MediaLibrary.Domain.Data;
using MediaLibrary.Domain.Models;
using MediaLibrary.Domain.Repositories;
using MediaLibrary.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace MediaLibrary.Tests.Fixtures;

/// <summary>
/// Fixture for tests
/// </summary>
public class MediaLibraryFixture : IDisposable
{
    public IArtistService ArtistService { get; private set; }
    public ISongService SongService { get; private set; }
    public IAlbumService AlbumService { get; private set; }

    private readonly ApplicationDbContext _context;

    public MediaLibraryFixture()
    {

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);

        SeedData();

        ArtistService = new ArtistService(new RepositoryInDBArtist(_context));
        SongService = new SongService(new RepositoryInDBSong(_context));
        AlbumService = new AlbumService(new RepositoryInDBAlbum(_context), new RepositoryInDBSong(_context));
    }

    private void SeedData()
    {
        _context.Artists.AddRange(new Artist[]
        {
            new() { Name = "Jon Bon Jovi", Description = "У него есть кожаная куртка с дюжиной застежек", AlbumIds = new List<int> { 1, 2 }, GenreIds = new List<int> { 1, 2 } },
            new() {  Name = "Bob Seger", Description = "Его не заткнуть, а его смех похож на скрежет бетономешалки", AlbumIds = new List<int> { 3, 4 }, GenreIds = new List<int> { 3 } },
            new() { Name = "Jay Kay", Description = "Он как-то говорил, что не смог бы стать раллийным гонщиком", AlbumIds = [5], GenreIds = [4] },
            new() { Name = "Roger Daltrey", Description = "Самый быстрый человек с билетом на автобус", AlbumIds = [6, 7], GenreIds = [3] },
            new() { Name = "Lionel Richie", Description = "Он часто оказывался на обочине и пытался открыть правую дверь", AlbumIds = [8], GenreIds = [4] },
            new() { Name = "Cliff Richard", Description = "Его усилия разогнаться иссякли на 130 километрах в час", AlbumIds = [9, 10], GenreIds = [4, 5] },
            new() { Name = "James Blunt", Description = "Оденажды он спел о чем-то там в море", AlbumIds = [11, 12], GenreIds = [3, 5] }
        });

        _context.Songs.AddRange(new Song[]
        {
            new() { AlbumName = "Stronger", Name = "Stronger Than That", Duration = TimeSpan.FromSeconds(281), NumberInAlbum = 1 },
            new() { AlbumName = "Stronger", Name = "Who's In Love", Duration = TimeSpan.FromSeconds(270), NumberInAlbum = 2 },
            new() { AlbumName = "Stronger", Name = "The Best Of Me", Duration = TimeSpan.FromSeconds(250), NumberInAlbum = 3 },
            new() { AlbumName = "Stronger", Name = "Clear Blue Skies", Duration = TimeSpan.FromSeconds(174), NumberInAlbum = 4 },
            new() { AlbumName = "Stronger", Name = "Lean On You", Duration = TimeSpan.FromSeconds(302), NumberInAlbum = 5 },
            new() { AlbumName = "Stronger", Name = "Keep Me Warm", Duration = TimeSpan.FromSeconds(264), NumberInAlbum = 6 },
            new() { AlbumName = "Against The Wind", Name = "The Horisontal Bop", Duration = TimeSpan.FromSeconds(241), NumberInAlbum = 1 },
            new() { AlbumName = "Against The Wind", Name = "No Man's Land", Duration = TimeSpan.FromSeconds(260), NumberInAlbum = 2 },
            new() { AlbumName = "Against The Wind", Name = "Good For Me", Duration = TimeSpan.FromSeconds(199), NumberInAlbum = 3 },
            new() { AlbumName = "Stranger in Town", Name = "Hollywood Nights", Duration = TimeSpan.FromSeconds(194), NumberInAlbum = 1 },
            new() { AlbumName = "Stranger in Town", Name = "Till It Shines", Duration = TimeSpan.FromSeconds(302), NumberInAlbum = 2 },
            new() { AlbumName = "Nine Tonight", Name = "Nine Tonight", Duration = TimeSpan.FromSeconds(264), NumberInAlbum = 1 },
            new() { AlbumName = "Beautiful Loser", Name = "Beautiful Loser", Duration = TimeSpan.FromSeconds(305), NumberInAlbum = 1 },
            new() { AlbumName = "Beautiful Loser", Name = "Jody Girl", Duration = TimeSpan.FromSeconds(184), NumberInAlbum = 2 },
            new() { AlbumName = "Beautiful Loser", Name = "Black Night", Duration = TimeSpan.FromSeconds(234), NumberInAlbum = 3 }
        });

        _context.Albums.AddRange(new Album[]
        {
            new() { Title = "Against The Wind", ArtistId = 2, ReleaseDate = 1980, SongIds = [1, 2, 12, 14] },
            new() { Title = "Stranger in Town", ArtistId = 2, ReleaseDate = 1978, SongIds = [4, 5, 24, 45, 444] },
            new() { Title = "Nine Tonight", ArtistId = 3, ReleaseDate = 1980, SongIds = [6, 7, 86, 90] },
            new() { Title = "Beautiful Loser", ArtistId = 2, ReleaseDate = 2075, SongIds = [9, 11, 100, 1120] }
        });

        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
﻿using MediaLibrary.Domain.Repositories;
using MediaLibrary.Domain.Services;

namespace MediaLibrary.Tests.Fixtures;

/// <summary>
/// Fixture for tests
/// </summary>
public class MediaLibraryFixture
{
    /// <summary>
    /// Repository for retrieving information about all artists and artists with the maximum number of albums.
    /// </summary>
    public IRepositoryArtist InfoAboutAllArtistsAndWithMaxAlbumsRepository { get; private set; }
    /// <summary>
    /// Repository for retrieving ordered tracks in an album.
    /// </summary>
    public IRepositorySong OrderedTracksInAlbumRepository { get; private set; }
    /// <summary>
    /// Repository for retrieving all albums released in a certain year.
    /// </summary>
    public IRepositoryAlbum AllAlbumsInCertainYearRepository { get; private set; }
    /// <summary>
    /// Repository for retrieving songs from the top five albums by duration.
    /// </summary>
    public IRepositorySong SongsForTopFiveAlbumsRepository { get; private set; }
    /// <summary>
    /// Repository for retrieving information about the minimum, maximum, and median album durations.
    /// </summary>
    public IRepositorySong MaxMinMedAlbumsDurationInfoRepository { get; private set; }
    /// <summary>
    /// Service for artist-related operations.
    /// </summary>
    public IArtistService ArtistService { get; private set; }
    /// <summary>
    /// Service for song-related operations.
    /// </summary>
    public ISongService SongService { get; private set; }
    /// <summary>
    /// Service for album-related operations.
    /// </summary>
    public IAlbumService AlbumService { get; private set; }
    /// <summary>
    /// Service for retrieving songs from the top five albums.
    /// </summary>
    public ISongService SongServiceTopFiveAlbums { get; private set; }
    /// <summary>
    /// Service for retrieving information about the minimum, maximum, and median album durations.
    /// </summary>
    public ISongService MaxMinMedAlbumsDurationInfoService { get; private set; }
    /// <summary>
    /// Initializes the fixture with predefined repositories and services.
    /// </summary>
    public MediaLibraryFixture()
    {
        InfoAboutAllArtistsAndWithMaxAlbumsRepository = new RepositoryInMemoryArtist
        (
            [
                new() { Id = 1, Name = "Jon Bon Jovi", Description = "У него есть кожаная куртка с дюжиной застежек", AlbumIds = [1, 2], GenreIds = [1, 2] },
                new() { Id = 2, Name = "Bob Seger", Description = "Его не заткнуть, а его смех похож на скрежет бетономешалки", AlbumIds = [3, 4], GenreIds = [3] },
                new() { Id = 3, Name = "Jay Kay", Description = "Он как-то говорил, что не смог бы стать раллийным гонщиком", AlbumIds = [5], GenreIds = [4] },
                new() { Id = 4, Name = "Roger Daltrey", Description = "Самый быстрый человек с билетом на автобус", AlbumIds = [6, 7], GenreIds = [3] },
                new() { Id = 5, Name = "Lionel Richie", Description = "Он часто оказывался на обочине и пытался открыть правую дверь", AlbumIds = [8], GenreIds = [4] },
                new() { Id = 6, Name = "Cliff Richard", Description = "Его усилия разогнаться иссякли на 130 километрах в час", AlbumIds = [9, 10], GenreIds = [4, 5] },
                new() { Id = 7, Name = "James Blunt", Description = "Оденажды он спел о чем-то там в море", AlbumIds = [11, 12], GenreIds = [3, 5] }
            ]
        );

        OrderedTracksInAlbumRepository = new RepositoryInMemorySong
        (
            [
                new() { Id = 1, AlbumName = "Stronger", Name = "Stronger Than That", Duration = TimeSpan.FromSeconds(281), NumberInAlbum = 1 },
                new() { Id = 2, AlbumName = "Stronger", Name = "Who's In Love", Duration = TimeSpan.FromSeconds(270), NumberInAlbum = 2 },
                new() { Id = 3, AlbumName = "Stronger", Name = "The Best Of Me", Duration = TimeSpan.FromSeconds(250), NumberInAlbum = 3 },
                new() { Id = 4, AlbumName = "Stronger", Name = "Clear Blue Skies", Duration = TimeSpan.FromSeconds(174), NumberInAlbum = 4 },
                new() { Id = 5, AlbumName = "Stronger", Name = "Lean On You", Duration = TimeSpan.FromSeconds(302), NumberInAlbum = 5 },
                new() { Id = 6, AlbumName = "Stronger", Name = "Keep Me Warm", Duration = TimeSpan.FromSeconds(264), NumberInAlbum = 6 }
            ]
        );

        AllAlbumsInCertainYearRepository = new RepositoryInMemoryAlbum
        (
            [
                new() { Id = 1, Title = "Against The Wind", ArtistId = 2, ReleaseDate = 1980, SongIds = [1, 2, 12, 14] },
                new() { Id = 2, Title = "Stranger in Town", ArtistId = 2, ReleaseDate = 1978, SongIds = [4, 5, 24, 45, 444] },
                new() { Id = 3, Title = "Nine Tonight", ArtistId = 3, ReleaseDate = 1980, SongIds = [6, 7, 86, 90] },
                new() { Id = 4, Title = "Beautiful Loser", ArtistId = 2, ReleaseDate = 2075, SongIds = [9, 11, 100, 1120] }
            ]
        );

        SongsForTopFiveAlbumsRepository = new RepositoryInMemorySong
        (
            [
                new() { Id = 1, AlbumName = "What is the word?", Duration = TimeSpan.FromSeconds(100), Name = "A.. bird. Bird is the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "B B B B Bird", Duration = TimeSpan.FromSeconds(101), Name = "Bird, bird, bird, b-bird's the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "Bird Is The Word", Duration = TimeSpan.FromSeconds(102), Name = "A-well, a bird, bird, bird, bird is the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "Do You Or Do You Not Know", Duration = TimeSpan.FromSeconds(103), Name = "A-well, a bird, bird, bird, well-a bird is the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "About The Bird", Duration = TimeSpan.FromSeconds(104), Name = "A-well, a bird, bird, bird, b-bird's the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "Couse Everybodys Heard That The Bird Is The Word", Duration = TimeSpan.FromSeconds(105), Name = "A-well, a bird, bird, b-bird is the word", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "Oh Have You Not Heard?", Duration = TimeSpan.FromSeconds(106), Name = "A-well-a don't you know about the bird?", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "It Was My Understanding That Everyone Had Heard", Duration = TimeSpan.FromSeconds(107), Name = "A-well-a-bird, bird, b-bird's the word, a-well-a", NumberInAlbum = 1 },
                new() { Id = 1, AlbumName = "A-well, A Bird, Bird, B-bird Is The Word", Duration = TimeSpan.FromSeconds(108), Name = "A-well-a bird, surfing bird", NumberInAlbum = 1 }
            ]
        );

        MaxMinMedAlbumsDurationInfoRepository = new RepositoryInMemorySong
        (
            [
                new() { Id = 1, AlbumName = "Against The Wind", Name = "The Horisontal Bop", Duration = TimeSpan.FromSeconds(241), NumberInAlbum = 1 },
                new() { Id = 2, AlbumName = "Against The Wind", Name = "No Man's Land", Duration = TimeSpan.FromSeconds(260), NumberInAlbum = 2 },
                new() { Id = 3, AlbumName = "Against The Wind", Name = "Good For Me", Duration = TimeSpan.FromSeconds(199), NumberInAlbum = 3 },
                new() { Id = 4, AlbumName = "Stranger in Town", Name = "Hollywood Nights", Duration = TimeSpan.FromSeconds(194), NumberInAlbum = 1 },
                new() { Id = 5, AlbumName = "Stranger in Town", Name = "Till It Shines", Duration = TimeSpan.FromSeconds(302), NumberInAlbum = 2 },
                new() { Id = 6, AlbumName = "Nine Tonight", Name = "Nine Tonight", Duration = TimeSpan.FromSeconds(264), NumberInAlbum = 1 },
                new() { Id = 7, AlbumName = "Beautiful Loser", Name = "Beautiful Loser", Duration = TimeSpan.FromSeconds(305), NumberInAlbum = 1 },
                new() { Id = 8, AlbumName = "Beautiful Loser", Name = "Jody Girl", Duration = TimeSpan.FromSeconds(184), NumberInAlbum = 2 },
                new() { Id = 9, AlbumName = "Beautiful Loser", Name = "Black Night", Duration = TimeSpan.FromSeconds(234), NumberInAlbum = 3 }
            ]
        );
        ArtistService = new ArtistService(InfoAboutAllArtistsAndWithMaxAlbumsRepository);
        SongService = new SongService(OrderedTracksInAlbumRepository);
        AlbumService = new AlbumService(AllAlbumsInCertainYearRepository, SongsForTopFiveAlbumsRepository);
        SongServiceTopFiveAlbums = new SongService(SongsForTopFiveAlbumsRepository);
        MaxMinMedAlbumsDurationInfoService = new SongService(MaxMinMedAlbumsDurationInfoRepository);
    }
}
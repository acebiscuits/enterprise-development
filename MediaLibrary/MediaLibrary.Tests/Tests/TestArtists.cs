using MediaLibrary.Tests.Fixtures;
namespace MediaLibrary.Tests.Tests;

/// <summary>
/// This class contains unit tests for testing various operations related to artists, genres, albums and songs.
/// </summary>
/// <param name="fixture">Fixture to provide data for testing.</param>
public class TestArtists(MediaLibraryFixture fixture) : IClassFixture<MediaLibraryFixture>
{
    private MediaLibraryFixture _fixture = fixture;

    /// <summary>
    /// Tests the selection and output info about every artist
    /// </summary>
    [Fact]
    public void TestShowInfoAboutAllArtists()
    {
        var artists = _fixture.ArtistService.GetAll().ToList();

        Assert.Equal(7, artists.Count);

        Assert.Equal(
            [
                "Jon Bon Jovi", "Bob Seger", "Jay Kay",
                "Roger Daltrey", "Lionel Richie", "Cliff Richard", "James Blunt"
            ],
            artists.Select(q => q.Name).ToList());

        Assert.Equal(
            [
                "У него есть кожаная куртка с дюжиной застежек", "Его не заткнуть, а его смех похож на скрежет бетономешалки",
                "Он как-то говорил, что не смог бы стать раллийным гонщиком", "Самый быстрый человек с билетом на автобус",
                "Он часто оказывался на обочине и пытался открыть правую дверь", "Его усилия разогнаться иссякли на 130 километрах в час",
                "Оденажды он спел о чем-то там в море"
            ],
            artists.Select(q => q.Description).ToList());

        Assert.Equal([ [ 1, 2 ], [ 3, 4 ], [ 5 ],
            [ 6, 7 ], [ 8 ], [ 9, 10 ], [ 11, 12 ] ],
            artists.Select(q => q.AlbumIds).ToList());

        Assert.Equal([ [ 1, 2 ], [ 3 ], [ 4 ],
            [ 3 ], [ 4 ], [ 4, 5 ], [ 3, 5 ] ],
            artists.Select(q => q.GenreIds).ToList());

    }

    /// <summary>
    /// Tests selection the info about every song in certain album, ordered by number
    /// </summary>
    [Fact]
    public void TestAllSongsInAlbumOrderedByNumber()
    {
        var songs = _fixture.SongService.GetAll().Where(a => a.AlbumName == "Stronger").OrderBy(a => a.NumberInAlbum).ToList();

        Assert.Equal(6, songs.Count);

        Assert.Equal([ "Stronger Than That", "Who's In Love", "The Best Of Me",
            "Clear Blue Skies", "Lean On You", "Keep Me Warm" ],
            songs.Select(q => q.Name).ToList());

        Assert.Equal([ TimeSpan.FromSeconds(281), TimeSpan.FromSeconds(270),
            TimeSpan.FromSeconds(250), TimeSpan.FromSeconds(174),
            TimeSpan.FromSeconds(302), TimeSpan.FromSeconds(264) ],
            songs.Select(q => q.Duration).ToList());

        Assert.Equal([1, 2, 3, 4, 5, 6],
            songs.Select(q => q.NumberInAlbum).ToList());

    }

    /// <summary>
    /// Tests the selection albums in specific year, noticing a number of songs
    /// </summary>
    [Fact]
    public void TestAlbumsInfoWithSongsCountInCertainYear()
    {
        var query = _fixture.AlbumService.GetAll().Where(q => q.ReleaseDate == 1980).ToList();

        Assert.Equal(2, query.Count);

        Assert.Equal(["Against The Wind", "Nine Tonight"],
            query.Select(q => q.Title).ToList());

        Assert.Equal([2, 3],
            query.Select(q => q.ArtistId).ToList());

        Assert.Equal([4, 4],
            query.Select(q => q.SongIds.Count).ToList());
    }

    /// <summary>
    /// Tests the selection top 5 albums by duration
    /// </summary>
    [Fact]
    public void TestTopFiveAlbumsByDuration()
    {
        var query = _fixture.songsForTopFiveAlbumsRepository.GetAll().GroupBy(q => q.AlbumName)
            .Select(a => new { AlbumName = a.Key, TotalDuration = a.Aggregate(TimeSpan.Zero, (total, song) => total + song.Duration) })
            .OrderByDescending(d => d.TotalDuration).Take(5).ToList();

        Assert.Equal([ TimeSpan.FromSeconds(108), TimeSpan.FromSeconds(107),
                       TimeSpan.FromSeconds(106), TimeSpan.FromSeconds(105),
                       TimeSpan.FromSeconds(104) ],
                     query.Select(d => d.TotalDuration).ToList());
    }

    /// <summary>
    /// Tests the selection artists with a max number of albums
    /// </summary>
    [Fact]
    public void TestArtistsWithMaxAlbumsCount()
    {
        var query = _fixture.ArtistService
        .GetAll()
        .Where(a => a.AlbumIds.Count == _fixture.infoAboutAllArtistsAndWithMaxAlbumsRepository.GetAll().Max(a => a.AlbumIds.Count))
        .Select(group => new
        {
            Id = group.Id,
            Count = group.AlbumIds.Count,
        }).ToList();
        var maxAlbumCount = _fixture.infoAboutAllArtistsAndWithMaxAlbumsRepository
        .GetAll()
        .Max(a => a.AlbumIds.Count);

        Assert.Equal([1, 2, 4, 6, 7], query!.Select(q => q.Id).ToList());
        Assert.All(query, q => Assert.Equal(maxAlbumCount, q.Count));
    }

    /// <summary>
    /// Tests the selection of max, min, avg duration of albums
    /// </summary>
    [Fact]
    public void TestMaxMinMedAlbumsDurationInfo()
    {
        var query = _fixture.MaxMinMedAlbumsDurationInfoService.GetAll().GroupBy(n => n.AlbumName)
            .Select(g => new { AlbumName = g.Key, TotalDuration = g.Sum(s => s.Duration.HasValue ? s.Duration.Value.TotalSeconds : 0) })
            .OrderByDescending(d => d.TotalDuration)
            .ToList();

        var minDuration = 264;
        var maxDuration = 723;
        var AvgDuration = 545.75;

        Assert.Equal(maxDuration, query.Max(a => a.TotalDuration));
        Assert.Equal(minDuration, query.Min(a => a.TotalDuration));
        Assert.Equal(AvgDuration, query.Average(a => a.TotalDuration));
    }
}
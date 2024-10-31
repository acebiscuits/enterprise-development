using MediaLibrary.Tests.Fixtures;
namespace MediaLibrary.Tests.Tests;

public class TestArtists(MediaLibraryFixture fixture) : IClassFixture<MediaLibraryFixture>
{
    private MediaLibraryFixture _fixture = fixture;

    [Fact]
    public async Task TestShowInfoAboutAllArtists()
    {
        var artists = (await _fixture.ArtistService.GetAll()).ToList();

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

    [Fact]
    public async Task TestAllSongsInAlbumOrderedByNumber()
    {
        var songs = (await _fixture.SongService.GetAll())
            .Where(a => a.AlbumName == "Stronger")
            .OrderBy(a => a.NumberInAlbum)
            .ToList();

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

    [Fact]
    public async Task TestAlbumsInfoWithSongsCountInCertainYear()
    {
        var albums = (await _fixture.AlbumService.GetAll())
            .Where(q => q.ReleaseDate == 1980)
            .ToList();

        Assert.Equal(2, albums.Count);

        Assert.Equal(["Against The Wind", "Nine Tonight"],
            albums.Select(q => q.Title).ToList());

        Assert.Equal([2, 3],
            albums.Select(q => q.ArtistId).ToList());

        Assert.Equal([4, 4],
            albums.Select(q => q.SongIds.Count).ToList());
    }

    [Fact]
    public async Task TestTopFiveAlbumsByDuration()
    {
        var albums = (await _fixture.SongService.GetAll())
            .GroupBy(s => s.AlbumName)
            .Select(group => new { AlbumName = group.Key, TotalDuration = group.Sum(s => s.Duration.HasValue ? s.Duration.Value.TotalSeconds : 0) })
            .OrderByDescending(album => album.TotalDuration)
            .Take(5)
            .ToList();

        Assert.Equal([1541.0, 723.0, 700.0, 496.0, 264.0],
                     albums.Select(d => d.TotalDuration).ToList());
    }

    [Fact]
    public async Task TestArtistsWithMaxAlbumsCount()
    {
        var maxAlbumCount = (await _fixture.ArtistService.GetAll())
            .Max(a => a.AlbumIds.Count);

        var artists = (await _fixture.ArtistService.GetAll())
            .Where(a => a.AlbumIds.Count == maxAlbumCount)
            .ToList();

        Assert.Equal([1, 2, 4, 6, 7], artists!.Select(q => q.Id).ToList());
        Assert.All(artists, q => Assert.Equal(maxAlbumCount, q.AlbumIds.Count));
    }

    [Fact]
    public async Task TestMaxMinMedAlbumsDurationInfo()
    {
        var albums = (await _fixture.SongService.GetAll())
            .GroupBy(s => s.AlbumName)
            .Select(group => new { AlbumName = group.Key, TotalDuration = group.Sum(s => s.Duration.HasValue ? s.Duration.Value.TotalSeconds : 0) })
            .ToList();

        var minDuration = 264;
        var maxDuration = 1541;
        var avgDuration = 744.8;

        Assert.Equal(maxDuration, albums.Max(a => a.TotalDuration));
        Assert.Equal(minDuration, albums.Min(a => a.TotalDuration));
        Assert.Equal(avgDuration, albums.Average(a => a.TotalDuration));
    }
}
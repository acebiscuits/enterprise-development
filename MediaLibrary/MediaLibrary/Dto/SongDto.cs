using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

internal class SongDto
{
    public required int Id { get; set; }
    public string Name { get; set; }
    public int? NumberInAlbum { get; set; }
    public string AlbumName { get; set; }
    public TimeSpan? Duration { get; set; }
}

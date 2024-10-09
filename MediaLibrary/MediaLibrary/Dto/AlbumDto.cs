using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

public class AlbumDto
{
    [Required]
    public required int Id { get; set; }
    public int? ArtistId { get; set; }
    public string Title { get; set; }
    public int? ReleaseDate { get; set; }
    public List<int> SongIds { get; set; } = new();
}

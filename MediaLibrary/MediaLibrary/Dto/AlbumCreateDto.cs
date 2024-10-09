using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

public class AlbumCreateDto
{
    [Required]
    public int ArtistId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int ReleaseDate { get; set; }
    public List<int> SongIds { get; set; } = new();
}

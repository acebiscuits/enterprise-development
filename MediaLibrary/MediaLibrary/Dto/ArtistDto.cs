﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Dto;

public class ArtistDto
{
    public required int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<int>? AlbumIds { get; set; }
    public List<int>? GenreIds { get; set; }
}
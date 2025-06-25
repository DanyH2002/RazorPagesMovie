using System;

namespace RazorPagesMovie.DTOs;

public class MovieInsert
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? Gender { get; set; }
    public int Year { get; set; }
}

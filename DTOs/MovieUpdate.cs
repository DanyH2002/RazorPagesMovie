using System;

namespace RazorPagesMovie.DTOs;

public class MovieUpdate
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? Gender { get; set; }
    public int Year { get; set; }
}

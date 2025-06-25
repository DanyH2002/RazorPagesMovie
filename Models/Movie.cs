using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Model;

public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? Gender { get; set; }
    public int Year { get; set; }
    

}

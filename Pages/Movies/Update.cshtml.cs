using RazorPagesMovie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using RazorPagesMovie.DTOs;



namespace RazorPagesMovie.Pages.Movies;

public class UpdateModel : PageModel
{
    private readonly MovieContext _context;
    private readonly IValidator<MovieUpdate> _validator;

    public UpdateModel(MovieContext context, IValidator<MovieUpdate> validator)
    {
        _context = context;
        _validator = validator;
    }

    [BindProperty]
    public Movie movie { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        movie = await _context.Movie.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = new MovieUpdate
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            Gender = movie.Gender,
            Year = movie.Year
        };

        var validar = await _validator.ValidateAsync(dto);

        if (!validar.IsValid)
        {
            foreach (var e in validar.Errors)
            {
                ModelState.AddModelError(string.Empty, e.ErrorMessage);
            }
            return Page();
        }

        var movieU = await _context.Movie.FindAsync(movie.Id);

        if (movieU == null)
        {
            return NotFound();
        }

        movieU.Title = movie.Title;
        movieU.Description = movie.Description;
        movieU.Director = movie.Director;
        movieU.Gender = movie.Gender;
        movieU.Year = movie.Year;


        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
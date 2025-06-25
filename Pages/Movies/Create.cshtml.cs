using RazorPagesMovie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using RazorPagesMovie.DTOs;


namespace RazorPagesMovie.Pages.Movies;

public class CreateModel : PageModel
{
    private readonly MovieContext _context;
    private readonly IValidator<MovieInsert> _validator;

    public CreateModel(MovieContext context, IValidator<MovieInsert> validator)
    {
        _context = context;
        _validator = validator;
    }

    [BindProperty]
    public Movie movie { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = new MovieInsert
        {
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

        _context.Movie.Add(movie);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
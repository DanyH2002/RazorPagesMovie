using RazorPagesMovie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;


namespace RazorPagesMovie.Pages.Movies;

public class DeleteModel : PageModel
{
    private readonly MovieContext _context;

    public DeleteModel(MovieContext context)
    {
        _context = context;
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
        var movieD = await _context.Movie.FindAsync(movie.Id);

        if (movieD == null)
        return NotFound();

        _context.Movie.Remove(movieD);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
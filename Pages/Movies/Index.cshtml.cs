using RazorPagesMovie.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RazorPagesMovie.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly MovieContext _context;

    public IndexModel(MovieContext context)
    {
        _context = context;
    }

    public List<Movie> movie { get; set; } = [];

    public async Task OnGetAsync()
    {
        movie = await _context.Movie.ToListAsync();
    }
}
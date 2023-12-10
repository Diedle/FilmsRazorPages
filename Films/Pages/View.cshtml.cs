using Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Films.Pages;
[IgnoreAntiforgeryToken]
public class View : PageModel
{
    ApplicationContext context;
    [BindProperty]
    public Film? Film { get; set; }
    [BindProperty]
    public Comment comment { get; set; } = new();

    public View(ApplicationContext db)
    {
        context = db;
    }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Film = await context.Films.FindAsync(id);

        if (Film == null) return NotFound();

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        context.Comments.Add(comment);
        await context.SaveChangesAsync();
        return RedirectToPage("View");
    }
}
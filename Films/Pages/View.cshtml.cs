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
    public List<Comment> Comment { get; private set; } = new();
    [BindProperty]
    public Comment Comments { get; set; } = new();

    public View(ApplicationContext db)
    {
        context = db;
    }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Film = await context.Films.FindAsync(id);

        if (Film == null) return NotFound();

        var comments = from m in context.Comments
                    select m;

        Comment = comments.ToList();
        Comment.Reverse();

        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        context.Comments.AddRange(Comments);
        await context.SaveChangesAsync();
        return RedirectToPage("View");
    }
}
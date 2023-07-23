using Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Films.Pages;

public class View : PageModel
{
    ApplicationContext context;
    [BindProperty]
    public Film? Film { get; set; }
    
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
        context.Films.Update(Film!);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
using Films.Models;
using FilmsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Films.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
            ApplicationContext context;
            [BindProperty]
            public Film film { get; set; } = new();
            public CreateModel(ApplicationContext db)
            {
                context = db;
            }
            public async Task<IActionResult> OnPostAsync()
            {
                context.Films.Add(film);
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
    }
}

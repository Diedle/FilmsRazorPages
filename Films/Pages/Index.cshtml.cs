using Films.Models;
using FilmsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Films.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Film> Films { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var films = from m in context.Films
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                films = films.Where(s => s.Title.Contains(SearchString));
            }

            Films = await films.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await context.Films.FindAsync(id);

            if (user != null)
            {
                context.Films.Remove(user);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
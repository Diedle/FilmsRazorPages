using Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnGet()
        {
            Films = context.Films.AsNoTracking().ToList();
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
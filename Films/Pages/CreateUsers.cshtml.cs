using Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Films.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateUsersModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public User user { get; set; } = new();
        public CreateUsersModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

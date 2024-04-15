using Films.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;

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

    HubConnection connection;

    public View()
    {
        connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7098/chat")
                .Build();

        connection.On<string, string>("Receive", (user, message) =>
        {
            Dispatcher.Invoke(() =>
            {
                var newMessage = $"{user}: {message}";
                chatbox.Items.Insert(0, newMessage);
            });
        });

    }
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
        Comments.Userid = User.Identity?.Name;
        context.Comments.AddRange(Comments);
        await context.SaveChangesAsync();
        return RedirectToPage("View");
    }
}
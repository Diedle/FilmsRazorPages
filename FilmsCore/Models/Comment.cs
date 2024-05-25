using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmsCore.Models;

public class Comment
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Commid { get; set; }

    public string? Userid { get; set; }

    public string? Filmid { get; set; }

    public string? Comm { get; set; }
}
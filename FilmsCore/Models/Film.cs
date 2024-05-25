namespace FilmsCore.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? Director { get; set; }

        public string? Country { get; set; }

        public string? Date { get; set; }

        public string? Genre { get; set; }

        public string? Time { get; set; }

        public string? InRole { get; set; }

        public string? Img { get; set; }
        public string? Trailer { get; set; }
    }
}
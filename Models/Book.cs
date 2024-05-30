namespace Library.Models
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? Pages { get; set; }
        public string? Language { get; set; }
        public DateOnly PublicationDate { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public int? EdithorialsId { get; set; }
        public Edithorial? edithorials { get; set; }
        public int? AuthorsId { get; set; }
        public Author? Authors { get; set; } 
    }
}
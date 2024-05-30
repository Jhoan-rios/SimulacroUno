using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Author
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo Name no puede ser null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El campo LastName no puede ser null")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "El campo Email no puede ser null")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Nationality no puede ser null")]
        public string? Nationality { get; set; }
        [Required(ErrorMessage = "El campo status no puede ser null")]
        public string? State { get; set; } 
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
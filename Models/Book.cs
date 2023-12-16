using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }

        [ForeignKey("Authors")]
        public int AuthorId { get; set; }
        public virtual Author Authors { get; set; }
    }
}

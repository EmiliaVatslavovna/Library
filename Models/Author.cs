using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyLibrary.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Author")]
        public string? Name { get; set; }
    }
}
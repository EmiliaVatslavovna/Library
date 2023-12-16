using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Author")]
        public string? Name { get; set; }
    }
}

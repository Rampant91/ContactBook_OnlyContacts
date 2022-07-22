using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyContactBook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public bool Editable { get; set; } = false;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

    }
}
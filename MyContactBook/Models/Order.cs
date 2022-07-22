using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyContactBook.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public int Date { get; set; }

        public string Name { get; set; }
                
        public Contact Contact { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyContactBookWithOrders.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public int Date { get; set; }

        public string Name { get; set; }
                
        public int ContactId { get; set; }
    }
}
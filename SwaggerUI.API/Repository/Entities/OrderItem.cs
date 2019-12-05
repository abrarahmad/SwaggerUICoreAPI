using System.ComponentModel.DataAnnotations;

namespace Persistance.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}

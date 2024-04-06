using System.ComponentModel.DataAnnotations;

namespace Oggetti_Usati.Models
{
    public class Oggetto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
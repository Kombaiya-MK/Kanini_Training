using System.ComponentModel.DataAnnotations;

namespace JWTAuthenticationApp.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}

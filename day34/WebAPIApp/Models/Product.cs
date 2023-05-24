namespace WebAPIApp.Models
{

    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public bool Equals(Product? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}

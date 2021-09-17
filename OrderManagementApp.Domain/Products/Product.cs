namespace OrderManagementApp.Domain.Products
{
    public class Product : BaseModel
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public static DomainResult<Product> Create(string name, decimal price)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return DomainResult<Product>.Fail(nameof(Product.Name));
            }

            if (price <= decimal.Zero)
            {
                return DomainResult<Product>.Fail(nameof(Product.Price));
            }

            var product = new Product
            {
                Name = name,
                Price = price
            };

            return DomainResult<Product>.Ok(product);
        }
    }
}
